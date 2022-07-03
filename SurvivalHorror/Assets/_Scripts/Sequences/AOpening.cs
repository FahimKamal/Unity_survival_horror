using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class AOpening : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject fadeScreenIn;
    public GameObject textBox;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(SceenPlayer());
    }

    IEnumerator SceenPlayer()
    {
        yield return new WaitForSeconds(1.5f);
        fadeScreenIn.SetActive(false);
        textBox.GetComponent<Text>().text = "I need to get out of here.";
        yield return new WaitForSeconds(2.0f);
        textBox.GetComponent<Text>().text = "";
        thePlayer.GetComponent<FirstPersonController>().enabled = true;
    }
}
