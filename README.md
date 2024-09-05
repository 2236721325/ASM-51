# ASM-51

## 使用
	 下载  Release 
	解压后 找到 ASM-51
	这是一个命令行工具 可添加环境变量中使用
	目前只有一条命令 
	ASM-51 [file_name]
	会生成 .hex 文件
	目前已经基本可以使用 要做的是去修复未知的bug
 ## 演示视频
 ( https://www.bilibili.com/video/BV1XW4y1f7BQ/?vd_source=f6f56669995eeadc8f4da105c926dfc7 )

## 说明
	因为以后可能想写个虚拟机 所以有些的代码对于纯粹的 汇编->机器码 这个过程是无用的 对于编写虚拟机是有用的。 
## 目前进度 100%
	已完成：
	支持伪指令 EQU, ORG, DB, END  $ 
	支持所有指令  
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


## TODO
		1. 生成 .omf，bin 格式文件
		2.一个虚拟机，用于调试
		3.更多的伪指令
		4.更加灵活的宏定义
		5.一些地方的重构（算了吧）
	

