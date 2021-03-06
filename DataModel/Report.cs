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
    
    public partial class Report
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Report()
        {
            this.ReportComponents = new HashSet<ReportComponent>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public int SoftwareMode { get; set; }
        public string Alias { get; set; }
        public bool Visible { get; set; }
        public int DisplayOrder { get; set; }
        public Nullable<int> InvestigationType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportComponent> ReportComponents { get; set; }
    }
}
