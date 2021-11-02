CROSS_PATH = nds32le-elf-
CC = $(CROSS_PATH)gcc
LDFLAGS = -mvh -mcmodel=medium -mcpu=n801
LDFLAGS += -lm -Tnds32.ld
CFLAGS = -c -g -mcpu=n801
SRCS = main.c sidelength.c area_cal.c
OBJS += $(SRCS:.c=.o)

RightTriangle.adx: $(OBJS)
	$(CC) $(OBJS) -o RightTriangle.adx $(LDFLAGS)
.c.o:
	$(CC) $(CFLAGS) $< -o $@
	
depend:$(SRCS)
	$(CC) -M $^ -o $@

-include depend
	
.PHONEY:clean
clean:
	rm *.o *.adx 
	
	

	
	