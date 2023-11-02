using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab1;

    [SerializeField] private Transform spawnPoint;

    void spawnEnemy()
    {
        enemyPrefab1.SetActive(true);
        //enemyPrefab.GetComponent<Animator>().SetFloat();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawnEnemy();
        }
    }
}
