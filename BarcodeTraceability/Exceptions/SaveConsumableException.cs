// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Laborie.Synergy.BarcodeTraceability.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Consumable has an unknown Category / GTIN
    /// </summary>
    [Serializable]
    internal class SaveConsumableException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SaveConsumableException"/> class.
        /// </summary>
        /// <param name="message">Exception message</param>
        internal SaveConsumableException(string message)
            : base(message)
        {
        }
    }
}