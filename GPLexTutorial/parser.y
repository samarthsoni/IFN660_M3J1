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
	public Identifier id;
	public Statement stmt;
	public AST.Type t;
	public List<AST.Type> ts;
	public List<Statement> stmts;
	public List<Identifier> ids;
	public List<Expression> es;
	public MemberDeclaration memberDeclaration;
	public List<MemberDeclaration> memberDeclarations;
	public MethodModifier methodModifier;
	public List<MethodModifier> methodModifiers;
	public ClassModifier classModifier;
	public List<ClassModifier> classModifiers;
	public TypeDeclaration typeDeclaration;
	public List<TypeDeclaration> typeDeclarations;
	public Node node;
	public MethodHeader methodHeader;
}

%token <num> NUMBER
%token <name> IDENT
%token <num> IntegerLiteral
%token <floatValue> FLOATLITERAL
%token <stringValue> STRINGLITERAL
%token <boolValue> BOOLEANLITERAL
%token EOF ABSTRACT ASSERT BOOLEAN BREAK BYTE CASE CATCH CHAR CLASS CONST CONTINUE DEFAULT DO DOUBLE ELSE ENUM EXTENDS FINAL FINALLY FLOAT FOR IF GOTO IMPLEMENTS IMPORT INSTANCEOF INT INTERFACE LONG NATIVE NEW PACKAGE PRIVATE PROTECTED PUBLIC RETURN SHORT STATIC STRICTFP SUPER SWITCH SYNCHRONIZED THIS THROW THROWS TRANSIENT TRY VOID VOLATILE WHILE CharacterLiteral NULL OPERATOR TRUE FALSE EndOfLineComment TraditionalComment ELIPSIS

%type <e> Expression Literal PrimaryNoNewArray Primary PodtfixExpression UnaryExpressionNotPlusMinus UnaryExpression MultiplicativeExpression AddictiveExpression ShiftExpression RelationalExpression EqualityExpression AndExpression ExclusiveOrExpression InclusiveOrExpression ConditionalAndExpression  ConditionalOrExpression ConditionalExpression AssignmentExpression Expression ExpressionName LeftHandSide Assignment VariableDeclaratorList  VariableDeclaratorId VariableDeclarator
%type <e> StatementExpression ForUpdate
%type <es> VariableDeclaratorList VariableDeclarators 

%type <t> IntegralType NumericType UnannPrimitiveType UnannType Result UnannClassType UnannClassOrInterfaceType UnannArrayType NormalClassDeclaration ClassDeclaration TypeDeclaration FloatingPointType BooleanType
%type <stmt> LocalVariableDeclaration LocalVariableDeclarationStatement BlockStatement Statement ExpressionStatement StatementWithoutTrailingSubstatement FormalParameter LastFormalParameter MethodBody IfThenStatement IfThenElseStatement StatementWithoutTrailingSubstatement StatementNoShortIf WhileStatement ForStatement BasicForStatement ForInit DoStatement EmptyStatement

%type <stmts> BlockStatements Block FormalParameterList FormalParameters
%type <memberDeclaration> MethodDeclaration ClassMemberDeclaration ClassBodyDeclaration
%type <methodModifier> MethodModifier
%type <methodModifiers> MethodModifiers
%type <memberDeclarations> ClassBodyDeclarations ClassBody
%type <classModifier> ClassModifier
%type <classModifiers> ClassModifiers
%type <ts> TypeDeclarations
%type <node> CompilationUnit  MethodDeclarator
%type <methodHeader> MethodHeader

%left '='
%nonassoc '<'
%left '+'

%%


CompilationUnit : 
	PackageDeclarations ImportDeclarations TypeDeclarations				{ RootNode = new CompilationUnit($3); }
	;

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
		TypeDeclarations TypeDeclaration									{ $$ = $1; $1.Add($2); }
	|	/* empty */															{ $$ = new List<AST.Type>(); }
	;

TypeDeclaration:		
		ClassDeclaration													{ $$ = $1; }
	|	InterfaceDeclaration
	;

ClassDeclaration:		
		NormalClassDeclaration												{$$ = $1;}
	|	EnumDeclaration;

NormalClassDeclaration: 
	ClassModifiers CLASS Identifier TypeParameters Superclasses Superinterfaces ClassBody			{$$ = new NormalClassDeclaration($1,new Identifier($3.name),$7);}
	;

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
	ClassModifier ClassModifiers									{$$ = $2; $2.Add($1);}
	|	/* empty */														{$$ = new List<ClassModifier>();}
	;

ClassModifier:		
		PUBLIC															{$$ = ClassModifier.Public		;}
	|	PROTECTED 														{$$ = ClassModifier.Protected 	;}
	|	PRIVATE															{$$ = ClassModifier.Private		;}
	|	ABSTRACT														{$$ = ClassModifier.Abstract	;}
	|	STATIC															{$$ = ClassModifier.Static		;}
	|	FINAL															{$$ = ClassModifier.Final		;}
	;

ClassBody:
	'{' ClassBodyDeclarations '}'										{ $$ = $2; };

