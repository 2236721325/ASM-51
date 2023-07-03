using Complier.Exceptions;
using Complier.Structures;
using Complier.Structures.Instructions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Complier.CodeAnalyzer.Parser
{
    public partial class Parser
    {

        private Instruction ParseOpInstruction()
        {
            var token = lexer.NextToken();
            switch (token.Kind)
            {
                case TokenKind.OP_ADD:
                    return ParseOp_ADD();
                case TokenKind.OP_ADDC:
                    return ParseOp_ADDC();

                case TokenKind.OP_INC:
                    return ParseOp_INC();
                case TokenKind.OP_SUBB:
                    return ParseOp_SUBB();

                case TokenKind.OP_DEC:
                    return ParseOp_DEC();

                case TokenKind.OP_MUL:
                    return ParseOp_MUL();

                case TokenKind.OP_DIV:
                    return ParseOp_DIV();

                case TokenKind.OP_DA:
                    return ParseOp_DA();

                case TokenKind.OP_ANL:
                    return ParseOp_ANL();

                case TokenKind.OP_ORL:
                    return ParseOp_ORL();

                case TokenKind.OP_XRL:
                    return ParseOp_XRL();

                case TokenKind.OP_CLR:
                    return ParseOp_CLR();

                case TokenKind.OP_CPL:
                    return ParseOp_CPL();

                case TokenKind.OP_RL:
                    return ParseOp_RL();

                case TokenKind.OP_RLC:
                    return ParseOp_RLC();

                case TokenKind.OP_RR:
                    return ParseOp_RR();

                case TokenKind.OP_RRC:
                    return ParseOp_RRC();

                case TokenKind.OP_SWAP:
                    return ParseOp_SWAP();

                case TokenKind.OP_MOV:
                    return ParseOp_MOV();

                case TokenKind.OP_MOVC:
                    return ParseOp_MOVC();

                case TokenKind.OP_MOVX:
                    return ParseOp_MOVX();

                case TokenKind.OP_PUSH:
                    return ParseOp_PUSH();

                case TokenKind.OP_POP:
                    return ParseOp_POP();

                case TokenKind.OP_XCH:
                    return ParseOp_XCH();

                case TokenKind.OP_XCHD:
                    return ParseOp_XCHD();

                case TokenKind.OP_SETB:
                    return ParseOp_SETB();

                case TokenKind.OP_ACALL:
                    return ParseOp_ACALL();

                case TokenKind.OP_LCALL:
                    return ParseOp_LCALL();

                case TokenKind.OP_RET:
                    return ParseOp_RET();

                case TokenKind.OP_RETI:
                    return ParseOp_RETI();
                case TokenKind.OP_AJMP:
                    return ParseOp_AJMP();

                case TokenKind.OP_LJMP:
                    return ParseOp_LJMP();

                case TokenKind.OP_SJMP:
                    return ParseOp_SJMP();

                case TokenKind.OP_JZ:
                    return ParseOp_JZ();

                case TokenKind.OP_NJZ:
                    return ParseOp_NJZ();

                case TokenKind.OP_JC:
                    return ParseOp_JC();

                case TokenKind.OP_NJC:
                    return ParseOp_NJC();

                case TokenKind.OP_JB:
                    return ParseOp_JB();

                case TokenKind.OP_JNB:
                    return ParseOp_JNB();

                case TokenKind.OP_JBC:
                    return ParseOp_JBC();

                case TokenKind.OP_CJNE:
                    return ParseOp_CJNE();

                case TokenKind.OP_DJNZ:
                    return ParseOp_DJNZ();

                case TokenKind.OP_NOP:
                    return ParseOp_NOP();
            }

            throw new SyntaxException($"Unexpected -> {token.Value} !", token.Line);
        }

        private Instruction ParseOp_NOP()
        {
            return new Nop_Instruction(lexer.Line);
        }

        private Instruction ParseOp_DJNZ()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_CJNE()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_JBC()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_JNB()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_JB()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_NJC()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_JC()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_NJZ()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_JZ()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_SJMP()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_LJMP()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_AJMP()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_RETI()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_RET()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_LCALL()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_ACALL()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_SETB()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_XCHD()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_XCH()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_POP()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_PUSH()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_MOVX()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_MOVC()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_MOV()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_SWAP()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_RRC()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_RR()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_RLC()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_RL()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_CPL()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_CLR()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_XRL()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_ORL()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_ANL()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_DA()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_DIV()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_MUL()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_DEC()
        {
            throw new NotImplementedException();
        }

        private Instruction ParseOp_SUBB()
        {
            var a_reg = lexer.NextTokenOfKind(TokenKind.REG_A);
            var comma = lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
            var end_token = lexer.NextToken();



            if (end_token.Kind == TokenKind.Number)
            {
                var prefix = new PrefixStructure(null, end_token);
                return new SubB_Instruction(prefix, 1, end_token.Line);
            }

            if (end_token.Kind == TokenKind.TOKEN_OP_LEN) //#
            {
                var data_token = lexer.NextTokenOfKind(TokenKind.Number);
                var prefix = new PrefixStructure(end_token, data_token);
                return new SubB_Instruction(prefix, 3, end_token.Line);
            }


            if (end_token.Kind == TokenKind.TOKEN_SEP_ARE) //@
            {
                var reg_Ri_token = lexer.NextToken();
                if (!TokenKindUtility.IsReg_Ri(reg_Ri_token.Kind))
                {
                    throw new SyntaxException($"Unexpected -> {reg_Ri_token.Value} ! Need  R0 or  R1", reg_Ri_token.Line);
                }
                var prefix = new PrefixStructure(end_token, reg_Ri_token);
                return new SubB_Instruction(prefix, 2, end_token.Line);
            }


            if (!TokenKindUtility.IsReg_Rn(end_token.Kind))
            {
                throw new SyntaxException($"Unexpected -> {end_token.Value} ! Need  R0 - R7", end_token.Line);
            }
            var prefix_end = new PrefixStructure(null, end_token);


            return new SubB_Instruction(prefix_end, 0, end_token.Line);
        }

        private Instruction ParseOp_INC()
        {
            var end_token = lexer.NextToken();



            if (end_token.Kind == TokenKind.Number)
            {
                var prefix = new PrefixStructure(null, end_token);
                return new INC_Instruction(prefix, 2, end_token.Line);
            }

            if (end_token.Kind == TokenKind.REG_A) 
            {
                
                var prefix = new PrefixStructure(null, end_token);
                return new INC_Instruction(prefix, 0, end_token.Line);
            }

            if (end_token.Kind == TokenKind.REG_DPTR) //#
            {

                var prefix = new PrefixStructure(null, end_token);
                return new INC_Instruction(prefix, 4, end_token.Line);
            }


            if (end_token.Kind == TokenKind.TOKEN_SEP_ARE) //@
            {
                var reg_Ri_token = lexer.NextToken();
                if (!TokenKindUtility.IsReg_Ri(reg_Ri_token.Kind))
                {
                    throw new SyntaxException($"Unexpected -> {reg_Ri_token.Value} ! Need  R0 or  R1", reg_Ri_token.Line);
                }
                var prefix = new PrefixStructure(end_token, reg_Ri_token);
                return new INC_Instruction(prefix, 3, end_token.Line);
            }


            if (!TokenKindUtility.IsReg_Rn(end_token.Kind))
            {
                throw new SyntaxException($"Unexpected -> {end_token.Value} ! Need  R0 - R7", end_token.Line);
            }
            var prefix_end = new PrefixStructure(null, end_token);


            return new INC_Instruction(prefix_end, 1, end_token.Line);
        }

        private Instruction ParseOp_ADDC()
        {
            var a_reg = lexer.NextTokenOfKind(TokenKind.REG_A);
            var comma = lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
            var end_token = lexer.NextToken();



            if (end_token.Kind == TokenKind.Number)
            {
                var prefix = new PrefixStructure(null, end_token);
                return new AddC_Instruction(prefix, 1, end_token.Line);
            }

            if (end_token.Kind == TokenKind.TOKEN_OP_LEN) //#
            {
                var data_token = lexer.NextTokenOfKind(TokenKind.Number);
                var prefix = new PrefixStructure(end_token, data_token);
                return new AddC_Instruction(prefix, 3, end_token.Line);
            }


            if (end_token.Kind == TokenKind.TOKEN_SEP_ARE) //@
            {
                var reg_Ri_token = lexer.NextToken();
                if (!TokenKindUtility.IsReg_Ri(reg_Ri_token.Kind))
                {
                    throw new SyntaxException($"Unexpected -> {reg_Ri_token.Value} ! Need  R0 or  R1", reg_Ri_token.Line);
                }
                var prefix = new PrefixStructure(end_token, reg_Ri_token);
                return new AddC_Instruction(prefix, 2, end_token.Line);
            }


            if (!TokenKindUtility.IsReg_Rn(end_token.Kind))
            {
                throw new SyntaxException($"Unexpected -> {end_token.Value} ! Need  R0 - R7", end_token.Line);
            }
            var prefix_end = new PrefixStructure(null, end_token);


            return new AddC_Instruction(prefix_end, 0, end_token.Line);
        }

        private Instruction ParseOp_ADD()
        {
            var a_reg = lexer.NextTokenOfKind(TokenKind.REG_A);
            var comma = lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
            var end_token = lexer.NextToken();


            
            if(end_token.Kind==TokenKind.Number)
            {
                var prefix = new PrefixStructure(null, end_token);
                return new Add_Instruction(prefix, 1, end_token.Line);
            }

            if(end_token.Kind==TokenKind.TOKEN_OP_LEN) //#
            {
                var data_token = lexer.NextTokenOfKind(TokenKind.Number);
                var prefix=new PrefixStructure(end_token, data_token);
                return new Add_Instruction(prefix, 3, end_token.Line);
            }


            if (end_token.Kind == TokenKind.TOKEN_SEP_ARE) //@
            {
                var reg_Ri_token = lexer.NextToken();
                if(!TokenKindUtility.IsReg_Ri(reg_Ri_token.Kind))
                {
                    throw new SyntaxException($"Unexpected -> {reg_Ri_token.Value} ! Need  R0 or  R1", reg_Ri_token.Line);
                }
                var prefix = new PrefixStructure(end_token, reg_Ri_token);
                return new Add_Instruction(prefix, 2, end_token.Line);
            }


            if(!TokenKindUtility.IsReg_Rn(end_token.Kind))
            {
                throw new SyntaxException($"Unexpected -> {end_token.Value} ! Need  R0 - R7", end_token.Line);
            }
            var prefix_end = new PrefixStructure(null, end_token);


            return new Add_Instruction(prefix_end, 0, end_token.Line);
        }
    }
}
