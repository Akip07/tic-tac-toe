﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            int i = 0;
            while(i>wasPressed.Length)
            {
                wasPressed[i] = false;
            }
            ButtonArray = Controls
            .OfType<Button>()
            .ToArray();
            Array.Reverse(ButtonArray);
            foreach  (Button button in ButtonArray)
            {
                button.Text = (Convert.ToString(i++));
            }
        }
        int turn = 0;
        bool[] wasPressed = new bool[9];
        Button[] ButtonArray;
        int gameCount = 1;
        int winsX, winsO = 0;

        void ButtonAction(int btn)
        {
            
            {
                if (wasPressed[btn - 1]==false && timer1.Enabled==true)
                {
                    wasPressed[btn - 1] = true;
                    if(turn%2==0)
                        ButtonArray[btn - 1].Text = "X";
                    else
                        ButtonArray[btn - 1].Text = "O";
                    turn++;
                    string winner = CheckWin();
                    WriteWinner(winner);
                }
               
            }
           
        }
        string CheckWin()
        {
            for (int j = 0; j <7; j+=3)
                if (ButtonArray[j+1].Text== ButtonArray[j].Text && ButtonArray[j+2].Text== ButtonArray[j].Text)
                {
                   return ButtonArray[j].Text;
                    
                }
           for(int j=0; j<3; j++)
            {
                if (ButtonArray[j].Text == ButtonArray[j+3].Text && ButtonArray[j].Text == ButtonArray[j+6].Text)
                {
                    return ButtonArray[j].Text;
                }
            }
            if (ButtonArray[0].Text == ButtonArray[4].Text && ButtonArray[0].Text == ButtonArray[8].Text)
            {
                return ButtonArray[0].Text;
            }
            else if (ButtonArray[2].Text == ButtonArray[4].Text && ButtonArray[2].Text == ButtonArray[6].Text)
            {
                return ButtonArray[2].Text;
            }
            else
                return null;
        }
        void UpdateWinnerCount (string winner)
        {
            if (winner == "X")
            {
                winsX += 1;
                xWinCount.Text = Convert.ToString(winsX);
            }
            else if (winner == "O")
            {
                winsO += 1;
                oWinCount.Text = Convert.ToString(winsO);
            }
            
        }
        void WriteWinner(string winner)
        {
            if (winner != null)
            {
                timer1.Stop();
                Console.WriteLine(winner + " Wins");
                winnerLabel.Text = "WINNER: " + winner;
                winnerLabel.Visible = true;
                UpdateWinnerCount(winner);
                return;
            }
        }
        



        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine(turn);
            label1.Text = "Turn:\n   "+Convert.ToString(turn);
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            GameCountLabel.Text = "GAME:\n    " + Convert.ToString(gameCount);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonAction(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ButtonAction(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ButtonAction(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ButtonAction(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ButtonAction(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ButtonAction(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ButtonAction(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ButtonAction(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ButtonAction(9);
            
        }

        


        private void winnerLabel_Click(object sender, EventArgs e)
        {
            turn = 0;
            int i = 0;
            foreach (Button button in ButtonArray)
            {
                button.Text = (Convert.ToString(i++));
            }
            for(int j=0; j< wasPressed.Length;j++)
            {
                wasPressed[j] = false;
            }
            winnerLabel.Visible = false;
            gameCount++;
            GameCountLabel.Text = "GAME:\n     "+Convert.ToString(gameCount);
            timer1.Start();
        }
    }
}
