namespace GPLexTutorial.AST
{
    public class ClassMemberDeclaration
    {
        public MethodDeclaration MethodDeclaration { get; set; }
        public ClassMemberDeclaration(MethodDeclaration methodDeclaration)
        {
            MethodDeclaration = methodDeclaration;
        }
    }
}