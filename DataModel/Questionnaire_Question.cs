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
    
    public partial class Questionnaire_Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Questionnaire_Question()
        {
            this.Answers = new HashSet<Answer>();
        }
    
        public long ID { get; set; }
        public int Questionnaire_ID { get; set; }
        public int Question_ID { get; set; }
        public Nullable<int> X { get; set; }
        public Nullable<int> Y { get; set; }
        public Nullable<int> Width { get; set; }
        public Nullable<int> Length { get; set; }
        public Nullable<int> PageIndex { get; set; }
        public Nullable<int> Columns { get; set; }
        public Nullable<short> QuestionIndex { get; set; }
        public string Color { get; set; }
        public string DefaultValue { get; set; }
        public string Visible { get; set; }
        public bool AlwaysCopyAnswer { get; set; }
        public string DependentOn { get; set; }
        public Nullable<int> AddToY { get; set; }
        public Nullable<int> SenderDBID { get; set; }
        public int Revision { get; set; }
        public Nullable<int> DB_ID { get; set; }
        public Nullable<int> DB_CID { get; set; }
        public int SyncError { get; set; }
        public string ModifiedByUser { get; set; }
        public System.DateTime ModifiedDatetime { get; set; }
    
        public virtual SQuestion SQuestion { get; set; }
        public virtual SQuestionnaire SQuestionnaire { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }
    }
}