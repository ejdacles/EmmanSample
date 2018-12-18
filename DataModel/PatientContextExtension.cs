// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// Partial Class extension for ReadPatients_Result which holds all necessary additional fields
    /// for the Patient Context.
    /// </summary>
    public partial class ReadPatients_Result
    {
        /// <summary>
        /// Gets or sets the value of the patient group name for a patient
        /// </summary>
        public string PatientGroupName { get; set; }

        /// <summary>
        /// Gets or sets the value of the doctor name for a patient
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// Gets or sets the value of the doctor name with title for a patient
        /// </summary>
        public string DoctorNameWithTitle { get; set; }

        /// <summary>
        /// Gets or sets the value of the referring doctor name for a patient
        /// </summary>
        public string ReferringDoctorName { get; set; }

        /// <summary>
        /// Gets or sets the value of the referring doctor name with title for a patient
        /// </summary>
        public string ReferringDoctorNameWithTitle { get; set; }

        /// <summary>
        /// Gets or sets the value of the investigating doctor name for a patient
        /// </summary>
        public string InvestigatorName { get; set; }

        /// <summary>
        /// Gets or sets the value of the investigating doctor name with title for a patient
        /// </summary>
        public string InvestigatorNameWithTitle { get; set; }
    }
}
