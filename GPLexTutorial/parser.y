%namespace GPLexTutorial

%union
{
    public int num;
    public string name;
    public float floatValue;
    public string stringValue;
    public bool boolValue;
}

%token <num> NUMBER
%token <name> IDENT
%token <floatValue> FLOATLITERAL
%token <stringValue> STRINGLITERAL
%token <boolValue> BOOL
%token EOF ABSTRACT ASSERT BOOLEAN BREAK BYTE CASE CATCH CHAR CLASS CONST CONTINUE DEFAULT DO DOUBLE ELSE ENUM EXTENDS FINAL FINALLY FLOAT FOR IF GOTO IMPLEMENTS IMPORT INSTANCEOF INT INTERFACE LONG NATIVE NEW PACKAGE PRIVATE PROTECTED PUBLIC RETURN SHORT STATIC STRICTFP SUPER SWITCH SYNCHRONIZED THIS THROW THROWS TRANSIENT TRY VOID VOLATILE WHILE IntegerLiteral CharacterLiteral NULL OPERATOR TRUE FALSE 


%left '='
%nonassoc '<'
%left '+'

%%

Program : Statement
        ;

Statement : IF '(' Expression ')' Statement ELSE Statement
          | '{' StatementList '}'
          | Expression ';'
          | Type IDENT ';'
          ;

Type : INT
     | BOOL
     ;

StatementList : StatementList Statement
              | /* empty */
              ;

Expression : NUMBER
           | IDENT
           | Expression '=' Expression
           | Expression '+' Expression
           | Expression '<' Expression
           ;

%%

public Parser(Scanner scanner) : base(scanner)
{
}
