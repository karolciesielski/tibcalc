using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tibicalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //listBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object profesja = listBox1.SelectedItem;
            //string profesja = listBox1.SelectedItem.ToString();
            string poziom = textBox1.Text;

            if(profesja == null)
            {
                MessageBox.Show("Wybierz profesję");
                return;
            }

            if (string.IsNullOrEmpty(poziom))
            {
                MessageBox.Show("Wpisz poziom");
                return;
            }

            int poziomLiczba = 0;
            bool toJestLiczba = int.TryParse(poziom, out poziomLiczba);

            if(toJestLiczba)
            {
                if (poziomLiczba < 0)
                {
                    MessageBox.Show("Wpisz poziom wyższy od zera");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Wpisz liczbę");
                return;
            }

            richTextBox1.Text = string.Format("Profesja: {0}\nPoziom: {1}", profesja, poziom);
            //"Profesja: " + profesja + "\nPoziom: " + poziom;
        }
    }
}
