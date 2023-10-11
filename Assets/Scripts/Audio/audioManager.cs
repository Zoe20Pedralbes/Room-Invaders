using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class audioManager : MonoBehaviour
{
    public static audioManager instance { get; private set; }


    private void Awake()
    {
        if (instance == null)
        {
            Debug.LogError("Hay más de 1 audioManager en la escena");
        }

        instance = this;

    }

    public void PlayOneShot(EventReference sound, Vector3 worldPosition)
    {
        RuntimeManager.PlayOneShot(sound, worldPosition);
    }
}
