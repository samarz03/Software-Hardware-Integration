char conn= '\0'; //CONNECTION VERIABLE
int IND=35; //INDICATIOR LIGHT FOR CONNECTION
int ACOF=34; //IDICATIOR LIGHT FOR AC ON/OFF
int R1=36; //RED AC INDICATOR LIGHT
int R2=37; //RED AC INDICATOR LIGHT
int Y1=38; //YELLOW AC INDICATOR LIGHT
int Y2=39; //YELLOW AC INDICATOR LIGHT
int G1=40; //GREEN AC INDICATOR LIGHT
int G2=41; //GREEN AC INDICATOR LIGHT
float volt=50; //VARIABLE FOR TEMP CALCS (VOLTAGE)
float senseread = 0; //VARIBLE FOR TEMP CALCS (WHAT THE ANALOG PIN GETS)
float temp = 0; //THE TEMPERATURWE!

void setup() {
  Serial.begin(9600); //BEGIN SERIAL MONITOR
  pinMode (IND, OUTPUT); //INITAILIZE INDICATIOR LIGHT
  pinMode (ACOF, OUTPUT); //INITAILIZE AC ON OFF LIGHT
  pinMode (R1, OUTPUT); //INITAILIZE RED LIGHT
  pinMode (R2, OUTPUT); //INITAILIZE RED LIGHT
  pinMode (Y1, OUTPUT); //INITAILIZE YEL:LOW LIGHT
  pinMode (Y2, OUTPUT); //INITAILIZE YELLOW LIGHT 
  pinMode (G1, OUTPUT); //INITAILIZE GREEN LIGHT
  pinMode (G2, OUTPUT); //INITAILIZE GREEEN LIGHT
  pinMode (A0,INPUT); //INITAILIZE TEMP ANALOG

}

void loop() {
  //READ PORT IF THERE IS INPUT
  if (Serial.available() >0){
    conn=Serial.read(); 
  }

  switch (conn){
    case '1': //OPEN PORT
      digitalWrite (IND,1); //TURN ON LIGHT WHEN CONNECTION IS ESTABLISHED
      Serial.println("PORT OPEN"); //COMMUNICATION WITH UI
    break;

    case '2': //CLOSE PORT
      digitalWrite (IND,0); //TURN OFF LIGHT WHEN PORT CLOSES
      digitalWrite (ACOF,0); //TURN OFF LIGHT WHEN PORT CLOSES
      digitalWrite (R1,0); //TURN OFF
      digitalWrite (R2,0); //TURN OFF
      digitalWrite (Y1,0); //TURN OFF
      digitalWrite (Y2,0); //TURN OFF
      digitalWrite (G1,0); //TURN OFF
      digitalWrite (G2,0); //TURN OFF
      Serial.println("PORT CLOSED"); //COMMUNICATION WITH UI
    break;
    
    case '3': //HIGH HEAT
      digitalWrite (Y1,1); //TURN ON LIGHT FOR FAN
      delay (30000); //DELAY 30 SECS
      digitalWrite (R1,1); //TURN ON LIGHT FOR HIGH HEAT
      digitalWrite (R2,1); //TURN ON LIGHT FOR HIGH HEAT
      digitalWrite (Y1,1); //FAN IS ALWAYS RUNNING
      digitalWrite (Y2,1); //COMPRESSIOOR ON
      digitalWrite (G1,0); //TURN OFF
      digitalWrite (G2,0); //TURN OFF
    break;
    
    case '4': //HEAT
      digitalWrite (Y1,1); //TURN ON LIGHT FOR FAN
      delay (30000); //DELAY 30 SECS
      digitalWrite (R1,1); //TURN ON LIGHT FOR HEAT
      digitalWrite (R2,0); //TURN OFF
      digitalWrite (Y1,1); //ALWAYS ONNNN
      digitalWrite (Y2,1); //COMPRESSOR
      digitalWrite (G1,0); //TURN OFF
      digitalWrite (G2,0); //TURN OFF
    break;

    case '5': //FAN
      digitalWrite (R1,0); //TURN OFF
      digitalWrite (R2,0); //TURN OFF
      digitalWrite (Y1,1); //TURN ON LIGHT FOR FAN
      digitalWrite (Y2,0); //NO COMPRESSOR! :)
      digitalWrite (G1,0); //TURN OFF
      digitalWrite (G2,0); //TURN OFF
    break;    

    case '6': //COOL
      digitalWrite (Y1,1); //TURN ON LIGHT FOR FAN
      delay (30000); //DELAY 30 SECS
      digitalWrite (R1,0); //TURN OFF
      digitalWrite (R2,0); //TURN OFF
      digitalWrite (Y1,1); //TURN ON LIGHT FOR COOL
      digitalWrite (Y2,1); //COMPRESSOR
      digitalWrite (G1,1); //TURN ON LIGHT FOR COOL
      digitalWrite (G2,0); //TURN OFF

    break;   
    
    case '7': //SUPER COOL
      digitalWrite (Y1,1); //TURN ON LIGHT FOR FAN
      delay (30000); //DELAY 30 SECS
      digitalWrite (R1,0); //TURN OFF
      digitalWrite (R2,0); //TURN OFF
      digitalWrite (Y1,1); //HEY LOOK- FANS STILL ON!
      digitalWrite (Y2,1); //COMPRESSOR
      digitalWrite (G1,1); //TURN ON LIGHT FOR SUPER COOL
      digitalWrite (G2,1); //TURN ON LIGHT FOR SUPER COOL
    break;     

    case '8': //TEMPURATURE READ
      digitalWrite (ACOF, 1);
      senseread = analogRead(A0); //TAKE INPUT FROM TEMP SENSOR
      volt = (senseread * 5.0) / 1023; //TURN INPUT INTO VOLTAGE
      temp = (volt - 0.5)*100; //USE VOLTAGE TO CALULATE TEMPERATURE (C)
      temp = ((9/5) * temp) + 32; //CHANGE TEMPERARTATURE TO F
      Serial.println(temp); //COMMUNICATE TEMP WITH UI
    break;

    case '9': //WHEN NO AC MODES ARE ACTIVE
      digitalWrite (ACOF, 0);//TURN OFF AC INDICATOR
      digitalWrite (R1,0); //TURN OFF
      digitalWrite (R2,0); //TURN OFF
      digitalWrite (Y1,0); //TURN FAN ON
      digitalWrite (Y2,0); //TURN OFF
      digitalWrite (G1,0); //TURN OFF
      digitalWrite (G2,0); //TURN OFF
    break;



  }

  delay (1); //DELAY BEFORE RE-RUNNING
}
