%{
int lines = 0;
%}

%namespace GPLexTutorial



digit [0-9]
hexDigit [0-9a-fA-F]
letter [a-zA-Z]
dot [.]
exponentIndicator [eE]
sign [-+]
signedInteger {sign}?{digit}+
exponentPart {exponentIndicator}{signedInteger}
quote [\"]
stringCharacter [^\"]
Underscore [_]
NonZeroDigit [1-9]
IntegerTypeSuffix [lL]
OctalDigit [0-7]
inputcharacter [^\r\n]
forwardslash [\/]
hexdigit [0-9a-fA-F]
hexdigitandunderscore _{hexdigit}
zerox 0x|0X
cr [\r]
lf [\n]
space [ ]
SingleCharacter [\\][u]{hexDigit}{4}
zeroToThree [0123]
EscapeSequence [\\]([btnfr\"'\\]|{zeroToThree}{OctalDigit}{2}|{OctalDigit}{2}|{OctalDigit})
%%

abstract        { return (int)Tokens.ABSTRACT; }
assert        { return (int)Tokens.ASSERT; }
boolean        { return (int)Tokens.BOOLEAN; }
break        { return (int)Tokens.BREAK; }
byte        { return (int)Tokens.BYTE; }
case        { return (int)Tokens.CASE; }
catch        { return (int)Tokens.CATCH; }
char        { return (int)Tokens.CHAR; }
class        { return (int)Tokens.CLASS; }
const        { return (int)Tokens.CONST; }
continue        { return (int)Tokens.CONTINUE; }
default        { return (int)Tokens.DEFAULT; }
do        { return (int)Tokens.DO; }
double        { return (int)Tokens.DOUBLE; }
else        { return (int)Tokens.ELSE; }
enum        { return (int)Tokens.ENUM; }
extends        { return (int)Tokens.EXTENDS; }
final        { return (int)Tokens.FINAL; }
finally        { return (int)Tokens.FINALLY; }
float        { return (int)Tokens.FLOAT; }
for        { return (int)Tokens.FOR; }
if        { return (int)Tokens.IF; }
goto        { return (int)Tokens.GOTO; }

implements        { return (int)Tokens.IMPLEMENTS; }
import        { return (int)Tokens.IMPORT; }
instanceof        { return (int)Tokens.INSTANCEOF; }
int        { return (int)Tokens.INT; }
interface        { return (int)Tokens.INTERFACE; }
long        { return (int)Tokens.LONG; }
native        { return (int)Tokens.NATIVE; }
new        { return (int)Tokens.NEW; }
package        { return (int)Tokens.PACKAGE; }
private        { return (int)Tokens.PRIVATE; }
protected        { return (int)Tokens.PROTECTED; }
public        { return (int)Tokens.PUBLIC; }
return        { return (int)Tokens.RETURN; }
short        { return (int)Tokens.SHORT; }
static        { return (int)Tokens.STATIC; }
strictfp        { return (int)Tokens.STRICTFP; }
super        { return (int)Tokens.SUPER; }
switch        { return (int)Tokens.SWITCH; }
synchronized        { return (int)Tokens.SYNCHRONIZED; }
this        { return (int)Tokens.THIS; }
throw        { return (int)Tokens.THROW; }
throws        { return (int)Tokens.THROWS; }
transient        { return (int)Tokens.TRANSIENT; }
try        { return (int)Tokens.TRY; }
void        { return (int)Tokens.VOID; }
volatile        { return (int)Tokens.VOLATILE; }
while        { return (int)Tokens.WHILE; }

true						 { yylval.boolValue = true; return (int)Tokens.BOOLEANLITERAL; }

false						 { yylval.boolValue = false; return (int)Tokens.BOOLEANLITERAL; }

{letter}({letter}|{digit})*  { yylval.name = yytext; return (int)Tokens.IDENT; }
{digit}+{dot}({digit})*{exponentPart}?[fFdD]?	     { yylval.floatValue =  yytext.EndsWith("f") || yytext.EndsWith("F") || yytext.EndsWith("d") || yytext.EndsWith("D")  ? float.Parse(yytext.Remove(yytext.Length-1)) : float.Parse(yytext); return (int)Tokens.FLOATLITERAL; }
{digit}*{dot}({digit})+{exponentPart}?[fFdD]?	     { yylval.floatValue =  yytext.EndsWith("f") || yytext.EndsWith("F") || yytext.EndsWith("d") || yytext.EndsWith("D")  ? float.Parse(yytext.Remove(yytext.Length-1)) : float.Parse(yytext); return (int)Tokens.FLOATLITERAL; }
{quote}({stringCharacter})*{quote}                             { yylval.stringValue = GetStringValue(yytext); return (int)Tokens.STRINGLITERAL; }
([0]|{NonZeroDigit}({Underscore}|{digit})*{digit}){IntegerTypeSuffix}?             {yylval.num = int.Parse(yytext); return (int)Tokens.IntegerLiteral;}
[0]({OctalDigit}|{Underscore})*{OctalDigit}{IntegerTypeSuffix}?             {yylval.name = yytext; return (int)Tokens.IntegerLiteral; }
[']({SingleCharacter}|{EscapeSequence})[']  {yylval.name = yytext; return (int)Tokens.CharacterLiteral; }

{forwardslash}{2}{inputcharacter}*({cr}|{lf}|{cr}{lf}) {return (int)Tokens.EndOfLineComment; }

{forwardslash}[*]([^*]|[*][^\/]|[^\/*][\/][*]|({cr}|{lf}|{cr}{lf}))*[*]{forwardslash}   {return (int)Tokens.TraditionalComment;}
 
{zerox}{hexdigit}{hexdigitandunderscore}*{IntegerTypeSuffix}? {return (int)Tokens.IntegerLiteral;}



"&&"  						 { yylval.name = "&&"; return (int)Tokens.OPERATOR; }

"||" 						 { yylval.name = "||"; return (int)Tokens.OPERATOR; }

"!"  						 { yylval.name = "!"; return (int)Tokens.OPERATOR; }

"="							 { yylval.name = "="; return (int)Tokens.OPERATOR; }

">"							 { yylval.name = ">"; return (int)Tokens.OPERATOR; }

"<"							 { yylval.name = "<"; return (int)Tokens.OPERATOR; }

"~"							 { yylval.name = "~"; return (int)Tokens.OPERATOR; }

"?"							 { yylval.name = "?"; return (int)Tokens.OPERATOR; }

":"							 { yylval.name = ":"; return (int)Tokens.OPERATOR; }

"->"						 { yylval.name = "->"; return (int)Tokens.OPERATOR; }

"=="						 { yylval.name = "=="; return (int)Tokens.OPERATOR; }

">="						 { yylval.name = ">="; return (int)Tokens.OPERATOR; }

"<="						 { yylval.name = "<="; return (int)Tokens.OPERATOR; }

"!="						 { yylval.name = "!="; return (int)Tokens.OPERATOR; }

"++"						{ yylval.name = "++"; return (int)Tokens.OPERATOR; }

"--"						{ yylval.name = "--"; return (int)Tokens.OPERATOR; }

"+"							{ yylval.name = "+"; return (int)Tokens.OPERATOR; }

"-"						    { yylval.name = "-"; return (int)Tokens.OPERATOR; }

"/"						    { yylval.name = "/"; return (int)Tokens.OPERATOR; }

"&"							{ yylval.name = "&"; return (int)Tokens.OPERATOR; }

"|"						    { yylval.name = "|"; return (int)Tokens.OPERATOR; }

"^"						    { yylval.name = "^"; return (int)Tokens.OPERATOR; }

"%"							{ yylval.name = "%"; return (int)Tokens.OPERATOR; }

"<<"						{ yylval.name = "<<"; return (int)Tokens.OPERATOR; }

">>"						{ yylval.name = ">>"; return (int)Tokens.OPERATOR; }

">>>"						{ yylval.name = ">>>"; return (int)Tokens.OPERATOR; }

"+="						{ yylval.name = "+="; return (int)Tokens.OPERATOR; }

"-="						{ yylval.name = "-="; return (int)Tokens.OPERATOR; }

"*="					    { yylval.name = "*="; return (int)Tokens.OPERATOR; }

"/="						{ yylval.name = "/="; return (int)Tokens.OPERATOR; }

"&="						{ yylval.name = "&="; return (int)Tokens.OPERATOR; }

"|="						{ yylval.name = "|="; return (int)Tokens.OPERATOR; }

"^="						{ yylval.name = "^="; return (int)Tokens.OPERATOR; }

"%="						{ yylval.name = "%="; return (int)Tokens.OPERATOR; }

"<<="						{ yylval.name = "<<="; return (int)Tokens.OPERATOR; }

">>="						{ yylval.name = ">>="; return (int)Tokens.OPERATOR; }

">>>="						{ yylval.name = ">>>="; return (int)Tokens.OPERATOR; }


"("                          { return '('; }
")"                          { return ')'; }
"{"                          { return '{'; }
"}"                          { return '}'; }
";"                          { return ';'; }
"."                          { return '.'; }
"*"							 { return '*'; }
","							 { return ','; }
"@"							 { return '@'; }
"["							 { return '['; }
"]"							 { return ']'; }
"..."						 { yylval.name = "..."; return (int)Tokens.ELIPSIS;}

[\n]		{ lines++;    }
[ \t\r]      /* ignore other whitespace */


.                            { 
                                 throw new Exception(
                                     String.Format(
                                         "unexpected character '{0}'", yytext)); 
                             }

%%
public override void yyerror( string format, params object[] args )
{
    System.Console.Error.WriteLine("Error: line {0}, {1}", lines,
        String.Format(format, args));
}
