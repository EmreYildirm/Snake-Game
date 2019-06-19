using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        private const string yilanSembolu = "*";
        private const string yemSembolu = "o";
        private const int _oyunAlaniYükseklik = 30;
        private const int _oyunAlaniGenislik = 80;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Oyun oyun = new Oyun(_oyunAlaniGenislik, _oyunAlaniYükseklik);
            oyun.OyunBasliyor += new OyunBasliyorHandler(YilaniVeYemiCiz);
            oyun.YilanHareketEtti += new YilanHareketiHandler(yilan_HareketEtti);
            oyun.Baslat();
            do
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        oyun.YilaniHareketEttir(Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        oyun.YilaniHareketEttir(Direction.Down);
                        break;
                    case ConsoleKey.RightArrow:
                        oyun.YilaniHareketEttir(Direction.Right);
                        break;
                    case ConsoleKey.LeftArrow:
                        oyun.YilaniHareketEttir(Direction.Left);
                        break;

                }
            } while (true);
        }
        public static void YilaniVeYemiCiz(ConsoleKonum[] yilanGovdeKonumlari,ConsoleKonum yemKonumu)
        {
            foreach(var konum in yilanGovdeKonumlari)
            {
                Console.SetCursorPosition(konum.SolaOlanUzaklik, konum.UsteOlanUzaklik);
                Console.Write(yilanSembolu);
            }
            Console.SetCursorPosition(yemKonumu.SolaOlanUzaklik, yemKonumu.UsteOlanUzaklik);
            Console.Write(yemSembolu);
        }
        public static void yilan_HareketEtti(Yılan yilan,ConsoleKonum kuyruk,ConsoleKonum bas)
        {
            Console.SetCursorPosition(bas.SolaOlanUzaklik, bas.UsteOlanUzaklik);
            Console.Write(yilanSembolu);
            Console.SetCursorPosition(kuyruk.SolaOlanUzaklik, kuyruk.UsteOlanUzaklik);
            Console.Write(" ");
        }
    }
}
