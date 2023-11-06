using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<GameObject> enemies;
    [SerializeField] private List<Transform> spawnPoint;

    void spawnEnemy()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            enemies[i].SetActive(true);
            enemies[i].transform.position = spawnPoint[i].position;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawnEnemy();
        }
    }
}
