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
    
    public partial class SubQuestionRowHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubQuestionRowHeader()
        {
            this.Question_SubQuestionRowHeader = new HashSet<Question_SubQuestionRowHeader>();
        }
    
        public int ID { get; set; }
        public string DisplayText { get; set; }
        public int QuestionnaireID { get; set; }
        public int DisplayIndex { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question_SubQuestionRowHeader> Question_SubQuestionRowHeader { get; set; }
        public virtual SQuestionnaire SQuestionnaire { get; set; }
    }
}