using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour {

    public GameObject unit1;
    public GameObject unit2;

    public float cost1;
    public float cost2;

    public Button button1;
    public Button button2;

    public Transform spawnLocation;

    public SelectUnits selectUnits;
    public GameObject buildingAbilities;
    public Money money;

    // Use this for initialization
    void Start () {
        button1.onClick.AddListener(Unit1Spawn);
        button2.onClick.AddListener(Unit2Spawn);
    }

    void Update()
    {
        //Checks to see if object is selected
        if (selectUnits.isSelected)
        {
            buildingAbilities.SetActive(true);
        }
        else
        {
            buildingAbilities.SetActive(false);
        }
    }

    public void Unit1Spawn ()
    {
        //Spawns unit if you have enough money
        if(money.currentMoney >= cost1)
        {
            money.currentMoney -= cost1;
            Instantiate(unit1, spawnLocation.position, spawnLocation.rotation);

        }
    }

    public void Unit2Spawn()
    {
        //Spawns unit if you have enough money
        if (money.currentMoney >= cost2)
        {
            money.currentMoney -= cost2;
            Instantiate(unit2, spawnLocation.position, spawnLocation.rotation);
            unit2.GetComponent<TankAttack>().tankAbilities = GameObject.FindWithTag("TankAbilities").transform.GetChild(0).gameObject;
        }
    }
}
