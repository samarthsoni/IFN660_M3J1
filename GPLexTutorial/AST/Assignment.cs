namespace GPLexTutorial.AST
{
    public class Assignment
    {
        public LeftHandSide LeftHandSide { get; set; }

        public char AssignmentOperator { get; set; }
        public Expression Expression { get; set; }

        public Assignment()
        {
            
        }
    }
}