#! /usr/bin/python3
# -*- coding:utf-8 -*-
# RGBLED class
# 上課用
# 2019/1/28
#
import RPi.GPIO as GPIO

class RGBLED:

    __COLOR = {"red":4, "green":2, "blue":1, "yellow":6, "cyan":3, "megenta":5, "white":7}

    def __init__(self, redpin, greenpin, bluepin, mode=0):
        self.__redpin = redpin
        self.__greenpin = greenpin
        self.__bluepin = bluepin
        self.__mode = mode

        GPIO.setmode(GPIO.BOARD)
        GPIO.setwarnings(False)
        GPIO.setup(self.__redpin, GPIO.OUT)
        GPIO.setup(self.__greenpin, GPIO.OUT)   
        GPIO.setup(self.__bluepin, GPIO.OUT)
        GPIO.output(self.__redpin, mode)
        GPIO.output(self.__greenpin, mode)
        GPIO.output(self.__bluepin, mode)


    def setColor(self, red=0, green=0, blue=0, color="", ON=False):

        self.OFF()

        if color == "" :
            self.__red = red
            self.__green = green
            self.__blue = blue
        else :
            num = self.__COLOR[color] 
            if num == 1 :
                self.setColor(0,0,1)
            elif num == 2 :
                self.setColor(0,1,0)
            elif num == 3 :
                self.setColor(0,1,1)
            elif num == 4 :
                self.setColor(1,0,0)
            elif num == 5 :
                self.setColor(1,0,1)
            elif num == 6 :
                self.setColor(1,1,0)
            elif num == 7 :
                self.setColor(1,1,1)
            else :
                pass

        if ON : self.ON()

    def ON(self):
        if self.__mode : #檢查是共陰極，還是共陽極
            if self.__red : GPIO.output(self.__redpin, False)
            if self.__green : GPIO.output(self.__greenpin, False)
            if self.__blue : GPIO.output(self.__bluepin, False)
        else :
            if self.__red : GPIO.output(self.__redpin, True)
            if self.__green : GPIO.output(self.__greenpin, True)
            if self.__blue : GPIO.output(self.__bluepin, True)
        pass

    def OFF(self):
        if self.__mode : #檢查是共陰極，還是共陽極
            GPIO.output(self.__redpin, True)
            GPIO.output(self.__greenpin, True)
            GPIO.output(self.__bluepin, True)
        else :
            GPIO.output(self.__redpin, False)
            GPIO.output(self.__greenpin, False)
            GPIO.output(self.__bluepin, False)
        pass

    def help(self):
        '''
共陰極mode=0，預設mode=0，如果是共陽極則需要將mode設定為1，mode=1
led = RGBLED(redpin,greenpin,bluepin,mode)
共陰極設定
led = RGBLED(11,13,15)
共陽極設定
led = RGBLED(11,13,15,mode=1)

RGBLED可以組成"red","green","blue","yellow","cyan","megenta","white"這些顏色。
你可以這樣設定顏色
led.setColor(color="red")
或是
led.setColor(1,0,0)

RGBLED的開啟
led.ON()
或是在設定顏色時開啟
led.setColor(color="blue", ON=True)
RGBLED的關閉
led.OFF()
        '''
        print (self.help.__doc__)

