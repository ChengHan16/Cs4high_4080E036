// Timer1 Interrupt

unsigned int t1=0,t0=0;

void setup() {
  Serial.begin(9600);
  delay(100);
  // initialize digital pin LED_BUILTIN as an output.
  pinMode(5, OUTPUT);
 
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
  TCCR1A=0x40;
  // Page 173, f_io/1024, f_io=16MHz
  TCCR1B=0x05;
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

  OCR1AH = 0x3D; 
  OCR1AL = 3D09; 
}

//Others:TIMER1_CAPT_vect,TIMER1_COMPB_vect, TIMER1_COMPA_vect,TIMER1_OVF_vect
ISR(TIMER1_COMPA_vect) 
{
  t1=TCNT1;
  TCNT1=0x0000;
  t0++;
  Serial.println(t1-1);
  Serial.println("Bye");  
}

unsigned int a=0,b=0;
// the loop function runs over and over again forever
void loop() {
   digitalWrite(13, HIGH);
   delay(500);
   Serial.println(t0);
   digitalWrite(13, LOW);
   delay(500);
   Serial.println(t0);
}
