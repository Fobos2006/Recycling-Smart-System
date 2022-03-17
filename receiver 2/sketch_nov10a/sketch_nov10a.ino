#include <RCSwitch.h>
#include <SoftwareSerial.h>
 
SoftwareSerial mySerial(6, 7); // RX, TX

RCSwitch mySwitch = RCSwitch();

void setup() {
  Serial.begin(9600);
    pinMode( 3, OUTPUT );
    mySwitch.enableReceive(0);
    mySerial.begin(9600);
}

void loop() {
    if( mySwitch.available() ){
        int value = mySwitch.getReceivedValue();
        Serial.println(value);
        mySwitch.resetAvailable();
        mySerial.println(value);
    }
}
