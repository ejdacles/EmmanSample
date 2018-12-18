// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// the DTO class for Patient Info
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// Gets or sets the Database ID for patient
        /// </summary>
        public int DbId { get; set; }

        /// <summary>
        /// Gets or sets the UUID for patient
        /// </summary>
        public System.Guid Uuid { get; set; }

        /// <summary>
        /// Gets or sets the Visibility Status
        /// </summary>
        public byte VisibilityStatus { get; set; }

        /// <summary>
        /// Gets or sets the patient ID (MRN)
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// Gets or sets the First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Middle name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the gender Id
        /// </summary>
        public byte GenderId { get; set; }

        /// <summary>
        /// Gets the gender
        /// </summary>
        public Gender Gender => (Gender)GenderId;

        /// <summary>
        /// Gets or sets the height
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets the weight
        /// </summary>
        public int? Weight { get; set; }

        /// <summary>
        /// Gets or sets the DOB
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the notes
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the allergy
        /// </summary>
        public string Allergy { get; set; }

        /// <summary>
        /// Gets or sets the personal number
        /// </summary>
        public string PersonalNumber { get; set; }

        /// <summary>
        /// Gets or sets the security code
        /// </summary>
        public string SecurityCode { get; set; }

        /// <summary>
        /// Gets or sets the address Id
        /// </summary>
        public long? AddressId { get; set; }

        /// <summary>
        /// Gets or sets the street
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the suite number
        /// </summary>
        public string SuiteNumber { get; set; }

        /// <summary>
        /// Gets or sets the city/town
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state/province
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the postal code
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the PoBox number
        /// </summary>
        public string PoBoxNumber { get; set; }

        /// <summary>
        /// Gets or sets the contact ID
        /// </summary>
        public long? ContactId { get; set; }

        /// <summary>
        /// Gets or sets the phone home
        /// </summary>
        public string PhoneHome { get; set; }

        /// <summary>
        /// Gets or sets the phone mobile
        /// </summary>
        public string PhoneMobile { get; set; }

        /// <summary>
        /// Gets or sets the create-date-time
        /// </summary>
        public DateTime? CreateDateTime { get; set; }

        /// <summary>
        /// Gets or sets the group Id
        /// </summary>
        public int? GroupId { get; set; }

        /// <summary>
        /// Gets or sets the Doctor id
        /// </summary>
        public int? DoctorId { get; set; }

        /// <summary>
        /// Gets or sets the investigator Id
        /// </summary>
        public int? InvestigatorId { get; set; }

        /// <summary>
        /// Gets or sets the referring doctor Id
        /// </summary>
        public int? ReferringDoctorId { get; set; }

        /// <summary>
        /// Gets or sets the Insurance Company
        /// </summary>
        public string InsuranceCompany { get; set; }

        /// <summary>
        /// Gets or sets the Insurance Policy Number
        /// </summary>
        public string InsurancePolicyNo { get; set; }

        /// <summary>
        /// Gets or sets the Insurance Id
        /// </summary>
        public int? InsuranceId { get; set; }

        /// <summary>
        /// Gets or sets the Group
        /// </summary>
        public Group Group { get; set; }

        /// <summary>
        /// Gets or sets the doctor
        /// </summary>
        public ReadDoctors_Result Doctor { get; set; }

        /// <summary>
        /// Gets or sets the investigator
        /// </summary>
        public ReadInvestigators_Result Investigator { get; set; }

        /// <summary>
        /// Gets or sets the referring doctor
        /// </summary>
        public ReadReferrals_Result ReferringDoctor { get; set; }

        /// <summary>
        /// Gets or sets the studies
        /// </summary>
        public List<Study> Studies { get; set; }

        /// <summary>
        /// Gets or sets the history
        /// </summary>
        public string History { get; set; }

        /// <summary>
        /// Gets the age of the patient - needs DateOfBirth to be set
        /// </summary>
        public int Age
        {
            get
            {
                if (!DateOfBirth.HasValue)
                    throw new ArithmeticException("Patient Date of Birth has no value");

                var patientAge = DateTime.Today.Year - DateOfBirth.Value.Year;
                if (DateOfBirth.Value > DateTime.Today.AddYears(-patientAge))
                    patientAge--;

                return patientAge;
            }
        }

        public int AgeAt(DateTime targetDateTime)
        {
            if (!DateOfBirth.HasValue)
                throw new ArithmeticException("Patient Date of Birth has no value");

            if (DateOfBirth.Value > targetDateTime)
                throw new InvalidOperationException("Operation would result in a negative age");

            var patientAge = targetDateTime.Year - DateOfBirth.Value.Year;
            if (DateOfBirth.Value > targetDateTime.AddYears(-patientAge))
                patientAge--;

            return patientAge;
        }
    }
}
