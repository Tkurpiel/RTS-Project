using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickMovement : MonoBehaviour {

	public Camera cam;
    public GameObject mCamera;
	public NavMeshAgent agent;
	public SelectUnits selectUnits;
	public bool canMove = true;

	void Start()
	{
        mCamera = GameObject.FindWithTag("MainCamera");
        cam = mCamera.GetComponent<Camera>();
		canMove = true;
	}
	void Update () {
		gameObject.GetComponent<SelectUnits> ();
        //moves gameobject when seleted and can move
		if (Input.GetMouseButtonDown (1) && selectUnits.isSelected == true && canMove == true) 
		{
				Ray ray = cam.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit)) {
					agent.SetDestination (hit.point);
				}
		}
	}
}
