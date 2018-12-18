// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System;
    
    /// <summary>
    /// Describes the status indicating the extent to which a Questionnaire is filled in
    /// </summary>
    public enum FilledInStatus
    {
        NotFilledIn = 0,
        PartiallyFilledIn = 1,
        CompletelyFilledIn = 2
    }
}
