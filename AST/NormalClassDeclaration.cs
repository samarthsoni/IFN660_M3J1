using System.Collections.Generic;

namespace AST
{
    public class NormalClassDeclaration
    {
        public ClassModifier ClassModifier { get; set; }
        public Identifier Identifier { get; set; }
        public List<ClassMemberDeclaration> ClassMemberDeclaration { get; set; }
    }
}