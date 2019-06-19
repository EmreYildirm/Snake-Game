using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Oyun
    {
        public event OyunBasliyorHandler OyunBasliyor;
        public event OyunBittiHandler OyunBitti;
        public event YilanHareketiHandler YilanHareketEtti;
        public event YeminYeriDegistiHandler YeminYeriDegisti;

        private Yem _aktifYem;
        private Yılan _yilan;
        private YemUretici _yemUretici;
        private int _puan;
        private int _oyunAlaniGenisligi;
        private int _oyunAlaniYuksekligi;
        public int Puan
        {
            get { return _puan; }
        }
        public Oyun(int oyunAlaniGenislik,int oyunAlaniYukseklik)
        {
            _oyunAlaniGenisligi = oyunAlaniGenislik;
            _oyunAlaniYuksekligi = oyunAlaniYukseklik;
        }
        public void Baslat()
        {
            _yilan = new Yılan(_oyunAlaniGenisligi, _oyunAlaniYuksekligi);
            _yemUretici = new YemUretici(_oyunAlaniYuksekligi, _oyunAlaniGenisligi);
            _aktifYem = _yemUretici.YeniYemUret();
            _puan = 0;
            _yilan.YilanHareketEtti += new YilanHareketiHandler(_yilan_hareketEtti);
            _yilan.YilanKendisineDegdi += new YilanHareketiHandler(_yilan_kendisineDegdi);
            OyunBasliyor(_yilan.Konumlar.ToArray(), _aktifYem.Konum);
        }
        public void YilaniHareketEttir(Direction yon)
        {
            _yilan.YonDegistir(yon);
            _yilan.HareketEt();
        }
        public void _yilan_hareketEtti(Yılan yilan,ConsoleKonum kuyrukSonu,ConsoleKonum yilanBasi)
        {
            YilanHareketEtti(yilan, kuyrukSonu, yilanBasi);
        }
        public void _yilan_kendisineDegdi(Yılan yilan,ConsoleKonum kuyrukSonu,ConsoleKonum yilanBasi)
        {

        }
    }
}
