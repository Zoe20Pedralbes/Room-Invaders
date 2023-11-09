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
        this.OnEnable();
        //animator = GetComponent<Animator>();
        //StartCoroutine(coroutineShoot());
    }
    void LateUpdate()
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
        //InvokeRepeating("Shoot", startShootingTime, repeatingTime);
        //startShooting=true;
    }
    void Shoot()
    {
        GameObject bullet = bulletPool.GetObject();
        //bullet.gameObject.tag = bulletTag;
        Debug.Log("Shooting");
        Debug.Log(bullet.active);
        bullet.GetComponent<TrailRenderer>().enabled = true;
        bullet.GetComponent<Bullet>().setDamage(this.gameObject.GetComponent<damageBehaviour>().getDamage());
        bullet.GetComponent<Bullet>().SetDirection(transform.forward, GetComponentInChildren<Transform>());
        //bullet.GetComponent<Bullet>().speedMultiplier =0;
    }
    public void endShoot()
    {
        CancelInvoke();
        animator.SetInteger("Move", 2);
    }

    private void OnEnable()
    {
        player = GameManager.gameManager.getPlayer();
        this.gameObject.transform.SetParent(player.transform.parent);
        animator = GetComponent<Animator>();
        animator.SetInteger("Move", 1);
    }
    void StartShooting() //Llamarse desde un evento al final de la animación de moverse.
    {
        bulletPool = new ObjectPooler(4, bulletPrefab, bulletTag);
        InvokeRepeating("Shoot", startShootingTime, repeatingTime);
    }

}
