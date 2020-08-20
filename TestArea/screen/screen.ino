#include <LCDWIKI_GUI.h>
#include <LCDWIKI_SPI.h>
#include "image.h"

#define DRIVER SSD1283A

#define CS 10 // Chip Select SPI pin (Might be called SS) - Wire this to pin 10 on an Arduino Pro Mini
#define CD 12
#define SDA 11
	 // if you use the hardware spi,this pin is no need to set - Wire this to pin 11, MOSI, on a Pro Mini
#define MOSI SDA // An alias
#define MISO 8	 // unused - my SSD1283A is write-only (no read)
#define SCK 13	 //if you use the hardware spi,this pin is no need to set - Wire to pin 13 on a Pro Mini
#define RST 9	 // Reset pin - I use 9 on my Pro Mini
#define LED -1

#define SCREEN_SIZE 130

LCDWIKI_SPI lcd(DRIVER, CS, CD, MISO, MOSI, RST, SCK, LED); // Tell the lib what pins we are using

void setup()
{
	Serial.begin(9600);
	lcd.Init_LCD();
	lcd.Fill_Screen(0x0000);
	lcd.Draw_Bit_Map(0, 0, 40, 40, exported, 1);
}

void loop()
{}
