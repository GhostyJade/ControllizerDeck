#include "Button.h"

Button::Button(byte id, byte pin)
{
    this->pin = pin;
    this->id = id;
    pinMode(pin, INPUT);
}

void Button::sendSerial()
{
    if (digitalRead(pin))
    {
        if (!pressed)
        {
            Serial.print("PB");
            Serial.print(this->id);
            Serial.print(":");
            Serial.println(true);
            pressed = true;
        }
    }
    else
    {
        if (pressed)
        {
            Serial.print("PB");
            Serial.print(this->id);
            Serial.print(":");
            Serial.println(false);
            pressed = false;
        }
    }
}

void Button::sendPacket(WiFiUDP &Udp)
{
    if (digitalRead(pin))
    {
        if (!pressed)
        {
            Udp.beginPacket(/*Udp.remoteIP()*/ "192.168.137.1", 4001);
            Udp.print("PB");
            Udp.print(this->id);
            Udp.print(":");
            Udp.print(true);
            Udp.endPacket();
            pressed = true;
        }
    }
    else
    {
        if (pressed)
        {
            Udp.beginPacket(/*Udp.remoteIP()*/ "192.168.137.1", 4001);
            Udp.print("PB");
            Udp.print(this->id);
            Udp.print(":");
            Udp.print(false);
            Udp.endPacket();
            pressed = false;
        }
    }
}

int Button::is_pressed()
{
    return digitalRead(pin);
}
