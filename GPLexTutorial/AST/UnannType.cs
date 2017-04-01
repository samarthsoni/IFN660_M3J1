namespace GPLexTutorial.AST
{
    public class UnannType
    {
    }

    public class UnannReferenceType : UnannType
    {
        public UnannClassOrInterfaceType UnannClassOrInterfaceType { get; set; }
        public Dims Dims { get; set; }
    }

    public class UnnanPrimitiveType : UnannType
    {
        public IntegralType IntegralType { get; set; }
    }

    public enum IntegralType
    {
        INT,
        BYTE,
        SHORT,
        LONG,
        CHAR
    }
}