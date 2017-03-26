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
%token EOF ABSTRACT ASSERT BOOLEAN BREAK BYTE CASE CATCH CHAR CLASS CONST CONTINUE DEFAULT DO DOUBLE ELSE ENUM EXTENDS FINAL FINALLY FLOAT FOR IF GOTO IMPLEMENTS IMPORT INSTANCEOF INT INTERFACE LONG NATIVE NEW PACKAGE PRIVATE PROTECTED PUBLIC RETURN SHORT STATIC STRICTFP SUPER SWITCH SYNCHRONIZED THIS THROW THROWS TRANSIENT TRY VOID VOLATILE WHILE IntegerLiteral CharacterLiteral NULL OPERATOR TRUE FALSE EndOfLineComment TraditionalComment SEPARATOR


%left '='
%nonassoc '<'
%left '+'

%%



CompilationUnit : 
	PackageDeclarations ImportDeclarations TypeDeclarations;

PackageDeclarations:
	PackageDeclaration
	|	PackageDeclaration PackageDeclarations
	|	/* empty */;

PackageDeclaration:
	PackageModifiers PACKAGE IDENT ColonSeparatedIdents ';';

PackageModifiers:
	PackageModifier
	|	PackageModifier PackageModifiers
	|	/* empty */;

PackageModifier:
	Annotation;

Annotations:
	Annotation
	|	Annotation Annotations
	|	/* empty */;

Annotation:
	NormalAnnotation 
	|	MarkerAnnotation
	|	SingleElementAnnotation;

ColonSeparatedIdents:
	'.' IDENT
	|	'.' IDENT ColonSeparatedIdents
	|	/* empty */;

NormalAnnotation:
	/* empty */;

MarkerAnnotation:
	/* empty */;

SingleElementAnnotation:
	/* empty */;

ImportDeclarations :	
		ImportDeclaration
	|	ImportDeclaration ImportDeclarations
	|	/* empty */;

ImportDeclaration:		
	SingleTypeImportDeclaration 
	|	TypeImportOnDemandDeclaration
	|	SingleStaticImportDeclaration 
	|	StaticImportOnDemandDeclaration;


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
	ClassModifiers CLASS IDENT TypeParameters Superclasses Superinterfaces '{' ClassBody '}';

Superclasses:
	Superclass
	|	Superclass Superclasses
	|	/* empty */;

Superclass:
	EXTENDS ClassType;

ClassType:
	Annotations IDENT TypeArguments
	| ClassOrInterfaceType '.' Annotations IDENT TypeArguments;

ClassOrInterfaceType:
	ClassType
	|	InterfaceType;

TypeArguments:
	/* empty */;

Superinterfaces:
	IMPLEMENTS InterfaceTypeList
	|	/* empty */;

InterfaceTypeList:
	InterfaceType ComaSeparatedInterfaceTypeList;

ComaSeparatedInterfaceTypeList:
	',' InterfaceType
	|	',' InterfaceType ComaSeparatedInterfaceTypeList
	|	/* empty */;

InterfaceType:
	ClassType;

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
	ClassModifiers ENUM IDENT Superinterfaces EnumBody;
EnumBody:			
	'{' /* empty */ '}';

InterfaceDeclaration : 
	NormalInterfaceDeclaration 
	|	AnnotationTypeDeclaration ;

NormalInterfaceDeclaration:
	InterfaceModifiers INTERFACE IDENT TypeParameters ExtendsInterfaces InterfaceBody;

AnnotationTypeDeclaration:
	InterfaceModifiers '@' INTERFACE IDENT AnnotationTypeBody ;

AnnotationTypeBody:
	'{' /* empty */ '}';

TypeParameters : 
	/* empty */;

ExtendsInterfaces:
	EXTENDS InterfaceTypeList;

InterfaceBody:
	'{' /* empty */ '}';

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

TypeImportOnDemandDeclaration:
	IMPORT PackageOrTypeName '.' '*' ';';

SingleStaticImportDeclaration:
	IMPORT STATIC TypeName ';';

StaticImportOnDemandDeclaration:
	IMPORT STATIC PackageOrTypeName '.' '*' ';';

TypeName:	
		IDENT
	|	PackageOrTypeName '.' IDENT ;

PackageOrTypeName:		
		IDENT 
	|	PackageOrTypeName '.' IDENT ;



BlockStatements:
	BlockStatement
	|	BlockStatement BlockStatements
	|	/* empty */;

BlockStatement : 
	LocalVariableDeclarationStatement ClassDeclaration Statement;

LocalVariableDeclarationStatment:
	LocalVariableDeclaration;

LocalVarialeDeclaration:
	VariableModifier
	|	UnannType
	|	VariableDeclaratorList
	|	/* empty */;

ClassDeclaration:
	NormalClassDeclaration EnumDeclaration;

NormalClassDeclaration:
	ClassModifier;

ClassModifier:
	ClassIdentifier
	|	TypeParameters
	|	Superclass
	|	Superinterfaces
	|	/* empty */;

EnumDeclaration:
	ClassModifier;

ClassModifier:
	EnumIdentifier
	|	Superinterfaces
	|	EnumBody
	|	/* empty */;

Statement:
	StatementWithoutTrailingSubstatement LabeledStatement IfThenElseStatementNoShortIf WhileStatementNoShortIf ForStatementNoShortIf;

StateWithoutTrailingSubstatement:
	Block EmptyStatement ExpressionStatement AssertStatement SwitchStatement Dostatement BreakStatement ContinueStatement ReturnStatement SynchronizedStatement ThrowStatement TryStatement;
	

ExpressionStatement:
	';'SEPARATOR
	|	';'SEPARATOR ColonSeparatedIdents
	|	/* empty */;

ExpressionStatment:
	StatementExpression;

StatementExpression:
	Assignment PreIncrementExpression PreDecrementExpression PostIncrementExpression PostDecrementExpression MethodInvoation ClassInstanceCreationExpression;





%%

public Parser(Scanner scanner) : base(scanner)
{
}
