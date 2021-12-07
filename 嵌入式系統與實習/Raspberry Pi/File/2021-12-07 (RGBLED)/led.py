#!/usr/bin/python3
# -*- coding:utf-8 -*-
#
#
#

from RGBLED import *
from time import sleep

led = RGBLED(11,13,15,mode=1)
i = 0

while True:

    if i == 1 :
        led.setColor(0,0,1,ON=True)
    elif i == 2 :
        led.setColor(0,1,0,ON=True)
    elif i == 3 :
        led.setColor(0,1,1,ON=True)
    elif i == 4 :
        led.setColor(1,0,0,ON=True)
    elif i == 5 :
        led.setColor(1,0,1,ON=True)
    elif i == 6 :
        led.setColor(1,1,0,ON=True)
    elif i == 7 :
        led.setColor(1,1,1,ON=True)
    else :
        led.OFF()
    sleep(0.5)
    i=(i+8+1)%8
