using System.Security.AccessControl;

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

    public class ExpressionStatement : BlockStatement
    {
        public Assignment Assignment { get; set; }
    }
}