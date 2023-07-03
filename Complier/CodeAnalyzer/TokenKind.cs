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

        public static int GetReg_Rn_index(TokenKind kind)
        {
            return (int)kind - 48;
        }


    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
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
        OP_NJZ,
        OP_JC,
        OP_NJC,
        OP_JB,
        OP_JNB,
        OP_JBC,
        OP_CJNE,
        OP_DJNZ,
        OP_NOP,
        REG_A,
        REG_ACC,
        REG_B,
        REG_R0,
        REG_R1,
        REG_R2,
        REG_R3,
        REG_R4,
        REG_R5,
        REG_R6,
        REG_R7,
        REG_P0,
        REG_P1,
        REG_P2,
        REG_P3,
        TOKEN_SEP_COMMA,
        TOKEN_OP_LEN,
        TOKEN_SEP_DOT,
        Number,
        TOKEN_SEP_COLON,
        Directive_ORG,
        Directive_END,
        TOKEN_SEP_ARE
    }
}
