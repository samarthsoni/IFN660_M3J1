namespace GPLexTutorial.AST
{
    public class AssignmentExpression
    {
        public IntegerLiteral IntegerLiteral { get; set; }
        public AssignmentExpression(IntegerLiteral integerLiteral)
        {
            IntegerLiteral = integerLiteral;
        }
    }
}