using Complier.CodeAnalyzer;
using System;
using System.Security.Principal;
using System.Text;

namespace Complier.Symbols
{

    public class Symbol
    {
        public string Name { get; set; }

        public int Value { get; set; }
        public SymbolType Type { get; set; }

        public bool canDotBit { get; set; }

        public Symbol(string name, int value, SymbolType type, bool canDotBit=false)
        {
            Name = name;
            Value = value;
            Type = type;
            this.canDotBit = canDotBit;
        }
    }

}
