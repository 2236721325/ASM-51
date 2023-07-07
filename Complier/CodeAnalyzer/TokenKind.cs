using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Complier.CodeAnalyzer
{

    public static class TokenKindUtility
    {
        public static bool IsReg_Rn(TokenKind kind)
        {
            var num=(int)kind;
            return num >= 48 && num <= 55;
        }
        public static bool IsReg_Ri(TokenKind kind)
        {
            return kind==TokenKind.REG_R0 || kind==TokenKind.REG_R1;
        }

        public static Byte GetReg_Rn_index(TokenKind kind)
        {
            return (byte)((int)kind - 48);
        }


    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TokenKind
    {
        EOF,//end of file
        Identifier,
        OP_ADD,
        OP_ADDC,
        OP_INC,
        OP_SUBB,
        OP_DEC,
        OP_MUL,
        OP_DIV,
        OP_DA,
        OP_ANL,
        OP_ORL,
        OP_XRL,
        OP_CLR,
        OP_CPL,
        OP_RL,
        OP_RLC,
        OP_RR,
        OP_RRC,
        OP_SWAP,
        OP_MOV,
        OP_MOVC,
        OP_MOVX,
        OP_PUSH,
        OP_POP,
        OP_XCH,
        OP_XCHD,
        OP_SETB,
        OP_ACALL,
        OP_LCALL,
        OP_RET,
        OP_RETI,
        OP_AJMP,
        OP_LJMP,
        OP_SJMP,
        OP_JZ,
        OP_JNZ,
        OP_JC,
        OP_JNC,
        OP_JB,
        OP_JNB,
        OP_JBC,
        OP_CJNE,
        OP_DJNZ,
        OP_NOP,
        REG_A,
        REG_R0,
        REG_R1,
        REG_R2,
        REG_R3,
        REG_R4,
        REG_R5,
        REG_R6,
        REG_R7,    
        REG_DPTR,
        REG_AB,
        REG_PC,
        REG_C,
        TOKEN_SEP_COMMA,
        TOKEN_OP_LEN,
        TOKEN_SEP_DOT,
        TOKEN_SEP_PLUS,
        Number,
        TOKEN_SEP_COLON,
        Directive_ORG,
        Directive_END,
        Directive_DB,
        Directive_EQU,
        TOKEN_SEP_ARE,
        TOKEN_SEP_SLASH,
        OP_JMP,
        TOKEN_SEP_DOLLAR,
        TOKEN_Symbol = Identifier,
    }
}
