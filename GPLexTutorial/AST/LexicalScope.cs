using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    class LexicalScope
    {
        LexicalScope parentScope;
        Dictionary<string, IDeclaration> symbolTable;

        public LexicalScope()
        {
            parentScope = null;
            symbolTable.Clear();
        }

        public IDeclaration ResolveHere(string symbol)
        {
            if(symbolTable.ContainsKey(symbol))
            {
                return symbolTable[symbol];
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
