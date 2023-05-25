using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kova"))
        {
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.transform.localRotation = Quaternion.Euler(Vector3.zero);

            gameObject.SetActive(false);
        }
        else if (other.CompareTag("AltObje"))
        {
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.transform.localRotation = Quaternion.Euler(Vector3.zero);

            gameObject.SetActive(false);
        }
    }

}
