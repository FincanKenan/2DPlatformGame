using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{

    public Button[] LevelButtons;   // "LevelSelect" ekran�ndaki butonlar �zerinde i�lem yapabilmek i�in array olu�turduk. Buraya Unity i�erisinden buttonlar�m�z� s�r�kledik.

    void Start()    // A�a��daki kodlar� start methoduna yazmam�z�n sebebi oyun ba�lar ba�lamaz kaydetmesini istiyoruz. 
    {
        int LevelReached = PlayerPrefs.GetInt("LevelReached2", 1);   // Mevcut seviyemizi kaydetmek i�in "int LevelReached"isimli de�i�ken olu�turduk. Oyunun bulundu�umuz seviyeyi kaydetmesini istiyoruz bu nedenle GetInt komutunu kulland�k bunu daha sonra SetInt ile �a��raca��z ve bu kay�t�n ad�na ise "LevelReached" dedik. 1 yazd�k ��nk� birinci butonun yani 1. seviyenin her zaman a��k olmas�n� istiyoruz.

        for (int i = 0; i < LevelButtons.Length; i++)       // Butonlar�m�z i�in bir de�er olu�turduk, her bir buton i�in bir de�er girece�iz, array ile belirtti�imiz de�i�kenlerde bir i�lem yapmak i�in genelde bu komutu kullan�r�z. Burada ki "i" de�i�kenini ula�t���m�z b�l�m yani mevcut seviyemiz olarak d���nebiliriz.
        {
            if (i + 1 > LevelReached)       //  E�er mevcut seviyemiz daha �nce ula�m�� oldu�umuz seviyeden b�y�kse,  sonraki seviyeler ve gelmi� oldu�umuz seviyeler i�in yapmak istedi�imiz i�lemler.
            {
                LevelButtons[i].interactable = false;   // Burada gelmi� oldu�umuz seviyelere kadar olan b�l�m se�me butonlar� a��k yani se�ilebilir olacak hen�z ula�mad���m�z seviyeler ise kapal� olacak komutunu yazd�k.
            }
        }
    }


    void Update()
    {

    }
}
