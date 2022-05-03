void setup() {
  Serial.begin(9600);
  pinMode(2, INPUT_PULLUP);
  pinMode(3, INPUT_PULLUP);
  pinMode(9, OUTPUT); 
  pinMode(10, OUTPUT); 
  digitalWrite(10,LOW);
  digitalWrite(9,LOW);
  attachInterrupt(digitalPinToInterrupt(2),LimitsensingR,RISING);
  attachInterrupt(digitalPinToInterrupt(3),LimitsensingL,RISING);
}

unsigned int Led_level=200,SW_status=0;


void loop() { 
  digitalWrite(9,HIGH);
  digitalWrite(10,LOW);
  delay(500);
  digitalWrite(10,HIGH);
  digitalWrite(9,LOW);
  delay(500);
}

void LimitsensingR()
{
  if (SW_status!=1)
    Serial.println("Right");
  SW_status=1;  
}

void LimitsensingL()
{  
  if(SW_status!=2)
    Serial.println("Left");
  SW_status=2;
}
