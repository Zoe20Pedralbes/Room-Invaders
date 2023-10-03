using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthBehaviour : MonoBehaviour
{
    [SerializeField]
    protected int maxHealth;
    [SerializeField]
    protected int actualHealth;
    [SerializeField]
    protected float destroyDelay = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        actualHealth = maxHealth;
    }

    protected virtual void getHit()
    {
        actualHealth--;
        checkLife();
    }

    protected virtual void checkLife()
    {
        if (actualHealth <= 0)
            Destroy(this.gameObject, destroyDelay);
    }

    protected abstract void getHit(int dmg);

    protected void OnTriggerEnter(Collider other)
    {
        getHit();
    }
}
