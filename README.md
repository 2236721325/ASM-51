# ASM-51

## 说明
	因为以后可能想写个虚拟机 所以有些的代码对于纯粹的 汇编->机器码 这个过程是无用的 对于编写虚拟机是有用的。 
## 目前进度 45%
	已完成：
	支持伪指令 EQU, ORG, DB, END  
	支持指令  
	   ADD
	   ADDC
	   SUBB
	   INC
	   DEC
	   MUL
	   DIV
	   ANL
	   ORL
	   XRL
	   CLR
	   CPL
	   RL
	   RLC
	   RR
	   RRC
	   SWAP
	   MOV
	   MOVC
	   MOVX
	   PUSH
	   POP
	   XCH
	   XCHD
	ToDO:
		1.允许指令和 Symbol 配合使用
		2.完成剩余指令
			//bit 
			CLR
			SETB
			CPL
			ANL
			ORL
			MOV
			//控制转移指令
		    ACALL
			LCALL
			RET
			RETI
			AJMP
			SJMP
			LJMP
			JMP
			JZ
			JNZ
			JC
			JNC
			JB
			JNB
			JBC
			CJNE
			DJNZ
			NOP
		3.生成.hex 格式文件 可直接烧录到单片机
		4.更多的测试 自动化测试 而不是现在的靠我肉眼对比观察生成的指令
		5.一些地方的重构（算了吧）
		6.开摆
		

