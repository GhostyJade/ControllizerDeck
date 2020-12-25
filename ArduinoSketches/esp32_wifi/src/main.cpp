#include <Arduino.h>

#include <WiFi.h>
#include <WiFiUdp.h>

#include <Adafruit_I2CDevice.h>
#include <Adafruit_GFX.h>
#include <Adafruit_SSD1306.h>

char ssid[] = "Jade";
char password[] = "123456789";

char packetBuffer[255];
char replyBuffer[] = "";

WiFiUDP Udp;
unsigned int localPort = 4000;

void setup()
{
  Serial.begin(9600);
  WiFi.begin(ssid, password);
  Serial.print("Connecting");
  while (WiFi.status() != WL_CONNECTED)
  {
    Serial.print(".");
  }
  Serial.println();
  Serial.print("Ip: ");
  Serial.println(WiFi.localIP());
  Udp.begin(localPort);
}

void loop()
{
  //  int packetSize = Udp.parsePacket();
  //  if (packetSize)
  //  {
  IPAddress remote = Udp.remoteIP();
  //  int l = Udp.read(packetBuffer, 255);
  //  if (l > 0)
  //  {
  //   packetBuffer[l] = 0;
  //  }
  //  String s(packetBuffer);
  //  Serial.println(s);

  String reStr = "Test";
  reStr.toCharArray(replyBuffer, 50);
  Udp.beginPacket(/*Udp.remoteIP()*/ "192.168.137.1", 4001);
  Udp.print(reStr);
  Udp.endPacket();
  //  }
}
