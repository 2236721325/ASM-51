﻿namespace Complier.CodeAnalyzer
{
    public class Token
    {
        public TokenKind Kind { get; set; }

        public string Value { get; set; }

        public int Line { get; set; }

        public Token(TokenKind kind, string value, int line)
        {
            Kind = kind;
            Value = value;
            Line = line;
        }
    }
}
