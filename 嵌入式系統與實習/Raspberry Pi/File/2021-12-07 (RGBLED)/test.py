#! /usr/bin/python3
# -*- coding:utf-8 -*-
# test RGBLED 
#
#

from RGBLED import *
from time import sleep

led = RGBLED(11,13,15,mode=1)
led.setColor(1,0,1)
led.ON()
sleep(5)

led.setColor(color="blue")
led.ON()
sleep(5)

led.setColor(color="green")
led.ON()
sleep(5)

led.OFF()
led.setColor(color="red")
led.ON()
sleep(5)
led.OFF()
#led.help()
