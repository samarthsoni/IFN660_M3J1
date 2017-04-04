namespace GPLexTutorial.AST
{
    public class UnannArrayType : UnannReferenceType
    {
        public UnannArrayType(UnannClassOrInterfaceType unannClassOrInterfaceType, Dims dimension) : base(unannClassOrInterfaceType, dimension)
        {
        }
    }
}
