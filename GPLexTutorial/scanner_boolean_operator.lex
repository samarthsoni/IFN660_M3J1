//Basem Alharbi 9837876
true						 { yylval.boolValue = true; return (int)Tokens.BOOLEAN; }

false						 { yylval.boolValue = false; return (int)Tokens.BOOLEAN; }

"&&"  						 { yylval.name = "&&"; return (int)Tokens.OPERATOR; }

"||" 						 { yylval.name = "||"; return (int)Tokens.OPERATOR; }

"!"  						 { yylval.name = "!"; return (int)Tokens.OPERATOR; }
