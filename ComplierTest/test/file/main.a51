﻿ORG 0000h
AJMP START
FUNC0: 
    MOV 30H,#0
    RET
FUNC1:
    MOV 31H,#1
    RET
FUNC2: 
    MOV 32H,#2
    RET
FUNC3:
    MOV 33H,#3
    RET
FUNCENTER:
    ADD A,ACC 
    MOV DPTR,#FUNCTAB
    JMP @A+DPTR
FUNCTAB:
    AJMP FUNC0
    AJMP FUNC1
    AJMP FUNC2
    AJMP FUNC3
START:
    MOV A,#0
    ACALL FUNCENTER
    MOV A,#1
    ACALL FUNCENTER
    MOV A,#2
    ACALL FUNCENTER
    MOV A,#3
    ACALL FUNCENTER

finish:
    AJMP finish
END
