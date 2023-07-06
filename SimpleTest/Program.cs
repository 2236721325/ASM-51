using Complier.CodeAnalyzer.Parser;
using Complier.CodeAnalyzer;
using Complier.Helpers;
using Complier.Symbols;
using Complier.CodeGenerate;

namespace SimpleTest


{
    internal class Program
    {
        static void Main(string[] args)
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
                Console.WriteLine($"[ {item.Address.ToString("X4")} ]  " + item.Instruction.ToString());
            }


            var code_create = new CodeGenerator(block);
            code_create.CreateHexFile("hello.hex");
            
        }
    }
}