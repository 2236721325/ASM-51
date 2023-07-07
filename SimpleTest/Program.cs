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
            var code = File.ReadAllText("C:\\Users\\wyh\\Desktop\\hello\\main.a51");

            var lexer = new Lexer(code, SymbolTableFactory.CreateDefaultTable());

            Parser parser = new Parser(lexer);

            var block = parser.ParseBlock();

            foreach (var item in block.Instructions)
            {
                Console.WriteLine($"[ {item.Address.ToString("X4")} ]  " + item.Instruction.ToString());
            }


            var code_create = new CodeGenerator(block);
            var hexFIle=code_create.CreateHexFile();
            hexFIle.WriteToFile("C:\\Users\\wyh\\Desktop\\hello\\test.hex");
            
        }
    }
}