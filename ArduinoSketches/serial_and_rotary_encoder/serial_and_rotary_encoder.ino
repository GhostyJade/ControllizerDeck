#define BTN1 12
#define BTN2 13

#define ROTARY_DT 6
#define ROTARY_CLK 7
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

  Serial.begin(BAUD_RATE);

  lastCLKValue = digitalRead(ROTARY_CLK);
}

bool btn1Pressed = false, btn2Pressed = false;

void loop()
{
  if (digitalRead(BTN1))
  {
    if (!btn1Pressed)
      Serial.write("[Btn1] Pressed\n");
    btn1Pressed = true;
  }
  else
  {
    if (btn1Pressed)
    {
      btn1Pressed = false;
      Serial.write("[Btn1] Released\n");
    }
  }
  if (digitalRead(BTN2))
  {
    if (!btn2Pressed)
      Serial.write("[Btn2] Pressed\n");
    btn2Pressed = true;
  }
  else
  {
    if (btn2Pressed)
    {
      btn2Pressed = false;
      Serial.write("[Btn2] Released\n");
    }
  }

  updateEncoder();
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

    Serial.print("Counter: ");
    Serial.println(encoderValue);
  }

  // Remember last CLK state
  lastCLKValue = encoderCLKState;
}
