using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

    public Transform Player;
    private GameObject[] gos;
    private Transform elocation;
    private bool canFire = true;

    public Transform fireLocation;
    public GameObject bulletPrefab;
    public bool autoAttack;

    public SelectUnits selectUnits;

    public GameObject playerAbilities;

    void Update()
    {
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;

        float distance = 20;
        Vector3 position = transform.position;

        foreach (GameObject go in gos)
        {
            //finding enemies nearest you
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && curDistance > 10)
            {
                closest = go;
                distance = curDistance;
                elocation = closest.transform;
                transform.LookAt(elocation);
            }
        }
        if (closest == null)
        {
            elocation = null;
        }
        if (canFire == true && elocation != null && autoAttack == true)
        {
            //teleport attack when off cooldown and close enough
            transform.LookAt(elocation);
            transform.position = elocation.position;
            canFire = false;
            StartCoroutine(FireAgain());
        }
    }

    IEnumerator FireAgain()
    {
        //cooldown for when you can attack again
        yield return new WaitForSeconds(1);
        canFire = true;
    }
}
