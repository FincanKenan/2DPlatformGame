using UnityEngine.SceneManagement;
using UnityEngine;
public class SahneKararma : MonoBehaviour
{

    public Animator anim;
    private int LevelToLoad;        // sahneler aras� ge�i� i�in olu�turdu�umuz int.

    public void FadeToLoad(int levelIndex)  // Kararma sonras� b�l�m�n y�klenmesi 
    {
        LevelToLoad = levelIndex;           // 
        anim.SetTrigger("Sahne��k��");      // animasyonu devreye sokan komut
    }

    public void OnFadeCopmlete()            // Kararma animasyonunun tamamlanmas�.
    {
        SceneManager.LoadScene(LevelToLoad);    // Kararma animasyonu tamamland�ktan sonra sahne ba�layacak bu methodu "Sahne��k��" adl� animasyonun sonunda tetiklenmesi i�in olu�turduk.
    }


    void Update()
    {

        {

        }
    }
}