ClassBodyDeclarations:	
		ClassBodyDeclarations ClassBodyDeclaration 						{ $$ = $1; $1.Add($2); }
	|	/* empty */														{ $$ = new List<MemberDeclaration>(); }
	;

ClassBodyDeclaration:
		 ClassMemberDeclaration											{ $$ = $1; }
		 ;

ClassMemberDeclaration:
	MethodDeclaration													{ $$ = $1; }
	|	';';

MethodDeclaration :
	MethodModifiers MethodHeader MethodBody								{ $$ = new MethodDeclaration($1,$2,$3); };

MethodHeader 
	:	Result MethodDeclarator Throws									{ $$ = new MethodHeader($1,$2); }
	;

MethodDeclarator
       :Identifier '(' FormalParameterList ')'  Dims					{ $$ = new MethodDeclarator(new Identifier($1.name),$3 ); }
	   ;
Throws
    :	/* empty */;

Result
	: VOID																{$$ = null;}
	;

MethodBody :
	Block  																{$$ = new MethodBody($1);}
	|	';' ;

Block:
	'{' BlockStatements '}'  											{$$ = $2;};

BlockStatements:
	BlockStatements BlockStatement 										{$$ = $1; $1.Add($2); }
	|	/* empty */														{$$ = new List<Statement>();}
	;

BlockStatement:
	LocalVariableDeclarationStatement 									{$$ = $1;}
    | Statement 														{$$ = $1;};

Statement:
    StatementWithoutTrailingSubstatement								{$$ = $1;}
	| LabeledStatement	
	| IfThenStatement													{$$ = $1;}	
	| IfThenElseStatement												{$$ = $1;}	
	| WhileStatement													{$$ = $1;}
	| ForStatement	
	;

LabeledStatement:
	Identifier ':' Statement
	;

WhileStatement:
	WHILE '(' Expression ')' Statement									{$$ = new WhileStatement($3,$5);}							
	;

ForStatement:
	BasicForStatement
	;

BasicForStatement:
	FOR '(' ForInit ';' Expression ';' ForUpdate ')' Statement
	;

ForInit:
	LocalVariableDeclaration
	;

ForUpdate:
	StatementExpressionList
	;

StatementExpressionList:
	StatementExpression ',' StatementExpressionList
	| StatmentExpression
	;

StatmentExpression:
	Assignment
	;

IfThenStatement:
	IF '(' Expression ')' Statement										{$$ = new IfStatement($3,$5,null);}										
	;

IfThenElseStatement:
	IF '(' Expression ')' StatementNoShortIf ELSE Statement				{$$ = new IfStatement($3,$5,$7);}
	;

StatementNoShortIf:
	StatementWithoutTrailingSubstatement								{$$ = $1;}
	;

StatementWithoutTrailingSubstatement:
	Block
    | ExpressionStatement												{$$ = $1;}
	|EmptyStatement														{$$ = $1;}
	|DoStatement														{$$ = $1;}
	;

EmptyStatement:
	';'
	;
	
DoStatement:
	DO Statement WHILE '(' Expression ')' ';'							
	;

ExpressionStatement:				
	StatementExpression ';'												{$$ = new ExpressionStatement($1);}
	;

StatementExpression:
	Assignment															{$$ = $1;}	
	;

Assignment:
	LeftHandSide AssignmentOperator Expression							{$$ = new AssignmentExpression($1, $3);}
	;

LeftHandSide:
	ExpressionName														{$$ = $1;}
	;

ExpressionName:
	Identifier															{$$ = new IdentifierExpression( new Identifier($1.name));}
	;

AssignmentOperator:
	OPERATOR															{$$ = $1;}
	;

Expression:
	AssignmentExpression										{$$ = $1;};
	
AssignmentExpression:
	ConditionalExpression										{$$ = $1;};

ConditionalExpression:
    ConditionalOrExpression										{$$ = $1;};

ConditionalOrExpression:
    ConditionalAndExpression									{$$ = $1;};

ConditionalAndExpression:
    InclusiveOrExpression										{$$ = $1;};

InclusiveOrExpression:
    ExclusiveOrExpression										{$$ = $1;};

ExclusiveOrExpression:
    AndExpression												{$$ = $1;};

AndExpression:
    EqualityExpression											{$$ = $1;};

EqualityExpression:
    RelationalExpression										{$$ = $1;};

RelationalExpression:
    ShiftExpression													{$$ = $1;}
	| RelationalExpression OPERATOR ShiftExpression					{$$ = new BinaryExpression($1,'<',$3);}
	| RelationalExpression '>' ShiftExpression					{$$ = new BinaryExpression($1,'>',$3);}
	;

ShiftExpression:
    AddictiveExpression								{$$ = $1; };

AddictiveExpression:
    MultiplicativeExpression										{$$ = $1; };

MultiplicativeExpression:					
    UnaryExpression												{$$ = $1; };

UnaryExpression:
    UnaryExpressionNotPlusMinus						{$$ = $1; };

UnaryExpressionNotPlusMinus:
    PodtfixExpression							{$$ = $1; };

