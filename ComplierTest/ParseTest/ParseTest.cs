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
ORG 0000h
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
            var lexer = new Lexer(code);

            var parser = new Parser(lexer);

            
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
            var lexer = new Lexer(code);

            var parser = new Parser(lexer);


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

    }
    }

