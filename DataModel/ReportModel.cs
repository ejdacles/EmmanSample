//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReportModel : WorkflowStepConfiguration
    {
        public int ReportId { get; set; }
        public int ReportConfiguration_Id { get; set; }
        public string ReportTemplateName { get; set; }
        public bool IsSilentPrint { get; set; }
        public bool IsPrintToPdf { get; set; }
        public bool IsPrintToPrinter { get; set; }
    
        public virtual ReportConfiguration ReportConfiguration { get; set; }
    }
}
