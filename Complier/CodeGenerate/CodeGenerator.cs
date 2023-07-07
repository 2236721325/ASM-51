using Complier.Helpers;
using Complier.Structures;
using Complier.Structures.Directives;
using System;
using System.Collections.Generic;
using System.Dynamic;
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


       
        public HexFile CreateHexFile()
        {
            var inst_array=block.Instructions.ToArray();
            var hexRecord_list=new List<HexRecord>();
            var temp_byte_array = new List<byte>();

            int last_start_address = 0;

            bool first_org = true;

            for (int i = 0; i <inst_array.Length; i++)
            {
                var inst = inst_array[i].Instruction;
                if(inst is Org_Directive org)
                {
                    if(first_org)
                    {
                        last_start_address = org.AddressToken.NumberTokenToInt();
                        first_org = false;
                    }
                    else
                    {
                        hexRecord_list.Add(new HexRecord(last_start_address, temp_byte_array.ToArray()));
                        last_start_address = org.AddressToken.NumberTokenToInt();
                        temp_byte_array.Clear();
                    }
                    continue;

                }
                var hex_code = inst.GetHexCode();
                if(hex_code!=null)
                {
                    for (int j = 0; j < hex_code.Length; j++)
                    {
                        temp_byte_array.Add(hex_code[j]);
                        if (temp_byte_array.Count == 16)
                        {
                            
                            hexRecord_list.Add(new HexRecord(last_start_address, temp_byte_array.ToArray()));


                            last_start_address = inst_array[i].Address + j + 1;
                            temp_byte_array.Clear();
                        }
                    }

                }

             
            }
            if(temp_byte_array.Count>0)
            {
                hexRecord_list.Add(new HexRecord(last_start_address, temp_byte_array.ToArray()));
            }
            return new HexFile(hexRecord_list);

           
        }



    }
}
