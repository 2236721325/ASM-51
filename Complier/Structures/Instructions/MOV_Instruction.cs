using Complier.Helpers;
using System;
using System.Collections.Generic;

namespace Complier.Structures.Instructions
{
    public class MOV_Instruction : Instruction
    {

        public PrefixStructure Second { get; set; }

        public PrefixStructure Third { get; set; }
        public ushort Type;
        public MOV_Instruction(PrefixStructure second, PrefixStructure third, ushort type, int line) : base(line)
        {
            Second = second;
            Third = third;
            Type = type;
        }

        public override Byte[] GetHexCode()
        {
            switch (Type)
            {
                case 0:
                    return new Byte[]
                    {
                        (byte)(0xE8+ Third.InnerToken.GetReg_Rn_index())
                    };

                case 1:
                    return new Byte[]
                    {
                       0xE5,
                       Third.InnerToken.NumberTokenToBytes()[0],
                    };

                case 2:
                    return new Byte[]
                    {
                        (byte)(0xE6+ Third.InnerToken.GetReg_Rn_index())
                    };
                case 3:
                    return new Byte[]
                    {
                       0x74,
                       Third.InnerToken.NumberTokenToBytes()[0],
                    };
                case 4:
                    return new Byte[]
                    {
                       (byte)(0xF8+ Second.InnerToken.GetReg_Rn_index())
                    };

                case 5:
                    return new Byte[]
                    {
                       (byte)(0xA8+ Second.InnerToken.GetReg_Rn_index()),
                       Third.InnerToken.NumberTokenToBytes()[0],
                    };
                case 6:
                    return new Byte[]
                      {
                       (byte)(0x78+ Second.InnerToken.GetReg_Rn_index()),
                       Third.InnerToken.NumberTokenToBytes()[0],
                      };
                case 7:
                    return new Byte[]
                    {
                       0xF5,
                       Second.InnerToken.NumberTokenToBytes()[0],
                    };
                case 8:
                    return new Byte[]
                    {
                       (byte)(0x88+ Third.InnerToken.GetReg_Rn_index()),
                       Second.InnerToken.NumberTokenToBytes()[0],
                    };

                case 9:
                    return new Byte[]
                    {
                        0x85,
                        Third.InnerToken.NumberTokenToBytes()[0],
                        Second.InnerToken.NumberTokenToBytes()[0],
                    };
                case 10:
                    return new Byte[]
                     {
                            0x86,
                            0x87,
                            Second.InnerToken.NumberTokenToBytes()[0],
                     };
                case 11:
                    return new Byte[]
                     {
                            0x75,
                            Second.InnerToken.NumberTokenToBytes()[0],
                            Third.InnerToken.NumberTokenToBytes()[0],
                     };
                case 12:
                    return new Byte[]
                     {
                            0xF6,
                            0xF7,
                     };
                case 13:
                    return new Byte[]
                     {
                            0xA6,
                            0xA7,
                            Third.InnerToken.NumberTokenToBytes()[0],
                     };
                case 14:
                    return new Byte[]
                     {
                            0x76,
                            0x77,
                            Third.InnerToken.NumberTokenToBytes()[0],

                     };
                default:
                    var bytes = new List<Byte>
                    {
                        0x90
                    };
                    bytes.AddRange(Third.InnerToken.NumberTokenToBytes(2));
                    return bytes.ToArray();

            }
        }


        public override string ToString()
        {
            return "{MOV_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}, Type={Type}" + "} }";
        }
    }


}
