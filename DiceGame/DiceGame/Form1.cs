using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceGame
{
    public partial class Form1 : Form
    {
        private const int MAX_PLAYERS = 12;
        private Player[] playerArray = new Player[MAX_PLAYERS];
        int player_amount = 0;
        int players_printed = 0;

        Random ran = new Random();
        int[] num = new int[5];
        Image[] imgs = new Image[6];
        PictureBox[] picBoxes = new PictureBox[5];
        int result = 0;
        public Form1()
        {
            InitializeComponent();

            buttonStart.Enabled = false;
            buttonSave.Enabled = false;

            imgs[0] = Image.FromFile("C:/temp1/images/dice1.png");
            imgs[1] = Image.FromFile("C:/temp1/images/dice2.png");
            imgs[2] = Image.FromFile("C:/temp1/images/dice3.png");
            imgs[3] = Image.FromFile("C:/temp1/images/dice4.png");
            imgs[4] = Image.FromFile("C:/temp1/images/dice5.png");
            imgs[5] = Image.FromFile("C:/temp1/images/dice6.png");

            picBoxes[0] = pictureBox1;
            picBoxes[1] = pictureBox2;
            picBoxes[2] = pictureBox3;
            picBoxes[3] = pictureBox4;
            picBoxes[4] = pictureBox5;

            foreach(PictureBox p in picBoxes)
            {
                p.Image = imgs[0];
                p.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            for (int i = 0; i < MAX_PLAYERS; ++i)
            {
                playerArray[i] = new Player();
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                result = 0;
                for (int i = 0; i < 5; i++)
                {
                    num[i] = ran.Next(6);
                    result = result + num[i] + 1;
                }
                buttonSave.Enabled = true;
                displayDice();
            }
        }
        private void displayDice()
        {
            for(int i = 0; i < 5; i++)
            {
                picBoxes[i].Image = imgs[num[i]];
            }
  
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            playerArray[player_amount].saveInfo(textBox1.Text, result);
            player_amount++;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            result = 0;
            buttonSave.Enabled = false;
            if(textBox1.Text != "")
            {
                buttonStart.Enabled = true;
            }
            else
            {
                buttonStart.Enabled = false;
            }
        }

        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            for (int i = players_printed; i < player_amount; i++)
            {
                textBoxList.AppendText(playerArray[i].getName() + " - " + playerArray[i].getScore().ToString() + "\n");
                players_printed++;
            }
        }
    }
}
