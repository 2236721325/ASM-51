using Complier.Exceptions;
using Complier.Structures.Directives;
using Complier.Structures.Instructions;
using Complier.Symbols;
using System;
using System.Collections.Generic;
using System.Text;

namespace Complier.CodeAnalyzer.Parser
{
    public partial class Parser
    {
        private Directive ParseDirective()
        {
            var token = lexer.NextToken();
            switch (token.Kind)
            {
                case TokenKind.Identifier:
                    if (lexer.LookAhead().Kind == TokenKind.TOKEN_SEP_COLON) //:
                    {
                        lexer.NextToken();

                        lexer.SymbolTable.AddNewSymbol(token, currentAddress, SymbolType.LABEL);
                        return new Label_Directive(token, token.Line);
                    }
                    if(lexer.LookAhead().Kind==TokenKind.Directive_EQU)
                    {
                        lexer.NextToken();
                        var value=lexer.NextTokenOfKind(TokenKind.Number);
                        lexer.SymbolTable.AddNewSymbol(token, value, SymbolType.CONST);
                        return new EQU_Directive(token, value, lexer.Line);
                    }
                    throw new SyntaxException($"Unexpected -> {token.Value} !", token.Line);
                case TokenKind.Directive_ORG:
                    var address_token = lexer.NextTokenOfKind(TokenKind.Number);
                    currentAddress = address_token.NumberTokenToInt();
                    return new Org_Directive(address_token, token.Line);
                case TokenKind.Directive_END:
                    return new End_Directive(token.Line);
                case TokenKind.Directive_DB:
                    var db= ParseDirective_DB();
                    currentAddress += db.GetHexCode().Length;
                    return db;

            }
            throw new SyntaxException($"Unexpected -> {token.Value} !", token.Line);

        }

        private Directive ParseDirective_DB()
        {
            var number_tokens = new List<Token>();
            number_tokens.Add(lexer.NextTokenOfKind(TokenKind.Number));
            while (true)
            {
                var next_token = lexer.LookAhead();
                if(next_token.Kind==TokenKind.TOKEN_SEP_COMMA)
                {
                    lexer.NextToken();
                    number_tokens.Add(lexer.NextTokenOfKind(TokenKind.Number));
                }
                else
                {
                    break;
                }
            }

            return new DB_Directive(number_tokens, lexer.Line);
        }

        
    }

}
