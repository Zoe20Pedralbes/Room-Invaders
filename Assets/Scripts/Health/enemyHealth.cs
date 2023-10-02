using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : HealthBehaviour
{


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
