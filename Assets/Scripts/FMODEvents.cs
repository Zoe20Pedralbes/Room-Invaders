using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Coin SFX")]
    [field: SerializeField] public EventReference coinCollected { get; private set; }

    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference playerTakeOff { get; private set; }

    [field: Header("Música")]
    [field: SerializeField] public EventReference playMusicLvl1 {  get; private set; }
    public static FMODEvents instance {  get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Encontrado más de un FMOD Events instance en la escena");
        }
        instance = this;
    }
}
