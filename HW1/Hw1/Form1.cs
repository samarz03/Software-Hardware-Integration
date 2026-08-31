using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hw1
{
    public partial class Form1 : Form
    {
        int inp = 0; //Initialize input int
        int[] cat= new int[8]; //Initialize array for binary
        char[] hex = new char[2]; //Initialize arry for Hexadecimal
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e) //Decimal to Binary
        {
            inp = int.Parse(textBox1.Text); //get data from textbox
            for (int i=0; i<=7; i++) //Initialize for loop
            {
                cat[7-i] = inp % 2; //put remainder in array
                inp = inp / 2;      //update input
            }
            textBox2.Text = cat[0].ToString() + cat[1].ToString() + cat[2].ToString() + cat[3].ToString() +
                cat[4].ToString() + cat[5].ToString() + cat[6].ToString() + cat[7].ToString(); //output data to textbox
        }
        private void button2_Click(object sender, EventArgs e) //Decimal to Hexadecimal
        {
            inp = int.Parse(textBox1.Text); //get data from textbox
            for (int i = 0; i <= 1; i++) //Initialize for loop
            {
                int hexhold = inp % 16; //Get remainder for coniverision
                if (hexhold == 10) //Check if reminder needs to be changed into letter
                {
                    hex[1-i] = 'A'; //Change remainder to A
                }
                if (hexhold == 11)//Check if reminder needs to be changed into letter
                {
                    hex[1 - i] = 'B'; //Change remainder to B
                }
                if (hexhold == 12)//Check if reminder needs to be changed into letter
                {
                    hex[1 - i] = 'C'; //Change remainder to C
                }
                if (hexhold == 13)//Check if reminder needs to be changed into letter
                {
                    hex[1 - i] = 'D'; //Change remainder to D
                }
                if (hexhold == 14)//Check if reminder needs to be changed into letter
                {
                    hex[1 - i] = 'E'; //Change remainder to E
                }
                if (hexhold == 15)//Check if reminder needs to be changed into letter
                {
                    hex[1 - i] = 'F'; //Change remainder to F
                }

                if (hexhold < 10) //Raminder doesnt need to be changed to letter
                {
                    hexhold = hexhold + 48; //Change to character for array
                    hex[1 - i] = (char)hexhold; //Input into array
                }
                inp = inp / 16;        //update input
            }
            textBox2.Text = hex[0].ToString() + hex[1].ToString(); //output data to textbox
        }

        private void button4_Click(object sender, EventArgs e) //Binary to Decimal
        {
            double inl = 0; //create double var
            char[] inpArr = textBox3.Text.ToArray<char>(); //parse into array

            for (int i = 0; i <= 7; i++) //Initialize for loop
            {
                double binhold = inpArr[7 - i] - '0'; //change array value into double
                binhold = binhold * Math.Pow(2.0, i); //Multiply value by power of 2
                inl = binhold + inl; //update output
            }
            textBox4.Text = inl.ToString(); //output data to textbox
        }

        private void button3_Click(object sender, EventArgs e) //Binary to Hexadecimal
        {
            double inl = 0; //create double var
            char[] inpArr = textBox3.Text.ToArray<char>(); //parse into array

            for (int i = 0; i <= 7; i++) //Initialize for loop to change into decimal
            {
                double binhold = inpArr[7 - i] - '0'; //change array value into double
                binhold = binhold * Math.Pow(2.0, i); //Multiply value by power of 2
                inl = binhold + inl; //update output
            }
            int inp = (int) inl; //change double to integer

            for (int i = 0; i <= 1; i++) //Initialize for loop to change into hexadecimal
            {
                int hexhold = inp % 16; //Get remainder for conversion
                if (hexhold == 10) //Check if reminder needs to be changed into letter
                {
                    hex[1 - i] = 'A'; //Change remainder to A
                }
                if (hexhold == 11)//Check if reminder needs to be changed into letter
                {
                    hex[1 - i] = 'B'; //Change remainder to B
                }
                if (hexhold == 12)//Check if reminder needs to be changed into letter
                {
                    hex[1 - i] = 'C'; //Change remainder to C
                }
                if (hexhold == 13)//Check if reminder needs to be changed into letter
                {
                    hex[1 - i] = 'D'; //Change remainder to D
                }
                if (hexhold == 14)//Check if reminder needs to be changed into letter
                {
                    hex[1 - i] = 'E'; //Change remainder to E
                }
                if (hexhold == 15)//Check if reminder needs to be changed into letter
                {
                    hex[1 - i] = 'F'; //Change remainder to F
                }

                if (hexhold < 10) //Raminder doesnt need to be changed to letter
                {
                    hexhold = hexhold + 48; //Change to character for array
                    hex[1 - i] = (char)hexhold; //Input into array
                }
                inp = inp / 16;        //update input
            }
            textBox4.Text = hex[0].ToString() + hex[1].ToString(); //output data to textbox

        }

        private void button6_Click(object sender, EventArgs e) //Hexadecimal to Binary
        {
            double inl = 0; //create double var
            char[] inpArr = textBox5.Text.ToArray<char>(); //parse into array
            double binhold = 0; //Initialize binhold varible
            for (int i = 0; i <= 1; i++) //Initialize for loop
            {
                if (inpArr[1 - i] == 'A') //Check if value is A
                {
                    binhold = 10; //Change output to equaivilent number
                }
                else if (inpArr[1 - i] == 'B') //Check if value is B
                {
                    binhold = 11; //Change output to quavuilanet number
                }
                else if (inpArr[1 - i] == 'C') //Check if value is C
                {
                    binhold = 12; //Change output to equaivilent number
                }
                else if (inpArr[1 - i] == 'D') //Check if value is D
                {
                    binhold = 13; //Change output to equaivilent number
                }
                else if (inpArr[1 - i] == 'E') //Check if value is E
                {
                    binhold = 14; //Change output to equaivilent number
                }
                else if (inpArr[1 - i] == 'F') //Check if value is F
                {
                    binhold = 15; //Change output to equaivilent number
                }
                else //If NOT a letter
                {
                    binhold = inpArr[1 - i] - '0'; //change array value into double
                }

                binhold = binhold * Math.Pow(16, i); //Multiply value by power of 16
                inl = binhold + inl; //update output
            }
            int binar = (int) inl;
            for (int i = 0; i <= 7; i++) //Initialize for loop to change into binary
            {
                cat[7 - i] = binar % 2; //put remainder in array
                binar = binar / 2;      //update input
            }
            textBox6.Text = cat[0].ToString() + cat[1].ToString() + cat[2].ToString() + cat[3].ToString() +
                cat[4].ToString() + cat[5].ToString() + cat[6].ToString() + cat[7].ToString(); //output data to textbox
        }
        private void button5_Click(object sender, EventArgs e) //Hexadecimal to Decimal
        {
            double inl = 0; //create double var
            char[] inpArr = textBox5.Text.ToArray<char>(); //parse into array
            double binhold = 0; //Initialize binhold varible
            for (int i = 0; i <= 1; i++) //Initialize for loop
            {
                if (inpArr[1 - i] == 'A') //Check if value is A
                {
                    binhold = 10; //Change output to equaivilent number
                }
                else if (inpArr[1 - i] == 'B') //Check if value is B
                {
                    binhold = 11; //Change output to quavuilanet number
                }
                else if (inpArr[1 - i] == 'C') //Check if value is C
                {
                    binhold = 12; //Change output to equaivilent number
                }
                else if (inpArr[1 - i] == 'D') //Check if value is D
                {
                    binhold = 13; //Change output to equaivilent number
                }
                else if (inpArr[1 - i] == 'E') //Check if value is E
                {
                    binhold = 14; //Change output to equaivilent number
                }
                else if (inpArr[1 - i] == 'F') //Check if value is F
                {
                    binhold = 15; //Change output to equaivilent number
                }
                else //If NOT a letter
                {
                    binhold = inpArr[1 - i] - '0'; //change array value into double
                }

                binhold = binhold * Math.Pow(16, i); //Multiply value by power of 16
                inl = binhold + inl; //update output
            }
            textBox6.Text = inl.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
    }
}
