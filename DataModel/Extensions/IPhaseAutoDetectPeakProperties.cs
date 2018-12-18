// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Laborie.Synergy.DataModel
{
    /// <summary>
    /// Interfaces detection properties
    /// </summary>
    public interface IPhaseAutoDetectPeakProperties
    {
        /// <summary>
        /// Gets a value indicating whether [automatic cough artifact detection].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [automatic cough artifact detection]; otherwise, <c>false</c>.
        /// </value>
        bool AutoCoughArtifactDetection { get; }

        /// <summary>
        /// Gets a value indicating whether [automatic transmission detection].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [automatic transmission detection]; otherwise, <c>false</c>.
        /// </value>
        bool AutoTransmissionDetection { get; }
    }
}