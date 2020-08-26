#include <MegaDAS_IOExtension.h>

#define SH_CP 13
#define DS 11
#define ST_CP 3
#define IN_P 4

#define KN1 A0
#define KN2 A1

#define KNOB_TRESHOLD 1

#define DELAY_MS 1000

unsigned long prevTime = 0;

IOExtension pushButtons(SH_CP, DS, ST_CP, IN_P);

String lastButtonsValue = "";

void setup()
{
    Serial.begin(9600);
    //pinMode(KN1, INPUT);
    //pinMode(KN2, INPUT);
    lastButtonsValue = readButtons();
}

#define lowestButtonID 2
#define highestButtonID 7

void loop()
{
    unsigned long currentTime = millis();

    if (currentTime - prevTime >= DELAY_MS) {
        String currentButtonsValue = readButtons();
        if (currentButtonsValue != lastButtonsValue)
        {
            Serial.println(currentButtonsValue);
            lastButtonsValue = currentButtonsValue;
        }
       // updateKnobs();
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

int KN1_PrevValue = 0;
int KN2_PrevValue = 0;

//Update knobs input value while performing debouncing
void updateKnobs()
{
    int kn1_val = analogRead(KN1);
    if ((kn1_val - KNOB_TRESHOLD > KN1_PrevValue) || (kn1_val + KNOB_TRESHOLD < KN1_PrevValue))
    {
        Serial.print("K0:");
        Serial.println(kn1_val);
        KN1_PrevValue = kn1_val;
    }

    int kn2_val = analogRead(KN2);
    if ((kn2_val - KNOB_TRESHOLD > KN2_PrevValue) || (kn2_val + KNOB_TRESHOLD < KN2_PrevValue))
    {
        Serial.print("K1:");
        Serial.println(kn2_val);
        KN2_PrevValue = kn2_val;
    }
}
