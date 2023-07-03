using System;
using System.Collections.Generic;
using System.Text;

namespace Complier.CodeAnalyzer
{
    public class Constants
    {

        public static readonly Dictionary<string, TokenKind> OpCode_Map = new Dictionary<string, TokenKind>()
        {
            {"ADD", TokenKind.OP_ADD},
            {"ADDC", TokenKind. OP_ADDC},
            {"SUBB", TokenKind. OP_SUBB},
            {"INC",TokenKind. OP_INC},
            {"DEC",TokenKind. OP_DEC},
            {"MUL",TokenKind. OP_MUL},
            {"DIV",TokenKind. OP_DIV},
            {"DA",TokenKind. OP_DA},
            {"ANL",TokenKind. OP_ANL},
            {"ORL",TokenKind. OP_ORL},
            {"XRL",TokenKind. OP_XRL},
            {"CLR",TokenKind. OP_CLR},
            {"CPL",TokenKind. OP_CPL},
            {"RL",TokenKind. OP_RL},
            {"RLC",TokenKind. OP_RLC},
            {"RR",TokenKind. OP_RR},
            {"RRC",TokenKind. OP_RRC},
            {"SWAP",TokenKind. OP_SWAP},
            {"MOV",TokenKind. OP_MOV},
            {"MOVC", TokenKind.OP_MOVC},
            {"MOVX",TokenKind. OP_MOVX},
            {"PUSH",TokenKind. OP_PUSH},
            {"POP",TokenKind. OP_POP},
            {"XCH",TokenKind. OP_XCH},
            {"XCHD",TokenKind. OP_XCHD},
            {"SETB",TokenKind. OP_SETB},
            {"ACALL",TokenKind. OP_ACALL},
            {"LCALL",TokenKind. OP_LCALL},
            {"RET",TokenKind. OP_RET},
            {"RETI",TokenKind. OP_RETI},
            {"AJMP",TokenKind. OP_AJMP},
            {"LJMP",TokenKind. OP_LJMP},
            {"SJMP",TokenKind. OP_SJMP},
            {"JZ",TokenKind. OP_JZ},
            {"NJZ",TokenKind. OP_NJZ},
            {"JC",TokenKind. OP_JC},
            {"NJC",TokenKind. OP_NJC},
            {"JB",TokenKind. OP_JB},
            {"JNB",TokenKind. OP_JNB},
            {"JBC",TokenKind. OP_JBC},
            {"CJNE",TokenKind. OP_CJNE},
            {"DJNZ",TokenKind. OP_DJNZ},
            {"NOP",TokenKind. OP_NOP},
        };



        public static readonly Dictionary<string, TokenKind> Register_Map = new Dictionary<string, TokenKind>()
        {
            {"A", TokenKind.REG_A},
            {"ACC", TokenKind.REG_ACC},
            {"B", TokenKind. REG_B},
            {"R0",TokenKind. REG_R0},
            {"R1",TokenKind. REG_R1},
            {"R2",TokenKind. REG_R2},
            {"R3",TokenKind. REG_R3},
            {"R4",TokenKind. REG_R4},
            {"R5",TokenKind. REG_R5},
            {"R6",TokenKind. REG_R6},
            {"R7",TokenKind. REG_R7},
            {"P0",TokenKind. REG_P0},
            {"P1",TokenKind. REG_P1},
            {"P2",TokenKind. REG_P2},
            {"P3",TokenKind. REG_P3},
        };


        public static readonly Dictionary<string, TokenKind> Directive_Map = new Dictionary<string, TokenKind>()
        {
            {"ORG", TokenKind.Directive_ORG },
            {"END", TokenKind.Directive_END },

        };
        public static readonly char[] WhiteSpace = new char[]
        {
            '\t',
            '\n',
            '\v',
            '\f',
            '\r',
            ' ',
        };


        //// Make it easy with regular expression
        //public const string NumberRegexString = @"^0[xX][0-9a-fA-F]*(\.[0-9a-fA-F]*)?([pP][+\-]?[0-9]+)?|^[0-9]*(\.[0-9]*)?([eE][+\-]?[0-9]+)?";
        //public const string IdentifierRegexString = @"^[_\d\w]+";

        //public const string ShortStrRegexString = @"(?s)(^'(\\\\|\\'|\\\n|\\z\s*|[^'\n])*')|(^""(\\\\|\\""|\\\n|\\z\s*|[^""\n])*"")";

        //public const string OpeningLongBracketRegexString = @"^\[=＊\[";
        //public const string DecEscapeSeqRegexString = @"^\\[0 - 9]{1,3}";
        //public const string HexEscapeSeqRegexString = @"^\\x[0 - 9a - fA - F]{2}";
        //public const string UnicodeEscapeSeqRegexString = @"^\\u\{[0 - 9a - fA - F] +\}";

        //public const string NewLineRegexString = "\r\n|\n\r|\n|\r";


    }
}
