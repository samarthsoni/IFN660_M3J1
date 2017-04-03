namespace GPLexTutorial.AST
{
    public class IntegerLiteral:Expression
    {
        public int Value { get; set; }

        public IntegerLiteral(int val)
        {
            Value = val;
        }
    }
}