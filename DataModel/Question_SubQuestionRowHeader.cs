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
    
    public partial class Question_SubQuestionRowHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question_SubQuestionRowHeader()
        {
            this.Answers = new HashSet<Answer>();
        }
    
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public int SubQuestionRowHeaderID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual SQuestion SQuestion { get; set; }
        public virtual SubQuestionRowHeader SubQuestionRowHeader { get; set; }
    }
}
