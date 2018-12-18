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
    /// The user roles.
    /// These values originate in the database
    /// </summary>
    public enum Roles
    {
        None = 0,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_Roles_LocalAdmins))]
        LocalAdmins = 1,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_Roles_LocalUsers))]
        LocalUsers = 2,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_Roles_DomainAdmins))]
        DomainAdmins = 3,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_Roles_DomainUsers))]
        DomainUsers = 4,
    }
}   
