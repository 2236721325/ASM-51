using Complier.CodeAnalyzer;
using System;
using System.Text;

namespace Complier.Symbols
{

    public class Symbol
    {
        public string Name { get; set; }

        public int Value { get; set; }
        SymbolType Type { get; set; }

        public Symbol(string name, int value, SymbolType type)
        {
            Name = name;
            Value = value;
            Type = type;
        }
    }

}
