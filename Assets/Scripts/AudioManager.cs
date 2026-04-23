using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

     void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.playOnAwake = false;
            s.source.loop = s.loop;
        }
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds,sound  => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("ses bulunamadý :" +  name);
            return;

        }
        
            s.source.Play();
    }

    public void PlaySoundAtPosition(string name, Vector3 position)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Ses bulunamadý: " + name);
            return;
        }

        // Yeni bir GameObject oluþtur ve sesi orada çal
        GameObject soundObject = new GameObject("Sound_" + name);
        soundObject.transform.position = position;

        AudioSource source = soundObject.AddComponent<AudioSource>();
        source.clip = s.clip;
        source.volume = s.volume;
        source.pitch = s.pitch;
        source.spatialBlend = 1.0f; // 3D Ses Efekti (Mesafeye baðlý olacak)
        source.rolloffMode = AudioRolloffMode.Logarithmic;
        source.minDistance = 2f; // Yakýndan tam ses
        source.maxDistance = 50f; // 50 birim uzaklýkta ses çok az duyulacak
        source.loop = s.loop;

        source.Play();

        // Ses bittiðinde nesneyi yok et
        if (!s.loop)
        {
            Destroy(soundObject, s.clip.length);
        }
    }
    public void StopSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null || s.source == null)
        {
            Debug.LogWarning("Ses bulunamadý veya oynatýlmýyor: " + name);
            return;
        }

        s.source.Stop(); //  Ses çalýyorsa durdur
    }

}
