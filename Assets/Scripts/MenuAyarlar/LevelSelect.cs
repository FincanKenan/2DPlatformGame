using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{

    public Button[] LevelButtons;   // "LevelSelect" ekranýndaki butonlar üzerinde iþlem yapabilmek için array oluþturduk. Buraya Unity içerisinden buttonlarýmýzý sürükledik.

    void Start()    // Aþaðýdaki kodlarý start methoduna yazmamýzýn sebebi oyun baþlar baþlamaz kaydetmesini istiyoruz. 
    {
        int LevelReached = PlayerPrefs.GetInt("LevelReached2", 1);   // Mevcut seviyemizi kaydetmek için "int LevelReached"isimli deðiþken oluþturduk. Oyunun bulunduðumuz seviyeyi kaydetmesini istiyoruz bu nedenle GetInt komutunu kullandýk bunu daha sonra SetInt ile çaðýracaðýz ve bu kayýtýn adýna ise "LevelReached" dedik. 1 yazdýk çünkü birinci butonun yani 1. seviyenin her zaman açýk olmasýný istiyoruz.

        for (int i = 0; i < LevelButtons.Length; i++)       // Butonlarýmýz için bir deðer oluþturduk, her bir buton için bir deðer gireceðiz, array ile belirttiðimiz deðiþkenlerde bir iþlem yapmak için genelde bu komutu kullanýrýz. Burada ki "i" deðiþkenini ulaþtýðýmýz bölüm yani mevcut seviyemiz olarak düþünebiliriz.
        {
            if (i + 1 > LevelReached)       //  Eðer mevcut seviyemiz daha önce ulaþmýþ olduðumuz seviyeden büyükse,  sonraki seviyeler ve gelmiþ olduðumuz seviyeler için yapmak istediðimiz iþlemler.
            {
                LevelButtons[i].interactable = false;   // Burada gelmiþ olduðumuz seviyelere kadar olan bölüm seçme butonlarý açýk yani seçilebilir olacak henüz ulaþmadýðýmýz seviyeler ise kapalý olacak komutunu yazdýk.
            }
        }
    }


    void Update()
    {

    }
}
