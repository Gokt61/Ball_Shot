using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Toplar;
    public GameObject FirePoint;
    public float TopGucu;
    int AktifTopIndex;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Toplar[AktifTopIndex].transform.SetPositionAndRotation(FirePoint.transform.position,FirePoint.transform.rotation);
            Toplar[AktifTopIndex].SetActive(true);

            Toplar[AktifTopIndex].GetComponent<Rigidbody>().AddForce(Toplar[AktifTopIndex].transform.TransformDirection(90, 90, 0) * TopGucu, ForceMode.Force);

            if (Toplar.Length-1 == AktifTopIndex)
            {
                AktifTopIndex = 0;
            }
            else
            {
                AktifTopIndex++;
            }
        }
    }
}
