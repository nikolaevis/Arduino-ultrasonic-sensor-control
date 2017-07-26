int switchState = 0;
int randomval;
void setup() {
  pinMode (3,OUTPUT);
  pinMode (4,OUTPUT);
  pinMode (5,OUTPUT);
  pinMode (2,INPUT); 

}

void loop(){
  switchState = digitalRead(2);
  // this is a comment
  if (switchState == LOW){
    digitalWrite(3, HIGH);
    delay(500);
    digitalWrite(3, LOW);
    digitalWrite(4, HIGH);
    delay(500);
    digitalWrite(4, LOW);
    digitalWrite(5, HIGH);
    delay(500);
    digitalWrite(5, LOW);
  }
 else{
    randomval = random(3);
    switch(randomval){
      case 1:
      digitalWrite(3, HIGH);
      delay(200);
      digitalWrite(3, LOW);
      break;
      case 2:
      digitalWrite(4, HIGH);
      delay(200);
      digitalWrite(4, LOW);
      break;
      case 0:
      digitalWrite(5, HIGH);
      delay(200);
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

