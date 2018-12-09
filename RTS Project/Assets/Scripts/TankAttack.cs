using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankAttack : MonoBehaviour {

	public Transform Player;
	private GameObject[] gos;
	private Transform elocation;
	private bool canFire = true;
	public Transform fireLocation;
	public GameObject bulletPrefab;
	private bool isRooted = false;
	private bool canChange = true;
	private Transform targetHitLocation;

	public ClickMovement clickMovement;
	public SelectUnits selectUnits;

	public GameObject tankAbilities;
	public Button tankMode;

	void Start()
	{
        //finds all components needed
        tankMode = tankAbilities.GetComponent<Button>();
		Button btn1 = tankMode.GetComponent<Button> ();
		btn1.onClick.AddListener (TankButton);
        tankAbilities.SetActive(false);
    }

    void Update()
	{
        //finds all enemies
        gos = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closest = null;

		float distance = 200;
		Vector3 position = transform.position;


		foreach (GameObject go in gos)
		{
            //finds closest enemy
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
				elocation = closest.transform;
				transform.LookAt (elocation);
			} 
		}

		if (Input.GetKeyDown(KeyCode.E) && !isRooted && selectUnits.isSelected == true && canChange) {
            //turns on rooted
			isRooted = true;
			canChange = false;
			clickMovement.canMove = false;
			StartCoroutine (ChangeTime ());
		}
		if (isRooted && Input.GetKeyDown(KeyCode.E) && canChange && selectUnits.isSelected == true) {
            //turns off rooted
			isRooted = false;
			canChange = false;
			clickMovement.canMove = true;
			StartCoroutine (ChangeTime ());
		}
			
		if (closest == null) {
			elocation = null;
		}
		if (isRooted && canFire && elocation != null) {
			StartCoroutine (Fire ());
			canFire = false;
			StartCoroutine (FireAgain ());
		}
	}
	void TankButton ()
	{
		if (!isRooted && canChange && selectUnits.isSelected == true) {
            //turns of rooted via button
			isRooted = true;
			canChange = false;
			clickMovement.canMove = false;
			StartCoroutine (ChangeTime ());
		}
		if (isRooted && canChange && selectUnits.isSelected == true) {
            //turns off rooted via button
			isRooted = false;
			canChange = false;
			clickMovement.canMove = true;
			StartCoroutine (ChangeTime ());
		}
	}

	IEnumerator FireAgain()
	{
        //when you can fire again
		yield return new WaitForSeconds (3);
		canFire = true;
	}
	IEnumerator ChangeTime()
	{
        //when you can root/unroot yourself
		yield return new WaitForSeconds (2);
		canChange = true;
	}
	IEnumerator Fire()
	{
        //time bullet takes to reach destination
		targetHitLocation = elocation;
		yield return new WaitForSeconds (1);
		Instantiate (bulletPrefab, targetHitLocation.transform.position, targetHitLocation.transform.rotation);
	}
}