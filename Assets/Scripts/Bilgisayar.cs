using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilgisayar : Oyuncu
{
    public Bilgisayar()
    {

    }
    public Bilgisayar(int oyuncuID, string oyuncuAdi, int skor) : base(oyuncuID,oyuncuAdi,skor)
    {

    }

    public override void KartSec()
    {
        //randam kart secme işlemi test sınıfında yapıldı
    }

}
