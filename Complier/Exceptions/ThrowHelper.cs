using Complier.CodeAnalyzer;
using System.Diagnostics.CodeAnalysis;

namespace Complier.Exceptions
{
    public static class ThrowHelper
    {
        public static SyntaxException UnexpectedToken(Token kind)
        {
            return new SyntaxException($"Unpected Token {kind.Value} !",kind.Line);
        }


        public static SyntaxException UnexpectedToken(Token kind,Token expect_token)
        {
            return new SyntaxException($"Unpected Token {kind.Value} ! Expected Token {expect_token.Value}", kind.Line);
        }

        public static SyntaxException UnexpectedToken(Token kind, string msg)
        {
            return new SyntaxException($"Unpected Token -> {kind.Value} ! {msg}", kind.Line);
        }

        public static DefaultException NameConflict(string name,int line)
        {
            return new DefaultException($" [Name Conflict]-> {name} ",line);
        }
    }
}
