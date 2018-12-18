// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System;

    public partial class ReadPatients_Result
    {
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
    }
}
