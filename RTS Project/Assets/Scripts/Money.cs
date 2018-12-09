using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour {

    //in charge of keeping track of your money
    public Text moneyText;
    public float currentMoney = 100;


    void Start () {
        currentMoney = 100;
	}
	
	void Update () {
        moneyText.text = currentMoney.ToString();
	}
}
