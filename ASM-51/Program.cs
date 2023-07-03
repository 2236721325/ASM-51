using Complier.CodeAnalyzer;
using System.Text.Json;

namespace ASM_51
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var code = @"
ORG 0000h
AJMP main
ORG 0003h
AJMP int0_interrupt
ORG 0010h
main:
    MOV A,#11111111b
    MOV P1,A
interrupt_init:
    SETB EA
    SETB EX0
    SETB IT0
wait:
    AJMP wait
int0_interrupt:
    MOV A, P1
    CPL A
    MOV P1, A
    RETI
END";
                var lexer = new Lexer(code);


            try
            {
                while (true)
                {
                    var token = lexer.NextToken();

                    var str = JsonSerializer.Serialize(token);
                    Console.WriteLine(str);


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