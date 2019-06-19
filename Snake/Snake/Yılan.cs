using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public class Yılan
    {
        public event YilanHareketiHandler YilanHareketEtti;
        public event YilanHareketiHandler YilanKendisineDegdi;
        public Queue<ConsoleKonum> Konumlar { get; set; }
        private ConsoleKonum _mevcutKafaKonumu;
        private Direction _mevcutYon;
        private int _oyunAlaniGenisligi;
        private int _oyunAlaniYuksekligi;

        public Yılan(int oyunAlaniGenisligi, int oyunAlaniYuksekligi)
        {
            Konumlar = new Queue<ConsoleKonum>();
            _oyunAlaniGenisligi = oyunAlaniGenisligi;
            _oyunAlaniYuksekligi = oyunAlaniYuksekligi;
            _mevcutYon = Direction.Right;
            for (int i = 0; i < 4; i++)
            {
                var varsayilanNokta = new ConsoleKonum() { SolaOlanUzaklik = 5 + i, UsteOlanUzaklik = oyunAlaniYuksekligi / 2 };
                Konumlar.Enqueue(varsayilanNokta);
                if (i == 3)
                {
                    _mevcutKafaKonumu = varsayilanNokta;
                }
            }
        }
        public void HareketEt()
        {
            var yeniKafaKonumu = YeniKafaKonumuYarat();
            var kuyruktanCikanKonum = Konumlar.Dequeue();
            CiktiysaGeriGirdir(yeniKafaKonumu);
            if (KuyrugaCarptiMi(yeniKafaKonumu))
                YilanKendisineDegdi(this, kuyruktanCikanKonum, yeniKafaKonumu);
            Konumlar.Enqueue(yeniKafaKonumu);
            _mevcutKafaKonumu = yeniKafaKonumu;
            if (YilanHareketEtti != null)
                YilanHareketEtti(this, kuyruktanCikanKonum, yeniKafaKonumu);
        }
        public void YonDegistir(Direction yon)
        {
            if (((int)_mevcutYon) % 2 == ((int)yon) % 2)
                return;
            _mevcutYon = yon;
        }
        public void Buyu()
        {
            var yeniKonum = YeniKafaKonumuYarat();
            this.Konumlar.Enqueue(yeniKonum);
        }
        private ConsoleKonum YeniKafaKonumuYarat()
        {
            ConsoleKonum yeniKafaKonumu = new ConsoleKonum();
            switch (_mevcutYon)
            {
                case Direction.Up:
                    yeniKafaKonumu.SolaOlanUzaklik = _mevcutKafaKonumu.SolaOlanUzaklik;
                    yeniKafaKonumu.UsteOlanUzaklik = _mevcutKafaKonumu.UsteOlanUzaklik - 1;
                    break;
                case Direction.Down:
                    yeniKafaKonumu.SolaOlanUzaklik = _mevcutKafaKonumu.SolaOlanUzaklik;
                    yeniKafaKonumu.UsteOlanUzaklik = _mevcutKafaKonumu.UsteOlanUzaklik + 1;
                    break;
                case Direction.Right:
                    yeniKafaKonumu.SolaOlanUzaklik = _mevcutKafaKonumu.SolaOlanUzaklik + 1;
                    yeniKafaKonumu.UsteOlanUzaklik = _mevcutKafaKonumu.UsteOlanUzaklik;
                    break;
                case Direction.Left:
                    yeniKafaKonumu.SolaOlanUzaklik = _mevcutKafaKonumu.SolaOlanUzaklik - 1;
                    yeniKafaKonumu.UsteOlanUzaklik = _mevcutKafaKonumu.UsteOlanUzaklik;
                    break;
            }
            return yeniKafaKonumu;
        }
        private void CiktiysaGeriGirdir(ConsoleKonum yeniKonum)
        {
            yeniKonum.SolaOlanUzaklik = yeniKonum.SolaOlanUzaklik > _oyunAlaniGenisligi ? 1 : yeniKonum.SolaOlanUzaklik;
            yeniKonum.UsteOlanUzaklik = yeniKonum.UsteOlanUzaklik > _oyunAlaniYuksekligi ? 1 : yeniKonum.UsteOlanUzaklik;
            yeniKonum.SolaOlanUzaklik = yeniKonum.SolaOlanUzaklik < 1 ? _oyunAlaniGenisligi : yeniKonum.SolaOlanUzaklik;
            yeniKonum.UsteOlanUzaklik = yeniKonum.UsteOlanUzaklik < 1 ? _oyunAlaniYuksekligi : yeniKonum.UsteOlanUzaklik;
        }
        private bool KuyrugaCarptiMi(ConsoleKonum yeniKafaKonumu)
        {
            return Konumlar.Contains(yeniKafaKonumu);
        }
    }
}
