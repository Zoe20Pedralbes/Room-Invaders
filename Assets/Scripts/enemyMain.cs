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
    public bool shootBool;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.gameManager.getPlayer();
        //animator = GetComponent<Animator>();
        //StartCoroutine(coroutineShoot());
    }
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
        bullet.GetComponent<Bullet>().setDamage(this.gameObject.GetComponent<damageBehaviour>().getDamage());
        bullet.GetComponent<Bullet>().SetDirection(transform.forward, GetComponentInChildren<Transform>());
    }

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("Move", 1);
    }
    void StartShooting() //Llamarse desde un evento al final de la animación de moverse.
    {
        bulletPool = new ObjectPooler(4, bulletPrefab, bulletTag);
        InvokeRepeating("Shoot", 1, .5f);
    }

}
