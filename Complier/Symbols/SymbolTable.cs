using Complier.CodeAnalyzer;
using Complier.Exceptions;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Complier.Symbols
{
    public abstract class SymbolTable
    {
        public List<Symbol> Symbols { get; set; }
        public void AddNewSymbol(string name, int value, SymbolType type)
        {
            Symbols.Add(new Symbol(name, value, type));
        }

        public void AddNewSymbol(Token token,int value,SymbolType type)
        {
            IfContainThrow(token.Value, token.Line);

            Symbols.Add(new Symbol(token.Value, value, type));
        }

        public Symbol FindSymbol(string name)
        {
            return Symbols.Find(e=>e.Name== name);
        }

        public bool Contains(string name)
        {
            return Symbols.Exists(e => e.Name == name);
        }

        public void IfContainThrow(string name, int line)
        {
            if (Contains(name))
            {
                throw ThrowHelper.NameConflict(name, line);
            }
        }



    }

}
