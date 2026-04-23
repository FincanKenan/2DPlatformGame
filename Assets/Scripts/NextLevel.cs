using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private Door door;

    private void Start()
    {
        door = FindObjectOfType<Door>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bir nesne kapýya çarptý: " + collision.gameObject.name);

        if (collision.CompareTag("Player") && door.isdoorReady == true) // Koþul saðlanmýþsa
        {
            Debug.Log("Koþul saðlandý! Kapýya giriþ yapýlýyor...");

            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) // Geçerli sahne sýnýrlarýný aþmadýðýndan emin ol
            {
                Debug.Log("Sonraki sahneye geçiliyor: " + nextSceneIndex);
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.LogWarning("Son sahnedesin! Daha ileri bir sahne yok.");
            }
        }
    }



}
