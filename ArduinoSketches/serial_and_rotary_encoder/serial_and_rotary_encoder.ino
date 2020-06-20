#define BTN1 12
#define BTN2 13

#define ROTARY_CLK 2
#define ROTARY_DT 3
#define ROTARY_SW 11

#define BAUD_RATE 9600

long encoderValue = 0;

int encoderCLKState;
int lastCLKValue;

void setup()
{
  pinMode(BTN1, INPUT);
  pinMode(BTN2, INPUT);

  pinMode(ROTARY_CLK, INPUT);
  pinMode(ROTARY_DT, INPUT);
  pinMode(ROTARY_SW, INPUT_PULLUP);

  Serial.begin(BAUD_RATE);

  lastCLKValue = digitalRead(ROTARY_CLK);

  attachInterrupt(0, updateEncoder, CHANGE);
  attachInterrupt(1, updateEncoder, CHANGE);
}

bool btn1Pressed = false, btn2Pressed = false, switchBtnPressed = false;

void loop()
{
  //1 pressed, 0 released
  if (digitalRead(BTN1))
  {
    if (!btn1Pressed)
      Serial.write("PB1:1\n");
    btn1Pressed = true;
  }
  else
  {
    if (btn1Pressed)
    {
      btn1Pressed = false;
      Serial.write("PB1:0\n");
    }
  }
  if (digitalRead(BTN2))
  {
    if (!btn2Pressed)
      Serial.write("PB2:1\n");
    btn2Pressed = true;
  }
  else
  {
    if (btn2Pressed)
    {
      btn2Pressed = false;
      Serial.write("PB2:0\n");
    }
  }

  //REB:"Rotary Encoder Button"
  if (!digitalRead(ROTARY_SW))
  {
    if (!switchBtnPressed)
      Serial.write("REB0:1\n");
    switchBtnPressed = true;
  }
  else
  {
    if (switchBtnPressed)
    {
      switchBtnPressed = false;
      Serial.write("REB0:0\n");
    }
  }
}

void updateEncoder()
{
  encoderCLKState = digitalRead(ROTARY_CLK);

  // If last and current state of CLK are different, then pulse occurred
  // React to only 1 state change to avoid double count
  if (encoderCLKState != lastCLKValue && encoderCLKState == 1)
  {

    // If the DT state is different than the CLK state then
    // the encoder is rotating CCW so decrement
    if (digitalRead(ROTARY_DT) != encoderCLKState)
    {
      encoderValue--;
    }
    else
    {
      // Encoder is rotating CW so increment
      encoderValue++;
    }

    Serial.print("RE0:");
    Serial.println(encoderValue);
  }

  // Remember last CLK state
  lastCLKValue = encoderCLKState;
}
