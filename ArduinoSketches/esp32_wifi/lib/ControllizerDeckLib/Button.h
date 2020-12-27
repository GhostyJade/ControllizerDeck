#ifndef _BUTTON_H_
#define _BUTTON_H_

#include <Arduino.h>
#include <WiFi.h>
#include <WiFiUdp.h>

class Button
{
public:
    Button(byte id, byte pin);
    int is_pressed();
    void sendPacket(WiFiUDP &Udp);
    void sendSerial();

private:
    byte pin, id;
    bool pressed;
};

#endif
