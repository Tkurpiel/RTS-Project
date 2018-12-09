using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;
	public Rigidbody bullet;
	public int attackDamage;

	void Start()
	{
		bullet = GetComponent<Rigidbody> ();
		StartCoroutine (DestroyBullet ());
	}

	void Update () {
        //moves bullet forward
		bullet.velocity = transform.forward * speed;
	}

	void OnCollisionEnter(Collision collision)
	{
        //if hit an enemy destroy object and deal damage
        if (collision.gameObject.tag == "Enemy")
        {
            var hit = collision.gameObject;
            Health healthCS = hit.GetComponent<Health>();
            if (healthCS != null)
            {
                healthCS.TakeDamage(attackDamage);
            }
            Destroy(gameObject);
        }
	}
	IEnumerator DestroyBullet()
	{
		yield return new WaitForSeconds (2);
		Destroy (gameObject);
	}
}
