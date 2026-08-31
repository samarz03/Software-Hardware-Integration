char conn= '\0'; //CONNECTION VERIABLE
byte curr= B00000000; //CURRENT CONTROL VARIABLE
byte inp= B00000000; //INPUT VARIABLE
void setup() {
  // put your setup code here, to run once:
    Serial.begin(9600); //BEGIN SERIAL MONITOR
    DDRC = B11110000; //iNITIALIZE PORT C
}

void loop() {
  // put your main code here, to run repeatedly:
  if (Serial.available() >0){
    conn=Serial.read(); //READ SERIAL INPUT
  }
  switch (conn){
    case '1': //M1FWD
      inp=B01000000; //INPUT BINARY (STOP MOTOR)
      curr = inp ^ curr; //KEEP M2 SAME- CHANGE M1
      PORTC = curr; //UPLOAD OUTPUT
      delay (2000); //WAIT 2 SECONDS
      inp=B00110000; //INPUT BINARY
      curr = inp & curr; //KEEP M2 SAME- CHANGE M1
      PORTC = curr; //UPLOAD OUTPUT

    break;
    case '2': //M1STP
      inp=B01000000; //INPUT BINARY
      curr = inp ^ curr; //KEEP M2 SAME- CHANGE M1
      PORTC = curr; //UPLOAD OUTPUT
      
    break;
    case '3': //M1REV
      inp=B01000000; //INPUT BINARY (STOP MOTOR)
      curr = inp ^ curr; //KEEP M2 SAME- CHANGE M1
      PORTC = curr; //UPLOAD OUTPUT
      delay (2000); //WAIT 2 SECONDS
      inp=B11000000; //INPUT BINARY
      curr = inp | curr; //KEEP M2 SAME- CHANGE M1
      PORTC = curr; //UPLOAD OUTPUT
      
    break;
    case '4': //M2FWD 
      inp=B00100000; //INPUT BINARY
      curr = inp ^ curr; //KEEP M1 SAME- CHANGE M2
      PORTC = curr; //UPLOAD OUTPUT
      delay (2000); //WAIT 2 SECONDS
      inp=B11000000; //INPUT BINARY
      curr = inp & curr; //KEEP M1 SAME- CHANGE M2
      PORTC = curr; //UPLOAD OUTPUT
      
    break;
    case '5': //M2STP
      inp=B00100000; //INPUT BINARY
      curr = inp ^ curr; //KEEP M1 SAME- CHANGE M2
      PORTC = curr; //UPLOAD OUTPUT
      
    break;
    case '6': //M2REV
      inp=B00100000; //INPUT BINARY
      curr = inp ^ curr; //KEEP M1 SAME- CHANGE M2
      PORTC = curr; //UPLOAD OUTPUT
      delay (2000); //WAIT 2 SECONDS
      inp=B00110000; //INPUT BINARY
      curr = inp | curr; //KEEP M1 SAME- CHANGE M2
      PORTC = curr; //UPLOAD OUTPUT
    break;
  }
}
