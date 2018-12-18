// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.BarcodeTraceability
{
    using System.Collections.Generic;

    using DataModel;
    using Model;

    /// <summary>
    /// Consumable Matrix Helper class
    /// </summary>
    internal interface IConsumableMatrixHelper
    {
        /////// <summary>
        /////// Gets the Consumable Data Contract object
        /////// </summary>
        ////ConsumableDataContract ConsumableData { get; }

        /// <summary>
        /// Load Consumable Data Contract object from the JSON file/stream, check the signature, then save to database.
        /// </summary>
        /// <param name="path">File Location or the path of stream, null means default file path</param>
        void LoadStreamToDb(string path = null);

        /// <summary>
        /// Check the file signature of the consumable compatibility string contents.
        /// </summary>
        /// <returns>true indicate valid signature</returns>
        bool CheckFileSignature();

        /// <summary>
        /// Get Consumable Type according the item number
        /// </summary>
        /// <param name="companyCode">Company Code</param>
        /// <param name="itemNo">item number</param>
        /// <returns>Consumable Type</returns>
        ConsumableType GetConsumableType(string companyCode, int itemNo);

        /// <summary>
        /// Get Consumable Type according the item number
        /// </summary>
        /// <param name="barcode">Barcode Model</param>
        /// <returns>Consumable Type</returns>
        ConsumableType GetConsumableType(BarcodeModel barcode);

        /// <summary>
        /// Get Laborie Company Code
        /// </summary>
        /// <returns>Laborie Company Code</returns>
        string GetLaborieCompanyCode();

        /// <summary>
        /// Get Supported Company Codes
        /// </summary>
        /// <returns>Company Code array</returns>
        List<string> GetSupportedCompanyCodes();

        /// <summary>
        /// to return the ChannelConsumableCategory for the specified channel 
        /// </summary>
        /// <param name="investigationType">Workflow Investigation Type</param>
        /// <param name="channelId">channel id</param>
        /// <returns>Channel Consumable Category list</returns>
        IEnumerable<ChannelConsumableCategory> GetChannelConsumableCategory(WorkflowInvestigationType investigationType, ChannelType channelId);
    }
}
