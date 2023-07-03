using System;

namespace Complier.Exceptions
{
    public class SyntaxException : Exception
    {
        public SyntaxException() : base(" [Syntax Error]: default syntax exception message.") { }

        public SyntaxException(string message, int line) : base(" [Syntax Error]: " + message + $" -> at line {line}.") { }
        public SyntaxException(string message, Exception innerException) : base(message, innerException) { }

    }
}
