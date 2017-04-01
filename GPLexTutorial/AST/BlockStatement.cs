namespace GPLexTutorial.AST
{
    public class BlockStatement
    {

    }

    public class LocalVariableDeclarationStatement : BlockStatement
    {
        public UnannType UnannType { get; set; }
        public VariableDeclaratorId VariableDeclaratorId { get; set; }
    }

    public class VariableDeclaratorId
    {
        public Identifier Identifier { get; set; }
        public Dims Dims { get; set; }
    }


}