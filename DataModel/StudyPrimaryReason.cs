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
    
    public partial class StudyPrimaryReason
    {
        public int ID { get; set; }
        public int StudiesID { get; set; }
        public int PrimaryReasonsID { get; set; }
    
        public virtual PrimaryReason PrimaryReason { get; set; }
    }
}
