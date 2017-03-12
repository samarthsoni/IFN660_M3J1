%namespace GPLexTutorial

digit [0-9]
letter [a-zA-Z]
inputcharacter [^\r\n]
forwardslash [/]
backslash [\\\\]
endlcomment {forwardslash}{forwardslash}
lineterm \r|\n|\r\n
space [ ]
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
