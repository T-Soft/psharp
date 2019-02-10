lexer grammar Parser3Lexer;

/*
 * Lexer Rules
 */

//============================================================================== Members
INVOCATION_SUBJECT
    : CF ID
    ;

//METHOD_DECLARATION
//    : AT ID
//    ;

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
//============================================================================== Logical operators
LOGICAL_OPER
	: AND | OR 
	;

BINARY_OPER
	: GT | LT | LEQ | GEQ | NE | EQ
	;

BINARY_STRING_OPER
	: SGT | SLT | SNE | SEQ
	;

//============================================================================== Unary operators

NOT
	: '!'
	;

//============================================================================== Binary operators

AND			
	: '&&'
	;

OR			
	: '||'
	;

GT	
	: '>'
	;

LT		
	: '<'
	;

LEQ		
	: '<='
	;

GEQ		
	: '>='
	;

NE		
	: '!='
	;

EQ		
	: '='
	;

// String logical operations

SNE		
	: 'ne'
	;

SEQ		
	: 'eq'
	;

SGT		
	: 'gt'
	;

SLT		
	: 'lt'
	;

//============================================================================== Identifiers
ID
	: [a-zA-Z_] [a-zA-Z0-9_]*
	;

//============================================================================== Lang symbols
AT
	: '@'
	;
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

//============================================================================== Directives
USE
	: '@USE'
	;
CLASS
	: '@CLASS'
	;
BASE
	: '@BASE'
	;
OPTIONS
	: '@OPTIONS'
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
STATIC
    : 'static'
    ;
LOCALS
    : 'locals'
    ;
DYNAMIC
    : 'dynamic'
    ;
//============================================================================== Brackets
PARENOPEN
	: '('
	;

PARENCLOSE
	: ')'
	;

BRACKETOPEN
	: '['
	;

BRACKETCLOSE
	: ']'
	;

CURLYOPEN
	: '{'
	;

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

//============================================================================== Literals
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
	;

fragment
DIGIT
	: [0-9]
	;
EVAL_BODY
	: ~[()]
	;

//============================================================================== Comments
COMMENTLINE
	: '#' ~[\r\n]+? ('\r'?'\n') -> channel(HIDDEN)
	;

//============================================================================== Skipped NL & WS

//NL
//	: ('\r' | '\n' | '\r\n')     -> channel(HIDDEN)
//	;

WS
	: [ \n\t\r]+ -> skip
	;