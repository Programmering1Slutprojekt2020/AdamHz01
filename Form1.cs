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
        bool[] correct_position = new bool[4];
        bool debug = false;  //If problems occur set debug true
              
                
        Random random = new Random();      
        int selectcolor = 0;              //integer used in switch for primary answers
        int UserTry = 0;                  //integer for user answer history
        

        int[] attempt = new int[4];          //users selected combination 
                    
                
        public Form1()
        {
            
            InitializeComponent();
            numericUpDown1.Controls.RemoveAt(0);  //remove up-down arrows
            numericUpDown2.Controls.RemoveAt(0);
            numericUpDown3.Controls.RemoveAt(0);
            numericUpDown4.Controls.RemoveAt(0);
            numericUpDown5.Controls.RemoveAt(0);
            numericUpDown6.Controls.RemoveAt(0);
            numericUpDown7.Controls.RemoveAt(0);
            numericUpDown8.Controls.RemoveAt(0);
            numericUpDown9.Controls.RemoveAt(0);
            numericUpDown10.Controls.RemoveAt(0);
            numericUpDown11.Controls.RemoveAt(0);
            numericUpDown12.Controls.RemoveAt(0);
            numericUpDown13.Controls.RemoveAt(0);
            numericUpDown14.Controls.RemoveAt(0);
            numericUpDown15.Controls.RemoveAt(0);
            numericUpDown16.Controls.RemoveAt(0);
            

            panel1.Visible = false;
            panel2.Visible = false;
           
            

            Timer_seconds.Controls.RemoveAt(0);
            Timer_minutes.Controls.RemoveAt(0);

            timer1.Interval = 1000;

            if (debug == false)
            {
                listBox1.Visible = false;
                listBox2.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                

            }
            if (debug == true)
            {
                listBox1.Visible = true;
                listBox2.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
            }

            Done_btn.Enabled = false; //disable buttons until start is clicked
            Blue_btn.Enabled = false;
            Yellow_btn.Enabled = false;
            Green_btn.Enabled = false;
            Red_btn.Enabled = false;
            Blue_btn.Enabled = false;
            Purple_btn.Enabled = false;
        }
       

        private void Start_btn_Click(object sender, EventArgs e)
        {
            

            for (int i = 0; i < 4; i++)               //Creates the correct answer
            {
                combination[i] = random.Next(1,6);
                listBox1.Items.Add(combination[i]);       
            }
            //Removes start button
            Start_btn.Text = ""; 
            Start_btn.Visible = false;
            
            timer1.Enabled = false; 
            Color1_btn.FlatAppearance.BorderSize = 3;
            Color2_btn.FlatAppearance.BorderSize = 3;
            Color3_btn.FlatAppearance.BorderSize = 3;
            Color4_btn.FlatAppearance.BorderSize = 3;


            Color1_btn.FlatAppearance.BorderColor = Color.Red; //Marks start position

            timer1.Start();
            Blue_btn.Enabled = true;
            Yellow_btn.Enabled = true;
            Green_btn.Enabled = true;
            Red_btn.Enabled = true;
            Blue_btn.Enabled = true;
            Purple_btn.Enabled = true;

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
                    Done_btn.Enabled = true;
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
            Done_btn.Enabled = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Timer_seconds.Value += 1;
            if (Timer_seconds.Value == 60)
            {
                Timer_minutes.Value += 1;
                Timer_seconds.Value = 0;
            }
         

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
        static Color Numbertranslate(int color)//method for diplaying the correct combination
        {
            if (color == 1) { return Color.Blue; }
            if (color == 2) { return Color.Lime; }
            if (color == 3) { return Color.Yellow; }
            if (color == 4) { return Color.Red; }
            if (color == 5) { return Color.Purple; }
            else { return Color.White; }
            
        }

        private void Done_btn_Click(object sender, EventArgs e)
        {
            
            
            attempt[0] = Colortranslate(Color1_btn.BackColor); //fills attempt with numbers
            attempt[1] = Colortranslate(Color2_btn.BackColor);
            attempt[2] = Colortranslate(Color3_btn.BackColor);
            attempt[3] = Colortranslate(Color4_btn.BackColor);
            
            button1.BackColor = Numbertranslate(combination[0]);
            button2.BackColor = Numbertranslate(combination[1]);
            button3.BackColor = Numbertranslate(combination[2]);
            button4.BackColor = Numbertranslate(combination[3]);

            






            UserTry++;
            switch (UserTry)
            {
                case 1:


                    code1_btn1.BackColor = Color1_btn.BackColor;  //when Done is clicked code combination is chosen and displayed
                    code1_btn2.BackColor = Color2_btn.BackColor;
                    code1_btn3.BackColor = Color3_btn.BackColor;
                    code1_btn4.BackColor = Color4_btn.BackColor;
                    numericUpDown9.Value = Check_right_place(correct_position, attempt, combination);          //Checks which positions already been filled with correct color
                    numericUpDown1.Value = Check_right_color(correct_position, combination, attempt);          //Checks which colors have been misplaced 
                    panel1.Visible = win_method(numericUpDown9.Value);                                         //if player guess all 4 colors correct
                    if (panel1.Visible == true)
                    {
                        Time_finnish.Text = "0" + Timer_minutes.Value + ": " + Timer_seconds.Value;            //Scoreboard
                        Attempts_finnish.Text = UserTry.ToString();                                            //scoreboard
                        timer1.Stop();
                        
                    }
                    Done_btn.Enabled = false;
                    break;
                case 2:

                    code2_btn1.BackColor = Color1_btn.BackColor;
                    code2_btn2.BackColor = Color2_btn.BackColor;
                    code2_btn3.BackColor = Color3_btn.BackColor;
                    code2_btn4.BackColor = Color4_btn.BackColor;
                    numericUpDown10.Value = Check_right_place(correct_position, attempt, combination);
                    numericUpDown2.Value = Check_right_color(correct_position, combination, attempt);
                    panel1.Visible = win_method(numericUpDown10.Value);
                    if (panel1.Visible == true)
                    {
                        Time_finnish.Text = "0" + Timer_minutes.Value + ": " + Timer_seconds.Value;
                        Attempts_finnish.Text = UserTry.ToString();
                        timer1.Stop();

                    }
                    Done_btn.Enabled = false;

                    break;
                case 3:
                    code3_btn1.BackColor = Color1_btn.BackColor;
                    code3_btn2.BackColor = Color2_btn.BackColor;
                    code3_btn3.BackColor = Color3_btn.BackColor;
                    code3_btn4.BackColor = Color4_btn.BackColor;
                    numericUpDown11.Value = Check_right_place(correct_position, attempt, combination);
                    numericUpDown3.Value = Check_right_color(correct_position, combination, attempt);
                    panel1.Visible = win_method(numericUpDown11.Value);
                    if (panel1.Visible == true)
                    {
                        Time_finnish.Text = "0" + Timer_minutes.Value + ": " + Timer_seconds.Value;
                        Attempts_finnish.Text = UserTry.ToString();
                        timer1.Stop();

                    }
                    Done_btn.Enabled = false;

                    break;
                case 4:
                    code4_btn1.BackColor = Color1_btn.BackColor;
                    code4_btn2.BackColor = Color2_btn.BackColor;
                    code4_btn3.BackColor = Color3_btn.BackColor;
                    code4_btn4.BackColor = Color4_btn.BackColor;
                    numericUpDown12.Value = Check_right_place(correct_position, attempt, combination);
                    numericUpDown4.Value = Check_right_color(correct_position, combination, attempt);
                    panel1.Visible = win_method(numericUpDown12.Value);
                    if (panel1.Visible == true)
                    {
                        Time_finnish.Text = "0" + Timer_minutes.Value + ": " + Timer_seconds.Value;
                        Attempts_finnish.Text = UserTry.ToString();
                        timer1.Stop();

                    }
                    Done_btn.Enabled = false;

                    break;
                case 5:
                    code5_btn1.BackColor = Color1_btn.BackColor;
                    code5_btn2.BackColor = Color2_btn.BackColor;
                    code5_btn3.BackColor = Color3_btn.BackColor;
                    code5_btn4.BackColor = Color4_btn.BackColor;
                    numericUpDown13.Value = Check_right_place(correct_position, attempt, combination);
                    numericUpDown5.Value = Check_right_color(correct_position, combination, attempt);
                    panel1.Visible = win_method(numericUpDown13.Value);
                    if (panel1.Visible == true)
                    {
                        Time_finnish.Text = "0" + Timer_minutes.Value + ": " + Timer_seconds.Value;
                        Attempts_finnish.Text = UserTry.ToString();
                        timer1.Stop();

                    }
                    Done_btn.Enabled = false;

                    break;
                case 6:
                    code6_btn1.BackColor = Color1_btn.BackColor;
                    code6_btn2.BackColor = Color2_btn.BackColor;
                    code6_btn3.BackColor = Color3_btn.BackColor;
                    code6_btn4.BackColor = Color4_btn.BackColor;
                    numericUpDown14.Value = Check_right_place(correct_position, attempt, combination);
                    numericUpDown6.Value = Check_right_color(correct_position, combination, attempt);
                    panel1.Visible = win_method(numericUpDown14.Value);
                    if (panel1.Visible == true)
                    {
                        Time_finnish.Text = "0" + Timer_minutes.Value + ": " + Timer_seconds.Value;
                        Attempts_finnish.Text = UserTry.ToString();
                        timer1.Stop();

                    }
                    Done_btn.Enabled = false;


                    break;
                case 7:
                    code7_btn1.BackColor = Color1_btn.BackColor;
                    code7_btn2.BackColor = Color2_btn.BackColor;
                    code7_btn3.BackColor = Color3_btn.BackColor;
                    code7_btn4.BackColor = Color4_btn.BackColor;
                    numericUpDown15.Value = Check_right_place(correct_position, attempt, combination);
                    numericUpDown7.Value = Check_right_color(correct_position, combination, attempt);
                    panel1.Visible = win_method(numericUpDown15.Value);
                    if (panel1.Visible == true)
                    {
                        Time_finnish.Text = "0" + Timer_minutes.Value + ": " + Timer_seconds.Value;
                        Attempts_finnish.Text = UserTry.ToString();
                        timer1.Stop();

                    }
                    Done_btn.Enabled = false;

                    break;
                case 8:
                    code8_btn1.BackColor = Color1_btn.BackColor;
                    code8_btn2.BackColor = Color2_btn.BackColor;
                    code8_btn3.BackColor = Color3_btn.BackColor;
                    code8_btn4.BackColor = Color4_btn.BackColor;
                    numericUpDown16.Value = Check_right_place(correct_position, attempt, combination);              
                    numericUpDown8.Value = Check_right_color(correct_position, combination, attempt);
                    panel1.Visible = win_method(numericUpDown16.Value);
                    if (panel1.Visible == true)
                    {
                        Time_finnish.Text = "0" + Timer_minutes.Value + ": " + Timer_seconds.Value;
                        Attempts_finnish.Text = UserTry.ToString();
                        timer1.Stop();

                    }
                    else
                    {
                        panel2.Visible = true;
                    }
                    Done_btn.Enabled = false;

                    break;

                    

                    
            }

            Color1_btn.BackColor = Color.Transparent;
            Color2_btn.BackColor = Color.Transparent;
            Color3_btn.BackColor = Color.Transparent;
            Color4_btn.BackColor = Color.Transparent;
            Color1_btn.FlatAppearance.BorderColor = Color.Red;
            Color2_btn.FlatAppearance.BorderColor = Color.Black;
            Color3_btn.FlatAppearance.BorderColor = Color.Black;
            Color4_btn.FlatAppearance.BorderColor = Color.Black;
            selectcolor = 0;







            for (int i = 0; i < 4; i++)
            {
                listBox2.Items.Add(attempt[i]); //will not be used in final version
            }
        }
        static int Check_right_place(bool[] correct_position, int[] attempt, int[] combination)
        {
            int correct_color_correct_place = 0;
            for (int i = 0; i < 4; i++)
            {
                if (combination[i] == attempt[i])
                {
                    correct_position[i] = true;
                    correct_color_correct_place++;
                }
                else { correct_position[i] = false; }

            }
            return correct_color_correct_place;

        }

        static int Check_right_color(bool[] correct_position, int[] combination, int[] attempt)
        {
            int check = 0;
            int correct_color_wrong_position=0;
            
            for (check = 1; check < 5; check++)
            {
                switch (check)
                {
                    case 1:

                        if (correct_position[0] == true) { break; }
                        else
                        {
                            for (int i = 1; i < 4; i++)
                            {
                                if (combination[0] == attempt[i])
                                {
                                    if (correct_position[i] == true) { }
                                    else { correct_color_wrong_position++; break; }
                                }


                            }

                        }
                        break;
                    case 2:
                        if (correct_position[1] == true) { break; }
                        else
                        {
                            for (int i = 2; i < 4; i++)
                            {

                                if (combination[1] == attempt[i])
                                {
                                    if (correct_position[i] == true) { }
                                    else { correct_color_wrong_position++; break; }
                                }

                                if (i == 0) { break; }
                                if (i == 3) { i = -1; }

                            }

                        }
                        break;
                    case 3:
                        if (correct_position[2] == true) { break; }
                        else
                        {
                            for (int i = 3; i < 4; i++)
                            {

                                if (combination[2] == attempt[i])
                                {
                                    if (correct_position[i] == true) { }
                                    else { correct_color_wrong_position++; break; }
                                }
                                else { }
                                if (i == 3) { i = -1; }
                                if (i == 1) { break; }
                            }

                        }
                        break;
                    case 4:
                        if (correct_position[3] == true) { break; }
                        else
                        {
                            for (int i = 0; i < 3; i++)
                            {

                                if (combination[3] == attempt[i])
                                {
                                    if (correct_position[i] == true) { }
                                    else { correct_color_wrong_position++; break; }
                                }
                                else { }


                            }

                        }
                        break;
                }

            }
            return correct_color_wrong_position;

        }
        static bool win_method (Decimal correct_color_correct_place)
        {
            if (correct_color_correct_place == 4)
            {
                return true;
                
            }

            else
            {
                return false;
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Your_time_Click(object sender, EventArgs e)
        {

        }

        private void Panel2_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            
        }

        private void Start_lbl_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
