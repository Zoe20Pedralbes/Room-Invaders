using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : damageBehaviour
{
    [SerializeField] private const float initialLifeTime = 2;
    private float lifeTime;
    public float speedMultiplier;
    private Vector3 velocity;
    [SerializeField] private EventReference bulletSound;
    private ObjectPooler pool;

    public void SetDirection(Vector3 direction, Transform spawnPoint)
    {
        transform.position = spawnPoint.position;
        velocity = direction * speedMultiplier;
    }



    private void Start()
    {
        lifeTime = initialLifeTime;
        //Debug.Log("Bala instanciada");
        //audioManager.instance.PlayOneShot(bulletSound, this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            this.gameObject.SetActive(false);
        }
        transform.position += velocity * Time.deltaTime;

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(this.gameObject, 0.03f);
        Debug.Log("Poom");
        this.pool.ToPool(this.gameObject);
        this.gameObject.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    public int getDamage()
    {
        this.pool.ToPool(this.gameObject);
        this.gameObject.SetActive(false);
        return damage;
    }

    public void setPool(ObjectPooler pool)
    {
        this.pool = pool;
    }

    private void OnEnable()
    {
        lifeTime = initialLifeTime;
    }
    private void OnDisable()
    {
        Debug.Log("Disable Bullet");
    }
}
