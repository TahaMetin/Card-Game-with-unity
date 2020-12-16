using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Futbolcu : Sporcu
{
    private int penalti;
    private int serbestAtis;
    private int kaleciKarsiKarsiya;
    private bool kartKullanildiMi = false;

    public int GetPenalti() { return penalti; }
    public void SetPenalti(int deger) { penalti = deger; }
    public int GetSerbestAtis() { return serbestAtis; }
    public void SetSerbestAtis(int deger) { serbestAtis = deger; }
    public int GetKaleciKarsiKarsiya() { return kaleciKarsiKarsiya; }
    public void SetKaleciKarsiKarsiya(int deger) { kaleciKarsiKarsiya = deger; }
    public bool GetKartKullanildiMi() { return kartKullanildiMi; }
    public void SetKartKullanildiMi(bool deger) { kartKullanildiMi = deger; }
    public Futbolcu()
    {
        penalti = -1;
        serbestAtis = -1;
        kaleciKarsiKarsiya = -1;
    }
    public Futbolcu(string adi, string takimi, int penalti, int serbestAtis, int kaleciKarsiKarsiya) : base(adi, takimi) // javadaki super() in C# taki karşılığı base() 
    {
        this.penalti = penalti;
        this.serbestAtis = serbestAtis;
        this.kaleciKarsiKarsiya = kaleciKarsiKarsiya;
    }

    public override int SporcuPuaniGoster(int i)
    {
        switch (i)
        {
            case 0:
                return penalti;
            case 1:
                return serbestAtis;
            case 2:
                return kaleciKarsiKarsiya;
            default:
                return -1;
        }
    }
    

}
