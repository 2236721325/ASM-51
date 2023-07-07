using CliWrap;
using Complier.CodeAnalyzer.Parser;
using Complier.CodeAnalyzer;
using Complier.CodeGenerate;
using Complier.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace ComplierTest.ParseTest
{
    public class CodeGeneratorTest
    {
        protected readonly ITestOutputHelper Output;

        public CodeGeneratorTest(ITestOutputHelper output)
        {
            Output = output;
        }

        [Theory]
        //[InlineData("main")]
        [InlineData("test_bit")]
        public async void TestSingelFile(string file_name)
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test/file");

            string out_file = Path.Combine(dir,file_name+".hex");
            var cmd = Cli.Wrap("ASEMW")
                .WithWorkingDirectory(dir)
                .WithValidation(CommandResultValidation.None)
                .WithArguments(file_name+".a51");

            await cmd.ExecuteAsync();

            var out_content=await File.ReadAllTextAsync(out_file);

            string target_file = Path.Combine(dir, file_name + ".a51");
            var target_code= await File.ReadAllTextAsync(target_file);


            var lexer = new Lexer(target_code, SymbolTableFactory.CreateDefaultTable());

            Parser parser = new Parser(lexer);

            var block = parser.ParseBlock();

            foreach (var item in block.Instructions)
            {
                Output.WriteLine($"[ {item.Address.ToString("X4")} ]  " + item.Instruction.ToString());
            }


            var code_create = new CodeGenerator(block);
            var out_str=code_create.CreateHexFile().WriteToString();



            Assert.Equal(out_content, out_str);



        }
    }
}
