using Complier.Exceptions;
using Complier.Structures;
using Complier.Structures.Instructions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
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

                case TokenKind.OP_JMP:
                    return ParseOp_JMP();

                case TokenKind.OP_JZ:
                    return ParseOp_JZ();

                case TokenKind.OP_JNZ:
                    return ParseOp_JNZ();

                case TokenKind.OP_JC:
                    return ParseOp_JC();

                case TokenKind.OP_JNC:
                    return ParseOp_JNC();

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
            var first_token = lexer.NextToken();
            if (first_token.IsReg_Rn())
            {
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
                var rel_token = lexer.NextTokenOfNumberOrSymbol();
                return new DJNE_Instruction(
                      currentAddress,
                      first_token,
                      rel_token,
                      0,
                      lexer.Line,
                      2
                      );
            }
            if(first_token.IsNumberOrSymbol())
            {
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
                var rel_token = lexer.NextTokenOfNumberOrSymbol();
                return new DJNE_Instruction(
                      currentAddress,
                      first_token,
                      rel_token,
                      1,
                      lexer.Line,
                      3
                      );
            }

            throw ThrowHelper.UnexpectedToken(first_token);

        }

        private Instruction ParseOp_CJNE()
        {
            var first_token = lexer.NextToken();
            if(first_token.Kind==TokenKind.REG_A)
            {
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
                var second_token=lexer.NextToken();
                if(second_token.IsNumberOrSymbol())
                {
                    lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
                    var end_token=lexer.NextTokenOfNumberOrSymbol();
                    return new CJNE_Instruction(
                        currentAddress, 
                        first_token, 
                        second_token, 
                        end_token, 
                        0, 
                        lexer.Line
                        );
                }
                if(second_token.Kind==TokenKind.TOKEN_OP_LEN)
                {
                    var data_token=lexer.NextTokenOfNumberOrSymbol();
                    lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
                    var rel_token=lexer.NextTokenOfNumberOrSymbol();
                    return new CJNE_Instruction(
                       currentAddress,
                       first_token,
                       data_token,
                       rel_token,
                       1,
                       lexer.Line
                       );
                }
                throw ThrowHelper.UnexpectedToken(second_token);
            }
            if(first_token.IsReg_Rn())
            {
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
                lexer.NextTokenOfKind(TokenKind.TOKEN_OP_LEN);
                var data_token=lexer.NextTokenOfNumberOrSymbol();
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
                var rel_token = lexer.NextTokenOfNumberOrSymbol();
                return new CJNE_Instruction(
                      currentAddress,
                      first_token,
                      data_token,
                      rel_token,
                      2,
                      lexer.Line
                      );
            }
            if(first_token.Kind==TokenKind.TOKEN_SEP_ARE)
            {
                var ri_token=lexer.NextTokenOfRi();
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
                lexer.NextTokenOfKind(TokenKind.TOKEN_OP_LEN);
                var data_token = lexer.NextTokenOfNumberOrSymbol();
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
                var rel_token = lexer.NextTokenOfNumberOrSymbol();
                return new CJNE_Instruction(
                      currentAddress,
                      ri_token,
                      data_token,
                      rel_token,
                      3,
                      lexer.Line
                      );
            }

            throw ThrowHelper.UnexpectedToken(first_token);


        }

        private Instruction ParseOp_JBC()
        {
            var first_token = lexer.NextTokenOfNumberOrSymbol();
            int bit_offset = 0;
            bool has_bit_dot = false;

            if (lexer.LookAhead().Kind == TokenKind.TOKEN_SEP_DOT)
            {
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_DOT);
                bit_offset = lexer.NextBitTokenOfValue();
                has_bit_dot = true;
            }
            lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
            var rel_token = lexer.NextTokenOfNumberOrSymbol();
            if (!has_bit_dot)
            {
                return new JBC_Instruction(
                    CurrentAddress,
                    first_token,
                    rel_token,
                    0,
                    lexer.Line);
            }
            return new JBC_Instruction(
                CurrentAddress,
                first_token,
                rel_token,
                1,
                lexer.Line,
                bit_offset);
        }


        private Instruction ParseOp_JNB()
        {
            var first_token = lexer.NextTokenOfNumberOrSymbol();
            int bit_offset = 0;
            bool has_bit_dot = false;

            if (lexer.LookAhead().Kind == TokenKind.TOKEN_SEP_DOT)
            {
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_DOT);
                bit_offset = lexer.NextBitTokenOfValue();
                has_bit_dot = true;
            }
            lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
            var rel_token = lexer.NextTokenOfNumberOrSymbol();
            if (!has_bit_dot)
            {
                return new JNB_Instruction(
                    CurrentAddress,
                    first_token,
                    rel_token,
                    0,
                    lexer.Line);
            }
            return new JNB_Instruction(
                CurrentAddress,
                first_token,
                rel_token,
                1,
                lexer.Line,
                bit_offset);
        }

        private Instruction ParseOp_JB()
        {
            var first_token = lexer.NextTokenOfNumberOrSymbol();
            int bit_offset = 0;
            bool has_bit_dot = false;
            
            if(lexer.LookAhead().Kind==TokenKind.TOKEN_SEP_DOT)
            {
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_DOT);
                bit_offset=lexer.NextBitTokenOfValue();
                has_bit_dot = true;
            }
            lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
            var rel_token = lexer.NextTokenOfNumberOrSymbol();
            if(!has_bit_dot)
            {
                return new JB_Instruction(
                    CurrentAddress,
                    first_token, 
                    rel_token,
                    0, 
                    lexer.Line);
            }
            return new JB_Instruction(
                CurrentAddress,
                first_token, 
                rel_token, 
                1, 
                lexer.Line, 
                bit_offset);
        }

        private Instruction ParseOp_JNC()
        {
            var rel_token = lexer.NextTokenOfNumberOrSymbol();
            return new JNC_Instruction(CurrentAddress, rel_token, lexer.Line);
        }

        private Instruction ParseOp_JC()
        {
            var rel_token = lexer.NextTokenOfNumberOrSymbol();
            return new JC_Instruction(CurrentAddress, rel_token, lexer.Line);
        }

        private Instruction ParseOp_JNZ()
        {
            var rel_token = lexer.NextTokenOfNumberOrSymbol();
            return new JNZ_Instruction(CurrentAddress, rel_token, lexer.Line);
        }

        private Instruction ParseOp_JZ()
        {
            var rel_token = lexer.NextTokenOfNumberOrSymbol();
            return new JZ_Instruction(CurrentAddress, rel_token, lexer.Line);
        }

        private Instruction ParseOp_JMP()
        {
            lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_ARE);
            lexer.NextTokenOfKind(TokenKind.REG_A);
            lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_PLUS);
            lexer.NextTokenOfKind(TokenKind.REG_DPTR);
            return new JMP_Instruction(lexer.Line);
        }

        private Instruction ParseOp_SJMP()
        {
            var rel_token = lexer.NextTokenOfNumberOrSymbol();
            return new SJMP_Instruction(CurrentAddress,rel_token, lexer.Line);
        }

        private Instruction ParseOp_LJMP()
        {
            var address16_token = lexer.NextTokenOfNumberOrSymbol();
            return new LJMP_Instruction(address16_token, lexer.Line);
        }

        private Instruction ParseOp_AJMP()
        {
            var address11_token = lexer.NextTokenOfNumberOrSymbol();
            return new AJMP_Instruction(address11_token, lexer.Line);
        }

        private Instruction ParseOp_RETI()
        {
            return new RETI_Instruction(lexer.Line);
        }

        private Instruction ParseOp_RET()
        {
            return new RET_Instruction(lexer.Line);
        }

        private Instruction ParseOp_LCALL()
        {
            var address16_token = lexer.NextTokenOfNumberOrSymbol();
            return new LCALL_Instruction(address16_token, lexer.Line);
        }

        private Instruction ParseOp_ACALL()
        {
            var address11_token=lexer.NextTokenOfNumberOrSymbol();
            return new ACALL_Instruction(address11_token,lexer.Line);
        }

        private Instruction ParseOp_SETB()
        {
            var token = lexer.NextToken();
            if(token.Kind==TokenKind.REG_C)
            {
                return new SETB_Instruction(token, 0, 1, lexer.Line);
            }
            if(token.IsNumberOrSymbol())
            {
                if (lexer.LookAhead().Kind != TokenKind.TOKEN_SEP_DOT)
                {
                    return new SETB_Instruction(token, 1, 2, lexer.Line);
                }
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_DOT);
                var bit_offset = lexer.NextBitTokenOfValue();

                return new SETB_Instruction(token, 2, 2, lexer.Line, bit_offset);
            }
            throw ThrowHelper.UnexpectedToken(token);
        }



        #region Data_Transfer_Op
        private Instruction ParseOp_XCHD()
        {
            lexer.NextTokenOfKind(TokenKind.REG_A);
            lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_ARE);
            var ri_token=lexer.NextToken();
            if(!ri_token.IsReg_Ri())
            {
                throw ThrowHelper.UnexpectedToken(ri_token);
            }
            return new XCHD_Instruction(ri_token, lexer.Line);
        }

        private Instruction ParseOp_XCH()
        {
            var reg_a_token=lexer.NextTokenOfKind(TokenKind.REG_A);
            lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
            var second_token = lexer.NextToken();
            if(second_token.IsReg_Rn())
            {
                return new XCH_Instruction(
                        reg_a_token,
                        second_token.ToPrefixStructure(),
                        0,
                        1,
                        lexer.Line
                    );
            }
            if (second_token.IsNumberOrSymbol())
            {
                return new XCH_Instruction(
                        reg_a_token,
                        second_token.ToPrefixStructure(),
                        1,
                        2,
                        lexer.Line
                    );
            }
            if (second_token.Kind==TokenKind.TOKEN_SEP_ARE)
            {
                var ri_token = lexer.NextToken();
                if(!ri_token.IsReg_Ri())
                {
                    throw ThrowHelper.UnexpectedToken(ri_token);
                }
                return new XCH_Instruction(
                        reg_a_token,
                        ri_token.ToPrefixStructure(second_token),
                        2,
                        1,
                        lexer.Line
                    );
            }
            throw ThrowHelper.UnexpectedToken(second_token);
        }

        private Instruction ParseOp_POP()
        {
            var token = lexer.NextTokenOfNumberOrSymbol();
            return new POP_Instruction(token, lexer.Line);
        }

        private Instruction ParseOp_PUSH()
        {
            var token = lexer.NextTokenOfNumberOrSymbol();
            return new PUSH_Instruction(token, lexer.Line);
        }

        private Instruction ParseOp_MOVX()
        {
            var first_token = lexer.NextToken();

            if(first_token.Kind==TokenKind.REG_A)
            {
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
                var are_token=lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_ARE);
                var end_token=lexer.NextToken();
                if(end_token.IsReg_Ri())
                {
                    return new MOVX_Instruction(
                            first_token.ToPrefixStructure(),
                            end_token.ToPrefixStructure(are_token),
                            0,
                            lexer.Line
                        );
                }
                if(end_token.Kind==TokenKind.REG_DPTR)
                {
                    return new MOVX_Instruction(
                            first_token.ToPrefixStructure(),
                            end_token.ToPrefixStructure(are_token),
                            1,
                            lexer.Line
                        );
                }

                throw ThrowHelper.UnexpectedToken(end_token);
            
            }
            

            if(first_token.Kind==TokenKind.TOKEN_SEP_ARE)
            {

                var second_token=lexer.NextToken();

                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
                var token_Reg_A=lexer.NextTokenOfKind(TokenKind.REG_A);
                if(second_token.IsReg_Ri())
                {
                    return new MOVX_Instruction(
                            second_token.ToPrefixStructure(first_token),
                            token_Reg_A.ToPrefixStructure(),
                            2,
                            lexer.Line

                        );

                }

                if (second_token.Kind==TokenKind.REG_DPTR)
                {
                    return new MOVX_Instruction(
                            second_token.ToPrefixStructure(first_token),
                            token_Reg_A.ToPrefixStructure(),
                            3,
                            lexer.Line
                        );

                }
                throw ThrowHelper.UnexpectedToken(second_token);








            }
            throw ThrowHelper.UnexpectedToken(first_token);

        }

        private Instruction ParseOp_MOVC()
        {
            var token_Reg_A=lexer.NextTokenOfKind(TokenKind.REG_A);
            lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
            lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_ARE);
            lexer.NextTokenOfKind(TokenKind.REG_A);
            lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_PLUS);
            var end_token= lexer.NextToken();
            if (end_token.Kind == TokenKind.REG_DPTR)
            {
                return new MOVC_Instruction(
                        token_Reg_A,
                        end_token.ToPrefixStructure(),
                        0,
                        lexer.Line
                    );
            }


            if (end_token.Kind == TokenKind.REG_PC)
            {
                return new MOVC_Instruction(
                        token_Reg_A,
                        end_token.ToPrefixStructure(),
                        1,
                        lexer.Line
                    );
            }

            throw ThrowHelper.UnexpectedToken(end_token);


        }
        private Instruction ParseOp_MOV()
        {
            var second_token = lexer.NextToken();


            if (second_token.Kind == TokenKind.REG_A)
            {
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);

                var third_token = lexer.NextToken();
                

                if (third_token.IsReg_Rn())
                {
                    return new MOV_Instruction(
                        second_token.ToPrefixStructure(),
                        third_token.ToPrefixStructure(),
                        0,
                        1,
                        second_token.Line
                        );
                }

                if (third_token.IsNumberOrSymbol())
                {
                    return new MOV_Instruction(
                        second_token.ToPrefixStructure(),
                        third_token.ToPrefixStructure(),
                        1,
                        2,
                        second_token.Line
                        );
                }


                if (third_token.Kind == TokenKind.TOKEN_SEP_ARE)
                {
                    var token_Ri = lexer.NextToken();
                    if (!token_Ri.IsReg_Ri())
                    {
                        throw ThrowHelper.UnexpectedToken(token_Ri, "Ri");
                    }
                    return new MOV_Instruction(
                        second_token.ToPrefixStructure(),
                        token_Ri.ToPrefixStructure(third_token),
                        2,
                        1,
                        second_token.Line
                        );
                }

                if (third_token.Kind == TokenKind.TOKEN_OP_LEN) //#
                {
                    var data = lexer.NextTokenOfNumberOrSymbol();

                    return new MOV_Instruction(
                        second_token.ToPrefixStructure(),
                        data.ToPrefixStructure(third_token),
                        3,
                        2,
                        second_token.Line
                        );
                }

                throw ThrowHelper.UnexpectedToken(third_token);

            }

            if (second_token.IsReg_Rn())
            {
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);

                var third_token = lexer.NextToken();


                if (third_token.Kind==TokenKind.REG_A)
                {
                    return new MOV_Instruction(
                        second_token.ToPrefixStructure(),
                        third_token.ToPrefixStructure(),
                        4,
                        1,
                        second_token.Line
                        );
                }

                if (third_token.IsNumberOrSymbol())
                {
                    return new MOV_Instruction(
                        second_token.ToPrefixStructure(),
                        third_token.ToPrefixStructure(),
                        5,
                        2,
                        second_token.Line
                        );
                }


              

                if (third_token.Kind == TokenKind.TOKEN_OP_LEN) //#
                {
                    var data = lexer.NextTokenOfNumberOrSymbol();

                    return new MOV_Instruction(
                        second_token.ToPrefixStructure(),
                        data.ToPrefixStructure(third_token),
                        6,
                        2,
                        second_token.Line
                        );
                }
                throw ThrowHelper.UnexpectedToken(third_token);

            }


            if (second_token.IsNumberOrSymbol())
            {
                int bit_offset = 0;
                bool has_bit_dot = false;
                if(lexer.LookAhead().Kind==TokenKind.TOKEN_SEP_DOT)
                {
                    lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_DOT);
                    bit_offset=lexer.NextBitTokenOfValue();
                    has_bit_dot = true;
                }
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);

                
                
                var third_token = lexer.NextToken();

                if(third_token.Kind==TokenKind.REG_C)
                {
                   if(!has_bit_dot)
                    {
                        return new MOV_Instruction(
                                 second_token.ToPrefixStructure(),
                                 third_token.ToPrefixStructure(),
                                 18,
                                 2,
                                 lexer.Line);
                    }
                    return new MOV_Instruction(
                                second_token.ToPrefixStructure(),
                                third_token.ToPrefixStructure(),
                                19,
                                2,
                                lexer.Line
                                ,bit_offset);
                }
                if (third_token.Kind == TokenKind.REG_A)
                {
                    return new MOV_Instruction(
                      second_token.ToPrefixStructure(),
                      third_token.ToPrefixStructure(),
                      7,
                      2,
                      lexer.Line
                      );
                }
                if (third_token.IsReg_Rn())
                {
                    return new MOV_Instruction(
                      second_token.ToPrefixStructure(),
                      third_token.ToPrefixStructure(),
                      8,
                      2,
                      lexer.Line
                      );
                }

                if (third_token.IsNumberOrSymbol())
                {
                    return new MOV_Instruction(
                      second_token.ToPrefixStructure(),
                      third_token.ToPrefixStructure(),
                      9,
                      3,
                      lexer.Line
                      );
                }

                if (third_token.Kind == TokenKind.TOKEN_SEP_ARE)//@
                {
                    var ri_token = lexer.NextToken();
                    if(!ri_token.IsReg_Ri())
                    {
                        throw ThrowHelper.UnexpectedToken(ri_token, "ri");
                    }
                    return new MOV_Instruction(
                      second_token.ToPrefixStructure(),
                      ri_token.ToPrefixStructure(third_token),
                      10,
                      2,
                      lexer.Line
                      );
                }

                if (third_token.Kind == TokenKind.TOKEN_OP_LEN)//#
                {
                    var data_token = lexer.NextTokenOfNumberOrSymbol();
                    return new MOV_Instruction(
                      second_token.ToPrefixStructure(),
                      data_token.ToPrefixStructure(third_token),
                      11,
                      3,
                      lexer.Line
                      );
                }

                throw ThrowHelper.UnexpectedToken(third_token);

            }


            if(second_token.Kind==TokenKind.TOKEN_SEP_ARE)
            {
                var token_Ri = lexer.NextToken();

                if (!token_Ri.IsReg_Ri())
                {
                    throw ThrowHelper.UnexpectedToken(token_Ri, "Ri");
                }

                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);

                var third_token = lexer.NextToken();


                if(third_token.Kind==TokenKind.REG_A)
                {
                    return new MOV_Instruction(
                     token_Ri.ToPrefixStructure(second_token),
                     third_token.ToPrefixStructure(),
                     12,
                     1,
                     lexer.Line
                     );
                }

                if (third_token.IsNumberOrSymbol())
                {
                    return new MOV_Instruction(
                     token_Ri.ToPrefixStructure(second_token),
                     third_token.ToPrefixStructure(),
                     13,
                     2,
                     lexer.Line
                     );
                }

                if (third_token.Kind == TokenKind.TOKEN_OP_LEN) //#
                {
                    var data_token=lexer.NextTokenOfNumberOrSymbol();
                    return new MOV_Instruction(
                     token_Ri.ToPrefixStructure(second_token),
                     data_token.ToPrefixStructure(third_token),
                     14,
                     2,
                     lexer.Line
                     );
                }

                throw ThrowHelper.UnexpectedToken(third_token);












            }


            if(second_token.Kind==TokenKind.REG_DPTR)
            {
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
                var third_token=lexer.NextTokenOfKind(TokenKind.TOKEN_OP_LEN);
                var data_token = lexer.NextTokenOfNumberOrSymbol();

                return new MOV_Instruction(
                     second_token.ToPrefixStructure(),
                     data_token.ToPrefixStructure(third_token),
                     15,
                     3,
                     lexer.Line
                     );


            }
            if (second_token.Kind == TokenKind.REG_C)
            {
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
                var third_token = lexer.NextToken();
                if (third_token.IsNumberOrSymbol())
                {
                    if (lexer.LookAhead().Kind != TokenKind.TOKEN_SEP_DOT)
                    {
                        return new MOV_Instruction(
                                second_token.ToPrefixStructure(),
                                third_token.ToPrefixStructure(),
                                16,
                                2,
                                lexer.Line);
                    }
                    lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_DOT);
                    var bit_offset = lexer.NextBitTokenOfValue();

                    return new MOV_Instruction(
                                                  second_token.ToPrefixStructure(),
                                                  third_token.ToPrefixStructure(),
                                                  17,
                                                  2,
                                                  lexer.Line,
                                                  bit_offset);
                }


                throw ThrowHelper.UnexpectedToken(third_token);

            }
            throw ThrowHelper.UnexpectedToken(second_token);
        }


        #endregion
        #region Logic_Op
        private Instruction ParseOp_SWAP()
        {
            lexer.NextTokenOfKind(TokenKind.REG_A);
            return new SWAP_Instruction(lexer.Line);
        }

        private Instruction ParseOp_RRC()
        {
            lexer.NextTokenOfKind(TokenKind.REG_A);
            return new RRC_Instruction(lexer.Line);
        }

        private Instruction ParseOp_RR()
        {
            lexer.NextTokenOfKind(TokenKind.REG_A);
            return new RR_Instruction(lexer.Line);
        }

        private Instruction ParseOp_RLC()
        {
            lexer.NextTokenOfKind(TokenKind.REG_A);
            return new RLC_Instruction(lexer.Line);
        }

        private Instruction ParseOp_RL()
        {
            lexer.NextTokenOfKind(TokenKind.REG_A);
            return new RL_Instruction(lexer.Line);
        }

        private Instruction ParseOp_CPL()
        {
            var token = lexer.NextToken();
            if (token.Kind == TokenKind.REG_A)
            {
                return new CPL_Instruction(token, 0, 1, lexer.Line);
            }
            if (token.Kind == TokenKind.REG_C)
            {
                return new CPL_Instruction(token, 1, 1, lexer.Line);
            }
            if (token.IsNumberOrSymbol())
            {
                if (lexer.LookAhead().Kind != TokenKind.TOKEN_SEP_DOT)
                {
                    return new CPL_Instruction(token, 2, 2, lexer.Line);
                }
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_DOT);
                var bit_offset = lexer.NextBitTokenOfValue();

                return new CPL_Instruction(token, 3, 2, lexer.Line, bit_offset);
            }
            throw ThrowHelper.UnexpectedToken(token);
        }

        private Instruction ParseOp_CLR()
        {
            var token = lexer.NextToken();
            if(token.Kind==TokenKind.REG_A)
            {
                return new CLR_Instruction(token, 0, 1, lexer.Line);
            }
            if (token.Kind == TokenKind.REG_C)
            {
                return new CLR_Instruction(token, 1, 1, lexer.Line);
            }
            if(token.IsNumberOrSymbol())
            {
                if(lexer.LookAhead().Kind!=TokenKind.TOKEN_SEP_DOT)
                {
                    return new CLR_Instruction(token, 2, 2, lexer.Line);
                }
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_DOT);
                var bit_offset=lexer.NextBitTokenOfValue();

                return new CLR_Instruction(token, 3, 2, lexer.Line,bit_offset);
            }
            throw ThrowHelper.UnexpectedToken(token);
        }

        private Instruction ParseOp_XRL()
        {
            var second_token = lexer.NextToken();
            lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);


            if (second_token.Kind == TokenKind.REG_A)
            {
                var third_token = lexer.NextToken();

                if (TokenKindUtility.IsReg_Rn(third_token.Kind))
                {
                    return new XRL_Instruction(
                        second_token.ToPrefixStructure(),
                        third_token.ToPrefixStructure(),
                        0,
                        1,
                        second_token.Line
                        );
                }

                if (third_token.IsNumberOrSymbol())
                {
                    return new XRL_Instruction(
                        second_token.ToPrefixStructure(),
                        third_token.ToPrefixStructure(),
                        1,
                        2,
                        second_token.Line
                        );
                }


                if (third_token.Kind == TokenKind.TOKEN_SEP_ARE)
                {
                    var token_Ri = lexer.NextToken();
                    if (!TokenKindUtility.IsReg_Ri(token_Ri.Kind))
                    {
                        throw ThrowHelper.UnexpectedToken(third_token, "Ri");
                    }
                    return new XRL_Instruction(
                        second_token.ToPrefixStructure(),
                        token_Ri.ToPrefixStructure(third_token),
                        2,
                        1,
                        second_token.Line
                        );
                }

                if (third_token.Kind == TokenKind.TOKEN_OP_LEN) //#
                {
                    var data = lexer.NextTokenOfNumberOrSymbol();

                    return new XRL_Instruction(
                        second_token.ToPrefixStructure(),
                        data.ToPrefixStructure(third_token),
                        3,
                        2,
                        second_token.Line
                        );
                }

                throw ThrowHelper.UnexpectedToken(third_token);

            }

            if (second_token.IsNumberOrSymbol())
            {
                var third_token = lexer.NextToken();
                if (third_token.Kind == TokenKind.REG_A)
                {
                    return new XRL_Instruction(
                      second_token.ToPrefixStructure(),
                      third_token.ToPrefixStructure(),
                      4,
                      2,
                      lexer.Line
                      );
                }

                if (third_token.Kind == TokenKind.TOKEN_OP_LEN)//#
                {
                    var data_token = lexer.NextTokenOfNumberOrSymbol();
                    return new XRL_Instruction(
                      second_token.ToPrefixStructure(),
                      data_token.ToPrefixStructure(third_token),
                      5,
                      3,
                      lexer.Line
                      );
                }

                throw ThrowHelper.UnexpectedToken(third_token);

            }
            throw ThrowHelper.UnexpectedToken(second_token);
        }


        private Instruction ParseOp_ORL()
        {
            var second_token = lexer.NextToken();
            lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);


            if (second_token.Kind == TokenKind.REG_A)
            {
                var third_token = lexer.NextToken();

                if (TokenKindUtility.IsReg_Rn(third_token.Kind))
                {
                    return new ORL_Instruction(
                        second_token.ToPrefixStructure(),
                        third_token.ToPrefixStructure(),
                        0,
                        1,
                        second_token.Line
                        );
                }

                if (third_token.IsNumberOrSymbol())
                {
                    return new ORL_Instruction(
                        second_token.ToPrefixStructure(),
                        third_token.ToPrefixStructure(),
                        1,
                        2,
                        second_token.Line
                        );
                }


                if (third_token.Kind == TokenKind.TOKEN_SEP_ARE)
                {
                    var token_Ri = lexer.NextToken();
                    if (!TokenKindUtility.IsReg_Ri(token_Ri.Kind))
                    {
                        throw ThrowHelper.UnexpectedToken(third_token, "Ri");
                    }
                    return new ORL_Instruction(
                        second_token.ToPrefixStructure(),
                        token_Ri.ToPrefixStructure(third_token),
                        2,
                        1,
                        second_token.Line
                        );
                }

                if (third_token.Kind == TokenKind.TOKEN_OP_LEN) //#
                {
                    var data = lexer.NextTokenOfNumberOrSymbol();

                    return new ORL_Instruction(
                        second_token.ToPrefixStructure(),
                        data.ToPrefixStructure(third_token),
                        3,
                        2,
                        second_token.Line
                        );
                }

                throw ThrowHelper.UnexpectedToken(third_token);

            }

            if (second_token.IsNumberOrSymbol())
            {
                var third_token = lexer.NextToken();
                if (third_token.Kind == TokenKind.REG_A)
                {
                    return new ORL_Instruction(
                      second_token.ToPrefixStructure(),
                      third_token.ToPrefixStructure(),
                      4,
                      2,
                      lexer.Line
                      );
                }

                if (third_token.Kind == TokenKind.TOKEN_OP_LEN)//#
                {
                    var data_token = lexer.NextTokenOfNumberOrSymbol();
                    return new ORL_Instruction(
                      second_token.ToPrefixStructure(),
                      data_token.ToPrefixStructure(third_token),
                      5,
                      3,
                      lexer.Line
                      );
                }

                throw ThrowHelper.UnexpectedToken(third_token);

            }

            if (second_token.Kind == TokenKind.REG_C)
            {
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
                var third_token = lexer.NextToken();
                if (third_token.IsNumberOrSymbol())
                {
                    if (lexer.LookAhead().Kind != TokenKind.TOKEN_SEP_DOT)
                    {
                        return new ORL_Instruction(
                                second_token.ToPrefixStructure(),
                                third_token.ToPrefixStructure(),
                                6,
                                2,
                                lexer.Line);
                    }
                    lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_DOT);
                    var bit_offset = lexer.NextBitTokenOfValue();

                    return new ORL_Instruction(
                                                  second_token.ToPrefixStructure(),
                                                  third_token.ToPrefixStructure(),
                                                  7,
                                                  2,
                                                  lexer.Line,
                                                  bit_offset);
                }

                if (third_token.Kind == TokenKind.TOKEN_SEP_SLASH)
                {
                    var symbol_token = lexer.NextTokenOfNumberOrSymbol();
                    if (lexer.LookAhead().Kind != TokenKind.TOKEN_SEP_DOT)
                    {
                        return new ORL_Instruction(
                                second_token.ToPrefixStructure(),
                                symbol_token.ToPrefixStructure(third_token),
                                8,
                                2,
                                lexer.Line);
                    }
                    lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_DOT);
                    var bit_offset = lexer.NextBitTokenOfValue();

                    return new ORL_Instruction(
                                                  second_token.ToPrefixStructure(),
                                                  symbol_token.ToPrefixStructure(third_token),
                                                  9,
                                                  2,
                                                  lexer.Line,
                                                  bit_offset);
                }

                throw ThrowHelper.UnexpectedToken(third_token);

            }

            throw ThrowHelper.UnexpectedToken(second_token);
        }


        private Instruction ParseOp_ANL()
        {
            var second_token = lexer.NextToken();

            lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);


            if (second_token.Kind==TokenKind.REG_A)
            {
                var third_token = lexer.NextToken();

                if(TokenKindUtility.IsReg_Rn( third_token.Kind))
                {
                    return new ANL_Instruction(
                        second_token.ToPrefixStructure(),
                        third_token.ToPrefixStructure(),
                        0, 
                        1,
                        second_token.Line
                        );
                }

                if (third_token.IsNumberOrSymbol())
                {
                    return new ANL_Instruction(
                        second_token.ToPrefixStructure(),
                        third_token.ToPrefixStructure(),
                        1,
                        2,
                        second_token.Line
                        );
                }


                if (third_token.Kind == TokenKind.TOKEN_SEP_ARE)
                {
                    var token_Ri = lexer.NextTokenOfRi();
                    return new ANL_Instruction(
                        second_token.ToPrefixStructure(),
                        token_Ri.ToPrefixStructure(third_token),
                        2,
                        1,
                        second_token.Line
                        );
                }

                if (third_token.Kind == TokenKind.TOKEN_OP_LEN) //#
                {
                    var data = lexer.NextTokenOfNumberOrSymbol();
                 
                    return new ANL_Instruction(
                        second_token.ToPrefixStructure(),
                        data.ToPrefixStructure(third_token),
                        3,
                        2,
                        second_token.Line
                        );
                }

               throw  ThrowHelper.UnexpectedToken(third_token);

            }

            if (second_token.IsNumberOrSymbol())
            {
                var third_token = lexer.NextToken();
                if(third_token.Kind==TokenKind.REG_A)
                {
                    return new ANL_Instruction(
                      second_token.ToPrefixStructure(),
                      third_token.ToPrefixStructure(),
                      4,
                      2,
                      lexer.Line
                      );
                }

                if (third_token.Kind == TokenKind.TOKEN_OP_LEN)//#
                {
                    var data_token = lexer.NextTokenOfNumberOrSymbol();
                    return new ANL_Instruction(
                      second_token.ToPrefixStructure(),
                      data_token.ToPrefixStructure(third_token),
                      5,
                      3,
                      lexer.Line
                      );
                }

                throw ThrowHelper.UnexpectedToken(third_token);

            }


            if(second_token.Kind==TokenKind.REG_C)
            {
                lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
                var third_token = lexer.NextToken();
                if(third_token.IsNumberOrSymbol())
                {
                    if (lexer.LookAhead().Kind != TokenKind.TOKEN_SEP_DOT)
                    {
                        return new ANL_Instruction(
                                second_token.ToPrefixStructure(),
                                third_token.ToPrefixStructure(),
                                6,
                                2,
                                lexer.Line);
                    }
                    lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_DOT);
                    var bit_offset = lexer.NextBitTokenOfValue();

                    return new ANL_Instruction(
                                                  second_token.ToPrefixStructure(),
                                                  third_token.ToPrefixStructure(),
                                                  7,
                                                  2,
                                                  lexer.Line,
                                                  bit_offset);
                }

                if(third_token.Kind==TokenKind.TOKEN_SEP_SLASH)
                {
                    var symbol_token = lexer.NextTokenOfNumberOrSymbol();
                    if (lexer.LookAhead().Kind != TokenKind.TOKEN_SEP_DOT)
                    {
                        return new ANL_Instruction(
                                second_token.ToPrefixStructure(),
                                symbol_token.ToPrefixStructure(third_token),
                                8,
                                2,
                                lexer.Line);
                    }
                    lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_DOT);
                    var bit_offset = lexer.NextBitTokenOfValue();

                    return new ANL_Instruction(
                                                  second_token.ToPrefixStructure(),
                                                  symbol_token.ToPrefixStructure(third_token),
                                                  9,
                                                  2,
                                                  lexer.Line,
                                                  bit_offset);
                }

                throw ThrowHelper.UnexpectedToken(third_token);

            }
            throw ThrowHelper.UnexpectedToken(second_token);
        }

        #endregion
        #region MATH_OP

        private Instruction ParseOp_DA()
        {
            var end_token = lexer.NextTokenOfKind(TokenKind.REG_A);
            return new DA_Instruction(end_token.Line);
        }

        private Instruction ParseOp_DIV()
        {
            var end_token = lexer.NextTokenOfKind(TokenKind.REG_AB);
            return new DIV_Instruction(end_token.Line);
        }

        private Instruction ParseOp_MUL()
        {
            var end_token = lexer.NextTokenOfKind(TokenKind.REG_AB);
            return new MUL_Instruction(end_token.Line);
        }

        private Instruction ParseOp_DEC()
        {
            var end_token = lexer.NextToken();



            if (end_token.Kind == TokenKind.REG_A)
            {

                return new DEC_Instruction(end_token.ToPrefixStructure(), 0,1, lexer.Line);
            }

            if (end_token.IsReg_Rn())
            {
                return new DEC_Instruction(end_token.ToPrefixStructure(), 1,1, lexer.Line);
            }
            if (end_token.IsNumberOrSymbol())
            {
                return new DEC_Instruction(end_token.ToPrefixStructure(), 2,2, lexer.Line);
            }

            if (end_token.Kind == TokenKind.TOKEN_SEP_ARE) //@
            {
                var reg_Ri_token = lexer.NextTokenOfRi();
                return new DEC_Instruction(reg_Ri_token.ToPrefixStructure(end_token), 3,1, lexer.Line);
            }
         


            throw ThrowHelper.UnexpectedToken(end_token);

        }


        private Instruction ParseOp_INC()
        {
            var end_token = lexer.NextToken();

         

            if (end_token.Kind == TokenKind.REG_A) 
            {
                
                return new INC_Instruction(end_token.ToPrefixStructure(), 0,1, lexer.Line);
            }

            if (end_token.IsReg_Rn())
            {
                return new INC_Instruction(end_token.ToPrefixStructure(), 1,1, lexer.Line);
            }
            if(end_token.IsNumberOrSymbol())
            {
                return new INC_Instruction(end_token.ToPrefixStructure(), 2,2, lexer.Line);
            }

            if (end_token.Kind == TokenKind.TOKEN_SEP_ARE) //@
            {
                var reg_Ri_token = lexer.NextTokenOfRi();
              
                return new INC_Instruction(reg_Ri_token.ToPrefixStructure(end_token), 3,1, lexer.Line);
            }
            if (end_token.Kind == TokenKind.REG_DPTR)
            {

                return new INC_Instruction(end_token.ToPrefixStructure(), 4,1, lexer.Line);
            }


            throw ThrowHelper.UnexpectedToken(end_token);

        }



        private Instruction ParseOp_SUBB()
        {
            var a_reg = lexer.NextTokenOfKind(TokenKind.REG_A);
            var comma = lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
            var end_token = lexer.NextToken();


            if (end_token.IsReg_Rn())
            {
                return new SUBB_Instruction(end_token.ToPrefixStructure(), 0,1, lexer.Line);
            }
            if (end_token.IsNumberOrSymbol())
            {
                return new SUBB_Instruction(end_token.ToPrefixStructure(), 1,2, lexer.Line);
            }
            if (end_token.Kind == TokenKind.TOKEN_SEP_ARE) //@
            {
                var reg_Ri_token = lexer.NextTokenOfRi();
           
                return new SUBB_Instruction(reg_Ri_token.ToPrefixStructure(end_token), 2,1, end_token.Line);
            }


            if (end_token.Kind == TokenKind.TOKEN_OP_LEN) //#
            {
                var data_token = lexer.NextTokenOfNumberOrSymbol();
                return new SUBB_Instruction(data_token.ToPrefixStructure(end_token), 3,2, end_token.Line);
            }

            throw ThrowHelper.UnexpectedToken(end_token);
        }

        private Instruction ParseOp_ADDC()
        {
            var a_reg = lexer.NextTokenOfKind(TokenKind.REG_A);
            var comma = lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
            var end_token = lexer.NextToken();


            if (end_token.IsReg_Rn())
            {
                return new ADDC_Instruction(end_token.ToPrefixStructure(), 0,1, lexer.Line);
            }
            if (end_token.IsNumberOrSymbol())
            {
                return new ADDC_Instruction(end_token.ToPrefixStructure(), 1,2, lexer.Line);
            }
            if (end_token.Kind == TokenKind.TOKEN_SEP_ARE) //@
            {
                var reg_Ri_token = lexer.NextTokenOfRi();
            
                return new ADDC_Instruction(reg_Ri_token.ToPrefixStructure(end_token), 2,1, end_token.Line);
            }


            if (end_token.Kind == TokenKind.TOKEN_OP_LEN) //#
            {
                var data_token = lexer.NextTokenOfNumberOrSymbol();
                return new ADDC_Instruction(data_token.ToPrefixStructure(end_token), 3, 2,end_token.Line);
            }

            throw ThrowHelper.UnexpectedToken(end_token);
        }

        private Instruction ParseOp_ADD()
        {
            var a_reg = lexer.NextTokenOfKind(TokenKind.REG_A);
            var comma = lexer.NextTokenOfKind(TokenKind.TOKEN_SEP_COMMA);
            var end_token = lexer.NextToken();


            if(end_token.IsReg_Rn())
            {
                return new ADD_Instruction(end_token.ToPrefixStructure(), 0,1, lexer.Line);
            }
            if (end_token.IsNumberOrSymbol())
            {
                return new ADD_Instruction(end_token.ToPrefixStructure(), 1,2, lexer.Line);
            }
            if (end_token.Kind == TokenKind.TOKEN_SEP_ARE) //@
            {
                var reg_Ri_token = lexer.NextTokenOfRi();

                return new ADD_Instruction(reg_Ri_token.ToPrefixStructure(end_token), 2,1, end_token.Line);
            }


            if (end_token.Kind == TokenKind.TOKEN_OP_LEN) //#
            {
                var data_token = lexer.NextTokenOfNumberOrSymbol();
                return new ADD_Instruction(data_token.ToPrefixStructure(end_token), 3,2, end_token.Line);
            }

            throw ThrowHelper.UnexpectedToken(end_token);
        }



        #endregion //MATH OP 算数运算指令

    }
}
