using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.SceneManagement;

public class audioManager : MonoBehaviour
{
    public static audioManager AudioManager { get; private set; }

    private List<EventInstance> eventInstances;
    private EventInstance musicEventInstance;

    private void Awake()
    {
        if (AudioManager != null)
        {
            Debug.LogError("Hay más de 1 audioManager en la escena");
        }

        AudioManager = this;
        eventInstances = new List<EventInstance>();

    }
    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            InitializeMusic(FMODEvents.instance.playMusicLvl1);
        }
    }

    private void InitializeMusic(EventReference musicEventReference)
    {
        musicEventInstance = CreateInstance(musicEventReference);
        musicEventInstance.start();
    }
    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPosition)
    {
        RuntimeManager.PlayOneShot(sound, worldPosition);
    }
}
