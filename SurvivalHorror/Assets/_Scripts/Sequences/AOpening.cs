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

    public AudioSource line01;
    public AudioSource line02;

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
        textBox.GetComponent<Text>().text = "...where am I?";
        line01.Play();
        yield return new WaitForSeconds(2.0f);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(0.5f);
        textBox.GetComponent<Text>().text = "I need to get out of here.";
        line02.Play();
        yield return new WaitForSeconds(1.5f);
        textBox.GetComponent<Text>().text = "";
        thePlayer.GetComponent<FirstPersonController>().enabled = true;
    }
}
