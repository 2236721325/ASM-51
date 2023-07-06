using Complier.Structures.Instructions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Complier.Structures
{
    //一页代码
    public class Block  
    {
        public IEnumerable<InstructionWrap> Instructions { get; set; }

        public Block(IEnumerable<InstructionWrap> instructions)
        {
            Instructions = instructions;
        }
    }
}
