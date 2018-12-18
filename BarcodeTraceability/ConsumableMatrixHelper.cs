// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.BarcodeTraceability
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Common;
    using DataModel;
    using DataStorage.Interfaces;
    using Model;

    /// <summary>
    /// Consumable Matrix Helper class
    /// </summary>
    public class ConsumableMatrixHelper : Matrix, IConsumableMatrixHelper
    {
        private static string consumableCompatibilityFileLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Consumables", @"ConsumableCompatibility.json");
        private ConsumableDataContract consumableData;

        public ConsumableMatrixHelper(IBarcodeRepository barcodeRepository, IFile consumableFile) : base(0)
        {
            BarcodeRepository = barcodeRepository;
            ConsumableFile = consumableFile;
        }

        /// <summary>
        /// Gets the Consumable Data Contract object: only available after LoadStreamToDb()
        /// </summary>
        public ConsumableDataContract ConsumableData => consumableData ?? (consumableData = LoadMatrixFromRepository());

        /// <summary>
        /// Gets the Barcode Traceability repository.
        /// </summary>
        private IBarcodeRepository BarcodeRepository { get; }

        /// <summary>
        /// Gets the Consumable File system.
        /// </summary>
        private IFile ConsumableFile { get; }

        /// <summary>
        /// Load Consumable Data Contract object from the JSON file/stream, check the signature, then save to database.
        /// </summary>
        /// <param name="path">File Location or the path of stream, null means default file path</param>
        public void LoadStreamToDb(string path = null)
        {
            ConsumableDataContract consumableDataContract = LoadMatrixFromFile(path);

            if (consumableDataContract == null)
            {
                throw new InvalidFileException(Translations.Language.Missing_ConsumableJSON_File);
            }

            if (IsFileSignatureValid(consumableDataContract))
            {
                SaveMatrixToRepository(consumableDataContract);
            }
            else
            {
                throw new InvalidFileException(Translations.Language.Invalid_ConsumableJSON_FileSignature);
            }
        }
        
        /// <summary>
        /// Check the file signature of the consumable compatibility string contents.
        /// </summary>
        /// <returns>true indicate valid signature</returns>
        public bool CheckFileSignature()
        {
            ConsumableDataContract consumableDataContract = LoadMatrixFromRepository();
            if (consumableDataContract == null)
            {
                throw new InvalidFileException(Translations.Language.Missing_ConsumableJSON_File);
            }

           if (IsFileSignatureValid(consumableDataContract))
           {
               BarcodeModel.LaborieCompanyCode = GetLaborieCompanyCode();
               BarcodeModel.SupportedCompanyCodes = GetSupportedCompanyCodes();
               return true;
           }
           else
           {
               throw new InvalidFileException(Translations.Language.Invalid_ConsumableJSON_FileSignature);
           }
        }

        /// <summary>
        /// Get Consumable Type according the item number
        /// </summary>
        /// <param name="companyCode">Company Code</param>
        /// <param name="itemNo">item number</param>
        /// <returns>Consumable Type</returns>
        public ConsumableType GetConsumableType(string companyCode, int itemNo)
        {
            return (ConsumableData?.ConsumableTypes)?.FirstOrDefault(x => x.CompanyCode.Equals(companyCode) && x.ItemNumber == itemNo);
        }

        /// <summary>
        /// Get Consumable Type according the item number
        /// </summary>
        /// <param name="barcode">the barcode</param>
        /// <returns>Consumable Type</returns>
        public ConsumableType GetConsumableType(BarcodeModel barcode)
        {
            if (BarcodeModel.IsGtinValid(barcode.GTIN))
            {
                return (ConsumableData?.ConsumableTypes)?.FirstOrDefault(x =>
                    x.CompanyCode.Equals(barcode.CompanyCode) && x.ItemNumber == barcode.ItemNo);
            }

            return null;
        }

        /// <summary>
        /// Get Laborie Company Code
        /// </summary>
        /// <returns>Laborie Company Code</returns>
        public string GetLaborieCompanyCode()
        {
            return ConsumableData?.LaborieCompanyCode;
        }

        /// <summary>
        /// Get Supported Company Codes
        /// </summary>
        /// <returns>Company Code array</returns>
        public List<string> GetSupportedCompanyCodes()
        {
            return ConsumableData?.SupportedCompanyCodes.ToList<string>();
        }

        /// <summary>
        /// to return the ChannelConsumableCategory for the specified channel 
        /// </summary>
        /// <param name="investigationType">Workflow Investigation Type</param>
        /// <param name="channelId">channel id</param>
        /// <returns>Channel Consumable Category list</returns>
        public IEnumerable<ChannelConsumableCategory> GetChannelConsumableCategory(WorkflowInvestigationType investigationType, ChannelType channelId)
        {
            var result = from cc in ConsumableData?.ChannelConsumableCategories
                where cc.InvestigationType.Equals(investigationType) && cc.ChannelType.Equals(channelId)
                orderby cc.ChannelType, cc.Category
                select cc;

            return result;
        }

        /// <summary>
        /// Load Consumable Data Contract object from the JSON file
        /// </summary>
        /// <param name="fileLocation">File Location</param>
        /// <returns>Json Consumable Root object Class Object</returns>
        private ConsumableDataContract LoadMatrixFromFile(string fileLocation)
        {
            if (string.IsNullOrEmpty(fileLocation))
            {
                fileLocation = consumableCompatibilityFileLocation;
            }

            if (!ConsumableFile.Exists(fileLocation))
            {
                return null;
            }

            // Read and Parse Json File, Convert JSON Object to Class Object
            return Serializer.Deserialize<ConsumableDataContract>(ConsumableFile.ReadAllText(fileLocation));
        }

        /// <summary>
        /// Set/Insert Consumable Data Contract object into Database
        /// </summary>
        /// <param name="rootObject">JSON RootObject</param>
        private void SaveMatrixToRepository(ConsumableDataContract rootObject)
        {
            var serializedJson = Serializer.Serialize<ConsumableDataContract>(rootObject);

            ConsumableCompatibility json = new ConsumableCompatibility()
            {
                FileSignature = rootObject.FileSignature,
                JSON = serializedJson
            };
            BarcodeRepository?.SetConsumableCompatibilityJson(json);

            BarcodeModel.LaborieCompanyCode = GetLaborieCompanyCode();
            BarcodeModel.SupportedCompanyCodes = GetSupportedCompanyCodes();
        }

        /// <summary>
        /// Get Consumable Data Contract object From Database
        /// </summary>
        /// <returns>JSON RootObject</returns>
        private ConsumableDataContract LoadMatrixFromRepository()
        {
            ConsumableCompatibility json = BarcodeRepository.GetConsumableCompatibilityJson();
            if (json?.JSON == null)
            {
                return null;
            }

            return Serializer.Deserialize<ConsumableDataContract>(json.JSON);
        }
    }
}
