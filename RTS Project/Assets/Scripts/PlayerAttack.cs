using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

	public Transform Player;
	private GameObject[] gos;
	private Transform elocation;
	private bool canFire = true;
	public Transform fireLocation;
	public GameObject bulletPrefab;

	public SelectUnits selectUnits;

	public GameObject playerAbilities;


	void Start()
	{

	}

	void Update()
	{
        //find all enemies on the map
		gos = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closest = null;

		float distance = 200;
		Vector3 position = transform.position;

		foreach (GameObject go in gos)
		{
            //finds nearest enemy to attack
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
				elocation = closest.transform;
				transform.LookAt (elocation);
			} 
		}
		if (closest == null) {
            // if no enemies nearby cannot attack
			elocation = null;
		}
		if (canFire == true && elocation != null) {
            //shoots bullet
			Instantiate (bulletPrefab, fireLocation.transform.position, fireLocation.transform.rotation);
			canFire = false;
			StartCoroutine (FireAgain ());
		}
	}
	IEnumerator FireAgain()
	{
        //cooldwon for attack
		yield return new WaitForSeconds (3);
		canFire = true;
	}
}