namespace GPLexTutorial.AST
{
    public class LeftHandSide
    {
        public Identifier Identifier { get; set; }
        public LeftHandSide(Identifier identifier)
        {
            Identifier = identifier;
        }
    }
}