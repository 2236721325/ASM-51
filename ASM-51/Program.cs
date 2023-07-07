using Complier.CodeAnalyzer;
using Complier.CodeAnalyzer.Parser;
using Complier.CodeGenerate;
using Complier.Symbols;
using System.Text.Json;

namespace ASM_51
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                if(args.Length >0)
                {
                    var file_name= args[0];
                    string entryLocation = Environment.CurrentDirectory;
                    Console.WriteLine("Entry Location: " + entryLocation);


                    var path=Path.Combine(entryLocation, file_name);
                    var code = File.ReadAllText(path);
                    var lexer = new Lexer(code, SymbolTableFactory.CreateDefaultTable());

                    Parser parser = new Parser(lexer);

                    var block = parser.ParseBlock();

                    foreach (var item in block.Instructions)
                    {
                        Console.WriteLine($"[ {item.Address.ToString("X4")} ]  " + item.Instruction.ToString());
                    }

                    var code_create = new CodeGenerator(block);

                    var target_path=Path.Combine(entryLocation, file_name+".hex");
                    var hex_file = code_create.CreateHexFile();
                    hex_file.WriteToFile(target_path);
                }
			}
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
            }
        }
      
    }
}