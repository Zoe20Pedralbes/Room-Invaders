using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;

    void spawnEnemy()
    {
        enemyPrefab.SetActive(true);
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