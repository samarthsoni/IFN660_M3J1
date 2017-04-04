namespace GPLexTutorial.AST
{
    public class IntegerLiteralExpression:Expression
    {
        public int Value { get; set; }

        public IntegerLiteralExpression(int val)
        {
            Value = val;
        }
    }
}