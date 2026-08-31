using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Exam1UI
{
    public partial class Form1 : Form
    {
        SerialPort ardu = new SerialPort();
        int cont = 1; //Varible to continue retreiving temp
        int clickcount = 0; //Count of clicks (duh)
        int termi = 0; //Terminate temp reterival
        int operationcount = 0; //How many time the operation button has been presed
        float temp = 0; //Whats the temp, Mr.Sensor?
        int desiretemp = 0; //What do you want it to be, User?
        float difftemp = 0; //Well thats (insert varible here) degrees different!
        
        public Form1()
        {
            InitializeComponent();
            ardu.BaudRate = 9600; //Communication speed
        }

        private void button1_Click(object sender, EventArgs e) //COM CONNECTION
        {
            
            ardu.PortName = textBox1.Text; //what com port do you want?
            ardu.Open(); //Open it!
            ardu.WriteLine("1"); //Tell it to turn on indicator light
            ardu.DiscardInBuffer(); //Get rid of the trash
            textBox2.Text = ardu.ReadLine(); //What is the board saying? P.S. its that the port is open
            label1.BackColor = Color.Green; //Change colors!
            textBox2.BackColor = Color.Green; //Change it some more!
            button1.Enabled = false; //NO YOU CANT PRESS THAT BUTTON
            button1.BackColor = Color.Gray; //No more color for you
            button1.ForeColor = Color.Gray; //No text- dont even think about pressing it
            button2.Enabled = true; //Hey! You can disconnect from the port now!
            button2.BackColor = Color.MediumSlateBlue; //See! The button is there! Its a different color now!
            button2.ForeColor = Color.Black; //AND YOU CAN READ IT!!! :)
            button3.Enabled = true; //You want to turn on the AC? You can!
            button3.BackColor = Color.MediumSlateBlue; //Really- please press the new colored button
            button3.ForeColor = Color.Black; //Read it- it says Power ;)

        }

        private void button2_Click(object sender, EventArgs e) //COM DISCONNECT
        {
            ardu.WriteLine("2"); //Tell Ardu to shut 'er down
            ardu.DiscardInBuffer(); //Get rid of the trash
            textBox2.Text = ardu.ReadLine(); //Ardu's telling you its last words (The port is closed)
            ardu.Close(); //Yep, closed
            label1.BackColor = Color.Gray; //Its really closed- hence the grey label
            textBox2.BackColor = Color.Gray; //Like i said- closed
            button1.Enabled = true; //But you can reconnect if you want!
            button1.BackColor = Color.MediumSlateBlue; //I even made it look pretty for you!
            button1.ForeColor = Color.Black; //And you can read it :)
            button2.Enabled = false; //But you cant disconnect again
            button2.BackColor = Color.Gray; //Really- its all grey
            button2.ForeColor = Color.Gray; //Very grey- please dont press the button
            button3.Enabled = false; //YOu cant turn the AC on either
            button3.BackColor = Color.Gray; //Like i said- grey means no press
            button3.ForeColor = Color.Gray; //Im not going to even let you read it
        }

        private async void button3_Click(object sender, EventArgs e) //TURN ON AC
        {
            cont=1; //Its a constant
            clickcount ++; //How many times have you touched my button
            termi = clickcount % 2; //This is a secret mouse-katool that will help up determine if you wanna turn on or off

            if (termi == 0) //If this is the second time, we powering down
            {
                cont = 0;
                textBox3.Text = "0"; //No temp- its off
                ardu.WriteLine("9"); //Tell Ardu to turn of AC system
                button4.Enabled = false; //You cant turn on the heat now
                button4.BackColor = Color.Gray; //Really, you cant
                button4.ForeColor = Color.Gray; //Grey means no
                button2.Enabled = true; //But you could disconnect from the port if you want
                button2.BackColor = Color.MediumSlateBlue; //Yep, you can disconnect
                button2.ForeColor = Color.Black; //Purple-ish blue means YES
                label2.Text = ("A/C OFF"); //In case you were wondering- its off
                label2.BackColor = Color.Crimson; //It's off
                label3.BackColor = Color.Crimson; //ITS OFF
                label3.Text = "OFF"; //SERIOUSLY ITS OFF
                label6.BackColor = Color.Gray; //Reset the SUPERCOOL LABEL
                label7.BackColor = Color.Gray; //Reset the COOL LABEL
                label8.BackColor = Color.Gray; //Reset the Fan LABEL
                label9.BackColor = Color.Gray; //Reset the Heat LABEL
                label10.BackColor = Color.Gray; //Reset the HighHeat LABEL

            }

            else
            {
                button4.Enabled = true; //Hey look, you can click the operation button now
                button4.BackColor = Color.MediumSlateBlue; //Yep- its in the click me color now
                button4.ForeColor = Color.Black; //And you can read it!
                button2.Enabled = false; //But you cant disconnect from the port
                button2.BackColor = Color.Gray; //Its in cant click grey
                button2.ForeColor = Color.Gray; //And not as readable
                label2.Text = ("A/C ON"); //See! Its on!
                label2.BackColor = Color.Green; //I changed the color incase your confusied (AC IS ON)

                while (cont == 1) //Run until constant changes
                { 
                    ardu.WriteLine("8"); //Turn on the AC indicator light
                    ardu.DiscardInBuffer(); //Get rid of trash
                    textBox3.Text = ardu.ReadLine(); //What temp are we reading
                    await Task.Delay(10000); //Wait to repeat for 10 seconds
                }
            }

           
        }

        private void button4_Click(object sender, EventArgs e) //Operation Button
        {
            operationcount++; //How many times have you clicked the operatio button?
            desiretemp = Int32.Parse(textBox4.Text); //What do you want the temp to be
            temp = (float)Convert.ToDouble(textBox3.Text); //What is it now?
            label6.BackColor = Color.Gray; //Reset the SUPERCOOL LABEL
            label7.BackColor = Color.Gray; //Reset the COOL LABEL
            label8.BackColor = Color.Gray; //Reset the Fan LABEL
            label9.BackColor = Color.Gray; //Reset the Heat LABEL
            label10.BackColor = Color.Gray; //Reset the HighHeat LABEL

            if (operationcount == 1) //Cool Mode Selected
            {
                label3.BackColor = Color.LightSteelBlue; //Showing that its cool
                label3.Text = "Cool"; //Now it reads it too
                difftemp = temp - desiretemp; //What is the difference between user input and actual temp
                if (difftemp > 1 && difftemp < 10) //Self explanitory (Difference is more then 1 and less then 10)
                {
                    ardu.WriteLine("6"); //Turn on cool mode
                    label7.BackColor = Color.Green; //Show that its on
                }
                else if (difftemp > 10) //If difference is higher then 10
                {
                    ardu.WriteLine("7"); //SUPER COOLLLL
                    label6.BackColor = Color.Green; //See- its in super cool mode!
                }
                else //Anything less then 1
                {
                    ardu.WriteLine("5"); //Nothing but fan
                }

            }

            else if (operationcount == 2) //Fan Mode Selected
            {
                label3.BackColor = Color.Gold; //Fan Mode is selected
                label3.Text = "Fan"; //Fan miode is writeen
                ardu.WriteLine("5"); //Fire up the fan
                label8.BackColor = Color.Green; //Show it on the mode list
            }

            else //HEAT
            {
                operationcount = 0; //Reset counting varible
                label3.BackColor = Color.PaleVioletRed; //Look- youve selected heat
                label3.Text = "Heat"; //Told ya that its heat
                difftemp = desiretemp - temp; //Difference between temepratures
                if (difftemp > 1 && difftemp < 10) //You know the drill, more then 1, less then 10
                {
                    ardu.WriteLine("4"); //Heat time boys
                    label9.BackColor = Color.Green; //SHow in mode list
                }
                else if (difftemp > 10) //More then 10 degree difference
                {
                    ardu.WriteLine("3"); //HIGH HEAT
                    label10.BackColor = Color.Green; //Show in mode list
                }
                else
                {
                    ardu.WriteLine("5"); //Turn everything but fan off
                }
            }
        }
    }
}
