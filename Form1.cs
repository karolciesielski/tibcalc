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

            int poziomOpuszczeniaRookgaard = 8;
            int punktyZycia = 0;
            int doswiadczenie = ((50 * (int)(Math.Pow((poziomLiczba - 1), 3))) - (150 * (int)(Math.Pow((poziomLiczba - 1), 2))) + (400 * (poziomLiczba -1)))/3;
            int expdolvla = 50 * (int)(Math.Pow(poziomLiczba, 2)) - (150 * poziomLiczba) + 200;
            int punktyMany = 0;
            int capacity = 0;
            //int baseSpeed = 0;

            switch (profesjaString)
            {
                case "Knight":
                    punktyZycia = 5 * ((3 * poziomLiczba) - 2 * poziomOpuszczeniaRookgaard + 29);
                    punktyMany = 5 * (poziomLiczba + 10);
                    capacity = 5 * ((5 * poziomLiczba) - (5 * poziomOpuszczeniaRookgaard) + 94);
                    //baseSpeed = 220 + (2 * (poziomLiczba - 1));

                    break;
                case "Paladin":
                    punktyZycia = 5 *((2 * poziomLiczba) - 8 + 29);
                    punktyMany = 5 * ((3 * poziomLiczba) - (2 * poziomOpuszczeniaRookgaard) + 10);
                    capacity = 10 * ((2 * poziomLiczba) - poziomOpuszczeniaRookgaard + 39);
                    //baseSpeed = 220 + (2 * (poziomLiczba - 1));
                    break;
                case "Sorc/Druid":
                    punktyZycia = 5 * (poziomLiczba + 29);
                    punktyMany = 5 * ((6 * poziomLiczba) - (5 * poziomOpuszczeniaRookgaard) + 10);
                    capacity = 10 * (poziomLiczba + 39);
                    //baseSpeed = 220 + (2 * (poziomLiczba - 1));
                    break;
                default:
                    punktyZycia = 5 *(poziomLiczba + 29);
                    punktyMany = 5 * (poziomLiczba + 10);
                    capacity = 10 * (poziomLiczba + 39);
                    //baseSpeed = 220 + (2 * (poziomLiczba - 1));
                    break;
            }

            richTextBox1.Text = string.Format("Profesja: {0}\nPoziom: {1}\n\nDoświadczenie: {2} exp\nDo Lvl'a: {3} exp\n\nCapacity: {4}\nPunkty zycia: {5}\nPunkty many: {6}", profesja, poziom, doswiadczenie, expdolvla, capacity, punktyZycia, punktyMany  );
            //"Profesja: " + profesja + "\nPoziom: " + poziom;
        }
    }
}
