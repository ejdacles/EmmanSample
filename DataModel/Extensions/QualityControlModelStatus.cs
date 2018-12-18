// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// The quality step model status
    /// These values are used in the memory
    /// </summary>
    public enum QualityStepModelStatus
    {
        Init = 0,
        Prepare = 1,
        Ready = 2,
        Error = 3
    }
}