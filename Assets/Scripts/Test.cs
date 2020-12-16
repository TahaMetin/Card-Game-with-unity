using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public Text KarsilastirilacakPozisyon, BilgisayarinOzellikPuani, KullanicininOzellikPuani, elinSporu,kullaniciSkoru,BilgisayarSkoru;
    public GameObject[] futbolcuKartlari,basketbolcuKartlari;
    public GameObject bilgisayarKartAtmaYeri, kullaniciKartAtmaYeri,bilgisayarKartYeri,kullaniciKartYeri,FutbolcuKarti,BasketbolcuKarti;
    public Sprite B_ersan, B_furkan, B_hidayet, B_ibrahim, B_mehmet, B_mirsad, B_omer, B_semih, F_abdulkadir, F_caglar, F_cengiz, F_cenk, F_hakan, F_okay, F_yusuf, F_zeki;
    public Button nextButton;
    private Futbolcu silinenFutbolcuKarti;
    private Basketbolcu silinenBasketbolcuKarti;
    public GameObject bilgisayarFutbolcuKarti, bilgisayarBasketbolcuKarti;
    Bilgisayar bilgisayar = new Bilgisayar(320102091, "Bilgisayar", 0);  // bilgisayara kartlarını rastgele verir
    Kullanıcı kullanıcı = new Kullanıcı(190201023, "Taha", 0);  // kalan kartları kullanıcıya verir
    bool elDegismeli=true;

    List<int> pozisyonlar = new List<int>();

    private void Start()
    {
        pozisyonlar.Add(0);
        pozisyonlar.Add(1);
        pozisyonlar.Add(2);

        nextButton.onClick.AddListener(TaskOnclick);

        Futbolcu cengiz = new Futbolcu("Cengiz Ünder", "Leicester City FC", 80,75,80);          // kartlar değerleriyle birlikte tanımlanıyor
        Futbolcu hakan = new Futbolcu("Hakan Çalhanoğlu", "AC Milan", 90,70,80);
        Futbolcu cenk = new Futbolcu("Cenk Tosun", "Everton FC", 85,90,80);
        Futbolcu caglar = new Futbolcu("Çağlar Söyüncü", "Leicester City FC", 65,95,80);
        Futbolcu yusuf = new Futbolcu("Yusuf Yazıcı", "Lille OSC", 85,85,80);
        Futbolcu okay = new Futbolcu("Okay Yokuşlu", "RC Celta de Vigo", 90,85,80);
        Futbolcu zeki = new Futbolcu("Zeki Çelik", "Lille OSC", 75,75,90);
        Futbolcu abdulkadir = new Futbolcu("Abdülkadir Ömür", "Trabzonspor", 80,80,80);

        Basketbolcu mirsad = new Basketbolcu("Mirsad Türkcan", "New York Knicks", 90,95,80);
        Basketbolcu hidayet = new Basketbolcu("Hidayet Türkoğlu", "Sacramento Kings", 90,90,65);
        Basketbolcu mehmet = new Basketbolcu("Mehmet Okur", "Detroit Pistons", 90,80,80);
        Basketbolcu ibrahim = new Basketbolcu("İbrahim Kutluay", "Seattle Supersonics", 90,75,90);
        Basketbolcu ersan = new Basketbolcu("Ersan İlyasova", "Milwaukee Bucks", 90,85,65);
        Basketbolcu omer = new Basketbolcu("Ömer Aşık", "Chicago Bulls", 90,75,85);
        Basketbolcu semih = new Basketbolcu("Semih Erden", "Boston Celtics", 90,85,70);
        Basketbolcu furkan = new Basketbolcu("Furkan Aldemir", "Philadelphia 76ers", 90,70,80);


        Oyuncu futbolcular = new Oyuncu();      //tüm futbolcular bir listeye atılıyor
        futbolcular.futbolcuKartlariListesi.Add(cengiz);
        futbolcular.futbolcuKartlariListesi.Add(hakan);
        futbolcular.futbolcuKartlariListesi.Add(cenk);
        futbolcular.futbolcuKartlariListesi.Add(caglar);
        futbolcular.futbolcuKartlariListesi.Add(yusuf);
        futbolcular.futbolcuKartlariListesi.Add(okay);
        futbolcular.futbolcuKartlariListesi.Add(zeki);
        futbolcular.futbolcuKartlariListesi.Add(abdulkadir);
        
        Oyuncu basketbolcular = new Oyuncu();       // tüm basketbolcular bir listeye atılıyor
        basketbolcular.basketbolcukartlariListesi.Add(mirsad);
        basketbolcular.basketbolcukartlariListesi.Add(hidayet);
        basketbolcular.basketbolcukartlariListesi.Add(mehmet);
        basketbolcular.basketbolcukartlariListesi.Add(ibrahim);
        basketbolcular.basketbolcukartlariListesi.Add(ersan);
        basketbolcular.basketbolcukartlariListesi.Add(omer);
        basketbolcular.basketbolcukartlariListesi.Add(semih);
        basketbolcular.basketbolcukartlariListesi.Add(furkan);

        for(int i = 0; i < 4; i++)
        {
            int rastgeleSayi = Random.Range(0, futbolcular.futbolcuKartlariListesi.Count);
            bilgisayar.futbolcuKartlariListesi.Add(futbolcular.futbolcuKartlariListesi[rastgeleSayi]);
            futbolcular.futbolcuKartlariListesi.RemoveAt(rastgeleSayi);
            rastgeleSayi = Random.Range(0, basketbolcular.basketbolcukartlariListesi.Count);
            bilgisayar.basketbolcukartlariListesi.Add(basketbolcular.basketbolcukartlariListesi[rastgeleSayi]);
            basketbolcular.basketbolcukartlariListesi.RemoveAt(rastgeleSayi);
        }

        for (int i = 0; i < 4; i++)
        {
            kullanıcı.futbolcuKartlariListesi.Add(futbolcular.futbolcuKartlariListesi[i]);
            kullanıcı.basketbolcukartlariListesi.Add(basketbolcular.basketbolcukartlariListesi[i]);
        }

        int k = 0;
        foreach (GameObject gameObject in futbolcuKartlari)
        {
            
            Transform child = gameObject.transform.Find("Adi");
            child.GetComponent<Text>().text = kullanıcı.futbolcuKartlariListesi[k].GetSporcıIsim();
            child = gameObject.transform.Find("Takimi");
            child.GetComponent<Text>().text = kullanıcı.futbolcuKartlariListesi[k].GetSporcıTakim();
            child = gameObject.transform.Find("PenaltiPuani");
            child.GetComponent<Text>().text = kullanıcı.futbolcuKartlariListesi[k].GetPenalti().ToString();
            child = gameObject.transform.Find("Serbest Atis Puani");
            child.GetComponent<Text>().text = kullanıcı.futbolcuKartlariListesi[k].GetSerbestAtis().ToString();
            child = gameObject.transform.Find("Kaleci ile Karsi Karsiya Puani");
            child.GetComponent<Text>().text = kullanıcı.futbolcuKartlariListesi[k].GetKaleciKarsiKarsiya().ToString();
            child = gameObject.transform.Find("Fotograf");
            ResimiKoy(child.GetComponent<Image>(), kullanıcı.futbolcuKartlariListesi[k].GetSporcıIsim());
            k++;

        }
        k = 0;
        foreach (GameObject gameObject in basketbolcuKartlari)
        {
            Transform child = gameObject.transform.Find("Adi");
            child.GetComponent<Text>().text = kullanıcı.basketbolcukartlariListesi[k].GetSporcıIsim();
            child = gameObject.transform.Find("Takimi");
            child.GetComponent<Text>().text = kullanıcı.basketbolcukartlariListesi[k].GetSporcıTakim();
            child = gameObject.transform.Find("İkilik Puani");
            child.GetComponent<Text>().text = kullanıcı.basketbolcukartlariListesi[k].GetIkilik().ToString();
            child = gameObject.transform.Find("Ucluk Puani");
            child.GetComponent<Text>().text = kullanıcı.basketbolcukartlariListesi[k].GetUcluk().ToString();
            child = gameObject.transform.Find("Serbest Atis Puani");
            child.GetComponent<Text>().text = kullanıcı.basketbolcukartlariListesi[k].GetSerbestAtis().ToString();
            child = gameObject.transform.Find("Fotograf");
            ResimiKoy(child.GetComponent<Image>(), kullanıcı.basketbolcukartlariListesi[k].GetSporcıIsim());
            k++;
        }
        BasketbolculariSürüklenemezFutbolculariSürüklenebilirYap();

    }
    void ResimiKoy(Image image , string adi)
    {
        switch (adi){
            case "Cengiz Ünder":
                image.sprite = F_cengiz;
                break;
            case "Hakan Çalhanoğlu":
                image.sprite = F_hakan;
                break;
            case "Cenk Tosun":
                image.sprite = F_cenk;
                break;
            case "Çağlar Söyüncü":
                image.sprite = F_caglar;
                break;
            case "Yusuf Yazıcı":
                image.sprite = F_yusuf;
                break;
            case "Okay Yokuşlu":
                image.sprite = F_okay;
                break;
            case "Zeki Çelik":
                image.sprite = F_zeki;
                break;
            case "Abdülkadir Ömür":
                image.sprite =F_abdulkadir;
                break;
            case "Mirsad Türkcan":
                image.sprite = B_mirsad;
                break;
            case "Hidayet Türkoğlu":
                image.sprite = B_hidayet;
                break;
            case "Mehmet Okur":
                image.sprite = B_mehmet;
                break;
            case "İbrahim Kutluay":
                image.sprite = B_ibrahim;
                break;
            case "Ersan İlyasova":
                image.sprite = B_ersan;
                break;
            case "Ömer Aşık":
                image.sprite = B_omer;
                break;
            case "Semih Erden":
                image.sprite = B_semih;
                break;
            case "Furkan Aldemir":
                image.sprite = B_furkan;
                break;

        }

        KarsilastirilacakPozisyon.text = "";
        BilgisayarinOzellikPuani.text = "";
        KullanicininOzellikPuani.text = "";

    }

    void OyunuBitir()
    {
        PlayerPrefs.SetInt("KullaniciPuani", int.Parse(kullaniciSkoru.text));
        PlayerPrefs.SetInt("BilgisayarPuani", int.Parse(BilgisayarSkoru.text));
        SceneManager.LoadScene(1);
    }

    int ilkPozisyon;
    void TaskOnclick()
    {

        if (bilgisayarKartAtmaYeri.transform.childCount == 0)
        {

            if (elinSporu.text == "F")
            {
                BilgisayaraKartAttir(0);
            }
            else
            {
                BilgisayaraKartAttir(1);
            }
        }
        else if (!bilgisayarKartAtmaYeri.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.activeSelf) // kartlar açılmamış ise
        {
            if (kullaniciKartAtmaYeri.transform.childCount > 0) // kart atıp atmadığımızı kontrol eder
            {
                BilgisayarinKartiniDoldur();
                BilgisayarinKartiniAc();
                ilkPozisyon = PozisyonuBelirle();
                PosizyonuKarsilastir(ilkPozisyon);
            }
        }
        else  // kartlar açılmış ise
        {
            Debug.Log("dsa");
            if (elDegismeli)
            {
                if (elinSporu.text == "F")
                {
                    elinSporu.text = "B";
                    FutbolculariSürüklenemezBasketbolculariSürüklenebilirYap();
                }
                else if(elinSporu.text == "B")
                {
                    elinSporu.text = "F";
                    BasketbolculariSürüklenemezFutbolculariSürüklenebilirYap();
                }

            }
            else
            {
                if (kullaniciKartYeri.transform.childCount > 0)
                {
                    if (elinSporu.text == "F")
                    {
                        bilgisayar.futbolcuKartlariListesi.Add(silinenFutbolcuKarti);
                        Instantiate(bilgisayarFutbolcuKarti, bilgisayarKartYeri.transform);
                        bilgisayarKartYeri.transform.GetChild(bilgisayarKartYeri.transform.childCount - 1).SetSiblingIndex(0);
                        kullaniciKartAtmaYeri.transform.GetChild(0).transform.SetParent(kullaniciKartYeri.transform);
                        Destroy(bilgisayarKartAtmaYeri.transform.GetChild(0).gameObject);
                    }
                    else
                    {
                        bilgisayar.basketbolcukartlariListesi.Add(silinenBasketbolcuKarti);
                        Instantiate(bilgisayarBasketbolcuKarti, bilgisayarKartYeri.transform);
                        kullaniciKartAtmaYeri.transform.GetChild(0).transform.SetParent(kullaniciKartYeri.transform);
                        Destroy(bilgisayarKartAtmaYeri.transform.GetChild(0).gameObject);
                    }
                }
                else
                {

                    pozisyonlar.Remove(ilkPozisyon);
                    ilkPozisyon = Random.Range(0, pozisyonlar.Count);
                    PosizyonuKarsilastir(pozisyonlar[ilkPozisyon]);
                    return;
                }
            }
            KarsilastirilacakPozisyon.text = "";
            BilgisayarinOzellikPuani.text = "";
            KullanicininOzellikPuani.text = "";
            if(kullaniciKartAtmaYeri.transform.childCount>0)
                Destroy(kullaniciKartAtmaYeri.transform.GetChild(0).gameObject);
            if (bilgisayarKartAtmaYeri.transform.childCount > 0)
                Destroy(bilgisayarKartAtmaYeri.transform.GetChild(0).gameObject);
        }
    }

    void FutbolculariSürüklenemezBasketbolculariSürüklenebilirYap()
    {
        foreach(var kart in futbolcuKartlari)
        {
            if(kart != null)
                kart.GetComponent<Draggable>().enabled = false;
        }
        foreach (var kart in basketbolcuKartlari)
        {
            if(kart != null)
                kart.GetComponent<Draggable>().enabled = true;
        }
    }
    void BasketbolculariSürüklenemezFutbolculariSürüklenebilirYap()
    {
        foreach (var kart in basketbolcuKartlari)
        {
            if (kart != null)
                kart.GetComponent<Draggable>().enabled = false;
        }
        foreach (var kart in futbolcuKartlari)
        {
            if(kart != null)
                kart.GetComponent<Draggable>().enabled = true;
        }
    }
    public void BilgisayarinKartiniDoldur()
    {
        if(elinSporu.text == "F")
        {
            int k = Random.Range(0, bilgisayar.futbolcuKartlariListesi.Count);
            Transform child = bilgisayarKartAtmaYeri.transform.GetChild(0).gameObject.transform.Find("Adi");
            child.GetComponent<Text>().text = bilgisayar.futbolcuKartlariListesi[k].GetSporcıIsim();
            child = bilgisayarKartAtmaYeri.transform.GetChild(0).gameObject.transform.Find("Takimi");
            child.GetComponent<Text>().text = bilgisayar.futbolcuKartlariListesi[k].GetSporcıTakim();
            child = bilgisayarKartAtmaYeri.transform.GetChild(0).gameObject.transform.Find("PenaltiPuani");
            child.GetComponent<Text>().text = bilgisayar.futbolcuKartlariListesi[k].GetPenalti().ToString();
            child = bilgisayarKartAtmaYeri.transform.GetChild(0).gameObject.transform.Find("Serbest Atis Puani");
            child.GetComponent<Text>().text = bilgisayar.futbolcuKartlariListesi[k].GetSerbestAtis().ToString();
            child = bilgisayarKartAtmaYeri.transform.GetChild(0).gameObject.transform.Find("Kaleci ile Karsi Karsiya Puani");
            child.GetComponent<Text>().text = bilgisayar.futbolcuKartlariListesi[k].GetKaleciKarsiKarsiya().ToString();
            child = bilgisayarKartAtmaYeri.transform.GetChild(0).gameObject.transform.Find("Fotograf");
            ResimiKoy(child.GetComponent<Image>(), bilgisayar.futbolcuKartlariListesi[k].GetSporcıIsim());
            silinenFutbolcuKarti = bilgisayar.futbolcuKartlariListesi[k];
            bilgisayar.futbolcuKartlariListesi.RemoveAt(k);
        }
        else
        {
            int k = Random.Range(0, bilgisayar.basketbolcukartlariListesi.Count);
            Transform child = bilgisayarKartAtmaYeri.transform.GetChild(0).gameObject.transform.Find("Adi");
            child.GetComponent<Text>().text = bilgisayar.basketbolcukartlariListesi[k].GetSporcıIsim();
            child = bilgisayarKartAtmaYeri.transform.GetChild(0).gameObject.transform.Find("Takimi");
            child.GetComponent<Text>().text = bilgisayar.basketbolcukartlariListesi[k].GetSporcıTakim();
            child = bilgisayarKartAtmaYeri.transform.GetChild(0).gameObject.transform.Find("İkilik Puani");
            child.GetComponent<Text>().text = bilgisayar.basketbolcukartlariListesi[k].GetIkilik().ToString();
            child = bilgisayarKartAtmaYeri.transform.GetChild(0).gameObject.transform.Find("Ucluk Puani");
            child.GetComponent<Text>().text = bilgisayar.basketbolcukartlariListesi[k].GetUcluk().ToString();
            child = bilgisayarKartAtmaYeri.transform.GetChild(0).gameObject.transform.Find("Serbest Atis Puani");
            child.GetComponent<Text>().text = bilgisayar.basketbolcukartlariListesi[k].GetSerbestAtis().ToString();
            child = bilgisayarKartAtmaYeri.transform.GetChild(0).gameObject.transform.Find("Fotograf");
            ResimiKoy(child.GetComponent<Image>(), bilgisayar.basketbolcukartlariListesi[k].GetSporcıIsim());
            silinenBasketbolcuKarti = bilgisayar.basketbolcukartlariListesi[k];
            bilgisayar.basketbolcukartlariListesi.RemoveAt(k);
        }
    }
    public void BilgisayaraKartAttir(int fulbolcu0Basketbolcu1)
    {
        if (bilgisayarKartYeri.transform.childCount == 0)
        {
            OyunuBitir();
            return;
        }
        if (fulbolcu0Basketbolcu1 == 0)
        {
            Destroy(bilgisayarKartYeri.transform.GetChild(0).gameObject);
            Instantiate(FutbolcuKarti, bilgisayarKartAtmaYeri.transform);
            for (int i = 0; i < 11; i++)
                bilgisayarKartAtmaYeri.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        else
        {
            Destroy(bilgisayarKartYeri.transform.GetChild(bilgisayarKartYeri.transform.childCount-1).gameObject);
            Instantiate(BasketbolcuKarti, bilgisayarKartAtmaYeri.transform);
            for (int i = 0; i < 11; i++)
                bilgisayarKartAtmaYeri.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void BilgisayarinKartiniAc()
    {
        for (int i = 0; i < 11; i++)
            bilgisayarKartAtmaYeri.transform.GetChild(0).gameObject.transform.GetChild(i).gameObject.SetActive(true);
    }

    public int PozisyonuBelirle()
    {
        return Random.Range(0, 3); //  0 1 2 döner
    }

    public void PosizyonuKarsilastir(int pozisyon) 
    {
        int aPuan=0, bPuan=0;
        if (elinSporu.text == "F")
        {
            switch (pozisyon)
            {
                case 0:
                    KarsilastirilacakPozisyon.text = "Penalti";
                    aPuan = int.Parse(bilgisayarKartAtmaYeri.transform.GetChild(0).transform.Find("PenaltiPuani").gameObject.GetComponent<Text>().text);
                    bPuan = int.Parse(kullaniciKartAtmaYeri.transform.GetChild(0).transform.Find("PenaltiPuani").gameObject.GetComponent<Text>().text);
                    break;
                case 1:
                    KarsilastirilacakPozisyon.text = "Serbest Atis";
                    aPuan = int.Parse(bilgisayarKartAtmaYeri.transform.GetChild(0).transform.Find("Serbest Atis Puani").gameObject.GetComponent<Text>().text);
                    bPuan = int.Parse(kullaniciKartAtmaYeri.transform.GetChild(0).transform.Find("Serbest Atis Puani").gameObject.GetComponent<Text>().text);
                    break;
                case 2:
                    KarsilastirilacakPozisyon.text = "Kaleci ile Karşı Karşıya";
                    aPuan = int.Parse(bilgisayarKartAtmaYeri.transform.GetChild(0).transform.Find("Kaleci ile Karsi Karsiya Puani").gameObject.GetComponent<Text>().text);
                    bPuan = int.Parse(kullaniciKartAtmaYeri.transform.GetChild(0).transform.Find("Kaleci ile Karsi Karsiya Puani").gameObject.GetComponent<Text>().text);
                    break;
            }
            KullanicininOzellikPuani.text = bPuan.ToString();
            BilgisayarinOzellikPuani.text = aPuan.ToString();
            if (aPuan < bPuan)
            {
                kullaniciSkoru.text = (int.Parse(kullaniciSkoru.text)+5).ToString();
                elDegismeli = true;

            }
            else if (aPuan > bPuan)
            {
                BilgisayarSkoru.text = (int.Parse(BilgisayarSkoru.text) + 5).ToString();
                elDegismeli = true;

            }
            else
            {
                elDegismeli = false;

            }

        }
        else
        {
            switch (pozisyon)
            {
                case 0:
                    KarsilastirilacakPozisyon.text = "İkilik";
                    aPuan = int.Parse(bilgisayarKartAtmaYeri.transform.GetChild(0).transform.Find("İkilik Puani").gameObject.GetComponent<Text>().text);
                    bPuan = int.Parse(kullaniciKartAtmaYeri.transform.GetChild(0).transform.Find("İkilik Puani").gameObject.GetComponent<Text>().text);
                    break;
                case 1:
                    KarsilastirilacakPozisyon.text = "Üçlük";
                    aPuan = int.Parse(bilgisayarKartAtmaYeri.transform.GetChild(0).transform.Find("Ucluk Puani").gameObject.GetComponent<Text>().text);
                    bPuan = int.Parse(kullaniciKartAtmaYeri.transform.GetChild(0).transform.Find("Ucluk Puani").gameObject.GetComponent<Text>().text);
                    break;
                case 2:
                    KarsilastirilacakPozisyon.text = "Serbest Atış";
                    aPuan = int.Parse(bilgisayarKartAtmaYeri.transform.GetChild(0).transform.Find("Serbest Atis Puani").gameObject.GetComponent<Text>().text);
                    bPuan = int.Parse(kullaniciKartAtmaYeri.transform.GetChild(0).transform.Find("Serbest Atis Puani").gameObject.GetComponent<Text>().text);
                    break;
            }
            KullanicininOzellikPuani.text = bPuan.ToString();
            BilgisayarinOzellikPuani.text = aPuan.ToString();
            if (aPuan < bPuan)
            {
                kullaniciSkoru.text = (int.Parse(kullaniciSkoru.text) + 5).ToString();
                elDegismeli = true;

            }
            else if (aPuan > bPuan)
            {
                BilgisayarSkoru.text = (int.Parse(BilgisayarSkoru.text) + 5).ToString();
                elDegismeli = true;

            }
            else
            {
                elDegismeli = false;

            }
        }
    }


}
