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
    /// The role types.
    /// These values originate in the database
    /// </summary>
    public enum RoleType
    {
        None = 0,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_RoleType_Local))]
        Local = 1,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_RoleType_Ad))]
        Ad = 2,
    }
}   
