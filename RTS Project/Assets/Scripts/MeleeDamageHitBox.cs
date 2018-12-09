using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamageHitBox : MonoBehaviour {


    public int attackDamage;
    public Rigidbody Sword;

    private void Start()
    {
        Sword = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // attack for melee
        if (collision.gameObject.tag == "Enemy")
        {
            var hit = collision.gameObject;
            Health healthCS = hit.GetComponent<Health>();
            if (healthCS != null)
            {
                healthCS.TakeDamage(attackDamage);
            }
        }
    }
}
