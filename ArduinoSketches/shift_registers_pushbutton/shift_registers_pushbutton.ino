#include <MegaDAS_IOExtension.h>

const int SH_CP = 13;

const int DS = 11;

const int ST_CP = 3;

const int IN_P = 4;

IOExtension myExt(SH_CP, DS, ST_CP, IN_P); // Make instance and named anything you want (in this example the instance is myExt)

void setup()
{
  Serial.begin(9600);
}

void loop()
{
  Serial.println(myExt.DigitalRead(2));
}
