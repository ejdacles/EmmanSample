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
    
    public partial class BridgePatternModel : ChallengeTemplateModel
    {
        public int RampPreDelaySeconds { get; set; }
        public int RampPostDelaySeconds { get; set; }
        public int DelayTargetPercentage { get; set; }
        public int RampUpSeconds { get; set; }
        public int RampDownSeconds { get; set; }
        public int WorkTargetSeconds { get; set; }
        public int WorkTargetPercentage { get; set; }
        public int TargetArea { get; set; }
    }
}