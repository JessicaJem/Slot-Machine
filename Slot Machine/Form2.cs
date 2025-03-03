using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Slot_Machine
{
    public partial class Form2 : Form
    {
        string connectionstring = @"Data Source = databasecoins.db; Version = 3; FailIfMissing = True";
        SQLiteConnection conn;
        //Create arrays of picture boxexs for all the columns
        PictureBox[] sthlh = new PictureBox[6];
        PictureBox[] sthlh2 = new PictureBox[6];
        PictureBox[] sthlh3 = new PictureBox[6];
        PictureBox[] sthlh4 = new PictureBox[6];
        PictureBox[] sthlh5 = new PictureBox[6];
        PictureBox[] sthlh6 = new PictureBox[6];
        Random random1 = new Random(); //New object random for every column
        Random random2 = new Random();
        Random random3 = new Random();
        Random random4 = new Random();
        Random random5 = new Random();
        Random random6 = new Random();

        public Form2(Form1 form1)
        {
            InitializeComponent();
            sthlh[0] = seven1; //initialization of arrays
            sthlh[1] = lemon1;
            sthlh[2] = karpouzi1;
            sthlh[3] = kerasi1;
            sthlh[4] = stafyli1;
            sthlh[5] = fraoula1;
            sthlh2[0] = seven2;
            sthlh2[1] = kerasi2;
            sthlh2[2] = lemon2;
            sthlh2[3] = karpouzi2;
            sthlh2[4] = stafyli2;
            sthlh2[5] = fraoula2;
            sthlh3[0] = seven3;
            sthlh3[1] = karpouzi3;
            sthlh3[2] = kerasi3;
            sthlh3[3] = lemon3;
            sthlh3[4] = stafyli3;
            sthlh3[5] = fraoula3;
            sthlh4[0] = seven4;
            sthlh4[1] = lemon4;
            sthlh4[2] = karpouzi4;
            sthlh4[3] = kerasi4;
            sthlh4[4] = stafyli4;
            sthlh4[5] = fraoula4;
            sthlh5[0] = seven5;
            sthlh5[1] = lemon5;
            sthlh5[2] = karpouzi5;
            sthlh5[3] = kerasi5;
            sthlh5[4] = stafyli5;
            sthlh5[5] = fraoula5;
            sthlh6[0] = seven6;
            sthlh6[1] = kerasi6;
            sthlh6[2] = lemon6;
            sthlh6[3] = karpouzi6;
            sthlh6[4] = stafyli6;
            sthlh6[5] = fraoula6;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) //checking if the user hasn't entered his coins
            {
                MessageBox.Show("Please enter your coins to spin!");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))//checking if the user's input contains letters
            {
                MessageBox.Show("Please enter a valid number!");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - textBox1.Text.Length);//removing all the wrong input
            }
            else // input is a valid number
            {

                if (label1.Text.Length > 1)//checking if there's something in the label
                {
                    conn = new SQLiteConnection(connectionstring); //connecting with my sqlite database
                    try
                    {
                        using (var connection = new SQLiteConnection(connectionstring))
                        {
                            conn.Open();
                            SQLiteCommand cmd = new SQLiteCommand();
                            cmd.CommandText = @"INSERT INTO COINS (COINS_TAKEN,COINS_GIVEN) VALUES (@COINS_TAKEN , @COINS_GIVEN)";
                            cmd.Connection = conn;
                            using (var conn = new SQLiteConnection(connectionstring))
                            {
                                cmd.Parameters.Add(new SQLiteParameter("@COINS_TAKEN", textBox1.Text)); //adding data for the coins that the slot machine took from the playes
                                cmd.Parameters.Add(new SQLiteParameter("@COINS_GIVEN", label1.Text)); //adding data for the coins that the slot machine gave to the players

                                int i = cmd.ExecuteNonQuery();
                            }
                            conn.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    label1.Text = label1.Text.Remove(label1.Text.Length - label1.Text.Length);//removing text from label to use it for the next round
                }

                //enabling timers used for rolling the fruits
                timer1.Enabled = true;
                timer2.Enabled = true;
                timer3.Enabled = true;
                if (column1.Visible) //if the user wants more columns the procedure must be done for every column enabling their timer
                {
                    timer4.Enabled = true;
                }
                if (column2.Visible)
                {
                    timer5.Enabled = true;
                }
                if (column3.Visible)
                {
                    timer6.Enabled = true;
                }
            }

        }

        int counter = 0; //counts the number of times that the fruits change for a specific timeline(1st timer 1st column)
        int num = 0;//holds the position of the fruit in the array in order to be visible or not
        int sthl = 3; // initialization of the columns, changes every time that the player selects a different number from settings
        int frouta = 4; //initialization of the fruits, changes every time that the player selects a different number from settings
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter < 60) //timer will be enabled till counter hits 60
            {
                sthlh[num].Visible = false; //the visible picture will be invisible in order to take place another fruit
                num = random1.Next(0, frouta); //random number that picks a random position of the first array 
                sthlh[num].Visible = true; // the fruit in that random position will be now visible
                counter++; // adding up the counter (+1) in order to stop the timer and stop to a random fruit
            }
            else if (counter3 == 100) // when the last timer finishes its procedure its time for the results
            {
                timer1.Enabled = false; // disabling the timer to start over again through spin button
                counter = 0; // initializing the counter to start over the procedure
            }
        }

        int counter2 = 0; //repeating the proceedure for every timer
        int num2 = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (counter2 < 80)
            {
                sthlh2[num2].Visible = false;
                num2 = random2.Next(0, frouta);
                sthlh2[num2].Visible = true;
                counter2++;
            }
            else if (counter3 == 100)
            {
                timer2.Enabled = false;
                counter2 = 0;
            }
        }
        int counter3 = 0;
        int num3 = 0;

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (counter3 < 100)
            {
                sthlh3[num3].Visible = false;
                num3 = random3.Next(0, frouta);
                sthlh3[num3].Visible = true;
                counter3++;
            }
            else
            {
                timer3.Enabled = false;
                counter3 = 0;
                string coins = textBox1.Text; // saving the bet into a variable to calculate the results
                if (sthl == 3) //if the selected columns are 3
                {
                    if (seven1.Visible & seven2.Visible & seven3.Visible) //calculation of the winnings based on the bet and the number of columns
                    { //checking if there are any same visible picture boxes
                        label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 3).ToString();
                        MessageBox.Show("JACKPOT! Seems that today is your day! Lucky you!"); //whenever the numbers of 7s = the number of columns the player hits the jackpot
                    }//repeating all the procedure for every condition with different winnings 
                    else if ((seven1.Visible & seven2.Visible) || (seven1.Visible & seven3.Visible) || (seven2.Visible & seven3.Visible))
                    {
                        label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 2).ToString();
                    }
                    else if ((kerasi1.Visible & kerasi2.Visible & kerasi3.Visible) || (lemon1.Visible & lemon2.Visible & lemon3.Visible) ||
                        (karpouzi1.Visible & karpouzi2.Visible & karpouzi3.Visible))
                    {
                        label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 2).ToString();
                        MessageBox.Show("CONGRATULATIONS! Play again and you might hit the Jackpot!");
                    }
                    else if ((kerasi1.Visible & kerasi2.Visible) || (kerasi1.Visible & kerasi3.Visible) ||
                       (kerasi2.Visible & kerasi3.Visible) || (lemon1.Visible & lemon2.Visible) || (lemon1.Visible & lemon3.Visible) ||
                       (lemon2.Visible & lemon3.Visible) || (karpouzi1.Visible & karpouzi2.Visible) || (karpouzi1.Visible & karpouzi3.Visible) ||
                       karpouzi2.Visible & karpouzi3.Visible)
                    {
                        label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 1).ToString();
                    }

                    else
                    {
                        label1.Text = "YOU LOSE";   
                    }
                    if ((frouta == 5) || (frouta == 6)) //in case the player selects 5 or 6 fruits it needs to be added to the conditions so he can see if he won
                    {
                        if (stafyli1.Visible & stafyli2.Visible & stafyli3.Visible)
                        {
                            label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 2).ToString();
                            MessageBox.Show("CONGRATULATIONS! Play again and you might hit the Jackpot!");
                        }
                        else if ((stafyli1.Visible & stafyli2.Visible) || (stafyli1.Visible & stafyli3.Visible) || (stafyli2.Visible & stafyli3.Visible))
                        {
                            label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 1).ToString();
                        }
                    }
                    if (frouta == 6) //last condition if the player selects 6 fruits
                    {
                        if (fraoula1.Visible & fraoula2.Visible & fraoula3.Visible)
                        {
                            label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 2).ToString();
                            MessageBox.Show("CONGRATULATIONS! Play again and you might hit the Jackpot!");
                        }
                        else if ((fraoula1.Visible & fraoula2.Visible) || (fraoula1.Visible & fraoula3.Visible) || (fraoula2.Visible & fraoula3.Visible))
                        {
                            label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 1).ToString();
                        }
                    }
                }
                else if (sthl == 4) //repeating procedure for 4 columns
                {
                    if (seven1.Visible & seven2.Visible & seven3.Visible & seven4.Visible)
                    {
                        label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 4).ToString();
                        MessageBox.Show("JACKPOT! Seems that today is your day! Lucky you!");
                    }
                    else if ((seven4.Visible & seven1.Visible & seven2.Visible) || (seven1.Visible & seven2.Visible & seven3.Visible) ||
                        (seven4.Visible & seven2.Visible & seven3.Visible) || (seven4.Visible & seven1.Visible & seven3.Visible))
                    {
                        label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 3).ToString();
                    }
                    else if ((kerasi1.Visible & kerasi2.Visible & kerasi3.Visible & kerasi4.Visible) || (lemon1.Visible & lemon2.Visible & lemon3.Visible & lemon4.Visible) ||
                        (karpouzi1.Visible & karpouzi2.Visible & karpouzi3.Visible & karpouzi4.Visible))
                    {
                        label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 3).ToString();
                        MessageBox.Show("CONGRATULATIONS! Play again and you might hit the Jackpot!");
                    }
                    else if ((kerasi4.Visible & kerasi1.Visible & kerasi2.Visible) || (kerasi1.Visible & kerasi2.Visible & kerasi3.Visible) ||
                        (kerasi4.Visible & kerasi2.Visible & kerasi3.Visible) || (kerasi4.Visible & kerasi1.Visible & kerasi3.Visible) ||
                       (lemon4.Visible & lemon1.Visible & lemon2.Visible) || (lemon1.Visible & lemon2.Visible & lemon3.Visible) ||
                       (lemon4.Visible & lemon2.Visible & lemon3.Visible) || (lemon4.Visible & lemon1.Visible & lemon3.Visible) ||
                       (karpouzi4.Visible & karpouzi1.Visible & karpouzi2.Visible) || (karpouzi1.Visible & karpouzi2.Visible & karpouzi3.Visible) ||
                       (karpouzi4.Visible & karpouzi2.Visible & karpouzi3.Visible) || (karpouzi4.Visible & karpouzi1.Visible & karpouzi3.Visible))
                    {
                        label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 1.5).ToString();
                    }
                    else
                    {
                        label1.Text = "YOU LOSE";
                    }
                    if ((frouta == 5) || (frouta == 6))
                    {
                        if (stafyli1.Visible & stafyli2.Visible & stafyli3.Visible & stafyli4.Visible)
                        {
                            label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 3).ToString();
                            MessageBox.Show("CONGRATULATIONS! Play again and you might hit the Jackpot!");
                        }
                        else if ((stafyli4.Visible & stafyli1.Visible & stafyli2.Visible) || (stafyli1.Visible & stafyli2.Visible & stafyli3.Visible) ||
                        (stafyli4.Visible & stafyli2.Visible & stafyli3.Visible) || (stafyli4.Visible & stafyli1.Visible & stafyli3.Visible))
                        {
                            label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 1.5).ToString();
                        }

                    }
                    if (frouta == 6)
                    {
                        if (fraoula1.Visible & fraoula2.Visible & fraoula3.Visible & fraoula4.Visible)
                        {
                            label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 3).ToString();
                            MessageBox.Show("CONGRATULATIONS! Play again and you might hit the Jackpot!");
                        }
                        else if ((fraoula4.Visible & fraoula1.Visible & fraoula2.Visible) || (fraoula1.Visible & fraoula2.Visible & fraoula3.Visible) ||
                        (fraoula4.Visible & fraoula2.Visible & fraoula3.Visible) || (fraoula4.Visible & fraoula1.Visible & fraoula3.Visible))
                        {
                            label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 1.5).ToString();
                        }
                    }

                }
                else if (sthl == 5) //repeating procedure for 5 columns
                {
                    if (seven1.Visible & seven2.Visible & seven3.Visible & seven4.Visible & seven5.Visible)
                    {
                        label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 6).ToString();
                        MessageBox.Show("JACKPOT! Seems that today is your day! Lucky you!");
                    }
                    else if ((seven4.Visible & seven1.Visible & seven2.Visible & seven3.Visible) || (seven1.Visible & seven2.Visible & seven3.Visible & seven5.Visible) ||
                        (seven4.Visible & seven2.Visible & seven3.Visible & seven5.Visible) || (seven4.Visible & seven1.Visible & seven3.Visible & seven5.Visible) ||
                        (seven4.Visible & seven1.Visible & seven2.Visible & seven5.Visible))
                    {
                        label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 4).ToString();
                    }
                    else if ((kerasi1.Visible & kerasi2.Visible & kerasi3.Visible & kerasi4.Visible & kerasi5.Visible) || (lemon1.Visible & lemon2.Visible & lemon3.Visible & lemon4.Visible & lemon5.Visible) ||
                       (karpouzi1.Visible & karpouzi2.Visible & karpouzi3.Visible & karpouzi4.Visible & karpouzi5.Visible))
                    {
                        label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 4).ToString();
                        MessageBox.Show("CONGRATULATIONS! Play again and you might hit the Jackpot!");
                    }
                    else if ((kerasi4.Visible & kerasi1.Visible & kerasi2.Visible & kerasi3.Visible) || (kerasi1.Visible & kerasi2.Visible & kerasi3.Visible & kerasi5.Visible) ||
                        (kerasi4.Visible & kerasi2.Visible & kerasi3.Visible & kerasi5.Visible) || (kerasi4.Visible & kerasi1.Visible & kerasi3.Visible & kerasi5.Visible) ||
                        (kerasi4.Visible & kerasi1.Visible & kerasi2.Visible & kerasi5.Visible) || (lemon4.Visible & lemon1.Visible & lemon2.Visible & lemon3.Visible) || (lemon1.Visible & lemon2.Visible & lemon3.Visible & lemon5.Visible) ||
                        (lemon4.Visible & lemon2.Visible & lemon3.Visible & lemon5.Visible) || (lemon4.Visible & lemon1.Visible & lemon3.Visible & lemon5.Visible) ||
                        (lemon4.Visible & lemon1.Visible & lemon2.Visible & lemon5.Visible) || (karpouzi4.Visible & karpouzi1.Visible & karpouzi2.Visible & karpouzi3.Visible) || (karpouzi1.Visible & karpouzi2.Visible & karpouzi3.Visible & karpouzi5.Visible) ||
                        (karpouzi4.Visible & karpouzi2.Visible & karpouzi3.Visible & karpouzi5.Visible) || (karpouzi4.Visible & karpouzi1.Visible & karpouzi3.Visible & karpouzi5.Visible) ||
                        (karpouzi4.Visible & karpouzi1.Visible & karpouzi2.Visible & karpouzi5.Visible))
                    {
                        label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 3).ToString();
                    }
                    else
                    {
                        label1.Text = "YOU LOSE";
                    }
                    if ((frouta == 5) || (frouta == 6))
                    {
                        if (stafyli1.Visible & stafyli2.Visible & stafyli3.Visible & stafyli4.Visible & stafyli5.Visible)
                        {
                            label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 4).ToString();
                            MessageBox.Show("CONGRATULATIONS! Play again and you might hit the Jackpot!");
                        }
                        else if ((stafyli4.Visible & stafyli1.Visible & stafyli2.Visible & stafyli3.Visible) || (stafyli1.Visible & stafyli2.Visible & stafyli3.Visible & stafyli5.Visible) ||
                        (stafyli4.Visible & stafyli2.Visible & stafyli3.Visible & stafyli5.Visible) || (stafyli4.Visible & stafyli1.Visible & stafyli3.Visible & stafyli5.Visible) ||
                        (stafyli4.Visible & stafyli1.Visible & stafyli2.Visible & stafyli5.Visible))
                        {
                            label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 3).ToString();
                        }
                    }
                    if (frouta == 6)
                    {
                        if (fraoula1.Visible & fraoula2.Visible & fraoula3.Visible & fraoula4.Visible & fraoula5.Visible)
                        {
                            label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 4).ToString();
                            MessageBox.Show("CONGRATULATIONS! Play again and you might hit the Jackpot!");
                        }
                        else if ((fraoula4.Visible & fraoula1.Visible & fraoula2.Visible & fraoula3.Visible) || (fraoula1.Visible & fraoula2.Visible & fraoula3.Visible & fraoula5.Visible) ||
                        (fraoula4.Visible & fraoula2.Visible & fraoula3.Visible & fraoula5.Visible) || (fraoula4.Visible & fraoula1.Visible & fraoula3.Visible & fraoula5.Visible) ||
                        (fraoula4.Visible & fraoula1.Visible & fraoula2.Visible & fraoula5.Visible))
                        {
                            label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 3).ToString();
                        }
                    }
                }
                else if (sthl == 6) // repeating procedure for 6 columns
                {
                    if (seven1.Visible & seven2.Visible & seven3.Visible & seven4.Visible & seven5.Visible & seven6.Visible)
                    {
                        label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 8).ToString();
                        MessageBox.Show("JACKPOT! Seems that today is your day! Lucky you!");
                    }
                    else if ((seven1.Visible & seven2.Visible & seven3.Visible & seven4.Visible & seven5.Visible) || (seven2.Visible & seven3.Visible & seven4.Visible & seven5.Visible & seven6.Visible) ||
                        (seven6.Visible & seven4.Visible & seven1.Visible & seven3.Visible & seven5.Visible) || (seven6.Visible & seven4.Visible & seven1.Visible & seven2.Visible & seven5.Visible) ||
                        (seven6.Visible & seven1.Visible & seven2.Visible & seven3.Visible & seven5.Visible) || (seven6.Visible & seven4.Visible & seven1.Visible & seven2.Visible & seven3.Visible))
                    {
                        label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 6).ToString();
                    }
                    else if ((seven6.Visible & seven4.Visible & seven1.Visible & seven2.Visible) || (seven4.Visible & seven1.Visible & seven2.Visible & seven3.Visible) || (seven1.Visible & seven2.Visible & seven3.Visible & seven5.Visible) ||
                        (seven6.Visible & seven1.Visible & seven2.Visible & seven3.Visible) || (seven6.Visible & seven2.Visible & seven3.Visible & seven5.Visible) || (seven6.Visible & seven4.Visible & seven1.Visible & seven3.Visible) ||
                        (seven6.Visible & seven4.Visible & seven1.Visible & seven5.Visible) || (seven6.Visible & seven4.Visible & seven3.Visible & seven5.Visible) || (seven6.Visible & seven1.Visible & seven2.Visible & seven5.Visible) ||
                        (seven1.Visible & seven2.Visible & seven4.Visible & seven5.Visible) || (seven6.Visible & seven1.Visible & seven3.Visible & seven5.Visible) || (seven2.Visible & seven3.Visible & seven4.Visible & seven5.Visible) ||
                        (seven6.Visible & seven4.Visible & seven2.Visible & seven3.Visible) || (seven1.Visible & seven3.Visible & seven4.Visible & seven5.Visible) || (seven2.Visible & seven4.Visible & seven5.Visible & seven6.Visible))
                    {
                        label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 4).ToString();
                    }
                    else if ((kerasi1.Visible & kerasi2.Visible & kerasi3.Visible & kerasi4.Visible & kerasi5.Visible & kerasi6.Visible) || (lemon1.Visible & lemon2.Visible & lemon3.Visible & lemon4.Visible & lemon5.Visible & lemon6.Visible) ||
                        (karpouzi1.Visible & karpouzi2.Visible & karpouzi3.Visible & karpouzi4.Visible & karpouzi5.Visible & karpouzi6.Visible))
                    {
                        label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 6).ToString();
                        MessageBox.Show("CONGRATULATIONS! Play again and you might hit the Jackpot!");
                    }
                    else if ((kerasi1.Visible & kerasi2.Visible & kerasi3.Visible & kerasi4.Visible & kerasi5.Visible) || (kerasi2.Visible & kerasi3.Visible & kerasi4.Visible & kerasi5.Visible & kerasi6.Visible) ||
                        (kerasi6.Visible & kerasi4.Visible & kerasi1.Visible & kerasi3.Visible & kerasi5.Visible) || (kerasi6.Visible & kerasi4.Visible & kerasi1.Visible & kerasi2.Visible & kerasi5.Visible) ||
                        (kerasi6.Visible & kerasi1.Visible & kerasi2.Visible & kerasi3.Visible & kerasi5.Visible) || (kerasi6.Visible & kerasi4.Visible & kerasi1.Visible & kerasi2.Visible & kerasi3.Visible) || (lemon1.Visible & lemon2.Visible & lemon3.Visible & lemon4.Visible & lemon5.Visible) ||
                        (lemon2.Visible & lemon3.Visible & lemon4.Visible & lemon5.Visible & lemon6.Visible) ||
                        (lemon6.Visible & lemon4.Visible & lemon1.Visible & lemon3.Visible & lemon5.Visible) || (lemon6.Visible & lemon4.Visible & lemon1.Visible & lemon2.Visible & lemon5.Visible) ||
                        (lemon6.Visible & lemon1.Visible & lemon2.Visible & lemon3.Visible & lemon5.Visible) || (lemon6.Visible & lemon4.Visible & lemon1.Visible & lemon2.Visible & lemon3.Visible) || (karpouzi1.Visible & karpouzi2.Visible & karpouzi3.Visible & karpouzi4.Visible & karpouzi5.Visible) ||
                        (karpouzi2.Visible & karpouzi3.Visible & karpouzi4.Visible & karpouzi5.Visible & karpouzi6.Visible) ||
                        (karpouzi6.Visible & karpouzi4.Visible & karpouzi1.Visible & karpouzi3.Visible & karpouzi5.Visible) || (karpouzi6.Visible & karpouzi4.Visible & karpouzi1.Visible & karpouzi2.Visible & karpouzi5.Visible) ||
                        (karpouzi6.Visible & karpouzi1.Visible & karpouzi2.Visible & karpouzi3.Visible & karpouzi5.Visible) || (karpouzi6.Visible & karpouzi4.Visible & karpouzi1.Visible & karpouzi2.Visible & karpouzi3.Visible))
                    {
                        label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 5).ToString();
                    }
                    else if ((kerasi6.Visible & kerasi4.Visible & kerasi1.Visible & kerasi2.Visible) || (kerasi4.Visible & kerasi1.Visible & kerasi2.Visible & kerasi3.Visible) || (kerasi1.Visible & kerasi2.Visible & kerasi3.Visible & kerasi5.Visible) ||
                        (kerasi6.Visible & kerasi1.Visible & kerasi2.Visible & kerasi3.Visible) || (kerasi6.Visible & kerasi2.Visible & kerasi3.Visible & kerasi5.Visible) || (kerasi6.Visible & kerasi4.Visible & kerasi1.Visible & kerasi3.Visible) ||
                        (kerasi6.Visible & kerasi4.Visible & kerasi1.Visible & kerasi5.Visible) || (kerasi6.Visible & kerasi4.Visible & kerasi3.Visible & kerasi5.Visible) || (kerasi6.Visible & kerasi1.Visible & kerasi2.Visible & kerasi5.Visible) ||
                        (kerasi1.Visible & kerasi2.Visible & kerasi4.Visible & kerasi5.Visible) || (kerasi6.Visible & kerasi1.Visible & kerasi3.Visible & kerasi5.Visible) || (kerasi2.Visible & kerasi3.Visible & kerasi4.Visible & kerasi5.Visible) ||
                        (kerasi6.Visible & kerasi4.Visible & kerasi2.Visible & kerasi3.Visible) || (kerasi1.Visible & kerasi3.Visible & kerasi4.Visible & kerasi5.Visible) || (kerasi2.Visible & kerasi4.Visible & kerasi5.Visible & kerasi6.Visible) || (lemon6.Visible & lemon4.Visible & lemon1.Visible & lemon2.Visible) || (lemon4.Visible & lemon1.Visible & lemon2.Visible & lemon3.Visible) || (lemon1.Visible & lemon2.Visible & lemon3.Visible & lemon5.Visible) ||
                        (lemon6.Visible & lemon1.Visible & lemon2.Visible & lemon3.Visible) || (lemon6.Visible & lemon2.Visible & lemon3.Visible & lemon5.Visible) || (lemon6.Visible & lemon4.Visible & lemon1.Visible & lemon3.Visible) ||
                        (lemon6.Visible & lemon4.Visible & lemon1.Visible & lemon5.Visible) || (lemon6.Visible & lemon4.Visible & lemon3.Visible & lemon5.Visible) || (lemon6.Visible & lemon1.Visible & lemon2.Visible & lemon5.Visible) ||
                        (lemon1.Visible & lemon2.Visible & lemon4.Visible & lemon5.Visible) || (lemon6.Visible & lemon1.Visible & lemon3.Visible & lemon5.Visible) || (lemon2.Visible & lemon3.Visible & lemon4.Visible & lemon5.Visible) ||
                        (lemon6.Visible & lemon4.Visible & lemon2.Visible & lemon3.Visible) || (lemon1.Visible & lemon3.Visible & lemon4.Visible & lemon5.Visible) || (lemon2.Visible & lemon4.Visible & lemon5.Visible & lemon6.Visible) || (karpouzi6.Visible & karpouzi4.Visible & karpouzi1.Visible & karpouzi2.Visible) || (karpouzi4.Visible & karpouzi1.Visible & karpouzi2.Visible & karpouzi3.Visible) || (karpouzi1.Visible & karpouzi2.Visible & karpouzi3.Visible & karpouzi5.Visible) ||
                        (karpouzi6.Visible & karpouzi1.Visible & karpouzi2.Visible & karpouzi3.Visible) || (karpouzi6.Visible & karpouzi2.Visible & karpouzi3.Visible & karpouzi5.Visible) || (karpouzi6.Visible & karpouzi4.Visible & karpouzi1.Visible & karpouzi3.Visible) ||
                        (karpouzi6.Visible & karpouzi4.Visible & karpouzi1.Visible & karpouzi5.Visible) || (karpouzi6.Visible & karpouzi4.Visible & karpouzi3.Visible & karpouzi5.Visible) || (karpouzi6.Visible & karpouzi1.Visible & karpouzi2.Visible & karpouzi5.Visible) ||
                        (karpouzi1.Visible & karpouzi2.Visible & karpouzi4.Visible & karpouzi5.Visible) || (karpouzi6.Visible & karpouzi1.Visible & karpouzi3.Visible & karpouzi5.Visible) || (karpouzi2.Visible & karpouzi3.Visible & karpouzi4.Visible & karpouzi5.Visible) ||
                        (karpouzi6.Visible & karpouzi4.Visible & karpouzi2.Visible & karpouzi3.Visible) || (karpouzi1.Visible & karpouzi3.Visible & karpouzi4.Visible & karpouzi5.Visible) || (karpouzi2.Visible & karpouzi4.Visible & karpouzi5.Visible & karpouzi6.Visible))
                    {
                        label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 4).ToString();
                    }
                    else
                    {
                        label1.Text = "YOU LOSE";
                    }
                    if ((frouta == 5) || (frouta == 6))
                    {
                        if (stafyli1.Visible & stafyli2.Visible & stafyli3.Visible & stafyli4.Visible & stafyli5.Visible & stafyli6.Visible)
                        {
                            label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 6).ToString();
                            MessageBox.Show("CONGRATULATIONS! Play again and you might hit the Jackpot!");
                        }
                        else if ((stafyli1.Visible & stafyli2.Visible & stafyli3.Visible & stafyli4.Visible & stafyli5.Visible) || (stafyli2.Visible & stafyli3.Visible & stafyli4.Visible & stafyli5.Visible & stafyli6.Visible) ||
                        (stafyli6.Visible & stafyli4.Visible & stafyli1.Visible & stafyli3.Visible & stafyli5.Visible) || (stafyli6.Visible & stafyli4.Visible & stafyli1.Visible & stafyli2.Visible & stafyli5.Visible) ||
                        (stafyli6.Visible & stafyli1.Visible & stafyli2.Visible & stafyli3.Visible & stafyli5.Visible) || (stafyli6.Visible & stafyli4.Visible & stafyli1.Visible & stafyli2.Visible & stafyli3.Visible))
                        {
                            label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 5).ToString();
                        }
                        else if ((stafyli6.Visible & stafyli4.Visible & stafyli1.Visible & stafyli2.Visible) || (stafyli4.Visible & stafyli1.Visible & stafyli2.Visible & stafyli3.Visible) || (stafyli1.Visible & stafyli2.Visible & stafyli3.Visible & stafyli5.Visible) ||
                        (stafyli6.Visible & stafyli1.Visible & stafyli2.Visible & stafyli3.Visible) || (stafyli6.Visible & stafyli2.Visible & stafyli3.Visible & stafyli5.Visible) || (stafyli6.Visible & stafyli4.Visible & stafyli1.Visible & stafyli3.Visible) ||
                        (stafyli6.Visible & stafyli4.Visible & stafyli1.Visible & stafyli5.Visible) || (stafyli6.Visible & stafyli4.Visible & stafyli3.Visible & stafyli5.Visible) || (stafyli6.Visible & stafyli1.Visible & stafyli2.Visible & stafyli5.Visible) ||
                        (stafyli1.Visible & stafyli2.Visible & stafyli4.Visible & stafyli5.Visible) || (stafyli6.Visible & stafyli1.Visible & stafyli3.Visible & stafyli5.Visible) || (stafyli2.Visible & stafyli3.Visible & stafyli4.Visible & stafyli5.Visible) ||
                        (stafyli6.Visible & stafyli4.Visible & stafyli2.Visible & stafyli3.Visible) || (stafyli1.Visible & stafyli3.Visible & stafyli4.Visible & stafyli5.Visible) || (stafyli2.Visible & stafyli4.Visible & stafyli5.Visible & stafyli6.Visible))
                        {
                            label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 4).ToString();
                        }

                    }
                    if (frouta == 6)
                    {
                        if (fraoula1.Visible & fraoula2.Visible & fraoula3.Visible & fraoula4.Visible & fraoula5.Visible & fraoula6.Visible)
                        {
                            label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 6).ToString();
                            MessageBox.Show("CONGRATULATIONS! Play again and you might hit the Jackpot!");
                        }
                        else if ((fraoula1.Visible & fraoula2.Visible & fraoula3.Visible & fraoula4.Visible & fraoula5.Visible) || (fraoula2.Visible & fraoula3.Visible & fraoula4.Visible & fraoula5.Visible & fraoula6.Visible) ||
                        (fraoula6.Visible & fraoula4.Visible & fraoula1.Visible & fraoula3.Visible & fraoula5.Visible) || (fraoula6.Visible & fraoula4.Visible & fraoula1.Visible & fraoula2.Visible & fraoula5.Visible) ||
                        (fraoula6.Visible & fraoula1.Visible & fraoula2.Visible & fraoula3.Visible & fraoula5.Visible) || (fraoula6.Visible & fraoula4.Visible & fraoula1.Visible & fraoula2.Visible & fraoula3.Visible))
                        {
                            label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 5).ToString();
                        }
                        else if ((fraoula6.Visible & fraoula4.Visible & fraoula1.Visible & fraoula2.Visible) || (fraoula4.Visible & fraoula1.Visible & fraoula2.Visible & fraoula3.Visible) || (fraoula1.Visible & fraoula2.Visible & fraoula3.Visible & fraoula5.Visible) ||
                        (fraoula6.Visible & fraoula1.Visible & fraoula2.Visible & fraoula3.Visible) || (fraoula6.Visible & fraoula2.Visible & fraoula3.Visible & fraoula5.Visible) || (fraoula6.Visible & fraoula4.Visible & fraoula1.Visible & fraoula3.Visible) ||
                        (fraoula6.Visible & fraoula4.Visible & fraoula1.Visible & fraoula5.Visible) || (fraoula6.Visible & fraoula4.Visible & fraoula3.Visible & fraoula5.Visible) || (fraoula6.Visible & fraoula1.Visible & fraoula2.Visible & fraoula5.Visible) ||
                        (fraoula1.Visible & fraoula2.Visible & fraoula4.Visible & fraoula5.Visible) || (fraoula6.Visible & fraoula1.Visible & fraoula3.Visible & fraoula5.Visible) || (fraoula2.Visible & fraoula3.Visible & fraoula4.Visible & fraoula5.Visible) ||
                        (fraoula6.Visible & fraoula4.Visible & fraoula2.Visible & fraoula3.Visible) || (fraoula1.Visible & fraoula3.Visible & fraoula4.Visible & fraoula5.Visible) || (fraoula2.Visible & fraoula4.Visible & fraoula5.Visible & fraoula6.Visible))
                        {
                            label1.Text = "YOU WON \n" + (Int32.Parse(coins) * 4).ToString();
                        }

                    }

                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e) //3 columns
        { //all the other columns must be invisible in case the player selects 4 or 5 or 6 and then 3
            sthl = 3;
            column1.Visible = false;
            column2.Visible = false;
            column3.Visible = false;
            keno1.Visible = false;
            keno2.Visible = false;
            keno3.Visible = false;
            seven4.Visible = false;
            kerasi4.Visible = false;
            lemon4.Visible = false;
            karpouzi4.Visible = false;
            stafyli4.Visible = false;
            fraoula4.Visible = false;
            seven5.Visible = false;
            kerasi5.Visible = false;
            lemon5.Visible = false;
            karpouzi5.Visible = false;
            stafyli5.Visible = false;
            fraoula5.Visible = false;
            seven6.Visible = false;
            kerasi6.Visible = false;
            lemon6.Visible = false;
            karpouzi6.Visible = false;
            stafyli6.Visible = false;
            fraoula6.Visible = false;
        }

        int counter4 = 0;
        int num4 = 0;
        private void timer4_Tick(object sender, EventArgs e) //timer for the new forth column
        {
            if (counter4 < 50)
            {
                sthlh4[num4].Visible = false;
                num4 = random4.Next(0, frouta);
                sthlh4[num4].Visible = true;
                counter4++;
            }
            else if (counter3 == 100)
            {
                timer4.Enabled = false;
                counter4 = 0;
            }
        }

        private void columnsToolStripMenuItem_Click(object sender, EventArgs e) //4 columns
        {// same as the 3 columns
            column2.Visible = false;
            keno2.Visible = false;
            seven5.Visible = false;
            karpouzi5.Visible = false;
            lemon5.Visible = false;
            kerasi5.Visible = false;
            stafyli5.Visible = false;
            fraoula5.Visible = false;
            column3.Visible = false;
            keno3.Visible = false;
            seven6.Visible = false;
            karpouzi6.Visible = false;
            lemon6.Visible = false;
            kerasi6.Visible = false;
            stafyli6.Visible = false;
            fraoula6.Visible = false;
            seven4.Visible = true;
            karpouzi4.Visible = true;
            lemon4.Visible = true;
            kerasi4.Visible = true;
            keno1.Visible = true;
            column1.Visible = true;
            sthl = 4;
        }

        private void columnsToolStripMenuItem1_Click(object sender, EventArgs e)// 5 columns
        {
            sthl = 5;
            seven4.Visible = true;
            karpouzi4.Visible = true;
            lemon4.Visible = true;
            kerasi4.Visible = true;
            keno1.Visible = true;
            column1.Visible = true;
            seven5.Visible = true;
            karpouzi5.Visible = true;
            lemon5.Visible = true;
            kerasi5.Visible = true;
            stafyli5.Visible = true;
            fraoula5.Visible = true;
            keno2.Visible = true;
            column2.Visible = true;
            column3.Visible = false;
            keno3.Visible = false;
            seven6.Visible = false;
            karpouzi6.Visible = false;
            lemon6.Visible = false;
            kerasi6.Visible = false;
            stafyli6.Visible = false;
            fraoula6.Visible = false;


        }

        private void fruitsToolStripMenuItem_Click(object sender, EventArgs e) //4 fruits
        {
            frouta = 4;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e) // 5 fruits
        {
            frouta = 5;
        }
        int counter5 = 0;
        int num5 = 0;
        private void timer5_Tick(object sender, EventArgs e) // timer for the fifth column
        {
            if (counter5 < 95)
            {
                sthlh5[num5].Visible = false;
                num5 = random5.Next(0, frouta);
                sthlh5[num5].Visible = true;
                counter5++;
            }
            else if (counter3 == 100)
            {
                timer5.Enabled = false;
                counter5 = 0;
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e) // 6 fruits
        {
            frouta = 6;
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // minimize the form
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); //close all the application 
        }

        private void statisticsOfTheGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3(); //create new form for the statistics of the game

            frm.Show(); //show the new form

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4(); //create new form to help the player 

            frm.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e) //6 columns
        {
            sthl = 6;
            seven6.Visible = true;
            karpouzi6.Visible = true;
            lemon6.Visible = true;
            kerasi6.Visible = true;
            stafyli6.Visible = true;
            fraoula6.Visible = true;
            keno3.Visible = true;
            column3.Visible = true;
            seven4.Visible = true;
            karpouzi4.Visible = true;
            lemon4.Visible = true;
            kerasi4.Visible = true;
            keno1.Visible = true;
            column1.Visible = true;
            seven5.Visible = true;
            karpouzi5.Visible = true;
            lemon5.Visible = true;
            kerasi5.Visible = true;
            stafyli5.Visible = true;
            fraoula5.Visible = true;
            keno2.Visible = true;
            column2.Visible = true;

        }
        int counter6 = 0;
        int num6 = 0;
        private void timer6_Tick(object sender, EventArgs e) //the timer for the sixth column
        {
            if (counter6 < 45)
            {
                sthlh6[num6].Visible = false;
                num6 = random6.Next(0, frouta);
                sthlh6[num6].Visible = true;
                counter6++;
            }
            else if (counter3 == 100)
            {
                timer6.Enabled = false;
                counter6 = 0;
            }
        }
    }

}

