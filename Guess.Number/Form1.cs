﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp;

namespace Guess.Number
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            textBox1.Focus();
            textBox2.Text = "0";
            textBox3.Text = Utility.GetRandomNumber(4).ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                return;
            }
            if (textBox3.Text==textBox1.Text)
            {
                dataGridView1.Rows.Clear();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = Utility.GetRandomNumber(4).ToString();
                MessageBox.Show("Your guess is right\nNumber was " + textBox3.Text+"\nYou guesed in "+textBox2.Text+"Attempts","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            string myNo = textBox1.Text;
            string guessNo = textBox3.Text;
            int match = 0, postion = 0;int attemt = Convert.ToInt32(textBox2.Text)+1;
            string Mynew =myNo;
            for (int i = 0; i < guessNo.Length; i++)
            {

                for (int j = 0; j < Mynew.Length; j++)
                {
                    if (Mynew[j]==guessNo[i])
                    {
                        match++;
                       Mynew= Mynew.Remove(j, 1);
                        break;
                    } 
                }
                if (myNo[i]==guessNo[i])
                {
                    postion++;
                }
            }
            dataGridView1.Rows.Add(attemt,myNo, match, postion);
            textBox2.Text = attemt.ToString();
            textBox1.Text = "";
            textBox1.Focus();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue==13)
            {
                button1.PerformClick();
            }
        }
    }
}
