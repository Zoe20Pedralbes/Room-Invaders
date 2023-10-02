using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : HealthBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("eBullet"))
        {
            if (other.gameObject.TryGetComponent<damageBehaviour>(out damageBehaviour damageBehaviour))
            {
                getHit(damageBehaviour.getDamage());
            }
        }
    }

    void checkLife()
    {
        if (actualHealth <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
