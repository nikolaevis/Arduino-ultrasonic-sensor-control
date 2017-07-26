int switchState = 0;
int state = 100;
int randomval;
char ledNo;
void setup() {
  Serial.begin(9600);
  Serial.flush();
  pinMode (3,OUTPUT);
  pinMode (4,OUTPUT);
  pinMode (5,OUTPUT);
  pinMode (2,INPUT); 
  
}

void loop(){
  switchState = digitalRead(2);
  // To display switch state only onse
  if (switchState == LOW){
    if (state != 0){
      state = 0;
      Serial.println("Tlacitko neni zmacknuto");
      Serial.println(ledNo);
        while (Serial.available() > 0) {
        ledNo = (char)Serial.read();
        delay(5);
        Serial.println(ledNo);
        switch(ledNo){
          case 3: 
          Serial.println("!!!!!!!!!!!!!!");
          digitalWrite(3, HIGH);
          delay(1000);
          digitalWrite(3, LOW);
          state = 100;
          break;
          case 52:
          digitalWrite(4, HIGH);
          delay(1000);
          digitalWrite(4, LOW);
          state = 100;
          case 53:
          digitalWrite(5, HIGH);
          delay(1000);
          digitalWrite(5, LOW);
          state = 100;
          default:
          Serial.println("this led is not installed");
        //state = 100;
        }
        }
      }
    // let's read from the console which led to light up
    }
 else{
    // To display switch state only onse
     if (state != 1){
      state = 1;
      Serial.println("Tlacitko je zmacknuto");
      }
    randomval = random(3);
      switch(randomval){
      case 0:
      Serial.print(randomval);
      Serial.println(" cervena");
      digitalWrite(3, HIGH);
      delay(1000);
      digitalWrite(3, LOW);
      break;
      case 1:
      Serial.print(randomval);
      Serial.println(" zluta");
      digitalWrite(4, HIGH);
      delay(1000);
      digitalWrite(4, LOW);
      break;
      case 2:
      Serial.print(randomval);
      Serial.println(" zelena");
      digitalWrite(5, HIGH);
      delay(1000);
      digitalWrite(5, LOW);
      break;
    }
    //digitalWrite(3, LOW);
    //digitalWrite(4, LOW);
    //digitalWrite(5, HIGH);
    
    //delay(2000);//wait for a quarter second
    //toggle the LEDs
    //digitalWrite (4, HIGH);
    //digitalWrite (5, LOW);
    //delay(2000);
  }
}

