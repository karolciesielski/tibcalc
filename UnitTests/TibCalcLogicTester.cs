using CalcLogic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestFixture]
    public class TibCalcLogicTester
    {
        [Test]
        public void Paladin_PoziomMagiczny30_PunktyMana67200()
        {
            string profesjaString = "Paladin";
            int mlvlliczba = 30;

            decimal mana = TibCalcLogic.WyliczManeNaMlvl(profesjaString, mlvlliczba);

            Assert.AreEqual(67200m, mana);
        }
        [Test]
        public void Knight_Poziom55_WyliczCapacity1645()
        {
            string profesjaString = "Knight";
            int poziomliczba = 55;
            int poziomOpuszczeniaRookgaard = 8;

            int cap = TibCalcLogic.WyliczCapacity(profesjaString, poziomliczba, poziomOpuszczeniaRookgaard);

            Assert.AreEqual(1645m, cap);
        }
        [Test]
        public void Knight_Poziom100_WyliczPunktyMany1565()
        {
            string profesjaString = "Knight";
            int poziomLiczba = 100;
            int poziomOpuszczeniaRookgaard = 8;

            int MP = TibCalcLogic.WyliczPunktyZycia(profesjaString, poziomLiczba, poziomOpuszczeniaRookgaard);

            Assert.AreEqual(1565m, MP);
        }
        [Test]
        public void SorcDruid_Poziom30_WyliczPunktyZycia295()
        {
            string profesjaString = "Sorc/Druid";
            int poziomLiczba = 30;
            int poziomOpuszczeniaRookgaard = 8;

            int HP = TibCalcLogic.WyliczPunktyZycia(profesjaString, poziomLiczba, poziomOpuszczeniaRookgaard);

            Assert.AreEqual(295m, HP);
        }
        [Test]
        public void Paladin_Poziom45_WyliczBaseSpeed154()
        {
            int poziomLiczba = 45;

            int SPEED = TibCalcLogic.WyliczBaseSpeed(poziomLiczba);

            Assert.AreEqual(154m, SPEED);
        }
        [Test]
        public void SorcDruid_Poziom200_WyliczExpDoLvl1970200()
        {
            int poziomLiczba = 200;

            int EXPNALVL = TibCalcLogic.WyliczExpDoLvl(poziomLiczba);

            Assert.AreEqual(1970200m, EXPNALVL);
        }
        [Test]
        public void SorcDruid_Poziom120_WyliczDoswiadczenie27393800()
        {
            int poziomLiczba = 120;

            int EXP = TibCalcLogic.WyliczDoswiadczenie(poziomLiczba);

            Assert.AreEqual(27393800m, EXP);
        }
        }
}
