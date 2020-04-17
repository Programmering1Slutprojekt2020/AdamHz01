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
        int[] combination = new int[4];
        int i;
        Random slumptal = new Random();
        int selectcolor = 0;

        int[] try1 = new int[4];
        int plats = 0;



        public Form1()
        {
            
            InitializeComponent();
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            for (i = 0; i < 4; i++)
            {
                combination[i] = slumptal.Next(1,6);
                listBox1.Items.Add(combination[i]);
            }
            
            Start_btn.Text = "";
            Start_btn.Visible = false;
            timer1.Enabled = true; 
            Color1_btn.FlatAppearance.BorderSize = 3;
            Color2_btn.FlatAppearance.BorderSize = 3;
            Color3_btn.FlatAppearance.BorderSize = 3;
            Color4_btn.FlatAppearance.BorderSize = 3;


            Color1_btn.FlatAppearance.BorderColor = Color.Red; //markerar startposition



        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void Blue_btn_Click(object sender, EventArgs e)
        {
            Blue_btn.Size = new Size(height:50, width:50);
            switch (selectcolor)
            {
                case 1:
                    Color1_btn.BackColor = Color.Blue;
                    break;
                case 2:
                    Color2_btn.BackColor = Color.Blue;
                    Blue_btn.FlatAppearance.BorderColor = Color.DarkRed;
                    break;
            }
            Color1_btn.BackColor = Color.Blue;

        }

        private void Color1_btn_Click(object sender, EventArgs e)
        {

        }

        private void Select_btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            

            selectcolor++;
            switch (selectcolor)
            {
                case 1:
                    Color1_btn.BackColor = btn.BackColor;
                    btn.FlatAppearance.BorderColor = Color.Red;
                    Color1_btn.FlatAppearance.BorderColor = Color.Black;
                    Color2_btn.FlatAppearance.BorderColor = Color.Red;
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
            
            if (selectcolor == 4)
            {
                selectcolor = 0;
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
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

        static int colortranslate(Color backcolor)
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
            try1[0] = colortranslate(Color1_btn.BackColor);
            try1[1] = colortranslate(Color2_btn.BackColor);
            try1[2] = colortranslate(Color3_btn.BackColor);
            try1[3] = colortranslate(Color4_btn.BackColor);

            kod1_btn1.BackColor = Color1_btn.BackColor;
            kod1_btn2.BackColor = Color2_btn.BackColor;
            kod1_btn3.BackColor = Color3_btn.BackColor;
            kod1_btn4.BackColor = Color4_btn.BackColor;



            /*
            if (Color1_btn.BackColor == Blue_btn.BackColor)
            {
                kod1[plats] = 1;
                kod1_btn1.BackColor = Blue_btn.BackColor;

            }
            if (Color1_btn.BackColor == Green_btn.BackColor)
            {
                kod1[plats] = 2;
                kod1_btn1.BackColor = Green_btn.BackColor;
            }
            if (Color1_btn.BackColor == Yellow_btn.BackColor)
            {
                kod1[plats] = 3;
                kod1_btn1.BackColor = Yellow_btn.BackColor;
            }
            if (Color1_btn.BackColor == Red_btn.BackColor)
            {
                kod1[plats] = 4;
                kod1_btn1.BackColor = Red_btn.BackColor;
            }
            if (Color1_btn.BackColor == Purple_btn.BackColor)
            {
                kod1[plats] = 5;
                kod1_btn1.BackColor = Purple_btn.BackColor;
            }
            plats++;

            if (Color2_btn.BackColor == Blue_btn.BackColor)
            {
                kod1[plats] = 1;
                kod1_btn2.BackColor = Blue_btn.BackColor;


            }
            if (Color2_btn.BackColor == Green_btn.BackColor)
            {
                kod1[plats] = 2;
                kod1_btn2.BackColor = Green_btn.BackColor;
            }
            if (Color2_btn.BackColor == Yellow_btn.BackColor)
            {
                kod1[plats] = 3;
                kod1_btn2.BackColor = Yellow_btn.BackColor;
            }
            if (Color2_btn.BackColor == Red_btn.BackColor)
            {
                kod1[plats] = 4;
                kod1_btn2.BackColor = Red_btn.BackColor;
            }
            if (Color2_btn.BackColor == Purple_btn.BackColor)
            {
                kod1[plats] = 5;
                kod1_btn2.BackColor = Purple_btn.BackColor;
            }
            plats++;

            if (Color3_btn.BackColor == Blue_btn.BackColor)
            {
                kod1[plats] = 1;
                kod1_btn3.BackColor = Blue_btn.BackColor;
            }
            if (Color3_btn.BackColor == Green_btn.BackColor)
            {
                kod1[plats] = 2;
                kod1_btn3.BackColor = Green_btn.BackColor;
            }
            if (Color3_btn.BackColor == Yellow_btn.BackColor)
            {
                kod1[plats] = 3;
                kod1_btn3.BackColor = Yellow_btn.BackColor;
            }
            if (Color3_btn.BackColor == Red_btn.BackColor)
            {
                kod1[plats] = 4;
                kod1_btn3.BackColor = Red_btn.BackColor;
            }
            if (Color3_btn.BackColor == Purple_btn.BackColor)
            {
                kod1[plats] = 5;
                kod1_btn3.BackColor = Purple_btn.BackColor;
            }
            plats++;
            if (Color4_btn.BackColor == Blue_btn.BackColor)
            {
                kod1[plats] = 1;
                kod1_btn4.BackColor = Blue_btn.BackColor;
            }
            if (Color4_btn.BackColor == Green_btn.BackColor)
            {
                kod1[plats] = 2;
                kod1_btn4.BackColor = Green_btn.BackColor;
            }
            if (Color4_btn.BackColor == Yellow_btn.BackColor)
            {
                kod1[plats] = 3;
                kod1_btn4.BackColor = Yellow_btn.BackColor;
            }
            if (Color4_btn.BackColor == Red_btn.BackColor)
            {
                kod1[plats] = 4;
                kod1_btn4.BackColor = Red_btn.BackColor;
            }

            if (Color4_btn.BackColor == Purple_btn.BackColor)
            {
                kod1[plats] = 5;
                kod1_btn4.BackColor = Purple_btn.BackColor;
            }*/




            for (int i = 0; i < 4; i++)
            {
                listBox2.Items.Add(try1[i]);
            }

        }
    }
}
