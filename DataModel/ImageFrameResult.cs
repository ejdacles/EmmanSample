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
    
    public partial class ImageFrameResult
    {
        public int Id { get; set; }
        public int ImageResult_ID { get; set; }
        public Nullable<int> FrameDetails_ID { get; set; }
        public string Position { get; set; }
        public Nullable<int> Burst { get; set; }
        public Nullable<int> Index { get; set; }
    
        public virtual ImageResult ImageResult { get; set; }
    }
}
