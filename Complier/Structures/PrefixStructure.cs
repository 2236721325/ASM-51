using Complier.CodeAnalyzer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Complier.Structures
{
    //修饰符 /前缀 结构/
    public class PrefixStructure
    {
        public Token InnerToken { get; set; }
        public Token PrefixToken { get; set; }

        public PrefixStructure(Token prefixToken, Token innerToken)
        {
            PrefixToken = prefixToken;
            InnerToken = innerToken;
        }
    }
}
