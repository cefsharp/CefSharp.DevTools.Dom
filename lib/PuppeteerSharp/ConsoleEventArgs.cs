using System;

namespace CefSharp.Dom
{
    /// <summary>
    /// <see cref="IDevToolsContext.Console"/> data.
    /// </summary>
    public class ConsoleEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleEventArgs"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public ConsoleEventArgs(ConsoleMessage message) => Message = message;

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public ConsoleMessage Message { get; }
    }
}
