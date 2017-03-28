namespace AST
{
    public class FormalParameter
    {
        public VariableModifier VariableModifier { get; set; }
        public UnannType UnannType { get; set; }
        public Identifier VariableDeclarator { get; set; }
    }
}