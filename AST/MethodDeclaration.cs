namespace AST
{
    public class MethodDeclaration
    {
        public MethodModifier MethodModifier { get; set; }
        public Result Result { get; set; }
        public MethodDeclarator MethodDeclarator { get; set; }
    }
}