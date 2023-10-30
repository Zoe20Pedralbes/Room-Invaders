using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private int points = 1;
    [SerializeField] private EventReference coinSound;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.gameManager.Score(points);
            audioManager.AudioManager.PlayOneShot(FMODEvents.instance.coinCollected, transform.position);
            Destroy(this.gameObject);
        }
        
    }


}
