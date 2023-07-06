using Complier.Exceptions;
using Complier.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Complier.CodeAnalyzer
{
    
    public class Lexer
    {
        public string Chunk { get; set; }

        public SymbolTable SymbolTable { get; set; }

        public int Line { get; set; }
        public Lexer(string code,SymbolTable table)
        {

            Chunk = code;
            Line = 1;
            nextToken = null;
            SymbolTable = table;
        }


        private Token nextToken;
        public Token NextToken()
        {
            if (nextToken != null)
            {
                Line = nextToken.Line;
                var result = nextToken;
                nextToken = null;
                return result;
            }


            SkipWhiteSpace();


            if (Chunk.Length == 0)
            {
                return new Token(TokenKind.EOF, null, Line);
            }
            switch (Chunk[0])
            {

                case ',':
                    Next(1);
                    return new Token(TokenKind.TOKEN_SEP_COMMA, ",", Line);
                case ':':
                    Next(1);
                    return new Token(TokenKind.TOKEN_SEP_COLON, ":", Line);
                case '#':
                    Next(1);
                    return new Token(TokenKind.TOKEN_OP_LEN, "#", Line);
                case '@':
                    Next(1);
                    return new Token(TokenKind.TOKEN_SEP_ARE, "@", Line);
                case '.':
                        Next(1);
                        return new Token(TokenKind.TOKEN_SEP_DOT, ".", Line);
                case '+':
                    Next(1);
                    return new Token(TokenKind.TOKEN_SEP_PLUS, "+", Line);
            }
            if (Chunk[0] == '_' || char.IsLetter(Chunk[0]))
            {
                var value = ScanIdentifier();
                var higher = value.ToUpper();

                if(SymbolTable.Contains(higher))
                {
                    return new Token(TokenKind.TOKEN_Symbol, value, Line);
                }
                if (Constants.OpCode_Map.ContainsKey(higher))
                {
                    return new Token(Constants.OpCode_Map[higher],value,Line);
                }
                if(Constants.Register_Map.ContainsKey(higher))
                {
                    return new Token(Constants.Register_Map[higher], value, Line);
                }
                if(Constants.Directive_Map.ContainsKey(higher))
                {
                    return new Token(Constants.Directive_Map[higher], value, Line);
                }
                else
                {
                    return new Token(TokenKind.Identifier, value, Line);
                }
            }



            if (char.IsDigit(Chunk[0]))
            {
                return ScanNumber();
            }



            throw new SyntaxException($"Lexer Error! Unexpected char [{Chunk[0]}] !", Line);

        }

        private Token ScanNumber()
        {
            var sb = new StringBuilder();
            sb.Append(Chunk[0]);
            Next(1);
            while (Chunk.Length > 0)
            {
                if (Char.ToLower(Chunk[0])=='b' || Char.ToLower(Chunk[0])=='h')
                {
                    if (!Char.IsLetterOrDigit(Chunk[1]))
                    {
                        sb.Append(Chunk[0]);
                        Next(1);
                        break;
                    }
                }
                if (char.IsLetterOrDigit(Chunk[0]))
                {
                    sb.Append(Chunk[0]);
                }
                else
                {
                    break;
                }
                Next(1);
            }
            return new Token(TokenKind.Number, sb.ToString(), Line);

        }

        private string ScanIdentifier()
        {
            var sb = new StringBuilder();
            sb.Append(Chunk[0]);
            Next(1);
            while(Chunk.Length > 0)
            {
                if(char.IsLetterOrDigit(Chunk[0]) || Chunk[0] =='_')
                {
                    sb.Append(Chunk[0]);
                }
                else
                {
                    break;
                }
                Next(1);
            }
            return sb.ToString();
        }

        public Token NextTokenOfKind(TokenKind kind)
        {
            var token = NextToken();
            if (token.Kind != kind)
            {
                throw new SyntaxException($"Unexpected Token kind {token.Kind}! We need Token {kind}", Line);
            }
            return token;
        }


        public Token NextTokenOfRi()
        {
            var token = NextToken();
            if (!token.IsReg_Ri())
            {
                throw ThrowHelper.UnexpectedToken(token, "We need Ri");
            }
            return token;

        }
        public Token NextTokenOfRn()
        {
            var token = NextToken();
            if (!token.IsReg_Rn())
            {
                throw ThrowHelper.UnexpectedToken(token, "We need Rn");
            }
            return token;

        }
        public Token NextTokenOfNumberOrSymbol()
        {
            var token = NextToken();
            if (!token.IsNumberOrSymbol())
            {
                throw ThrowHelper.UnexpectedToken(token, "We need Number of Symbol");
            }
            return token;

        }
        public Token NextIdentifier()
        {
            return NextTokenOfKind(TokenKind.Identifier);
        }

        private void Next(int n)
        {
            Chunk = Chunk[n..];
        }

        private bool IsWhiteSpace(char c)
        {
            return Constants.WhiteSpace.Contains(c);
        }

        private bool IsNewLine(char c)
        {
            return c == '\r' || c == '\n';
        }

        private void SkipWhiteSpace()
        {
            while (Chunk.Length > 0)
            {
                if (Chunk.StartsWith(";"))
                {
                    SkipComment();
                }
                else if (Chunk.StartsWith("\r\n") || Chunk.StartsWith("\n\r"))
                {
                    Next(2);
                    Line += 1;
                }
                else if (IsNewLine(Chunk[0]))
                {
                    Next(1);
                    Line += 1;
                }
                else if (IsWhiteSpace(Chunk[0]))
                {
                    Next(1);
                }
                else
                {
                    break;
                }
            }
        }

        private void SkipComment()
        {
            Next(1);
            while (Chunk.Length > 0 && !IsNewLine(Chunk[0]))
            {
                Next(1);
            }
        }


        public Token LookAhead()
        {
            if (nextToken != null)
            {
                return nextToken;
            }
            var currentLine = Line;
            nextToken = NextToken();
            Line = currentLine;
            return nextToken;
        }


        
    }
}
