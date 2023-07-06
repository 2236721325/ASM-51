using Complier.CodeAnalyzer;
using Complier.CodeAnalyzer.Parser;
using Complier.Structures.Instructions;
using Complier.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Newtonsoft.Json;
using Complier.Symbols;

namespace ComplierTest.ParseTest
{
    public class ParseTest
    {

        protected readonly ITestOutputHelper Output;

        public ParseTest(ITestOutputHelper output)
        {
            Output = output;
        }

        [Fact]
        public void Test_ADD()
        {
            var code = @"
ORG 0030h
add a,#55h
add a,#10000000b
add a,0afh
add a,R0
add a,R1
add a,r7
add a,@r0


addc a,#55h
addc a,#10000000b
addc a,0afh
addc a,R0
addc a,R1
addc a,r7
addc a,@r0

ORG 0090h


add a,#55h
add a,#10000000b
add a,0afh
add a,R0
add a,R1
add a,r7
add a,@r0


addc a,#55h
addc a,#10000000b
addc a,0afh
addc a,R0
addc a,R1
addc a,r7
addc a,@r0
END

";
            var lexer = new Lexer(code, new Default_SymbolTable());

            var parser = new Parser(lexer);

            
            while (true)
            {
                var token = lexer.LookAhead();

                if (token.Kind == TokenKind.EOF)
                {
                    break;
                }
                int line = parser.CurrentAddress;
                Instruction inst = parser.ParseEvery();

                Output.WriteLine($"[ {line.ToString("X2")} ]  "+ inst.ToString());

            }

        }

        [Fact]
        public void Test_Derective()
        {
            var code = @"
ORG 0000h
people EQU 05h

hello:
    db 1,1,1
    mov a,#0fh
END
";
            var lexer = new Lexer(code, new Default_SymbolTable());

            var parser = new Parser(lexer);


            while (true)
            {
                var token = lexer.LookAhead();

                if (token.Kind == TokenKind.EOF)
                {
                    break;
                }
                int line = parser.CurrentAddress;
                Instruction inst = parser.ParseEvery();

                Output.WriteLine($"[ {line.ToString("X4")} ]  " + inst.ToString());

            }

        }
        [Fact]
        public void Test_INC()
        {
            var code = @"
ORG 0000h
inc a
inc r7
inc 0ffh
inc @r0
inc DPTR
END

";
            var lexer = new Lexer(code, new Default_SymbolTable());

            Parser parser = new Parser(lexer);


            while (true)
            {
                var token = lexer.LookAhead();

                if (token.Kind == TokenKind.EOF)
                {
                    break;
                }

                Instruction inst = parser.ParseEvery();

                Output.WriteLine(inst.ToString());

            }

        }


        [Fact]
        public void Test_DEC()
        {
            var code = @"
ORG 0000h
dec a
dec r7
dec 0ffh
dec @r0
END
";
            var lexer = new Lexer(code, new Default_SymbolTable());

            Parser parser = new Parser(lexer);


            while (true)
            {
                var token = lexer.LookAhead();

                if (token.Kind == TokenKind.EOF)
                {
                    break;
                }

                Instruction inst = parser.ParseEvery();

                Output.WriteLine(inst.ToString());

            }

        }



        [Fact]
        public void Test_MOV()
        {
            var code = @"
ORG 0000h
mov a,r1
mov a,r2
mov a,r3
mov a,0feh
mov a,10000000b
mov a,@r0
mov a,@r1
mov a,#05h
mov r1,A
mov r3,#05h
mov r3,05h
mov 05h,A
mov 05h,R1
mov 05h,#05h
mov 05h,05h
mov 05h,@r1
mov @r0,A
mov @r1,#05h
mov @r1,05h
mov DPTR,#0566h

END
";
            var lexer = new Lexer(code, new Default_SymbolTable());

            Parser parser = new Parser(lexer);


            while (true)
            {
                var token = lexer.LookAhead();

                if (token.Kind == TokenKind.EOF)
                {
                    break;
                }

                Instruction inst = parser.ParseEvery();

                Output.WriteLine(inst.ToString());

            }

        }



        [Fact]
        public void Test_Symbol()
        {
            var code = @"
ORG 0000h

mov DPTR , #m_data

mov A,P1



m_data:
    db 1,2

END

";
            var lexer = new Lexer(code, SymbolTableFactory.CreateDefaultTable());

            Parser parser = new Parser(lexer);

            var block=parser.ParseBlock();

            foreach (var item in block.Instructions)
            {
                Output.WriteLine($"[ {item.Address.ToString("X4")} ]  " + item.Instruction.ToString());
            }


          

        }




        [Fact]
        public void Test_JMP()
        {
            var code = @"
ORG 0000h

entry:
    ACALL first
    ACALL init_second
    ACALL second
    AJMP entry


first:
    MOV R0,#01h
    MOV R1,#02h
    MOV R2,#03h
    MOV R3,#01h
    MOV A,R0
    ADD A,R2
    DA A
    MOV R4,A
    MOV A,R1
    ADDC A,R3
    DA A
    MOV R5,A
    RET


init_second:
    MOV DPTR,#0000h
    MOV R0,#1h
    MOV R1,0
    _loop_init:
        MOV A,R0
        MOVX @DPTR,A


        INC R0
        INC R1
        INC DPTR
        CJNE R1, #11h, _loop_init
    RET


second:
    MOV DPTR,#0000h
    MOV R0,#60h
    _loop:
        MOVX A,@DPTR
        MOV @R0,A
        INC R0
        INC DPTR
        CJNE R0, #71h, _loop
    RET




END
";
            var lexer = new Lexer(code, SymbolTableFactory.CreateDefaultTable());

            Parser parser = new Parser(lexer);

            var block = parser.ParseBlock();

            foreach (var item in block.Instructions)
            {
                Output.WriteLine($"[ {item.Address.ToString("X4")} ]  " + item.Instruction.ToString());
            }




        }

    }
}

