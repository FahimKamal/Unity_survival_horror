using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class BFirstTrigger : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject textBox;
    public GameObject theMarker;

    private void OnTriggerEnter(Collider other)
    {
        //thePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(SceenPlayer());
    }

    IEnumerator SceenPlayer()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        textBox.GetComponent<Text>().text = "Looks like a weapon on that table.";
        theMarker.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        textBox.GetComponent<Text>().text = "";
        //thePlayer.GetComponent<FirstPersonController>().enabled = true;
        
    }
}
