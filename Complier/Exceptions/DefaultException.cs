using System;

namespace Complier.Exceptions
{
    public class DefaultException : Exception
    {
        public DefaultException() : base(" [Default Error]: default syntax exception message.") { }

        public DefaultException(string message, int line) : base( message + $" -> at line {line}.") { }
        public DefaultException(string message, Exception innerException) : base(message, innerException) { }

    }
}
