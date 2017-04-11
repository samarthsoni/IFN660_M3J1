namespace GPLexTutorial.AST
{
    public class UnannArrayType : Type
    {
        public Type NameType { get; set; }
        public Dims Dims { get; set; }
        public UnannArrayType(Type nameType, Dims dimension)
        {
            NameType = nameType;
            Dims = dimension;
        }
    }
}
