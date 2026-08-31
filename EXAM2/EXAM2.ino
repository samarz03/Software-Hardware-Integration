char conn= '\0'; //CONNECTION VERIABLE
int m1f=30; //motor 1 fwd pin
int m1b=31; //motor 1 bwd pin
int m2f=32; //motor 2 fwd pin
int m2b=33; //motor 2 bwdpin
int m3f=34; //motor 3 fwd pin
int m3b=35; //motor 3 bwd pin
int m4f=36; //motor 4 fwd pin
int m4b=37; //motor 4 bwd pin
int pwm1=7; //motor 1 pwm pin
int pwm2=8; //motor 2 pwm pin
int pwm3=9; //motor 3 pwm pin
int pwm4=10; //motor 4 pwm pin
int irl=23; //ir ledft sensor
int irr=22; //ir right sesor
int left=0; //left indicator variable
int right=0; //right indicartor variable

void setup() {
  // put your setup code here, to run once:
  pinMode(m1f,OUTPUT); //initalizxe motor pin
  pinMode(m1b,OUTPUT); //initalizxe motor pin
  pinMode(m2f,OUTPUT); //initalizxe motor pin
  pinMode(m2b,OUTPUT); //initalizxe motor pin
  pinMode(m3f,OUTPUT); //initalizxe motor pin
  pinMode(m3b,OUTPUT); //initalizxe motor pin
  pinMode(m4f,OUTPUT); //initalizxe motor pin
  pinMode(m4b,OUTPUT); //initalizxe motor pin

  pinMode(pwm1,OUTPUT); //initialize opwm pin
  pinMode(pwm2,OUTPUT); //initialize pwm pin
  pinMode(pwm3,OUTPUT); //initialize pwm pin
  pinMode(pwm4,OUTPUT); //initialize pwm pin

  pinMode(irr,INPUT); //initialize ir pin
  pinMode(irl,INPUT); //initialize ir pin
  Serial.begin(9600); //BEGIN SERIAL MONITOR
}

void loop() {
  // put your main code here, to run repeatedly:
  if (Serial.available() >0){
    conn=Serial.read(); //read connection variable
  }

  switch (conn){
    case '1': //FWD
      digitalWrite (m1f,1); //FWD
      digitalWrite (m1b,0); //FWD
      digitalWrite (m2f,1); //FWD
      digitalWrite (m2b,0); //FWD
      digitalWrite (m3f,1); //FWD
      digitalWrite (m3b,0); //FWD
      digitalWrite (m4f,1); //FWD
      digitalWrite (m4b,0); //FWD
    break;

    case '2': //REV
      digitalWrite (m1f,0); //REV
      digitalWrite (m1b,1); //REV
      digitalWrite (m2f,0); //REV
      digitalWrite (m2b,1); //REV
      digitalWrite (m3f,0); //REV
      digitalWrite (m3b,1); //REV
      digitalWrite (m4f,0); //REV
      digitalWrite (m4b,1); //REV
    break;

    case '3': //FWD LFT
      digitalWrite (m1f,0); //REV
      digitalWrite (m1b,1); //REV
      digitalWrite (m2f,0); //REV
      digitalWrite (m2b,1); //REV

      digitalWrite (m3f,1); //FWD
      digitalWrite (m3b,0); //FWD
      digitalWrite (m4f,1); //FWD
      digitalWrite (m4b,0); //FWD
    break;

    case '4': //REV LFT
      digitalWrite (m1f,1); //FWD
      digitalWrite (m1b,0); //FWD
      digitalWrite (m2f,1); //FWD
      digitalWrite (m2b,0); //FWD

      digitalWrite (m3f,0); //REV
      digitalWrite (m3b,1); //REV
      digitalWrite (m4f,0); //REV
      digitalWrite (m4b,1); //REV
    break;

    case '5': //FWD RGT
      digitalWrite (m1f,1); //FWD
      digitalWrite (m1b,0); //FWD
      digitalWrite (m2f,1); //FWD
      digitalWrite (m2b,0); //FWD

      digitalWrite (m3f,0); //REV
      digitalWrite (m3b,1); //REV
      digitalWrite (m4f,0); //REV
      digitalWrite (m4b,1); //REV
    break;

    case '6': //REV RGT
      digitalWrite (m1f,0); //REV
      digitalWrite (m1b,1); //REV
      digitalWrite (m2f,0); //REV
      digitalWrite (m2b,1); //REV

      digitalWrite (m3f,1); //FWD
      digitalWrite (m3b,0); //FWD
      digitalWrite (m4f,1); //FWD
      digitalWrite (m4b,0); //FWD
    break;

    case 'H': //HIGH SPEED
      analogWrite (pwm1,255); //MAX SPEED
      analogWrite (pwm2,255); //MAX SPEED
      analogWrite (pwm3,255); //MAX SPEED
      analogWrite (pwm4,255); //MAX SPEED
    break;

    case 'M': //MED SPEED
      analogWrite (pwm1,191); //.75 MAX SPEED
      analogWrite (pwm2,191); //.75 MAX SPEED
      analogWrite (pwm3,191); //.75 MAX SPEED
      analogWrite (pwm4,191); //.75 MAX SPEED
    break;

    case 'S': //SLOW SPEED
      analogWrite (pwm1,128); //.50 MAX SPEED
      analogWrite (pwm2,128); //.50 MAX SPEED
      analogWrite (pwm3,128); //.50 MAX SPEED
      analogWrite (pwm4,128); //.50 MAX SPEED
    break;

    case 'X': //SHUT DOWN PWM
      analogWrite (pwm1,0); //NO SPEED
      analogWrite (pwm2,0); //NO SPEED
      analogWrite (pwm3,0); //NO SPEED
      analogWrite (pwm4,0); //NO SPEED
    break;

    case 'P': //SHUT DOWN MOTORS
      digitalWrite (m1f,0); //REV
      digitalWrite (m1b,0); //REV
      digitalWrite (m2f,0); //REV
      digitalWrite (m2b,0); //REV
      digitalWrite (m3f,0); //REV
      digitalWrite (m3b,0); //REV
      digitalWrite (m4f,0); //REV
      digitalWrite (m4b,0); //REV
    break;


    case '7': //OBSTACLE SENSORS
      right=digitalRead(irr); //read right sensor
      left=digitalRead(irl); //read left sesor

      if (right == 1 && left == 0){ //left only
        Serial.println('1');
      }
      else if (right == 0 && left == 0){ //both
        Serial.println('2');
     }
      else if (right == 0 && left == 1){ //right only
        Serial.println('3');
      }
      else { //no obstacle
        Serial.println('0');
      }
      delay (50); //wait a hot sec
    break;
  }


}
