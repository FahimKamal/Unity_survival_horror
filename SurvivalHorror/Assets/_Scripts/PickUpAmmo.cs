using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAmmo : MonoBehaviour
{
    public GameObject ammoDisplayPanel;
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        ammoDisplayPanel.SetActive(true);
        GlobalAmmo.ammoCount += 6;
    }
}
