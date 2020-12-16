using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oyuncu : MonoBehaviour
{
    int oyuncuID,skor;
    string oyuncuAdi;
    public List<Futbolcu> futbolcuKartlariListesi = new List<Futbolcu>();
    public List<Basketbolcu> basketbolcukartlariListesi = new List<Basketbolcu>();

    public int GetOyuncuID() { return oyuncuID; }
    public void SetOyuncuID(int ID) { oyuncuID = ID; }
    public int GetSkor() { return skor; }
    public void SetSkor(int skor) { this.skor = skor; }
    public string GetOyuncuAdi() { return oyuncuAdi; }
    public void SetOyuncuAdi(string ad) { oyuncuAdi = ad; }
    
    public Oyuncu()
    {
        oyuncuAdi = "Oyuncu Adi girilmemis";
        oyuncuID = -1;
        skor = 0;
    }
    public Oyuncu(int oyuncuID, string oyuncuAdi, int skor)
    {
        this.oyuncuID = oyuncuID;
        this.oyuncuAdi = oyuncuAdi;
        this.skor = skor;
    }
    public int SkorGoster()
    {
        return skor;
    }
    public virtual void KartSec()
    {

    }
}
