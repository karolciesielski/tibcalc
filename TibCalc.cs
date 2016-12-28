using CalcLogic;
using System;
using System.Windows.Forms;

namespace tibicalc
{
    public partial class TibCalc : Form
    {
        public TibCalc()
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
            string profesjaString = TibCalcLogic.PobierzProfesje(profesja);

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

            int poziomOpuszczeniaRookgaard = TibCalcLogic.PoziomWyjsciaZRooka();
            int doswiadczenie = TibCalcLogic.WyliczDoswiadczenie(poziomLiczba);
            int expdolvla = TibCalcLogic.WyliczExpDoLvl(poziomLiczba);
            int baseSpeed = TibCalcLogic.WyliczBaseSpeed(poziomLiczba);
            int PunktyZycia = TibCalcLogic.WyliczPunktyZycia(profesjaString, poziomLiczba, poziomOpuszczeniaRookgaard);
            int punktyMany = TibCalcLogic.WyliczPunktyMany(profesjaString, poziomLiczba, poziomOpuszczeniaRookgaard);
            int capacity = TibCalcLogic.WyliczCapacity(profesjaString, poziomLiczba, poziomOpuszczeniaRookgaard);
            decimal manaNaMlvl = TibCalcLogic.WyliczManeNaMLvl(profesjaString, mlvlLiczba);
            

            richTextBox1.Text = string.Format("Profesja: {0}\nLVL: {1}\nMLVL: {2}\n\nDoświadczenie: {3} exp\nDo LVL'a: {4} exp\nDo MLVL'a: {5}\n\nCapacity: {6}\nPunkty zycia: {7}\nPunkty many: {8}\nSpeed: {9} ", profesja, lvl, mlvl, doswiadczenie, expdolvla, manaNaMlvl, capacity, PunktyZycia, punktyMany, baseSpeed);
            //"Profesja: " + profesja + "\nPoziom: " + poziom;
        }
    }
}
