using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLogic
{
    public static class TibCalcLogic
    {
        public static int PoziomWyjsciaZRooka()
        {
            return 8;
        }
        public static string PobierzProfesje(object profesja)
        {
            return (profesja == null)
                ? string.Empty
                : profesja.ToString();
        }
        public static int WyliczDoswiadczenie(int poziomLiczba)
        {
            int doswiadczenie = ((50 * (int)(Math.Pow((poziomLiczba - 1), 3))) - (150 * (int)(Math.Pow((poziomLiczba - 1), 2))) + (400 * (poziomLiczba - 1))) / 3;

            return doswiadczenie;
        }
        public static int WyliczExpDoLvl(int poziomLiczba)
        {
            int expdolvla = 50 * (int)(Math.Pow(poziomLiczba, 2)) - (150 * poziomLiczba) + 200;

            return expdolvla;
        }
        public static int WyliczBaseSpeed(int poziomLiczba)
        {
            int baseSpeed = 110 + poziomLiczba - 1;
            return baseSpeed;
        }
        public static int WyliczPunktyZycia(string profesjaString, int poziomLiczba, int poziomOpuszczeniaRookgaard)
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
        public static int WyliczPunktyMany(string profesjaString, int poziomLiczba, int poziomOpuszczeniaRookgaard)
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
        public static int WyliczCapacity(string profesjaString, int poziomLiczba, int poziomOpuszczeniaRookgaard)
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
        public static decimal WyliczManeNaMLvl(string profesjaString, int mlvlLiczba)
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
