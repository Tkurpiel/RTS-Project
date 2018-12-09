using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTracker : MonoBehaviour {

    SelectUnits selectUnits;

    public GameObject tankAbilities;
    public GameObject unitAbilities;
    public GameObject[] tanks;
    public GameObject[] units;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //keeps track of all the player units
        tanks = GameObject.FindGameObjectsWithTag("Tank1");
        for (int i = 0; i < tanks.Length; i++)
        {
            if(tanks[i].GetComponent<SelectUnits>().isSelected == true)
            {
                tankAbilities.SetActive(true);
                return;
            }
            else
            {
                tankAbilities.SetActive(false);
            }
        }
        units = GameObject.FindGameObjectsWithTag("Unit1");
        for (int i = 0; i < units.Length; i++)
        {
            if (units[i].GetComponent<SelectUnits>().isSelected == true)
            {
                unitAbilities.SetActive(true);
                return;
            }
            else
            {
                unitAbilities.SetActive(false);
            }
        }
    }
}
