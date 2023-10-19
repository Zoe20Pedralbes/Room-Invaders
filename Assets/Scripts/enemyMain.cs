using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMain : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public GameObject bulletPrefab;
    public ObjectPooler bulletPool;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.gameManager.getPlayer();
        //StartCoroutine(coroutineShoot());
        InvokeRepeating("Shoot", 1, .5f);
        bulletPool = new ObjectPooler(4, bulletPrefab, "eBullet");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
    }

    void Shoot()
    {
        GameObject bullet = bulletPool.GetObject();
        
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
