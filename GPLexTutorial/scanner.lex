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
underscore [_]
nonZeroDigit [1-9]
zero [0]
integerLiteralIndicator [lL]

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


{letter}({letter}|{digit})*  { yylval.name = yytext; return (int)Tokens.IDENT; }
{digit}+	                 { yylval.num = int.Parse(yytext); return (int)Tokens.NUMBER; }
{digit}*{dot}?({digit})*{exponentPart}?[fFdD]?	     { yylval.floatValue =  yytext.EndsWith("f") || yytext.EndsWith("F") || yytext.EndsWith("d") || yytext.EndsWith("D")  ? float.Parse(yytext.Remove(yytext.Length-1)) : float.Parse(yytext); return (int)Tokens.FLOATLITERAL; }
0[xX]{hexDigit}*{dot}                                { yylval.floatValue =  yytext.EndsWith("f") || yytext.EndsWith("F") || yytext.EndsWith("d") || yytext.EndsWith("D")  ? float.Parse(yytext.Remove(yytext.Length-1)) : float.Parse(yytext); return (int)Tokens.FLOATLITERAL; }
{quote}({stringCharacter})*{quote}                             { yylval.stringValue = GetStringValue(yytext); return (int)Tokens.STRINGLITERAL; }
({zero}|{nonZeroDigit}({underscore}|{digit})*{digit}){integerLiteralIndicator}             {yylval.name = yytext; return (int)Tokens.DecimalInteger;}


"="                          { return '='; }
"+"                          { return '+'; }
"<"                          { return '<'; }
"("                          { return '('; }
")"                          { return ')'; }
"{"                          { return '{'; }
"}"                          { return '}'; }
";"                          { return ';'; }

[ \r\n\t]                    /* skip whitespace */

.                            { 
                                 throw new Exception(
                                     String.Format(
                                         "unexpected character '{0}'", yytext)); 
                             }

%%
