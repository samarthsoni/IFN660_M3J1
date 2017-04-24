using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class LexicalScope
    {
        LexicalScope parentScope;
        Dictionary<string, IDeclaration> SymbolTable;

        public LexicalScope(Dictionary<string, IDeclaration> symbolTable, LexicalScope parentLexicalScope)
        {
            parentScope = parentLexicalScope;
            SymbolTable = symbolTable;
        }

        public IDeclaration ResolveHere(string symbol)
        {
            if(SymbolTable.ContainsKey(symbol))
            {
                return SymbolTable[symbol];
            }

            return null;
        }

        public IDeclaration Resolve(string symbol)
        {
            IDeclaration local = ResolveHere(symbol);
            if (local != null)
                return local;
            else if (parentScope != null)
                return parentScope.Resolve(symbol);
            else
                return null;
        }
    }
}
