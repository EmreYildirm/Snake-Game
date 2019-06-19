using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class YemUretici
    {
        private int _konsolGenislik;
        private int _konsolYukseklik;
        public YemUretici(int konsolYukseklik,int konsolGenislik)
        {
            _konsolGenislik = konsolGenislik;
            _konsolYukseklik = konsolYukseklik;
        }
        public Yem YeniYemUret()
        {
            Random rnd = new Random();
            Yem yeniYem = new Yem();
            yeniYem.Konum.UsteOlanUzaklik = rnd.Next(1, _konsolYukseklik);
            yeniYem.Konum.SolaOlanUzaklik = rnd.Next(1, _konsolGenislik);
            return yeniYem;
        }
    }
}
