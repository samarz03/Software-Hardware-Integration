//Linear Actuator :D

//Variable definitions
const int one = 24; //Defining one as pin 1
const int two = 25; //Defining two as pin 2

void setup(){
    pinMode(one, OUTPUT); //Pin 1 is now an output
    pinMode(two, OUTPUT); //Pin 2 is now an output

    Serial.begin (9600);
}

void loop (){
    //Extension - This is just an initial setup. If one = Low and two = High, the LA extends
    digitalWrite(one, LOW);
    digitalWrite(two, HIGH);

    delay(5000); //We are indeed chilling

    //Stop - If both one and two = High, the LA stops moving
    digitalWrite(one, HIGH);
    digitalWrite(two, HIGH);

    delay(2000); //Again. Chillin'

    //Retraction - If one = High and two = Low, the LA retracts
    digitalWrite(one, HIGH);
    digitalWrite(two, LOW);

    delay(5000); //Wow we do use these delays a lot don't we

    //Stop - You get the gist
    digitalWrite(one, HIGH);
    digitalWrite(two, HIGH);

    delay(2000);
}
