using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sporcu : MonoBehaviour
{
    private string sporcuIsim;
    private string sporcuTakim;

    public string GetSporcıIsim() { return sporcuIsim; }
    public void SetSporcuIsim(string isim) { sporcuIsim = isim; }
    public string GetSporcıTakim() { return sporcuTakim; }
    public void SetSporcuTakim(string isim) { sporcuTakim = isim; }
    public  Sporcu()
    {
        sporcuIsim = "Isim Bilgisi Girilmemis";
        sporcuTakim = "Takim Bilgisi Girilmemis";
    }
    public Sporcu(string isim, string takim)
    {
        sporcuIsim = isim;
        sporcuTakim = takim;
    }
    public virtual int SporcuPuaniGoster(int i)
    {
        return -1;
    }

}
