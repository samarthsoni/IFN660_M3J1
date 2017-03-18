%namespace GPLexTutorial

quote [\"]
stringCharacter [^\"]
%%


{quote}({stringCharacter})*{quote}                             { yylval.stringValue = (yytext); return (int)Tokens.STRINGLITERAL; }



[ \r\n\t]                    /* skip whitespace */

.                            { 
                                 throw new Exception(
                                     String.Format(
                                         "unexpected character '{0}'", yytext)); 
                             }

%%
