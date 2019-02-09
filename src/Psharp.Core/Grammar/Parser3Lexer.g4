lexer grammar Parser3Lexer;

/*
 * Lexer Rules
 */

//============================================================================== Members
INVOCATION_SUBJECT
    : CF ID
    ;

METHOD_DECLARATION
    : AT ID
    ;

VARIABLE_NAME
    : DOL ID
    ;

HASH_MEMBER
    : DOLDOT ID
    ;

STATIC_MEMBER
    : C ID
    ;

MEMBER
    : DOT ID
    ;

CTOR
    : CC ID
    ;
//============================================================================== Lang symbols
fragment
C
	: ':'
	;
fragment
CC
	: '::'
	;

fragment
CF
	: '^'
	;
fragment
AT
	: '@'
	;
fragment
DOL
	: '$'
	;
fragment
DOLDOT
	: '$.'
	;

DOT
	: '.'
	;

PERCENT
	: '%'
	;

SC
	: ';'
	;

COMMA
	: ','
	;
//============================================================================== Comments
COMMENTLINE	
	: '#' ~[\r\n]+? ('\r'?'\n') -> channel(HIDDEN)
	;
//============================================================================== Language words
WHILE			
	: 'while'
	;
FOR			
	: 'for'
	;
IF
	: 'if'
	;
USE			
	: 'USE'
	;
CLASS			
	: 'CLASS'
	;
BASE			
	: 'BASE'
	;
OPTIONS		
	: 'OPTIONS'
	;
DEF			
	: 'def'
	;
IS			
	: 'is'
	;
IN			
	: 'in'
	;
FILEEXISTS		
	: '-f'
	;
DIRECTORYEXISTS	
	: '-d'
	;
EVAL			
	: 'eval'
	;
// not inplemented in parser yet
SWITCH
		: 'switch'
		;
CASE
		: 'case'
		;
TRY
		: 'try'
		;
REM
		: 'rem'
		;
PROCESS
		: 'process'
		;
CONNECT
		: 'connect'
		;
UNTAINT
		: 'untaint'
		;
TAINT
		: 'taint'
		;
APPLY_TAINT
		: 'apply-taint'
		;

//============================================================================== Brackets
//fragment
PARENOPEN	
	: '('
	;
//fragment
PARENCLOSE	
	: ')'
	;
//fragment
BRACKETOPEN		
	: '['
	;
//fragment
BRACKETCLOSE	
	: ']'
	;
//fragment
CURLYOPEN	
	: '{'
	;
//fragment
CURLYCLOSE	
	: '}'
	;

//============================================================================== Math operations
MATH_OPER
	: PLUS | MINUS | DIV | MUL
	;
fragment
PLUS		
	: '+'
	;
fragment
MINUS		
	: '-'
	;
fragment
DIV		
	: '/'
	;
fragment
MUL		
	: '*'
	;

//============================================================================== Logical operators
NOT	
	: '!'
	;
LOGICAL_OPER
	: AND | OR 
	;
BINARY_OPER
	: GT | LT | LEQ | GEQ | NE | EQ
	;
BINARY_STRING_OPER
	: SGT | SLT | SNE | SEQ
	;

fragment
AND			
	: '&&'
	;
fragment
OR			
	: '||'
	;
fragment
GT	
	: '>'
	;
fragment
LT		
	: '<'
	;
fragment
LEQ		
	: '<='
	;
fragment
GEQ		
	: '>='
	;
fragment
NE		
	: '!='
	;
fragment
EQ		
	: '='
	;
// String logical operations
fragment
SNE		
	: 'ne'
	;
fragment
SEQ		
	: 'eq'
	;
fragment
SGT		
	: 'gt'
	;
fragment
SLT		
	: 'lt'
	;
//============================================================================== Fragments for names & numbers
//fragment
ID
	: [a-zA-Z_] [a-zA-Z0-9_]*
	;

fragment 
DIGIT
	: [0-9]
	;
//============================================================================== Literal values
NUMBER
	: DIGIT+
	| DIGIT+ '.' DIGIT+ 
	;
BOOLVALUE
	: 'true'
	| 'false'
	;
STRING
	: ~[#@$^{}()[\]][a-z]* '\r\n'
	| ~[#@$^{}()[\]][~\]][a-z]* ']'
	//| '[' .? ']'
	;
EVAL_BODY
	: ~[()]
	;
//============================================================================== Skipped NL & WS

NL
	: '\r\n'        -> channel(HIDDEN)
	;
WS
	//:	' ' : channel(HIDDEN)
	: [ \r\t\n]+ 	-> skip
	;