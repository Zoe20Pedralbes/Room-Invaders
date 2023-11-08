using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMain : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public GameObject bulletPrefab;
    public ObjectPooler bulletPool;
    [SerializeField] private string bulletTag;
    [SerializeField] private float waitTimeToLeave;
    [SerializeField] private Transform spawnPoint;
    public bool shootBool;
    private Animator animator;
    [SerializeField] private float startShootingTime = 0.5f, repeatingTime = 0.8f;
    private bool startShooting = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.gameManager.getPlayer();
        Debug.Log("Padre de player: " + player.transform.parent);
        this.gameObject.transform.SetParent(player.transform.parent);
        //animator = GetComponent<Animator>();
        //StartCoroutine(coroutineShoot());
    }
    void Update()
    {
        transform.LookAt(player.transform, Vector3.up);
        if (startShooting)
        {
            waitTimeToLeave -= Time.deltaTime;
        }
        if (waitTimeToLeave < 0 )
            endShoot();
    }
    public void startShoot()
    {
        /*InvokeRepeating("Shoot", startShootingTime, repeatingTime);
        startShooting=true;*/
    }
    void Shoot()
    {
        GameObject bullet = bulletPool.GetObject();
        //bullet.gameObject.tag = bulletTag;
        startShooting = true;
        Debug.Log("Shooting");
        Debug.Log(bullet.active);
        bullet.GetComponent<Bullet>().setDamage(this.gameObject.GetComponent<damageBehaviour>().getDamage());
        bullet.GetComponent<Bullet>().SetDirection(transform.forward, GetComponentInChildren<Transform>());
    }
    public void endShoot()
    {
        CancelInvoke();
        animator.SetInteger("Move", 2);
    }

    private void OnEnable()
    {
        Debug.Log("Padre de player: "+player.transform.parent);
        //this.gameObject.transform.SetParent(player.transform.parent);
        animator = GetComponent<Animator>();
        animator.SetInteger("Move", 1);
    }
    void StartShooting() //Llamarse desde un evento al final de la animación de moverse.
    {
        bulletPool = new ObjectPooler(4, bulletPrefab, bulletTag);
        InvokeRepeating("Shoot", startShootingTime, repeatingTime);
    }

}
