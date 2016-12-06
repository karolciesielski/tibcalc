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
            //object profesja = listBox1.SelectedItem;
            string profesja = listBox1.SelectedItem.ToString();
            string lvl = textBox1.Text;
            string mlvl = textBox2.Text;
            string profesjaString = PobierzProfesje(profesja);

            int poziomLiczba = 0;
            bool toJestLiczba = int.TryParse(lvl, out poziomLiczba);

            if (profesja == null)
            {
                MessageBox.Show("Wybierz profesję");
                return;
            }

            if (string.IsNullOrEmpty(lvl))
            {
                MessageBox.Show("Wpisz LVL");
                return;
            }

            if (toJestLiczba)
            {
                if (poziomLiczba < 0)
                {
                    MessageBox.Show("Wpisz LVL wyższy od zera");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Wpisz liczbę w polu LVL");
                return;
            }

            int mlvlLiczba = 0;
            bool toJestLiczba2 = int.TryParse(mlvl, out mlvlLiczba);

            if (profesja == null)
            {
                MessageBox.Show("Wybierz profesję");
                return;
            }

            if (string.IsNullOrEmpty(mlvl))
            {
                MessageBox.Show("Wpisz MLVL");
                return;
            }

            if (toJestLiczba2)
            {
                if (mlvlLiczba < 0)
                {
                    MessageBox.Show("Wpisz MLVL wyższy od zera");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Wpisz liczbę w polu MLVL");
                return;
            }

            int poziomOpuszczeniaRookgaard = PoziomWyjsciaZRooka();
            int doswiadczenie = WyliczDoswiadczenie(poziomLiczba);
            int expdolvla = WyliczExpDoLvl(poziomLiczba);
            int baseSpeed = WyliczBaseSpeed(poziomLiczba);
            int PunktyZycia = WyliczPunktyZycia(profesjaString, poziomLiczba, poziomOpuszczeniaRookgaard);
            int punktyMany = WyliczPunktyMany(profesjaString, poziomLiczba, poziomOpuszczeniaRookgaard);
            int capacity = WyliczCapacity(profesjaString, poziomLiczba, poziomOpuszczeniaRookgaard);
            decimal manaNaMlvl = WyliczManeNaMLvl(profesjaString, mlvlLiczba);
            

            richTextBox1.Text = string.Format("Profesja: {0}\nLVL: {1}\nMLVL: {2}\n\nDoświadczenie: {3} exp\nDo LVL'a: {4} exp\nDo MLVL'a: {5}\n\nCapacity: {6}\nPunkty zycia: {7}\nPunkty many: {8}\nSpeed: {9} ", profesja, lvl, mlvl, doswiadczenie, expdolvla, manaNaMlvl, capacity, PunktyZycia, punktyMany, baseSpeed);
            //"Profesja: " + profesja + "\nPoziom: " + poziom;
        }

        private static int PoziomWyjsciaZRooka()
        {
            return 8;
        }
        private static string PobierzProfesje(object profesja)
        {
            return (profesja == null)
                ? string.Empty
                : profesja.ToString();
        }
        private int WyliczDoswiadczenie(int poziomLiczba)
        {
            int doswiadczenie = ((50 * (int)(Math.Pow((poziomLiczba - 1), 3))) - (150 * (int)(Math.Pow((poziomLiczba - 1), 2))) + (400 * (poziomLiczba - 1))) / 3;

            return doswiadczenie;
        }
        private int WyliczExpDoLvl(int poziomLiczba)
        {
            int expdolvla = 50 * (int)(Math.Pow(poziomLiczba, 2)) - (150 * poziomLiczba) + 200;

            return expdolvla;
        }
        private int WyliczBaseSpeed(int poziomLiczba)
        {
            int baseSpeed = 110 + poziomLiczba - 1;
            return baseSpeed;
        }
        private int WyliczPunktyZycia(string profesjaString, int poziomLiczba, int poziomOpuszczeniaRookgaard)
        {
            int punktyZycia = 0;

            switch (profesjaString)
            {
                case "Knight":
                    punktyZycia = 5 * ((3 * poziomLiczba) - 2 * poziomOpuszczeniaRookgaard + 29);
                    break;
                case "Paladin":
                    punktyZycia = 5 * ((2 * poziomLiczba) - poziomOpuszczeniaRookgaard + 29);
                    break;
                case "Sorc/Druid":
                    punktyZycia = 5 * (poziomLiczba + 29);
                    break;
                default:
                    punktyZycia = 5 * (poziomLiczba + 29);
                    break;
                    // liczenie...
                    // punktyZycia = xxx
                   
            }
            return punktyZycia;
        }
        private int WyliczPunktyMany(string profesjaString, int poziomLiczba, int poziomOpuszczeniaRookgaard)
        {
            int punktyMany = 0;

            switch (profesjaString)
            {
                case "Knight":
                    punktyMany = 5 * (poziomLiczba + 10);
                    break;
                case "Paladin":
                    punktyMany = 5 * ((3 * poziomLiczba) - (2 * poziomOpuszczeniaRookgaard) + 10);
                    break;
                case "Sorc/Druid":
                    punktyMany = 5 * ((6 * poziomLiczba) - (5 * poziomOpuszczeniaRookgaard) + 10);
                    break;
                default:
                    punktyMany = 5 * (poziomLiczba + 10);
                    break;
            }
            return punktyMany;
        }
        private int WyliczCapacity(string profesjaString, int poziomLiczba, int poziomOpuszczeniaRookgaard)
        {
            int capacity = 0;
            switch (profesjaString)
            {
                case "Knight":
                    capacity = 5 * ((5 * poziomLiczba) - (5 * poziomOpuszczeniaRookgaard) + 94);
                    break;
                case "Paladin":
                    capacity = 10 * ((2 * poziomLiczba) - poziomOpuszczeniaRookgaard + 39);
                    break;
                case "Sorc/Druid":
                    capacity = 10 * (poziomLiczba + 39);
                    break;
                default:
                    capacity = 10 * (poziomLiczba + 39);
                    break;
            }
            return capacity;
        }
        private decimal WyliczManeNaMLvl(string profesjaString, int mlvlLiczba)
        {
            decimal manaNaMlvl = 0;
            switch (profesjaString)
            {
                case "Knight":
                    manaNaMlvl = 1600 * 3m * mlvlLiczba;
                    break;
                case "Paladin":
                    manaNaMlvl = (1600 * 1.4m * mlvlLiczba);
                    break;
                case "Sorc/Druid":
                    manaNaMlvl = 1600 * 1.1m * mlvlLiczba;
                    break;
            }
            return manaNaMlvl;
        }
    }
}
