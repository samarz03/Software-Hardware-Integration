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

namespace Exam2
{
    public partial class Form1 : Form
    {
        SerialPort ardu = new SerialPort(); //Initialize SerialPort Variable (ARDU)
        int clikN = 0; //Click count for north
        int clikS = 0; //Click count for south
        int clikE = 0; //Click count for east
        int clikW = 0; //Click count for west
        int determ = 0; //For deteriming if statments
        int clikAQ = 0; //Click count for obsacle sensors
        int termi = 0; //For determining termination
        int clikPort = 0; //Click count for port
        int cont = 0; // continue polling obstable data
        string speedstr = null; //String for speed data
        char speedset = '\0'; //Character to comminicate with ardu
        int rof = 0; //reverse or forward direction (for turning)
        char OBS = '\0'; //Obstacle varible
        string OBSSTR = null; //Obstacle varible

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clikPort++; //HOW MANY TIMES HAS THIS BUTTON BEEN PRESSED
            determ = clikPort % 2; //DETERMINE IF DIVISIBLE BY 2
            if (determ == 1) //IF IT ISNT
            {
                ardu.PortName = textBox1.Text; //GET PORT NAME
                ardu.Open(); //OPEN PORT
                button1.Text = "PORT OPEN"; //PORT IS OPEN

                //enable all buttons
                button2.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
            }
            else
            {
                ardu.WriteLine("X"); //stop pwm
                ardu.WriteLine("P"); //stop motors
                ardu.Close(); //CLOSE PORT
                button1.Text = "PORT CLOSED"; //PORT IS OPEN

                //disable all buttons and reset colors
                button2.Enabled = false;
                button2.BackColor = Color.AntiqueWhite;
                button3.Enabled = false;
                button3.BackColor = Color.AntiqueWhite;
                button4.Enabled = false;
                button4.BackColor = Color.AntiqueWhite;
                button5.Enabled = false;
                button5.BackColor = Color.AntiqueWhite;
                button6.Enabled = false;
                button6.BackColor = Color.AntiqueWhite;
                button7.Enabled = false;
                button7.BackColor = Color.AntiqueWhite;

                //Reset labels, textboxes, and crit variables
                label1.BackColor = Color.Silver;
                label1.Text = "SPEED";
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clikN++; //click count
            determ = clikN % 2; //determine if first or second time
            if (determ == 1) //IF IT ISNT
            {
                ardu.WriteLine("1"); //FORWARD
                ardu.DiscardInBuffer(); //CLEAN OUT
                button3.Enabled = true; //Can turn now
                button4.Enabled = true; //Can turn now
                button5.Enabled = false; //Can't reverse
                button2.BackColor = Color.DarkSeaGreen; //change colors
                rof = 1;
            }
            else
            {
                ardu.WriteLine("P"); //STOP
                ardu.DiscardInBuffer(); //CLEAN OUT
                button3.Enabled = false; //No more turning
                button4.Enabled = false; //No more turning
                button5.Enabled = true; //Can reverse
                button2.BackColor = Color.AntiqueWhite; //change colors
                rof = 0; //no movement
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clikW++; //click count
            determ = clikW % 2; //First or second time
            if (determ == 1) //IF IT ISNT
            {
                if (rof == 1) //if moving fwd
                    ardu.WriteLine("3"); //FORWARD LEFT

                if (rof == 2) //if moving bck
                    ardu.WriteLine("4"); //BACKWARD LEFT

                ardu.DiscardInBuffer(); //CLEAN OUT
                button4.Enabled = false; //Cant turn other direction now
                button3.BackColor = Color.DarkSeaGreen; //change colors
            }
            else
            {
                if (rof == 1) //if moving fwd
                    ardu.WriteLine("1"); //FORWARD

                if (rof == 2) //if moving bck
                    ardu.WriteLine("2"); //BACKWARD

                ardu.DiscardInBuffer(); //CLEAN OUT
                button4.Enabled = true; //Can turn other direction now
                button3.BackColor = Color.AntiqueWhite; //change colors
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clikE++; //click count
            determ = clikE % 2; //Come here often?
            if (determ == 1) //IF IT ISNT
            {
                if (rof == 1) //if moving fwd
                    ardu.WriteLine("5"); //FORWARD RIGHT

                if (rof == 2) //if moving bck
                    ardu.WriteLine("6"); //BACKWARD RIGHT

                ardu.DiscardInBuffer(); //CLEAN OUT
                button3.Enabled = false; //Cant turn other direction now
                button4.BackColor = Color.DarkSeaGreen; //change colors
            }
            else
            {
                if (rof == 1) //if moving fwd
                    ardu.WriteLine("1"); //FORWARD

                if (rof == 2) //if moving bck
                    ardu.WriteLine("2"); //BACKWARD

                ardu.DiscardInBuffer(); //CLEAN OUT
                button3.Enabled = true; //Can turn other direction now
                button4.BackColor = Color.AntiqueWhite; //change colors
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clikS++; //clickcount
            determ = clikS % 2; //first or second time
            if (determ == 1) //IF IT ISNT
            {
                ardu.WriteLine("2"); //BACKWARD
                ardu.DiscardInBuffer(); //CLEAN OUT
                button3.Enabled = true; //Can turn now
                button4.Enabled = true; //Can turn now
                button2.Enabled = false; //Can't go fwd
                button5.BackColor = Color.DarkSeaGreen; //change colors
                rof = 2; //moving bck
            }
            else
            {
                ardu.WriteLine("P"); //STOP
                ardu.DiscardInBuffer(); //CLEAN OUT
                button3.Enabled = false; //No more turning
                button4.Enabled = false; //No more turning
                button2.Enabled = true; //Can go fwd
                button5.BackColor = Color.AntiqueWhite; //change colors
                rof = 0; //no movement
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            speedstr = textBox2.Text; //take user input
            speedset = speedstr[0]; //change to char
            switch (speedset) //determine user command
            {
                case 'H': //high speed
                    ardu.WriteLine("H"); //send to ardu
                    ardu.DiscardInBuffer(); //take trash out
                    label1.Text = "HIGH"; //indicate to user
                    label1.BackColor = Color.DarkSeaGreen; //change color
                    break;
                case 'M': //med speed
                    ardu.WriteLine("M"); //send to ardu
                    ardu.DiscardInBuffer(); //take trash out
                    label1.Text = "MEDIUM"; //indicate to user
                    label1.BackColor = Color.DarkSeaGreen; //change color
                    break;
                case 'S': //slow speed
                    ardu.WriteLine("S"); //send to ardu
                    ardu.DiscardInBuffer(); //take trash out
                    label1.Text = "SLOW"; //indiacte to user
                    label1.BackColor = Color.DarkSeaGreen; //change color
                    break;
                default: //invalid speed
                    label1.Text = "Invalid Speed"; //bad chouice
                    label1.BackColor = Color.Firebrick; //bad choice color
                    ardu.WriteLine("X"); //stop pwm
                    ardu.DiscardInBuffer(); //take trash out
                    break;
            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            cont = 1; //Its a constant
            clikAQ++; //How many times have you touched my button
            termi = clikAQ % 2; //This is a secret mouse-katool that will help up determine if you wanna turn on or off

            if (termi == 0)
            {
                cont = 0; //change constant
                label2.BackColor = Color.Silver; //turn off color
                label3.BackColor = Color.Silver; //turn off color
            }

            else
            {
                while (cont == 1) 
                {
                    ardu.WriteLine("7"); //send command to ardu
                    OBSSTR = ardu.ReadLine(); //read data
                    OBS = OBSSTR[0]; //put it into something we can work with
                    ardu.DiscardInBuffer(); //take trash out

                    switch (OBS)
                    {
                        case '0': //no obstacle
                            label2.BackColor = Color.DarkSeaGreen;
                            label3.BackColor = Color.DarkSeaGreen;
                            break;
                        case '3': //right obstacle
                            label2.BackColor = Color.DarkSeaGreen;
                            label3.BackColor = Color.Firebrick;
                            break;

                        case '2': //both obstacle   
                            label2.BackColor = Color.Firebrick;
                            label3.BackColor = Color.Firebrick;
                            break;

                        case '1': //left obstacle
                            label2.BackColor = Color.Firebrick;
                            label3.BackColor = Color.DarkSeaGreen;
                            break;
                    }

                    ardu.DiscardInBuffer(); //CLEAN OUT
                    await Task.Delay(2000); //Wait to repeat for 10 seconds

                }

                
            }
            
        }
    }
}