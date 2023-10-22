using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Sound Effects")]
    public AudioClip waterFX;
    public AudioClip growFX;
    public AudioClip popFX;

    private AudioSource sfxSource;

    // Awake is called on object initialisation
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        sfxSource = gameObject.AddComponent<AudioSource>();

    }

    //Methods for calling sound effects
    public void WaterSound()
    {
        sfxSource.PlayOneShot(waterFX);
    }
    public void GrowSound()
    {
        sfxSource.PlayOneShot(growFX);
    }
    public void PopSound()
    {
        sfxSource.PlayOneShot(popFX);
    }

}
