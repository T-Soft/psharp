grammar Parser3;

/*
 * Parser Rules
 */

program
	:	useDirective? classDirective? baseDirective? optionsDirective? functionDefinition+ EOF
	;
//============================================================================== DIRECTIVES
useDirective
	:	AT USE ID (NL ID)*
	;
classDirective
	:	AT CLASS ID (NL ID)*
	;
baseDirective
	:	AT BASE ID (NL ID)*
	;
optionsDirective
	:	AT OPTIONS ID (NL ID)*
	;
//============================================================================== FUNCTION DEFINITION
functionDefinition
	:	AT functionName BRACKETOPEN paramsDefinitions? BRACKETCLOSE (BRACKETOPEN variablesDefinitions BRACKETCLOSE)? body
	;

functionName 
	:	ID
	;
paramsDefinitions
	:	ID (SC ID)*
	;
variablesDefinitions
	:	ID (SC ID)*
	;
//============================================================================== BODY
body
	:	(
	    variable
	    | stringAssignment
	    | numericOrBooleanAssignment
	    | evalConstruct
	    | whileCycle
	    | forCycle
	    | functionCall
	    | ifCondition
	    | STRING)+
	;

//============================================================================== VARIABLE
// think about how to implement this : $testClass:testStaticMember.testDynamicMember
// and wheter it should be implemented
variable		
	: 	DOL ID 
	|	DOL ID (DOT (fieldName | variable))*
	|	DOL ID (C (fieldName | variable))*
	;
variableName
	:	ID
	;
fieldName 		
	: 	ID
	;
literal		
	: NUMBER 
	| BOOLVALUE
	| STRING 	
	;
//============================================================================== ASSIGNMENT
stringAssignment
	:	variable BRACKETOPEN assignmentBody BRACKETCLOSE 
	;
numericOrBooleanAssignment
	:	variable PARENOPEN assignmentBody PARENCLOSE
	;

assignmentBody	
	: BOOLVALUE
	|(NUMBER | STRING | functionCall | variable) (MATH_OPER (NUMBER | STRING | functionCall | variable))*
	| 	hashAssignment+
	|
	;

hashAssignment	
	: 	hashKey BRACKETOPEN assignmentBody BRACKETCLOSE
	|	hashKey PARENOPEN assignmentBody PARENCLOSE
	;

hashKey			
	:	DOLDOT ID
	;
//============================================================================== FUNCTION CALL
// think about parsing a multi call such as ^a.b.c[]
functionCall
	:	CF (functionName | staticFunctionName | instatnceFunctionName | constructorFunctionName) BRACKETOPEN params? BRACKETCLOSE
	|	CF (functionName | staticFunctionName | instatnceFunctionName | constructorFunctionName) PARENOPEN params? PARENCLOSE
	;

staticFunctionName
	:	C functionName
	;
instatnceFunctionName
	:	DOT functionName
	;
constructorFunctionName
	:	CC functionName
	;

params			
	: 	param (SC param)*
	;
param
	: 	NUMBER | STRING | functionCall | hashAssignment+
	;
//============================================================================== EVAL
evalConstruct
	:	EVAL PARENOPEN EVAL_BODY PARENCLOSE (BRACKETOPEN formatString BRACKETCLOSE)?
	;
formatString
	: 	PERCENT STRING
	;
//============================================================================== WHILE CYCLE
whileCycle		
	: 	WHILE whileCondition whileBody cycleSeparator?
	;
whileCondition	
	: 	PARENOPEN boolCondition (LOGICAL_OPER boolCondition) PARENCLOSE
	;
whileBody		
	: 	CURLYOPEN body CURLYCLOSE
	;
cycleSeparator	
	: 	BRACKETOPEN body BRACKETCLOSE
	|	CURLYOPEN body CURLYCLOSE
	;

//============================================================================== BOOL CONDITION
boolCondition 	
	: (variable (NOT)? (BINARY_OPER | BINARY_STRING_OPER | IS | IN) (variable | literal)) 
	| functionCall 
	| BOOLVALUE
	| (NOT)? DEF variable
	| FILEEXISTS (variable | STRING)
	| DIRECTORYEXISTS (variable | STRING);

//============================================================================== FOR CYCLE
forCycle		
	: FOR forCounter PARENOPEN forFrom SC forTo PARENCLOSE forBody cycleSeparator?
	;
forCounter		
	: BRACKETOPEN variable BRACKETCLOSE
	;
forFrom		
	: NUMBER 
	| functionCall 
	| variable
	;
forTo	
	: NUMBER 
	| functionCall 
	| variable
	;
forBody		
	: CURLYOPEN body CURLYCLOSE
	;
//============================================================================== IF CONDITION
ifCondition		
	: IF PARENOPEN boolCondition PARENCLOSE ifTrueBranch ifFalseBranch?
	;
ifTrueBranch		
	: CURLYOPEN body CURLYCLOSE
	;
ifFalseBranch	
	: CURLYOPEN body CURLYCLOSE
	;

/*
 * Lexer Rules
 */
//============================================================================== Lang symbols
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

//============================================================================== Symbols
//fragment
SC	        
	: ';'
	;
//fragment
COMMA		
	: ','
	;
//fragment
C		
	: ':'
	;
//fragment
CC		
	: '::'
	;
//fragment
DOT		
	: '.'
	;
//fragment
PERCENT
	: '%'
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
	: [a-zA-Z] [a-zA-Z0-9]*
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