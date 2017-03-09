%namespace GPLexTutorial

digit [0-9]
letter [a-zA-Z]
dot [.]
exponentIndicator [eE]
sign [-+]
signedInteger {sign}?{digit}+
exponentPart {exponentIndicator}{signedInteger}

%%

if                           { return (int)Tokens.IF; }
else                         { return (int)Tokens.ELSE; }
int                          { return (int)Tokens.INT; }
bool                         { return (int)Tokens.BOOL; }

{letter}({letter}|{digit})*  { yylval.name = yytext; return (int)Tokens.IDENT; }
{digit}+	                 { yylval.num = int.Parse(yytext); return (int)Tokens.NUMBER; }
{digit}*{dot}?({digit})*{exponentPart}?[fFdD]?	     { yylval.floatValue =  yytext.EndsWith("f") || yytext.EndsWith("F") || yytext.EndsWith("d") || yytext.EndsWith("D")  ? float.Parse(yytext.Remove(yytext.Length-1)) : float.Parse(yytext); return (int)Tokens.FLOAT; }



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
