using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class KazananSahnesiYonetimi : MonoBehaviour
{
    public Button button;
    public Text text,skorText;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(OnClick);
        int kullaniciSkoru, bilgisayarSkoru;
        kullaniciSkoru = PlayerPrefs.GetInt("KullaniciPuani");
        bilgisayarSkoru = PlayerPrefs.GetInt("BilgisayarPuani");

        if (bilgisayarSkoru < kullaniciSkoru)
        {
            text.text = "Kullanici Kazandi";
        }
        else if(bilgisayarSkoru > kullaniciSkoru)
        {
            text.text = "Bilgisayar Kazandi";
        }
        else
        {
            text.text = "Berabere";
        }
        skorText.text = kullaniciSkoru+" vs " +bilgisayarSkoru ;
    }

    void OnClick()
    {
        SceneManager.LoadScene(0);
    }

}
