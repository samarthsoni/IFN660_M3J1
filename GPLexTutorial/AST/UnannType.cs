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

    }
}