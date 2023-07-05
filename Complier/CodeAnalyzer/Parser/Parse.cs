using Complier.CodeAnalyzer;
using Complier.Exceptions;
using Complier.Structures;
using Complier.Structures.Directives;
using Complier.Structures.Instructions;
using Complier.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace Complier.CodeAnalyzer.Parser
{
    public partial class Parser
    {
        private Lexer lexer;

        private int currentAddress;

        public int CurrentAddress { get => currentAddress; }

        public Parser(Lexer lexer)
        {
            this.lexer = lexer;
            currentAddress = 0;
        }

        public Block Parse()
        {
            return ParseBlock(); 
        }

        public Block ParseBlock()
        {
            var instructions = new List<Instruction>();
            while(true)
            {
                var token = lexer.LookAhead();

                if (token.Kind == TokenKind.EOF)
                {
                    break;
                }

                instructions.Add(ParseEvery());
            }

            return new Block ( instructions);
        }



        public Instruction ParseEvery()
        {
            var token = lexer.LookAhead();
            switch (token.Kind)
            {
                case TokenKind.OP_ADD:
                case TokenKind.OP_ADDC:
                case TokenKind.OP_INC:
                case TokenKind.OP_SUBB:
                case TokenKind.OP_DEC:
                case TokenKind.OP_MUL:
                case TokenKind.OP_DIV:
                case TokenKind.OP_DA:
                case TokenKind.OP_ANL:
                case TokenKind.OP_ORL:
                case TokenKind.OP_XRL:
                case TokenKind.OP_CLR:
                case TokenKind.OP_CPL:
                case TokenKind.OP_RL:
                case TokenKind.OP_RLC:
                case TokenKind.OP_RR:
                case TokenKind.OP_RRC:
                case TokenKind.OP_SWAP:
                case TokenKind.OP_MOV:
                case TokenKind.OP_MOVC:
                case TokenKind.OP_MOVX:
                case TokenKind.OP_PUSH:
                case TokenKind.OP_POP:
                case TokenKind.OP_XCH:
                case TokenKind.OP_XCHD:
                case TokenKind.OP_SETB:
                case TokenKind.OP_ACALL:
                case TokenKind.OP_LCALL:
                case TokenKind.OP_RET:
                case TokenKind.OP_RETI:
                case TokenKind.OP_AJMP:
                case TokenKind.OP_LJMP:
                case TokenKind.OP_SJMP:
                case TokenKind.OP_JZ:
                case TokenKind.OP_JNZ:
                case TokenKind.OP_JC:
                case TokenKind.OP_JNC:
                case TokenKind.OP_JB:
                case TokenKind.OP_JNB:
                case TokenKind.OP_JBC:
                case TokenKind.OP_CJNE:
                case TokenKind.OP_DJNZ:
                case TokenKind.OP_NOP:
                    var ret= ParseOpInstruction();
                    currentAddress+= ret.GetHexCode().Length;
                    return ret;
                case TokenKind.Identifier:
                case TokenKind.Directive_ORG:
                case TokenKind.Directive_END:
                case TokenKind.Directive_DB:
                    return ParseDirective();
            }
            throw new SyntaxException($"Unexpected ->[{token.Value}]", token.Line);
        }



    }
}
