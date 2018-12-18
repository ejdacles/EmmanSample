// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System;

    [Flags]
    public enum EditableButtonModelProperties
    {
        None = 0,
        CanMove = 1,
        CanDelete = 2,
        CanChangeAllowDropDown = 4,
        CanChangeAllowRepeat = 8,
        CanModifyAutoGotoNext = 16,
        CanChangeCaption = 32
    }
}
