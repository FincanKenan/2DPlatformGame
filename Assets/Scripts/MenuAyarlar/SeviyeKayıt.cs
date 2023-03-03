using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeviyeKayıt : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")   // Bölümün sonuna player ulaştırsa komutu.
        {
            int sahneler = SceneManager.GetActiveScene().buildIndex;        // sahneler isimli bir int oluşturduk ve bunu o anki mevcut sahne neyse ona eşitledik, bunu yapmamızın sebebi playerprefs ayarlarını kaydederken geldiğimiz mevcut seviyeyinin kayıt altına alınmasını istememiz. 

           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   // nextLevelZone'a playerımız ulaştığında bir sonraki sahneyi yükleme komutu.
            PlayerPrefs.SetInt("LevelReached2", sahneler);       // Oyuncu bir sonraki seviyeye geçtiğinde bunun "LevelSelect" ekranında seçilebilmesi ve geldiğimiz seviyeyi oyuna daha sonra girdiğimizde görebilmek için yazdığımız kod. Oluşturduğumuz "int sahneler" ile bu veriyi doldurduk çünkü mevcut sahne hangisiyse onun yüklenmesini istiyoruz. 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
