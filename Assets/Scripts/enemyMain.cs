using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMain : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public GameObject bulletPrefab;
    public ObjectPooler bulletPool;
    [SerializeField] private string bulletTag;
    [SerializeField] private Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.gameManager.getPlayer();
        //StartCoroutine(coroutineShoot());
        bulletPool = new ObjectPooler(4, bulletPrefab, bulletTag);
        InvokeRepeating("Shoot", 1, .5f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform, Vector3.up);
    }

    void Shoot()
    {
        GameObject bullet = bulletPool.GetObject();
        //bullet.gameObject.tag = bulletTag;
        Debug.Log("Shooting");
        Debug.Log(bullet.active);
        bullet.GetComponent<Bullet>().SetDirection(transform.forward, GetComponentInChildren<Transform>());
    }


    /* IEnumerator coroutineShoot()
     {
         while (true)
         {
             GameObject bullet = ObjectPooler.poolInstance.GetPooledObject();
             if (bullet != null)
             {
                 bullet.SetActive(true);
             }
             yield return new WaitForSecondsRealtime(.5f);

         }


     }
    */
}
