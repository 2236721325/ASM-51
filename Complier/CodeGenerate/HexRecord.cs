using System;
using System.Text;

namespace Complier.CodeGenerate
{
    public class HexRecord
    {

        public int StartAddress { get; set; }

        public byte[] Bytes { get; set; }
        public HexRecord(int startAddress, byte[] bytes)
        {
            StartAddress = startAddress;
            Bytes = bytes;
        }

    }
}
