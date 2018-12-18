// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// Channel calculation types
    /// These values are used in the database, existing values are not allowed to be changed
    /// </summary>
    public enum ChannelType
    {
        NotSet = 0,

        #region Common channels (1 - 100)
        Pves = 1,
        Pura = 2,
        Pabd = 3,
        Pclos = 4,
        Pdet = 5,
        Flow = 6,
        Volume = 7,
        InfusedVolume = 8,
        Stimulation = 9,
        BladderVolume = 10,
        P4 = 11, // 4th pressure channel
        #endregion

        #region Emg channels (101 - 200)
        Emg = 101,
        EmgPelvic = 102,
        EmgAbd = 103,
        #endregion

        #region pressure channels (201 - 300)
        Pressure = 201,
        #endregion
    }
}
