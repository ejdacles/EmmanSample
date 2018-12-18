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
    /// The user permission names
    /// These values originate in the database
    /// </summary>
    public enum PermissionNames
    {
        None = 0,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_PermissionNames_UserManagement))]
        UserManagement = 1,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_PermissionNames_ChangePassword))]
        ChangePassword = 2,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_PermissionNames_RecordStudy))]
        RecordStudy = 3,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_PermissionNames_ViewSavedStudy))]
        ViewSavedStudy = 4,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_PermissionNames_AddPatient))]
        AddPatient = 5,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_PermissionNames_UpdatePatient))]
        UpdatePatient = 6,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_PermissionNames_ViewPatient))]
        ViewPatient = 7,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_PermissionNames_DeletePatient))]
        DeletePatient = 8,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_PermissionNames_ReassignStudy))]
        ReassignStudy = 9,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_PermissionNames_WorkflowConfiguration))]
        WorkflowConfiguration = 10,
        [Display(ResourceType = typeof(Language), Name = nameof(Language.Enum_PermissionNames_ViewAuditLog))]
        ViewAuditLog = 11,
    }
}   
