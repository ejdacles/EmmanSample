// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Laborie">
//   Copyright (c) Laborie. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Laborie.Synergy.BarcodeTraceability.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Consumable is already used by same patient before more that 4 hours ago exception class
    /// </summary>
    [Serializable]
    internal class ConsumableTimeLimitExpiredException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableTimeLimitExpiredException"/> class.
        /// </summary>
        internal ConsumableTimeLimitExpiredException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableTimeLimitExpiredException"/> class.
        /// </summary>
        /// <param name="message">Exception message</param>
        internal ConsumableTimeLimitExpiredException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableTimeLimitExpiredException"/> class.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        internal ConsumableTimeLimitExpiredException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsumableTimeLimitExpiredException"/> class.
        /// </summary>
        /// <param name="info">Serialization information</param>
        /// <param name="context">Streaming context</param>
        protected ConsumableTimeLimitExpiredException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
