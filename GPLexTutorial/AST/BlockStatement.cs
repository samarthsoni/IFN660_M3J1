using System.Security.AccessControl;

namespace GPLexTutorial.AST
{
    public abstract class Statement
    {

    }

    public class LocalVariableDeclarationStatement : Statement
    {
        public UnannType UnannType { get; set; }
        public VariableDeclaratorId VariableDeclaratorId { get; set; }
        public LocalVariableDeclarationStatement(UnannType unannType, VariableDeclaratorId variableDeclaratorId)
        {
            UnannType = unannType;
            VariableDeclaratorId = variableDeclaratorId;
        }
    }

    public class ExpressionStatement : Statement
    {
        public Assignment Assignment { get; set; }
        public ExpressionStatement(Assignment assignment)
        {
            Assignment = assignment;
        }
    }
}