using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : damageBehaviour
{
    [SerializeField] private const float initialLifeTime = 2;
    private float lifeTime;
    public float speedMultiplier;
    public GameObject explosionPrefab;
    private Vector3 velocity;
    [SerializeField]private ObjectPooler pool;
    private Transform spawnPoint;
    [SerializeField] private int bulletDamage = 1;


    private void Start()
    {
        lifeTime = initialLifeTime;
        audioManager.AudioManager.PlayOneShot(FMODEvents.instance.bulletShot, this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            pool.ToPool(this.gameObject);
            //this.gameObject.SetActive(false);
        }
        transform.position += velocity * Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {
        this.pool.ToPool(this.gameObject);
        this.gameObject.SetActive(false);
        GameObject expl = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(expl, .4f);
    }

    public void SetDirection(Vector3 direction, Transform spawnPoint)
    {
        transform.position = spawnPoint.position;
        velocity = direction * speedMultiplier;
        this.spawnPoint = spawnPoint;
    }

    public void setDamage(int damage)
    {
        bulletDamage = damage;
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
        audioManager.AudioManager.PlayOneShot(FMODEvents.instance.bulletShot, this.transform.position);
    }

    private void OnDisable()
    {
        TrailRenderer trailRenderer = this.GetComponent<TrailRenderer>();
        trailRenderer.enabled = false;
        trailRenderer.Clear();
        //this.transform.position = spawnPoint.position;
    }

}
