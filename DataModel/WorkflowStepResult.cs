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
    
    public abstract partial class WorkflowStepResult
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkflowStepResult()
        {
            this.GeneratedReportComponents1 = new HashSet<GeneratedReportComponent>();
        }
    
        public Nullable<int> study_id { get; set; }
        public int ID { get; set; }
        public Nullable<int> WorkflowStepConfigurationId { get; set; }
    
        public virtual Study Study { get; set; }
        public virtual WorkflowStepConfiguration WorkflowStepConfiguration { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GeneratedReportComponent> GeneratedReportComponents1 { get; set; }
    }
}
