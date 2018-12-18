// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// The service type.
    /// These values are used in the database, existing values are not allowed to be changed
    /// </summary>
    public enum ServiceType
    {
        None = 0,
        Acquisition = 1,
        Stimulation = 2,
        RemoteControl = 3,
        Pump = 4,
        Puller = 5,
        Resistance = 6,
        Pim = 7,
        Connection = 8
    }
}