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
    
    public partial class OffsetEvent
    {
        public long ID { get; set; }
        public int Test_id { get; set; }
        public decimal Time { get; set; }
        public decimal Offset { get; set; }
        public int ChannelID { get; set; }
        public Nullable<int> EqualChannelID { get; set; }
    
        public virtual Test Test { get; set; }
    }
}
