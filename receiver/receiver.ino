#include <SPI.h>
#include <Ethernet.h>
#include <SoftwareSerial.h>
 
SoftwareSerial mySerial(6, 7); // RX, TX

IPAddress server(192, 168, 2, 103);
int port = 8080;

byte mac[] = {
  0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED
};

EthernetClient client;
void setup() {
  mySerial.begin(9600);
  Serial.begin(9600);
    pinMode( 3, OUTPUT );
    pinMode( 4, OUTPUT );
    if(Ethernet.begin(mac) == 0){
      Serial.println("Failed to configure IP address");
      for(;;);
    }
    Serial.print("Local IP: ");
    Serial.println(Ethernet.localIP());
  while (!Serial) {
    ; // wait for serial port to connect. Needed for native USB port only
  }
}

void loop() {
  
    if (!client.connected()) {
     if (client.connect(server, port)) {
      Serial.println("connected");
      client.println(111);
     } else {
      Serial.println("connection failed");
      delay(2000);
     }
    }else{
      if( mySerial.available() > 0 ){
        String str = mySerial.readString();
        Serial.print("send: ");
        Serial.println(str);
        client.println(str);
      }
    }
}
