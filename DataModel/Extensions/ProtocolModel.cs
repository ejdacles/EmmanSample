// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    using System;
    using System.Linq;

    public partial class ProtocolModel
    {
        /// <summary>
        /// Gets a value indicating the flow delay (in seconds) for the current protocol
        /// </summary>
        /// <remarks>The value is 0 if the current protocol does not have a combination of flow and pressure channels or flow and emg channels</remarks>
        public double ActualFlowDelayInSeconds
        {
            get
            {
                return IsFlowDelayOffsetApplicable()
                    ? FlowDelay
                    : 0;
            }
        }

        /// <summary>
        /// Determines whether the flow delay offset is applicable by checking for the presence of a combination of flow and pressure channels of flow and emg channels.
        /// </summary>
        /// <returns>True if applicable, False otherwise</returns>
        private bool IsFlowDelayOffsetApplicable()
        {
            var anyEMGChannels = ChannelModels.Any(s => s.ChannelType == ChannelType.Emg 
            || s.ChannelType == ChannelType.EmgAbd 
            || s.ChannelType == ChannelType.EmgPelvic);
            var anyPressureChannels = ChannelModels.Any(s => s.ChannelType == ChannelType.Pressure 
            || s.ChannelType == ChannelType.Pves 
            || s.ChannelType == ChannelType.Pabd 
            || s.ChannelType == ChannelType.Pura
            || s.ChannelType == ChannelType.Pdet
            || s.ChannelType == ChannelType.Pclos
            || s.ChannelType == ChannelType.P4);

            return ChannelModels.Any(s => s.ChannelType == ChannelType.Flow)
                && (anyPressureChannels || anyEMGChannels);
        }
    }
}
