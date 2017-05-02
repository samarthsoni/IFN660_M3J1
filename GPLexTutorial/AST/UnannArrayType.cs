using System;

namespace GPLexTutorial.AST
{
    public class UnannArrayType : Type, IDeclaration
    {
        public Type NameType { get; set; }
        public Dims Dims { get; set; }
        public UnannArrayType(Type nameType, Dims dimension)
        {
            NameType = nameType;
            Dims = dimension;
        }

        public string GetName()
        {
            if (Dims is IDeclaration)
                return ((IDeclaration) Dims).GetName();
            else
                return null;
        }

        public override void ResolveNames(LexicalScope ls)
        {
            throw new NotImplementedException();
        }

        public Type GetDeclarationType()
        {
            return NameType;

        }
    }
}
