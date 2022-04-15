using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{

    public Health enemyHealth;
    public int mult;

    public void Damage(int damage, Vector3 startPos)
    {
        enemyHealth.TakeDamage(damage * mult, startPos);
    }

}
