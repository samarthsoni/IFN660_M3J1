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
%token EOF ABSTRACT ASSERT BOOLEAN BREAK BYTE CASE CATCH CHAR CLASS CONST CONTINUE DEFAULT DO DOUBLE ELSE ENUM EXTENDS FINAL FINALLY FLOAT FOR IF GOTO IMPLEMENTS IMPORT INSTANCEOF INT INTERFACE LONG NATIVE NEW PACKAGE PRIVATE PROTECTED PUBLIC RETURN SHORT STATIC STRICTFP SUPER SWITCH SYNCHRONIZED THIS THROW THROWS TRANSIENT TRY VOID VOLATILE WHILE IntegerLiteral CharacterLiteral NULL OPERATOR TRUE FALSE EndOfLineComment TraditionalComment


%left '='
%nonassoc '<'
%left '+'

%%



CompilationUnit : 
	ImportDeclarations TypeDeclarations;

ImportDeclarations :	
		ImportDeclaration
	|	ImportDeclaration ImportDeclarations
	|	/* empty */;

ImportDeclaration:		
	SingleTypeImportDeclaration ;

TypeDeclarations:		
		TypeDeclaration
	|	TypeDeclaration TypeDeclarations
	|	/* empty */;

TypeDeclaration:		
		ClassDeclaration 
	|	InterfaceDeclaration;

ClassDeclaration:		
		NormalClassDeclaration 
	|	EnumDeclaration;

NormalClassDeclaration: 
	ClassModifiers CLASS IDENT '{' ClassBody '}';

ClassModifiers:			
		ClassModifier
	|	ClassModifier ClassModifiers
	|	/* empty */;

ClassModifier:		
		PUBLIC 
	|	PROTECTED 
	|	PRIVATE
	|	ABSTRACT
	|	STATIC
	|	FINAL;

ClassBody:
	/* empty */;


EnumDeclaration : 
	ClassModifiers ENUM IDENT Superinderfaces EnumBody;
Superinderfaces:	
	/* empty */;
EnumBody:			
	/* empty */;

InterfaceDeclaration : 
	InterfaceModifiers INTERFACE TypeParameters ExtendsInterfaces InterfaceBody;

TypeParameters : 
	/* empty */;

ExtendsInterfaces:
	/* empty */;

InterfaceBody:
	/* empty */;

InterfaceModifiers :	
		InterfaceModifier
	|	InterfaceModifier InterfaceModifiers
	|	/* empty */;

InterfaceModifier:		
		PUBLIC 
	|	PROTECTED 
	|	PRIVATE
	|	ABSTRACT
	|	STATIC;

SingleTypeImportDeclaration : 
	IMPORT TypeName ';' ;

TypeName:	
		IDENT
	|	PackageOrTypeName '.' IDENT ;

PackageOrTypeName:		
		IDENT 
	|	PackageOrTypeName '.' IDENT ;



%%

public Parser(Scanner scanner) : base(scanner)
{
}
