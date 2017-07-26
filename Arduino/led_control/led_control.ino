 /*
  Simple LED sketch
*/
 int led1 = 3;// Pin 3
 int led2 = 4;// Pin 4
 int led3 = 5;// Pin 5
 
 void setup()
 {
     pinMode(led1, OUTPUT); // Set pin 3 as digital out
     pinMode(led2, OUTPUT); // Set pin 4 as digital out
     pinMode(led3, OUTPUT); // Set pin 5 as digital out  
     // Start up serial connection
     Serial.begin(9600); // baud rate
     Serial.flush();
 }
 
 void loop()
 {
     String input = "";
 
     // Read any serial input
     while (Serial.available() > 0)
     {
         input += (char) Serial.read(); // Read in one char at a time
         delay(5); // Delay for 5 ms so the next char has time to be received
     }
     //handshake
     if (input == "<Hello Arduino>"){
        Serial.println("<Hello there>");
        digitalWrite(led1, HIGH);
        digitalWrite(led2, HIGH);
        digitalWrite(led3, HIGH);
        delay(100);
        digitalWrite(led1, LOW);
        digitalWrite(led2, LOW);
        digitalWrite(led3, LOW);
      }
 
     if (input == "on1")
     {
         digitalWrite(led1, HIGH); // on
     }
     else if (input == "off1")
     {
         digitalWrite(led1, LOW); // off
     }
     else if (input == "on2")
     {
         digitalWrite(led2, HIGH); // on
     }
     else if (input == "off2")
     {
         digitalWrite(led2, LOW); // off
     }
     else if (input == "on3")
     {
         digitalWrite(led3, HIGH); // on
     }
     else if (input == "off3")
     {
         digitalWrite(led3, LOW); // off
     }
     else if (input == "on_all")
     {
         digitalWrite(led1, HIGH); // on
         digitalWrite(led2, HIGH); // on
         digitalWrite(led3, HIGH); // on
     }
     else if (input == "off_all")      
     {
         digitalWrite(led1, LOW); // on
         digitalWrite(led2, LOW); // on
         digitalWrite(led3, LOW); // off
     }
 }
