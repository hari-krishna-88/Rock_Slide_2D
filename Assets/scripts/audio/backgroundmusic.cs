using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance;
    private AudioSource audiosource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audiosource = GetComponent<AudioSource>();

            audiosource.volume = PlayerPrefs.GetFloat("MusicVolume", 1.0f);

            if (!audiosource.isPlaying)
            {
                audiosource.Play();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to set volume from the slider
    public void SetVolume(float volume)
    {
        if (audiosource != null)
        {
            audiosource.volume = volume;
            PlayerPrefs.SetFloat("MusicVolume", volume);
            PlayerPrefs.Save();
        }
    }
    private void Update()
    {

    }
}
