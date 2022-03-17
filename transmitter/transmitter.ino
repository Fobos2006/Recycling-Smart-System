#include <Ultrasonic.h>

#include <Ultrasonic.h>  // подключаем библиотеку Ultrasonic
Ultrasonic ultrasoniccc(10,11);
Ultrasonic ultrasonicc(8,9);
Ultrasonic ultrasonic(6,7); // назначаем выходы для Trig и Echo
#include <RCSwitch.h>

RCSwitch mySwitch = RCSwitch();

void setup() {
    mySwitch.enableTransmit(2);
    Serial.begin(9600);  
}

void loop() {
  int dist = ultrasonic.Ranging(CM);
  Serial.print(dist);     // выводим расстояние в сантиметрах
  Serial.println(" cm");
  delay(1000);
  int a = 1000-(dist*100/3-(dist*100/3%100));
  Serial.println(a);
  delay(1000);
  int distt = ultrasonicc.Ranging(CM);
  Serial.print(distt);     // выводим расстояние в сантиметрах
  Serial.println(" cmm");
  delay(1000);
  int b = 100-((distt*10/3)-(distt*10/3)%10);
  Serial.println(b);
  delay(1000); 
  int disttt = ultrasoniccc.Ranging(CM);
  Serial.print(disttt);     // выводим расстояние в сантиметрах
  Serial.println(" cmmm");
  delay(1000);
  int c = 10-disttt/3;
  Serial.println(c);
  delay(1000);   
  int d = a+b+c;
  Serial.println(d);
  mySwitch.send(d, 10);
}    
