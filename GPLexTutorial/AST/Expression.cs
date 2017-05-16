namespace GPLexTutorial.AST
{
    public abstract class Expression : Node
    {
        public Type type;
        public abstract void GenCode(string output);
        public abstract void GenStoreCode(string output);
    }
}