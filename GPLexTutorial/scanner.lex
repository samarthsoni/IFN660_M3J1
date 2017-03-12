%namespace GPLexTutorial

digit [0-9]
letter [a-zA-Z]
inputcharacter [^\r\n]
forwardslash [/]
hexdigit [0-9a-fA-F]
hexdigitandunderscore _{hexdigit}
endlcomment {forwardslash}{forwardslash}
zerox 0x|0X
lineterm \r|\n|\r\n
space [ ]
long [lL]
%%

if                           { return (int)Tokens.IF; }
else                         { return (int)Tokens.ELSE; }
int                          { return (int)Tokens.INT; }
bool                         { return (int)Tokens.BOOL; }

{letter}({letter}|{digit})* { yylval.name = yytext; return (int)Tokens.IDENT; }
{digit}+	    { yylval.num = int.Parse(yytext); return (int)Tokens.NUMBER; }

{endlcomment}({inputcharacter}|{space}+)*{lineterm} {return (int)Tokens.EndOfLineComment; }
{lineterm}  {return (int)Tokens.LineTermination;}
{space}+ {return (int)Tokens.WhiteSpace;} 
{zerox}{hexdigit}{hexdigitandunderscore}*{long} {return (int)Tokens.HexNumeral;}

"="                          { return '='; }
"+"                          { return '+'; }
"<"                          { return '<'; }
"("                          { return '('; }
")"                          { return ')'; }
"{"                          { return '{'; }
"}"                          { return '}'; }
";"                          { return ';'; }

//[ \r\n\t]                    /* skip whitespace */

.                            { 
                                 throw new Exception(
                                     String.Format(
                                         "unexpected character '{0}'", yytext)); 
                             }

%%
