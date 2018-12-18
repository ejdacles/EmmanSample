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
    
    public partial class Question_Choice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question_Choice()
        {
            this.Answers = new HashSet<Answer>();
        }
    
        public long ID { get; set; }
        public Nullable<int> Question_ID { get; set; }
        public long ChoiceGroup_ID { get; set; }
        public Nullable<int> ChoiceType_ID { get; set; }
        public Nullable<short> OrderBy { get; set; }
        public Nullable<int> SenderDBID { get; set; }
        public int Revision { get; set; }
        public Nullable<int> DB_ID { get; set; }
        public Nullable<int> DB_CID { get; set; }
        public int SyncError { get; set; }
        public string ModifiedByUser { get; set; }
        public System.DateTime ModifiedDatetime { get; set; }
    
        public virtual SQuestion SQuestion { get; set; }
        public virtual ChoiceGroup ChoiceGroup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }
    }
}