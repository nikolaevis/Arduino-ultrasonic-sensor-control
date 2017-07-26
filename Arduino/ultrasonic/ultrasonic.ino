const int ledRed = 3;// Pin 3
const int ledYel = 4;// Pin 4
const int ledGrn = 5;// Pin 5
const int usTrig = 8;// Pin 8
const int usEcho = 9;// Pin 9
long dist;
bool ultrasonicOn = false; 
 void setup()
 {
     pinMode(ledRed, OUTPUT); // Set pin 3 as digital out
     pinMode(ledGrn, OUTPUT); // Set pin 4 as digital out
     pinMode(ledYel, OUTPUT); // Set pin 5 as digital out  
     pinMode(usTrig, OUTPUT); // Set pin 8 as digital out for the ultrasonic sensor
     pinMode(usEcho, INPUT); // Set pin 9 as digital in for the ultrasonic sensor
     // Start up serial connection
     Serial.begin(9600); // baud rate
     Serial.flush(); //they say it is handy to have it here
 }

void loop() {
SerialTalk();
//UltrasonicOn();
if(ultrasonicOn){
  dist = Distance(usTrig, usEcho);
  Serial.print("<cm>");
  Serial.print(dist);
  Serial.println("</cm>");
  LedIndication(dist);
}
delay(500);
}

long Distance(int usTrig, int usEcho){
  digitalWrite(usTrig, LOW);
  delayMicroseconds(2);
  digitalWrite(usTrig, HIGH);
  delayMicroseconds(10);
  digitalWrite(usTrig, LOW);
  long duration; // time for sound travel in ms
  duration = pulseIn(usEcho, HIGH);//get time between echo and signal
  return duration*0.03403/2;//time*speed of sound in cm/microseconds/2(as sound travels there and back)
  }
void LedIndication(long distance){
  if(distance>=200){//if distance is gt then 2m, leds are off
    digitalWrite(ledGrn, LOW);
    digitalWrite(ledYel, LOW);
    digitalWrite(ledRed, LOW);
    }
  if(distance>=100&&distance<200){//if distance is greater then 1m and less then 2m, Green led is on
    digitalWrite(ledGrn, HIGH);
    digitalWrite(ledYel, LOW);
    digitalWrite(ledRed, LOW);
    }
  if(distance>=50 && distance<100){//if distance is greater then 0.5m and less then 1m, Green and yellow leds are on
    digitalWrite(ledGrn, HIGH);
    digitalWrite(ledYel, HIGH);
    digitalWrite(ledRed, LOW);
    }
  if(distance<50){//if distance is less then 0.5m, all leds are on
    digitalWrite(ledGrn, HIGH);
    digitalWrite(ledYel, HIGH);
    digitalWrite(ledRed, HIGH);
    }
 }
void SerialTalk(){
   String input = "";
   while (Serial.available() > 0)//read data from serial
     {
         input += (char) Serial.read(); // Read in one char at a time
         delay(5); // Delay for 5 ms so the next char has time to be received
     }
     //handshake
     if (input == "<Hello Arduino>"){
        Serial.println("<Hello there>");
     }
     
     if (input == "<OnUltrasonic>"){
        ultrasonicOn=true;
     }
     if (input == "<OffUltrasonic>"){
        ultrasonicOn=false;
     }
}

  
void UltrasonicOn() {
   String input = "";
   while (Serial.available() > 0)//read data from serial
     {
         input += (char) Serial.read(); // Read in one char at a time
         delay(5); // Delay for 5 ms so the next char has time to be received
     }
     if (input == "<OnUltrasonic>"){
        delay(50);
        Serial.println("Sensor is on");
        ultrasonicOn=true;
     }
     if (input == "<OffUltrasonic>"){
        delay(50);
        Serial.println("Sensor is off");
        ultrasonicOn=false;
     }
  }
