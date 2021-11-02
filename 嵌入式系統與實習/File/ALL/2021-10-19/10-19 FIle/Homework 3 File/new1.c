AA = nds32le-elf-gcc
BB = -lm -mvh -Tnds32.ld -o

testprint.adx:hello.o printtxt.o
	$(AA) hello.o printtxt.o $(BB) testprint.adx
hello.o:hello.c
	$(AA) -c -g hello.c -o hello.o
printtxt.o:printtxt.c
	$(AA) -c -g printtxt.c -o printtxt.o