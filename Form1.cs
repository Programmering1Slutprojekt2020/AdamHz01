using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mastermind
{
    public partial class Form1 : Form
    {
        int[] combination = new int[4];    //correct combination
        int i;
        Random random = new Random();      
        int selectcolor = 0;              //integer used in switch for primary answers
        int UserTry = 0;                  //integer for user answer history

        int[] attempt = new int[4];          //users selected combination 
        



        public Form1()
        {
            
            InitializeComponent();
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            for (i = 0; i < 4; i++)               //Creates the correct answer
            {
                combination[i] = random.Next(1,6);
                listBox1.Items.Add(combination[i]);       //will not be used in final version 
            }
            //Removes start button
            Start_btn.Text = ""; 
            Start_btn.Visible = false;
            timer1.Enabled = true; 
            Color1_btn.FlatAppearance.BorderSize = 3;
            Color2_btn.FlatAppearance.BorderSize = 3;
            Color3_btn.FlatAppearance.BorderSize = 3;
            Color4_btn.FlatAppearance.BorderSize = 3;


            Color1_btn.FlatAppearance.BorderColor = Color.Red; //Marks start position



        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }

       

        private void Color1_btn_Click(object sender, EventArgs e)
        {

        }

        private void Select_btn_Click(object sender, EventArgs e) //Shared commandcenter for color options
        {
            Button btn = (Button)sender; 
            //Typecast sender to button
            //Used to be able to reach button information in switch
            

            selectcolor++;
            switch (selectcolor)  //Fills users primary answer accordingly
            {
                case 1:
                    Color1_btn.BackColor = btn.BackColor;
                    btn.FlatAppearance.BorderColor = Color.Red;         
                    Color1_btn.FlatAppearance.BorderColor = Color.Black;
                    Color2_btn.FlatAppearance.BorderColor = Color.Red;    //Shows next box to fill
                    break;
                case 2:
                    Color2_btn.BackColor = btn.BackColor;

                    Color2_btn.FlatAppearance.BorderColor = Color.Black;
                    Color3_btn.FlatAppearance.BorderColor = Color.Red;
                    
                    break;
                case 3:
                    Color3_btn.BackColor = btn.BackColor;

                    Color3_btn.FlatAppearance.BorderColor = Color.Black;
                    Color4_btn.FlatAppearance.BorderColor = Color.Red;
                    break;
                case 4:
                    Color4_btn.BackColor = btn.BackColor;
                    Color4_btn.FlatAppearance.BorderColor = Color.Black;
                    Color1_btn.FlatAppearance.BorderColor = Color.Red;
                    break;
            }
            
            if (selectcolor == 4) //One square blank will create program failure
            {
                selectcolor = 0;
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e) //Clears the primary answer
        {
            Color1_btn.BackColor = Color.Transparent; 
            Color2_btn.BackColor = Color.Transparent;
            Color3_btn.BackColor = Color.Transparent;
            Color4_btn.BackColor = Color.Transparent;
            Color1_btn.FlatAppearance.BorderColor = Color.Red;
            Color2_btn.FlatAppearance.BorderColor = Color.Black;
            Color3_btn.FlatAppearance.BorderColor = Color.Black;
            Color4_btn.FlatAppearance.BorderColor = Color.Black;
            selectcolor = 0;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            
         

        }

        static int Colortranslate(Color backcolor) //Mehod for translating colors to numbers
        {
            if (backcolor == Color.Blue) { return 1; }
            if (backcolor == Color.Lime) { return 2; }
            if (backcolor == Color.Yellow) { return 3; }
            if (backcolor == Color.Red) { return 4; }
            if (backcolor == Color.Purple) { return 5; }
            else { return 0; }
        }

        private void Done_btn_Click(object sender, EventArgs e)
        {
            attempt[0] = Colortranslate(Color1_btn.BackColor); //fills try1 with numbers
            attempt[1] = Colortranslate(Color2_btn.BackColor);
            attempt[2] = Colortranslate(Color3_btn.BackColor);
            attempt[3] = Colortranslate(Color4_btn.BackColor);
            
            UserTry++;
            switch (UserTry)
            {
                case 1:
                    

                    code1_btn1.BackColor = Color1_btn.BackColor;  //when Done is clicked code combination is chosen and displayed
                    code1_btn2.BackColor = Color2_btn.BackColor;
                    code1_btn3.BackColor = Color3_btn.BackColor;
                    code1_btn4.BackColor = Color4_btn.BackColor;
                    break;
                case 2:
                    
                    code2_btn1.BackColor = Color1_btn.BackColor;  
                    code2_btn2.BackColor = Color2_btn.BackColor;
                    code2_btn3.BackColor = Color3_btn.BackColor;
                    code2_btn4.BackColor = Color4_btn.BackColor;
                    break;
                case 3:
                    code3_btn1.BackColor = Color1_btn.BackColor; 
                    code3_btn2.BackColor = Color2_btn.BackColor;
                    code3_btn3.BackColor = Color3_btn.BackColor;
                    code3_btn4.BackColor = Color4_btn.BackColor;
                    break;
                case 4:
                    code4_btn1.BackColor = Color1_btn.BackColor;
                    code4_btn2.BackColor = Color2_btn.BackColor;
                    code4_btn3.BackColor = Color3_btn.BackColor;
                    code4_btn4.BackColor = Color4_btn.BackColor;
                    break;
                case 5:
                    code5_btn1.BackColor = Color1_btn.BackColor;
                    code5_btn2.BackColor = Color2_btn.BackColor;
                    code5_btn3.BackColor = Color3_btn.BackColor;
                    code5_btn4.BackColor = Color4_btn.BackColor;
                    break;
                case 6:
                    code6_btn1.BackColor = Color1_btn.BackColor;
                    code6_btn2.BackColor = Color2_btn.BackColor;
                    code6_btn3.BackColor = Color3_btn.BackColor;
                    code6_btn4.BackColor = Color4_btn.BackColor;
                    break;
                case 7:
                    code7_btn1.BackColor = Color1_btn.BackColor;
                    code7_btn2.BackColor = Color2_btn.BackColor;
                    code7_btn3.BackColor = Color3_btn.BackColor;
                    code7_btn4.BackColor = Color4_btn.BackColor;
                    break;
                case 8:
                    code8_btn1.BackColor = Color1_btn.BackColor;
                    code8_btn2.BackColor = Color2_btn.BackColor;
                    code8_btn3.BackColor = Color3_btn.BackColor;
                    code8_btn4.BackColor = Color4_btn.BackColor;
                    break;


            }



           



            for (int i = 0; i < 4; i++)
            {
                listBox2.Items.Add(attempt[i]); //will not be used in final version
            }

        }
    }
}
