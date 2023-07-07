ORG 0000H
AJMP MAIN
ORG 000BH
AJMP T0IT
ORG 0200H
 
;初始化函数
INIT:
 
	MOV TMOD, #01H	   ;选择模式1，不使用门控位
	MOV TL0,#0AFH	   ;装载初值
	MOV TH0,#3CH
	SETB EA			   ;打开中断总开关
	SETB ET0		   ;打开中断分开关
	SETB TR0   ;开启定时器
	MOV R2,#20
	MOV R3,#0FEH
	RET
 
MAIN:
	   ACALL INIT		   ;调用初始化函数
S:	   MOV A,R3			   
	   MOV P2,A			   ;IO口输出
 
	  AJMP S
 
 
 
 
;中断服务函数
T0IT:
 	MOV TL0,#0AFH ;重装载初值（模式1下进入中断函数后一定要重装载）
	MOV TH0,#3CH
	DEC R2		   ;让R2自减1，
	MOV A,R2	   ; 
	JZ ONE	  		;到零时说明已经产生了20次的50ms中断	,即1s
	LJMP CHU		;如果没到1s直接跳出中断，不执行下面的程序
ONE:
	MOV R2,#20			;重新赋值R2
	CLR A
	MOV A,R3
	CPL	A				;取反指令，
	MOV R3,A            ;实现R3数据的翻转，在主函数中实现LED的闪烁
	CLR A
 
	LJMP CHU
							
										
CHU: 	RETI 
 
 
END
