void setup() {  
  Serial.begin(9600);
  pinMode(2,INPUT_PULLUP);
  pinMode(3,INPUT_PULLUP);
  pinMode(9,OUTPUT);
  pinMode(10,OUTPUT);
  Serial.println("Begin:");
}

void loop() {
  if (digitalRead(2))
    Serial.println("2");
  else if (digitalRead(3))
    Serial.println("3");
  digitalWrite(9,HIGH);
  digitalWrite(10,LOW);
  delay(500);
  digitalWrite(10,HIGH);
  digitalWrite(9,LOW);
  delay(500);
}
