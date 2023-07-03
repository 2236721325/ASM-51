using Complier.CodeAnalyzer;
using System.Text.Json;
using Xunit.Abstractions;

namespace ComplierTest.ParseTest
{
    public class LexTest
    {
        protected readonly ITestOutputHelper Output;

        public LexTest(ITestOutputHelper output)
        {
            Output = output;
        }

        [Fact]
        public void TestLexer()
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
END";
            var lexer = new Lexer(code);


            try
            {
                while (true)
                {
                    var token = lexer.NextToken();

                    var str = JsonSerializer.Serialize(token);
                    Output.WriteLine(str);


                    if (token.Kind == TokenKind.EOF)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
    }

