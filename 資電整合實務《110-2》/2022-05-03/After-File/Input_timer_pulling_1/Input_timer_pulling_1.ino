void setup() {  
  Serial.begin(9600);
  pinMode(2,INPUT_PULLUP);
  pinMode(3,INPUT_PULLUP);
  pinMode(9,OUTPUT);
  pinMode(10,OUTPUT);
  Serial.println("Begin:");
  Timer_initial();
}

void Timer_initial()
{
  // Timer0
  /*TCCR0A=0x00;
  TCCR0B=0x07;
  TIFR0=0x00;
  TCNT0=0x00;
  //GTCCR=0x80;  */
   
  // Timer1: a 16bit counter
  // Page 170, 
  TCCR1A=0x00;
  // Page 173, f_io/64, f_io=16MHz
  TCCR1B=0x03;
  // Page 175, 
  TCCR1C=0x80;
  // TC1 Interrupt Flag Register, Page 185
  // Set OCFA
  TIFR1=0x02;
  // Clear counter value
  TCNT1=0x0000;

  // Timer/Counter 1 Interrupt Mask Register, Page 184
  // Set OCIEA
  TIMSK1=0x02;
  // Global Interrupt Enable, Page 27
  SREG=0x80;
  //GTCCR=0x00;

  // 1ms 16000000/64/250
  OCR1AH = 0x00; 
  OCR1AL = 0xF4; 
}

int SW_status=0;

ISR(TIMER1_COMPA_vect) 
{
  TCNT1=0x0000;

  //if (digitalRead(2))
  if (digitalRead(2)&&(SW_status!=2))
  {  Serial.println("2"); SW_status=2; }
  //else if (digitalRead(3))
  else if (digitalRead(3)&&(SW_status!=3))
  {  Serial.println("3"); SW_status=3; }
}

void loop() {
  if (SW_status==2)
  {Serial.println(SW_status);
  digitalWrite(9,HIGH);delay(500);
  digitalWrite(9,LOW);delay(500);
  }
  else if (SW_status==3)
  {Serial.println(SW_status);
  digitalWrite(10,HIGH);delay(500);
  digitalWrite(10,LOW);delay(500);
}

}
