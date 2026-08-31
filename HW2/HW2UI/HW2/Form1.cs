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

namespace HW2
{
    public partial class Form1 : Form
    {
        SerialPort ardu = new SerialPort(); //Initialize SerialPort Variable (ARDU)
        int clikM1=0; //Click count for motor 1
        int determ = 0; //For deteriming if statments
        int clikM2=0; //Click count for motor 2
        int clikPort = 0; //Click count for port
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ardu.WriteLine("1"); //M1 FWD
            ardu.DiscardInBuffer(); //Clean Out
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ardu.WriteLine("3"); //M1 REV
            ardu.DiscardInBuffer(); //Clean Out
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clikM1++; //How many times button has been pressed 
            determ = clikM1 % 2; //Determine if divisible by 2
            if (determ == 1) //If it isnt divisiblke by 2
            {
                ardu.WriteLine("1"); //Motor1 FWD
                ardu.DiscardInBuffer(); //Clean out
                button2.BackColor = Color.DarkSeaGreen; //Change color of button
                button2.Text = "ON"; //Motor is on
            }
            else
            {
                ardu.WriteLine("2"); //Motor1 Stop
                ardu.DiscardInBuffer(); //Clean out
                button2.BackColor= Color.LightCoral; //Change Color of button
                button2.Text = "OFF"; //Motor is off
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clikM2++; //How many times button has been pressed
            determ = clikM2 % 2; //Determine if divisible by 2
            if (determ == 1) //If it isnt divisiblke by 2
            {
                ardu.WriteLine("4"); //M2 FWD
                ardu.DiscardInBuffer(); //Clean out
                button5.BackColor = Color.DarkSeaGreen; //Change COlor of Button
                button5.Text = "ON"; //Motor is on
            }
            else
            {
                ardu.WriteLine("5"); //M2 Stop
                ardu.DiscardInBuffer(); //Clean OUt
                button5.BackColor = Color.LightCoral; //Change color of button
                button5.Text = "OFF"; //Motor off
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ardu.WriteLine("4"); //M2 FWD
            ardu.DiscardInBuffer(); //CLEANOUT
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ardu.WriteLine("6"); //M2 REV
            ardu.DiscardInBuffer(); //CLEAN OUT
        }

        private void button7_Click(object sender, EventArgs e)
        {
            clikPort++; //HOW MANY TIMES HAS THIS BUTTON BEEN PRESSED
            determ = clikPort % 2; //DETERMINE IF DIVISIBLE BY 2
            if (determ == 1) //IF IT ISNT
            {
                ardu.PortName = textBox1.Text; //GET PORT NAME
                ardu.Open(); //OPEN PORT
                button7.BackColor = Color.DarkSeaGreen; //CHANGE BUTTON COLOR
                button7.Text = "PORT OPEN"; //PORT IS OPEN
            }
            else
            {
                ardu.Close(); //CLOSE PORT
                button7.BackColor = Color.LightCoral; //CHANGE BUTTON COLOR
                button7.Text = "PORT CLOSED"; //PORT IS CLOSED
            }
        }
    }
}
