#define BTN1 3
#define BTN2 5

#define BAUD_RATE 9600

void setup() {
  pinMode(BTN1, INPUT);
  pinMode(BTN2, INPUT);
  Serial.begin(BAUD_RATE);
}

bool btn1Pressed = false, btn2Pressed = false;

void loop() {
  if(digitalRead(BTN1)){
    if(!btn1Pressed)
      Serial.write("[Btn1] Pressed\n");
    btn1Pressed = true;
  }else {
    if(btn1Pressed){
      btn1Pressed = false;
      Serial.write("[Btn1] Released\n");
    }
  }
  if(digitalRead(BTN2)){
    if(!btn2Pressed)
      Serial.write("[Btn2] Pressed\n");
    btn2Pressed = true;
  }else{
    if(btn2Pressed) {
      btn2Pressed = false;
      Serial.write("[Btn2] Released\n");
    }
  }
}
