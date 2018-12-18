// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.BarcodeTraceability.Model
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Consumable Types class
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
    public class ConsumableType
    {
        /// <summary>
        /// Gets or sets the CompanyCode : the 2-7 digit of GTIN, fixed as "627825" for Laborie
        /// </summary>
        public string CompanyCode { get; set; }

        /// <summary>
        /// Gets or sets the Item Number : the 8-12 digit of GTIN
        /// </summary>
        public int ItemNumber { get; set; }

        /// <summary>
        /// Gets or sets the Type Name(Part Number)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Qualify Level: 0-Extra ; 1- Qualified; 2- Secondary
        /// </summary>
        public QualifyType QualifyLevel { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Technology
        /// </summary>
        public string Technology { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it has PvesCatheter: 0-No ;1-Yes;
        /// </summary>
        public bool PvesCatheter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it has PabdCatheter: 0-No ;1-Yes;
        /// </summary>
        public bool PabdCatheter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it has Pura Catheter: 0-No ;1-Yes;
        /// </summary>
        public bool PuraCatheter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it has VinfCatheter: 0-No ;1-Yes;
        /// </summary>
        public bool VinfCatheter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it has VinfTubing: 0-No ;1-Yes;
        /// </summary>
        public bool VinfTubing { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it has EMGProbe: 0-No ;1-Yes;
        /// </summary>
        public bool EmgProbe { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it has Patches Electrodes: 0-No ;1-Yes;
        /// </summary>
        public bool Patches { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it has Manometry Probe: 0-No ;1-Yes;
        /// </summary>
        public bool ManometryProbe { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it has Manometry Tubing: 0-No ;1-Yes;
        /// </summary>
        public bool ManometryTubing { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it has StimProbe: 0-No ;1-Yes;
        /// </summary>
        public bool StimProbe { get; set; }

        /// <summary>
        /// Gets or sets the InfusionRate, unit Hz
        /// </summary>
        public int InfusionRate { get; set; }

        /// <summary>
        /// Gets or sets the EMGSampling, unit: Hz
        /// </summary>
        public int EmgSampling { get; set; }

        /// <summary>
        /// Gets or sets the StimLevel, unit: mA
        /// </summary>
        public int StimLevel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it has Video: 0-No ;1-Yes;
        /// </summary>
        public bool Video { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it is Obstructed: 0-No ;1-Yes;
        /// </summary>
        public bool Obstructed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it is for Pediatric: 0-No ;1-Yes;
        /// </summary>
        public bool Pediatric { get; set; }

        /// <summary>
        /// Gets or sets the TimeLimit, unit: hour 
        /// </summary>
        public int TimeLimit { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it is only for SinglePatient flag: 0- for many patients ;1-only for single patient;
        /// </summary>
        public bool SinglePatient { get; set; }

        /// <summary>
        /// Gets or sets the ImageFile name
        /// </summary>
        public string ImageFile { get; set; }

        /// <summary>
        /// Gets or sets the qualify level type
        /// </summary>
        public QualifyLevelType QualifyLevelType { get; set; }
    }
}