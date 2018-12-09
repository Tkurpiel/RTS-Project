using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Pool
{
    public GameObject unitsAvailable;
    public float costsPerUnit = 1;
    public Button unitButton;
}

public class SpawnUnits : MonoBehaviour {
    public List<Pool> spawnableUnits;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public SelectUnits selectUnits;
    public GameObject buildingAbilities;
    public float money = 100;

	// Use this for initialization
	void Start () {
        buildingAbilities.SetActive(false);
        foreach (Pool pool in spawnableUnits)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (selectUnits.isSelected)
        {
            buildingAbilities.SetActive(true);
        }
        else
        {
            buildingAbilities.SetActive(false);
        }
    }
    private void AddButtons ()
    {
        //for (int i = 0 < )
    }
}
