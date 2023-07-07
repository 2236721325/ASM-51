ORG 0000h
main:
    mov TMOD,#02h 
    MOV TL0,#00h
	MOV TH0,#00h
    SETB TR0
loop:
    JNB TF0,loop
    CLR TF0
    CPL P1.0
    AJMP $
END