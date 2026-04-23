using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private float resTime = 1.5f;
    public GameObject doorBack;

    public void RestartStart()
    {
        StartCoroutine(ResetScene());
    }

    private IEnumerator ResetScene()
    {
        yield return new WaitForSeconds(resTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
