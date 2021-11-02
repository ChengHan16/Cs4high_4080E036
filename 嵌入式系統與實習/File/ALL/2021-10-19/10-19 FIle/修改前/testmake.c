testprint.adx:hello.o printtext.o
	nds32le-elf-gcc hello.o printtext.o -lm -mvh -Tnds32.ld -o testprint.adx
hello.o:hello.c
	nds32le-elf-gcc -c -g hello.c -o
printtext.o:printtext.c
	nds32le-elf-gcc -c -g printtext.c -o printtext.o