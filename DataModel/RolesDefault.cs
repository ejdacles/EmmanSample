// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System.ComponentModel.DataAnnotations;
    using Translations;

    /// <summary>
    /// The user roles default type.
    /// These values originate in the database
    /// </summary>
    public enum RolesDefault
    {
        None = 0,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_Roles_IsDefaultY))]
        IsDefaultY = 1,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_Roles_IsDefaultN))]
        IsDefaultN = 2
    }
}   
