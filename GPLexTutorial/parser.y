%namespace GPLexTutorial
%using GPLexTutorial.AST

%union
{
    public int num;
    public string name;
    public float floatValue;
    public string stringValue;
    public bool boolValue;
	public Expression e;
}

%token <num> NUMBER
%token <name> IDENT
%token <num> IntegerLiteral
%token <floatValue> FLOATLITERAL
%token <stringValue> STRINGLITERAL
%token <boolValue> BOOL
%token EOF ABSTRACT ASSERT BOOLEAN BREAK BYTE CASE CATCH CHAR CLASS CONST CONTINUE DEFAULT DO DOUBLE ELSE ENUM EXTENDS FINAL FINALLY FLOAT FOR IF GOTO IMPLEMENTS IMPORT INSTANCEOF INT INTERFACE LONG NATIVE NEW PACKAGE PRIVATE PROTECTED PUBLIC RETURN SHORT STATIC STRICTFP SUPER SWITCH SYNCHRONIZED THIS THROW THROWS TRANSIENT TRY VOID VOLATILE WHILE CharacterLiteral NULL OPERATOR TRUE FALSE EndOfLineComment TraditionalComment

%type <e> Literal PrimaryNoNewArray Primary PodtfixExpression UnaryExpressionNotPlusMinus UnaryExpression MultiplicativeExpression AddictiveExpression ShiftExpression RalationalExpression EqualityExpression AndExpression ExclusiveOrExpression InclusiveOrExpression ConditionalAndExpression  ConditionalOrExpression ConditionalExpression AssignmentExpression

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
	ClassModifiers CLASS IDENT TypeParameters Superclasses Superinterfaces ClassBody;

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
	'{' ClassBodyDeclarations '}'
	|	/* empty */;

ClassBodyDeclarations:	
		ClassBodyDeclaration
	|	ClassBodyDeclaration ClassBodyDeclarations	
	|	/* empty */;

ClassBodyDeclaration:
		 ClassMemberDeclaration;

ClassMemberDeclaration:
	MethodDeclaration  
	|	';';

MethodDeclaration :
	MethodModifiers MethodHeader MethodBody;

MethodHeader 
	:	Result MethodDeclarator Throws;

MethodDeclarator
       :Identifier '(' FormalParameterList ')'  Dims;
Throws
    :	/* empty */;

Result
	: VOID;

MethodBody :
	Block
	|	';' ;

Block:
	'{' BlockStatements '}';

BlockStatements:
	BlockStatement BlockStatements
	|BlockStatement ;

BlockStatement:
	LocalVariableDeclarationStatement
    | Statement ;

Statement:
    StatementWithoutTrailingSubstatement ;

StatementWithoutTrailingSubstatement:
    ExpressionStatement;
	
ExpressionStatement:
	StatementExpression ';' ;

StatementExpression:
	Assignment;

Assignment:
	LeftHandSide AssignmentOperator Expression;

LeftHandSide:
	ExpressionName;

ExpressionName:
	Identifier;

AssignmentOperator:
	OPERATOR ;

Expression:
	AssignmentExpression;

AssignmentExpression:
	ConditionalExpression;

ConditionalExpression:
    ConditionalOrExpression;

ConditionalOrExpression:
    ConditionalAndExpression; 

ConditionalAndExpression:
    InclusiveOrExpression;

InclusiveOrExpression:
    ExclusiveOrExpression;

ExclusiveOrExpression:
    AndExpression;

AndExpression:
    EqualityExpression;

EqualityExpression:
    RalationalExpression;

RalationalExpression:
    ShiftExpression;

ShiftExpression:
    AddictiveExpression;

AddictiveExpression:
    MultiplicativeExpression;

MultiplicativeExpression:					
    UnaryExpression;

UnaryExpression:
    UnaryExpressionNotPlusMinus;

UnaryExpressionNotPlusMinus:
    PodtfixExpression;

PodtfixExpression:
    Primary;

Primary:
    PrimaryNoNewArray;

PrimaryNoNewArray:
    Literal;

Literal:
    IntegerLiteral							{ $$=new IntegerLiteral($1) ;}
	;

LocalVariableDeclarationStatement:
	LocalVariableDeclaration ';' ;

LocalVariableDeclaration:
	VariableModifiers UnannType VariableDeclaratorList ;

VariableModifiers:
	/* empty */ ;

UnannType:
	UnannPrimitiveType ; 

UnannPrimitiveType:
	NumericType ;

NumericType:
	IntegralType				{$$ = $1;}
	;

IntegralType:
	BYTE
	|	SHORT
	|	INT						{$$ = $1;}
	|	LONG
	|	CHAR ;

VariableDeclaratorList:
	VariableDeclarator
	| VariableDeclarator VariableDeclarators;

VariableDeclarators:
	/* empty */ ;

VariableDeclarator:
	VariableDeclaratorId
	|VariableDeclaratorId '=' VariableInitializer;

VariableDeclaratorId:
	Identifier
	|Identifier Dims;

Identifier:
	IDENT;

Dims:
	/* empty */ ;

VariableInitializer:
	/* empty */ ;

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

MethodModifiers
	:	MethodModifier
	|	MethodModifier MethodModifiers
	|	/* empty */;

MethodModifier:		
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

FormalParameterList:
		FormalParameters ',' LastFormalParameter
	|	LastFormalParameter;

LastFormalParameter:
	VariableModifiers UnannType VariableDeclaratorId;

FormalParameters:
	FormalParameter
	| FormalParameter FormalParameters;

FormalParameter:
	VariableModifiers UnannType VariableDeclaratorId;

VariableModifiers:
	/* empty */;	 

UnannType:
	UnannReferenceType;

UnannReferenceType:
	UnannArrayType;

UnannArrayType:
	UnannClassOrInterfaceType Dims;

UnannClassOrInterfaceType:
	UnannClassType;

UnannClassType:
	Identifier TypeArguments;

Identifier:
	STRINGLITERAL;

TypeArguments:
	/* empty */;

VariableDeclaratorId:
	Identifier Dims;

Dims:
	Annotations '[' ']' DimsPost;

DimsPost
	:	Annotations '[' ']' 
	|	Annotations '[' ']' DimsPost
	|	/* empty */;


%%

public Parser(Scanner scanner) : base(scanner)
{
}
