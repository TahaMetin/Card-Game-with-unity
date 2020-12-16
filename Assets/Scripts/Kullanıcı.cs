using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kullanıcı : Oyuncu
{
    public Kullanıcı()
    {

    }
    public Kullanıcı(int oyuncuID, string oyuncuAdi, int skor) : base(oyuncuID, oyuncuAdi, skor)
    {

    }
    public override void KartSec()
    {
        //kullanıcıya kart sectirme işlemi test sınıfında yapıldı
    }

}
