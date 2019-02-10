parser grammar Parser3Parser;

/*
 * Parser Rules
 */

program
	:	useDirective? classDirective? baseDirective? optionsDirective? methodDefinition+ EOF
	;
//============================================================================== DIRECTIVES
useDirective
	:	USE ID+
	;
classDirective
	:	CLASS ID+
	;
baseDirective
	:	BASE ID+
	;
optionsDirective
	:	OPTIONS ID+
	;
//============================================================================== METHOD DEFINITION
methodDefinition
	:	AT ID BRACKETOPEN paramsDefinitions? BRACKETCLOSE (BRACKETOPEN localsDefinitions BRACKETCLOSE)? body
	;

paramsDefinitions
	:	ID (SC ID)*
	;

localsDefinitions
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
	    | methodCall
	    | ifCondition
	    | STRING)+
	;

//============================================================================== VARIABLE
// think about how to implement this : $testClass:testStaticMember.testDynamicMember
// and wheter it should be implemented
variable		
	: 	VARIABLE_NAME (STATIC_MEMBER | MEMBER)*
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
	|(NUMBER | STRING | methodCall | variable) (MATH_OPER (NUMBER | STRING | methodCall | variable))*
	| 	hashAssignment+
	|
	;

hashAssignment	
	: 	HASH_MEMBER BRACKETOPEN assignmentBody BRACKETCLOSE
	|	HASH_MEMBER PARENOPEN assignmentBody PARENCLOSE
	;

//============================================================================== METHOD CALL

methodCall
	:	INVOCATION_SUBJECT (STATIC_MEMBER | MEMBER | CTOR)* BRACKETOPEN params? BRACKETCLOSE
	|	INVOCATION_SUBJECT (STATIC_MEMBER | MEMBER | CTOR)* PARENOPEN params? PARENCLOSE
	;

params			
	: 	param (SC param)*
	;
param
	: 	NUMBER | STRING | ID | methodCall | hashAssignment+
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
	| methodCall 
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
	| methodCall 
	| variable
	;
forTo	
	: NUMBER 
	| methodCall 
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