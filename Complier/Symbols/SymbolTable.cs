using Complier.CodeAnalyzer;
using Complier.Exceptions;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Complier.Symbols
{
    public abstract class SymbolTable
    {
        public List<Symbol> Symbols { get; set; }
        public void AddNewSymbol(string name, int value, SymbolType type,bool can_dot_bit=false)
        {
            Symbols.Add(new Symbol(name, value, type,can_dot_bit));
        }

        public void AddNewSymbol(Token token,int value,SymbolType type,bool can_dot_bit=false)
        {
            IfContainThrow(token.Value, token.Line);

            Symbols.Add(new Symbol(token.Value, value, type,can_dot_bit));
        }

        public void AddNewSymbol(Token name_token, Token value_token, SymbolType type)
        {
            AddNewSymbol(name_token, value_token.NumberTokenToInt(),type);
        }

        public Symbol FindSymbol(string name)
        {
            return Symbols.Find(e=>e.Name== name);
        }
        public Symbol FindSymbol(Token token)
        {
            var ret = FindSymbol(token.Value);
            if(ret==null)
            {
                throw ThrowHelper.UnexpectedToken(token);
            }
            return ret;
        }

        public Symbol FindSymbolOfKind(Token token,SymbolType type)
        {
            Symbol symbol = FindSymbol(token.Value);
            if(symbol.Type!=type)
            {
                throw ThrowHelper.UnexpectedToken(token);
            }
            return symbol;
        }


        public Symbol FindSymbolOfKind(Token token,Predicate<Symbol> predicate)
        {
            Symbol symbol = FindSymbol(token.Value);
            if (symbol == null) throw ThrowHelper.UnexpectedToken(token, "UnNamed Symbol!");
            if (!predicate(symbol))
            {
                throw ThrowHelper.UnexpectedToken(token);
            }
            return symbol;
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
