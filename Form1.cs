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

            string profesjaString = (profesja == null)
                ? string.Empty
                : profesja.ToString();

            int poziomLiczba = 0;
            bool toJestLiczba = int.TryParse(poziom, out poziomLiczba);

            if (profesja == null)
            {
                MessageBox.Show("Wybierz profesję");
                return;
            }

            if (string.IsNullOrEmpty(poziom))
            {
                MessageBox.Show("Wpisz poziom");
                return;
            }

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

            int punktyZycia = 0;
            int doswiadczenie = 50 * (int)(Math.Pow(poziomLiczba, 2)) - (150 * poziomLiczba) + 200;

            switch (profesjaString)
            {
                case "Knight":
                    punktyZycia = poziomLiczba * 3;
                    break;
                case "Paladin":
                    punktyZycia = poziomLiczba * 2;
                    break;
                //case "Druid":
                //case "Sorc":
                //    punktyZycia = poziomLiczba;
                //    break;
                default:
                    punktyZycia = poziomLiczba;
                    break;
            }

            richTextBox1.Text = string.Format("Profesja: {0}\nPoziom: {1}\nPunkty zycia: {2}\nDoświadczenie: {3}", profesja, poziom, punktyZycia, doswiadczenie );
            //"Profesja: " + profesja + "\nPoziom: " + poziom;
        }
    }
}
