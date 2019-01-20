namespace Laborie.Synergy.HardwareManager.Transport.Interfaces
{
    using System;

    /// <summary>
    /// Interface for Transport Communication
    /// </summary>
    public interface ITransport : IDisposable
    {
        /// <summary>
        /// Event that indicates data has been received through port.
        /// </summary>
        event EventHandler<byte[]> TransportDataReceived;

        /// <summary>
        /// Open Transport Communication to Device
        /// </summary>
        /// <returns>true or false if port is open</returns>
        bool Open();

        /// <summary>
        /// Writes bytes to the Transport
        /// </summary>
        /// <param name="buffer">The byte array to write to the port</param>
        /// <returns>true of false if bytes were transmitted</returns>
        bool Write(byte[] buffer);

        /// <summary>
        /// Closes Transport Communication of Device
        /// </summary>
        /// <returns>true or false if port is closed</returns>
        bool Close();

        /// <summary>
        /// Reads buffer from Transport Communication
        /// </summary>
        /// <returns>buffer of characters</returns>
        byte[] Read();

        string ToString();
    }
}
