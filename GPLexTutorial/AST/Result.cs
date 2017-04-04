namespace GPLexTutorial.AST
{
    public class Result
    {

    }

    public class UnanntypeResult : Result
    {
        public UnannType UnannType { get; set; }
        public UnanntypeResult(UnannType unannType)
        {
            UnannType = unannType;
        }
    }

    public class VoidResult : Result
    {
        
    }
}