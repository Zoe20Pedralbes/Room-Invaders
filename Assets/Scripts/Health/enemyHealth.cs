using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : HealthBehaviour
{
    [SerializeField]
    protected EventReference HealthDie;
    protected int enemyScore = 1;
    protected override void getHit(int dmg)
    {
        actualHealth = actualHealth - dmg;
        checkLife();
    }

    private void checkLife()
    {
        if (actualHealth <= 0)
        {
            OnEnemyDie.Invoke(enemyScore);

            //Destroy(this.gameObject, destroyDelay);
            this.gameObject.SetActive(false);
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pBullet"))
        {
            if (other.gameObject.TryGetComponent<damageBehaviour>(out damageBehaviour damageBehaviour))
            {
                getHit(damageBehaviour.getDamage());
            }
        }
    }

    public static event Action<int> OnEnemyDie = delegate { };

}
