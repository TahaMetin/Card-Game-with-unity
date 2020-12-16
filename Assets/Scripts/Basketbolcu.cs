using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketbolcu : Sporcu
{
    private int ikilik;
    private int ucluk;
    private int serbestAtis;
    private bool kartKullanildiMi =false;
    public int GetIkilik() { return ikilik; }
    public void SetIkilik(int deger) { ikilik = deger; }
    public int GetUcluk() { return ucluk; }
    public void SetUcluk(int deger) { ucluk = deger; }
    public int GetSerbestAtis() { return serbestAtis; }
    public void SetSerbestAtis(int deger) { serbestAtis = deger; }
    public bool GetKartKullanildiMi() { return kartKullanildiMi; }
    public void SetKartKullanildiMi(bool deger) { kartKullanildiMi = deger; }
    public Basketbolcu()
    {
        ikilik = -1;
        ucluk = -1;
        serbestAtis = -1;
    }
    public Basketbolcu(string adi, string takimi, int ikilik, int ucluk, int serbestAtis) : base(adi, takimi)
    {
        this.ikilik = ikilik;
        this.ucluk = ucluk;
        this.serbestAtis = serbestAtis;
    }


    public override int SporcuPuaniGoster(int i)
    {
        switch (i)
        {
            case 0:
                return ikilik;
            case 1:
                return ucluk;
            case 2:
                return serbestAtis;
            default:
                return -1;
        }
    }
}
