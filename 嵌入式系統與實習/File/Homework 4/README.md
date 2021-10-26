2021-10-19 嵌入式系統與實習
-----------------------
〈完整路徑〉
cygdrive/ D:\NDS_TOOL\nds32le-elf-mculib-v3m\bin

CROSS_PATH = cygdrive/d/NDS_TOOL/nds32le-elf-mculib-v3m/bin/nds32le-elf-gcc
-----------------------
〈auto 變數應用〉
$< 取 mian.o:main.c 的 第一個 .c 檔
$^ 取 target 後的全部

p12 $(SRCS:.c=.o) -> 取代 .c 轉 .o
-----------------------
刪除指令：rm *.o *.adx
檢查時間：ls -la
-----------------------
〈自改1〉
CROSS_PATH = nds32le-elf-
CC = $(CROSS_PATH)gcc
LDFLAGS = -mvh -mcmodel=medium -mcpu=n801
LDFLAGS += -lm -Tnds32.ld
CFLAGS = -c -g -mcpu=n801
#SRCS = main.c sidelength.c area_cal.c
#OBJS += $(SRCS:.c=.o)

RightTriangle.adx: main.o sidelength.o area_cal.o
	$(CC) main.o sidelength.o area_cal.o -o RightTriangle.adx $(LDFLAGS)
main.o:main.c
	$(CC) $(CFLAGS) main.c -o main.o
sidelength.o:sidelength.c
	$(CC) $(CFLAGS) sidelength.c -o sidelength.o
area_cal.o:area_cal.c
	$(CC) $(CFLAGS) area_cal.c -o area_cal.o
-----------------------
〈自改2〉
CROSS_PATH = nds32le-elf-
CC = $(CROSS_PATH)gcc
LDFLAGS = -mvh -mcmodel=medium -mcpu=n801
LDFLAGS += -lm -Tnds32.ld
CFLAGS = -c -g -mcpu=n801
#SRCS = main.c sidelength.c area_cal.c
#OBJS += $(SRCS:.c=.o)

RightTriangle.adx: main.o sidelength.o area_cal.o
	$(CC) main.o sidelength.o area_cal.o -o RightTriangle.adx $(LDFLAGS)
main.o:main.c
	$(CC) $(CFLAGS) main.c -o main.o
sidelength.o:sidelength.c
	$(CC) $(CFLAGS) sidelength.c -o sidelength.o
area_cal.o:area_cal.c
	$(CC) $(CFLAGS) area_cal.c -o area_cal.o
-----------------------
〈使用 Auto 修改完成〉

CROSS_PATH = nds32le-elf-
CC = $(CROSS_PATH)gcc
LDFLAGS = -mvh -mcmodel=medium -mcpu=n801
LDFLAGS += -lm -Tnds32.ld
CFLAGS = -c -g -mcpu=n801
SRCS = main.c sidelength.c area_cal.c
OBJS += $(SRCS:.c=.o)

RightTriangle.adx: $(OBJS)
	$(CC) $(OBJS) -o RightTriangle.adx $(LDFLAGS)
%.o:%.c
	$(CC) $(CFLAGS) $< -o $@
-----------------------
