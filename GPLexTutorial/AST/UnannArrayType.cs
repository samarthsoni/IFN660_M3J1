namespace GPLexTutorial.AST
{
    public class UnannArrayType : Type
    {
        Type NameType;
        Dims Dims;
        public UnannArrayType(Type nameType, Dims dimension)
        {
            NameType = nameType;
            Dims = dimension;
        }
    }
}
