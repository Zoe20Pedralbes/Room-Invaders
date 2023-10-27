using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class audioManager : MonoBehaviour
{
    public static audioManager AudioManager { get; private set; }


    private void Awake()
    {
        if (AudioManager != null)
        {
            Debug.LogError("Hay más de 1 audioManager en la escena");
        }

        AudioManager = this;

    }

    public void PlayOneShot(EventReference sound, Vector3 worldPosition)
    {
        RuntimeManager.PlayOneShot(sound, worldPosition);
    }
}
