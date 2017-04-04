namespace GPLexTutorial.AST
{
    public class VariableDeclaratorId
    {
        public Identifier Identifier { get; set; }
        public Dims Dims { get; set; }
        public VariableDeclaratorId(Identifier identifier, Dims dims)
        {
            Identifier = identifier;
            Dims = dims;
        }
    }
}