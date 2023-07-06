using Complier.Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Complier.CodeGenerate
{
    public class CodeGenerator
    {

        private Block block;

        public CodeGenerator(Block block)
        {
            this.block = block;
        }

        public void CreateHexFile(string file_path)
        {
            var inst_array=block.Instructions.ToArray();
            var hexRecord_list=new List<HexRecord>();
            var temp_byte_array = new List<byte>();

            int last_start_index = 0;

            for (int i = 0; i <inst_array.Length; i++)
            {
                var hex_code = inst_array[i].Instruction.GetHexCode();
                if(hex_code!=null)
                {
                    temp_byte_array.AddRange(hex_code);
                }

                if (temp_byte_array.Count==16)
                {
                    hexRecord_list.Add(new HexRecord(inst_array[last_start_index].Address, temp_byte_array.ToArray()));
                    last_start_index = i+1;
                    temp_byte_array.Clear();
                }
            }
            if(temp_byte_array.Count>0)
            {
                hexRecord_list.Add(new HexRecord(inst_array[last_start_index].Address, temp_byte_array.ToArray()));
            }
            var hex_file=new HexFile(hexRecord_list);

            hex_file.WriteToFile(file_path);
        }
    }
}
