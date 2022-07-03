using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpPistol : MonoBehaviour
{
    public float theDistance;
    [Tooltip("Name of the button to press for the action.")]
    public GameObject actionDisplay;
    [Tooltip("Name of the action.")]
    public GameObject actionText;
    public GameObject fakePistol;
    public GameObject realPistol;
    public GameObject guidArrow;
    public GameObject extraCross;
    public GameObject ammoDisplayPanel;
    public GameObject theJumpTrigger;

    [Tooltip("The Sound of the pistol picking up.")]
    public AudioSource pickUpSound;

    // Update is called once per frame
    void Update()
    {
        theDistance = PlayerCasting.distanceFromTarget;
    }

    private void OnMouseOver()
    {
        if(theDistance <= 2)
        {
            actionDisplay.SetActive(true);
            actionText.GetComponent<Text>().text = "Pick Up Postol";
            actionText.SetActive(true);            
            extraCross.SetActive(true);
        }

        if (Input.GetButtonDown("Action"))
        {
            if(theDistance <= 2)
            {
                //gameObject.GetComponent<BoxCollider>().enabled = false;
                actionDisplay.SetActive(false);
                actionText.SetActive(false);
                fakePistol.SetActive(false);
                realPistol.SetActive(true);
                ammoDisplayPanel.SetActive(true);
                extraCross.SetActive(false);
                guidArrow.SetActive(false);
                theJumpTrigger.SetActive(true);
                //pickUpSound.Play();
            }
        }
    }

    private void OnMouseExit()
    {
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
        extraCross.SetActive(false);
        //gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
