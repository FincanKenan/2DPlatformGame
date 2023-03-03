using UnityEngine.SceneManagement;
using UnityEngine;
public class SahneKararma : MonoBehaviour
{

    public Animator anim;
    private int LevelToLoad;        // sahneler arasý geçiþ için oluþturduðumuz int.

    public void FadeToLoad(int levelIndex)  // Kararma sonrasý bölümün yüklenmesi 
    {
        LevelToLoad = levelIndex;           // 
        anim.SetTrigger("SahneÇýkýþ");      // animasyonu devreye sokan komut
    }

    public void OnFadeCopmlete()            // Kararma animasyonunun tamamlanmasý.
    {
        SceneManager.LoadScene(LevelToLoad);    // Kararma animasyonu tamamlandýktan sonra sahne baþlayacak bu methodu "SahneÇýkýþ" adlý animasyonun sonunda tetiklenmesi için oluþturduk.
    }


    void Update()
    {

        {

        }
    }
}
