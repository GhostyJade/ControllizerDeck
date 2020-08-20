#include <MegaDAS_IOExtension.h>
#include <LCDWIKI_GUI.h>
#include <LCDWIKI_SPI.h>

#define DRIVER SSD1283A

const int SH_CP = 13;

const int DS = 11;

const int ST_CP = 3;

const int IN_P = 4;

#define CS 8
#define CD 9 //a0
#define RST 10

IOExtension pushButtons(SH_CP, DS, ST_CP, IN_P);
LCDWIKI_SPI lcd(DRIVER, CS, CD, RST, -1);

String lastButtonsValue = "";

void setup()
{
  Serial.begin(9600);
  lastButtonsValue = readButtons();
  lcd.Init_LCD();
  lcd.Fill_Screen(255, 0, 255);
  //lcd.Fill_Rectangle(0, 0, lcd.Get_Display_Width(), lcd.Get_Display_Height());
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
  String values = "PB:";
  for (int i = lowestButtonID; i < highestButtonID + 1; i++)
  {
    values += pushButtons.DigitalRead(i);
  }
  return values;
}
