using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsPrefs : MonoBehaviour
{
    [SerializeField] private Slider sliderValue;
    [SerializeField] private TMP_Text sliderText;


    public void slidertextValue(float volume)
    {
        sliderText.text = volume.ToString("0.0");
    }

    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValues");
        sliderValue.value = volumeValue;
        AudioListener.volume = volumeValue;
    }

    public void SaveVolumeButton()
    {
        float volumeValue = sliderValue.value;
        PlayerPrefs.SetFloat("VolumeValues", volumeValue);
        LoadValues();
    }

   
    
    void Start()
    {
        LoadValues();
    }
}
