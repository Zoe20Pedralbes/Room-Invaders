using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageBehaviour : MonoBehaviour
{
    [SerializeField]
    protected int damage=1;

    



    public int getDamage()
    {
        return damage;
    }
}
