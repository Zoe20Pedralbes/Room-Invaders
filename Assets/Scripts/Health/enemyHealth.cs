using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : HealthBehaviour
{
    protected override void getHit(int dmg)
    {
        actualHealth = actualHealth - dmg;
        checkLife();
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
}
