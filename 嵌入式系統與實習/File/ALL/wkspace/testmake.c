testprint.adx:hello.o printtxt.o
	nds32le-elf-gcc hello.o printtxt.o -lm -mvh -Tnds32.ld -o testprint.adx
hello.o:hello.c
	nds32le-elf-gcc -c -g hello.c -o hello.o
printtxt.o:printtxt.c
	nds32le-elf-gcc -c -g printtxt.c -o printtxt.o