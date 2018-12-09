using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int health;

	// Use this for initialization
	void Start () {
		
	}
	
	public void TakeDamage (int amount)
	{
        //whenever you take damage you lose health based on the damage of the object
		health -= amount;

		if (health <= 0) {
			Destroy (gameObject);
		}
	}

	void Update () {

	}
}