PodtfixExpression:
    Primary									{$$ = $1; }
	|ExpressionName							{$$ = $1;};

Primary:
    PrimaryNoNewArray				{$$ = $1; };

PrimaryNoNewArray:
    Literal									{$$ = $1; };

Literal:
    IntegerLiteral											{ $$=new IntegerLiteralExpression($1) ;}
	|	STRINGLITERAL										{ $$=new StringLiteralExpression($1) ;}
	|	BOOLEANLITERAL										{ $$=new BooleanLiteralExpression($1) ;}
	|	FLOATLITERAL										{ $$=new FloatingPointLiteralExpression($1) ;}								
	;

ForStatement:
	BasicForStatement										{$$ = $1; }
	;

BasicForStatement:
	FOR '(' ForInit ';' Expression ';' ForUpdate ')' Statement 
	;

ForUpdate:
	StatementExpression									{$$ = $1; }
	;

ForInit:
	LocalVariableDeclarationStatement					{$$ = $1; }
	;
	
LocalVariableDeclarationStatement:
	LocalVariableDeclaration ';' 						{$$ = $1; }
	;

LocalVariableDeclaration:
	VariableModifiers UnannType VariableDeclaratorList	{ $$ = new VariableDeclarationStatement($2,$3,null);};

VariableModifiers:
	/* empty */ ;

UnannType:
	UnannPrimitiveType									{$$ = $1; }
	; 

UnannPrimitiveType:
	NumericType											{$$ = $1; }		
	|	BooleanType											{$$ = $1;}
	;

BooleanType:
	BOOLEAN											{$$ = new NamedType( typeof(bool).Name );}
	;

NumericType:
	IntegralType										{$$ = $1; }
	|	FloatingPointType								{$$ = $1; }
	;

FloatingPointType:
	FLOAT												{$$ = new NamedType( typeof(float).Name );}
	|	DOUBLE											{$$ = new NamedType( typeof(float).Name );}
	;

IntegralType:
	BYTE												{$$ = new NamedType( typeof(int).Name );}
	|	SHORT											{$$ = new NamedType( typeof(int).Name );}
	|	INT												{$$ = new NamedType( typeof(int).Name );}
	|	LONG											{$$ = new NamedType( typeof(int).Name );}
	|	CHAR											{$$ = new NamedType( typeof(int).Name );}
	;

VariableDeclaratorList:
	VariableDeclarator									{$$ = new List<Expression>();$$.Add($1);}					
	| VariableDeclarator VariableDeclarators
	;

VariableDeclarators:
	VariableDeclarators	VariableDeclarator				{$$ = $1; $1.Add($2);}
	|	/* empty */										{$$ = new List<Expression>();}
	;

VariableDeclarator:
	VariableDeclaratorId								{$$ = $1; }
	|VariableDeclaratorId '=' VariableInitializer		
	;


VariableDeclaratorId:
	Identifier											{$$ = new IdentifierExpression( new Identifier($1.name));}
	|Identifier Dims;

Identifier:
	IDENT												
	;

Dims:
	/* empty */ ;

VariableInitializer:
	Expression 
	;

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
	:	MethodModifiers MethodModifier 		{$$ = $1;$1.Add($2);}
	|	/* empty */							{$$ = new List<MethodModifier>();};

MethodModifier:		
		PUBLIC								{$$= MethodModifier.Public;}
	|	PROTECTED							{$$= MethodModifier.Protected;}
	|	PRIVATE								{$$= MethodModifier.Private;}
	|	ABSTRACT							{$$= MethodModifier.Abstract;}
	|	STATIC								{$$= MethodModifier.Static;}
	;

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
		FormalParameters ',' LastFormalParameter				{ $$ = $1; }
	|	LastFormalParameter										{ $$ = new List<Statement>(); $$.Add($1); }
	|	/* empty */												{ $$ = new List<Statement>(); }
	;

LastFormalParameter:
		VariableModifiers UnannType  ELIPSIS VariableDeclaratorId
	|	FormalParameter											{$$ = $1;}
	;

FormalParameters:
	FormalParameters FormalParameter							{$$ = $1;$1.Add($2);}
	| /* empty */												{$$ = new List<Statement>();};

FormalParameter:
	VariableModifiers UnannType VariableDeclaratorId			{$$ = new FormalParameterDeclarationStatement($2,$3);}
	;

VariableModifiers:
	/* empty */;	 

UnannType:
	UnannReferenceType;

UnannReferenceType:
	UnannArrayType;

UnannArrayType:
	UnannClassOrInterfaceType Dims								{$$ = new UnannArrayType($1, null);}
	;

UnannClassOrInterfaceType:
	UnannClassType												{$$ = $1;}	
	;

UnannClassType:
	Identifier TypeArguments									{$$ = new NamedType($1.name);}
	;

TypeArguments:
	/* empty */;

Dims:
	Annotations '[' ']' DimsPost;

DimsPost
	:	Annotations '[' ']' 
	|	Annotations '[' ']' DimsPost
	|	/* empty */;


%%

public Node RootNode { get; set; }

public Parser(Scanner scanner) : base(scanner)
{
}
