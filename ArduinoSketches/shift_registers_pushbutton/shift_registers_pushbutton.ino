#include <MegaDAS_IOExtension.h>

const int SH_CP = 13;

const int DS = 11;

const int ST_CP = 3;

const int IN_P = 4;

IOExtension pushButtons(SH_CP, DS, ST_CP, IN_P);

String lastButtonsValue = "";

void setup()
{
  Serial.begin(9600);
  lastButtonsValue = readButtons();
}

#define lowestButtonID 2
#define highestButtonID 7

void loop()
{
  String currentButtonsValue = readButtons();
  if (!currentButtonsValue.equals(lastButtonsValue))
  {
    Serial.println(currentButtonsValue);
    lastButtonsValue = currentButtonsValue;
  }
}

// Read pushbutton (74HC595) values
String readButtons()
{
  String values = "PB";
  for (int i = lowestButtonID; i < highestButtonID + 1; i++)
  {
    values += pushButtons.DigitalRead(i);
  }
  return values;
}
