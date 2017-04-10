using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Sudoku
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();




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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox81_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                int[,] tablica = Tools.Wczytaj(openFileDialog1.FileName);

                int n = 1;
                for (int j = 0; j < 9; j++)
                    for (int i = 0; i < 9; i++)
                    {
                        foreach (Control contrl in this.Controls)
                        {
                            if (contrl.Name == ("textBox" + (n)))
                            {
                                contrl.Text = tablica[j, i] + "";
                                contrl.BackColor = System.Drawing.SystemColors.GrayText;
                                contrl.Enabled = false;

                            }
                            if (contrl.Text == "0")
                            {
                                contrl.Text = "";
                                contrl.BackColor = System.Drawing.SystemColors.Window;
                                contrl.Enabled = true;
                            }

                        }
                        n++;
                    }
            }


            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int n = 1;
            for (int i = 0; i < 81; i++)
            // for (int i = 0; i < 9; i++)
            {
                foreach (Control contrl in Controls)
                {
                    if (contrl.Name == ("textBox" + (n)))
                    {
                        contrl.Text = "";
                        contrl.BackColor = System.Drawing.SystemColors.Window;
                        contrl.Enabled = true;

                    }
                }
                n++;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            

            DialogResult dialogResult = MessageBox.Show("Wszystko zostanie zniszczone\n Czy jesteś pewien?", "Uwaga", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                int n = 1;
                for (int j = 0; j < 81; j++)
                // for (int i = 0; i < 9; i++)
                {
                    foreach (Control contrl in this.Controls)
                    {
                        if (contrl is TextBox)
                        {
                            contrl.Dispose();
                            this.Controls.Remove(contrl);
                        }
                        n++;
                        foreach (Control butt in this.Controls)
                        {
                            if (butt is Button)
                            {
                                contrl.Dispose();
                                this.Controls.Remove(butt);
                            }

                        }
                    }
                    this.Controls.Remove(comboBox2);
                }
                
               // if (timeLeft > 0)
               // {
               //     timeLeft = timeLeft - 1;
               //     timeLabel.Text = " seconds" + timeLeft ;
               // }
            }
            



        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox55_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string file_name = @"C:\Users\user\Desktop\sudoku2.txt";
            StreamWriter objWriter;
            objWriter = new StreamWriter(file_name, true);
            int n = 1;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    foreach (Control contrl in Controls)
                    {

                        if (contrl.Name == ("textBox" + (n)))
                        {
                            if (!(contrl.Text == ""))
                            objWriter.Write(contrl.Text + ";");
                            if (n == 9 || n == 18 || n == 27 || n == 36 || n == 45 || n == 54 || n == 63 || n == 72)
                            {
                                //   objWriter.Write(contrl.Text);
                                objWriter.Write(Environment.NewLine);
                            }
                            if (contrl.Text == "")
                            {
                                objWriter.Write("0;");
                            }


                        }

                    }
                    n++;


                }
            objWriter.Flush();
            objWriter.Close();
            MessageBox.Show("Zapisano", "Zapisano", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[,] tablica = new int[9, 9];
            int n = 1, temp = 0;
            for (int j = 0; j < 9; j++)
                for (int i = 0; i < 9; i++)
                {
                    foreach (Control contrl in this.Controls)
                    {
                        if (contrl.Name == ("textBox" + (n)))
                        {
                            Int32.TryParse(contrl.Text, out temp);
                            tablica[i, j] = temp;
                        }
                    }
                    n++;
                }
            if (Tools.Sprawdz(tablica))
                MessageBox.Show("Poprawne", "Sprawdzenie", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
                MessageBox.Show("Sudoku nie jest poprawne", "Sprawdzenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

