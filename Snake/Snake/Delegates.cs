using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public delegate void YilanHareketiHandler(Yılan yilan, ConsoleKonum kuyrukSonu, ConsoleKonum yilanBasi);
    public delegate void OyunBittiHandler(Oyun oyun);
    public delegate void YeminYeriDegistiHandler(Yem yem);
    public delegate void OyunBasliyorHandler(ConsoleKonum[] yilanGovdeKonumlari, ConsoleKonum yemKonumu);
}
