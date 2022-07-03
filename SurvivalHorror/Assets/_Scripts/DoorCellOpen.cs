using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorCellOpen : MonoBehaviour
{
    public float theDistance;
    [Tooltip("Name of the button to press for the action.")]
    public GameObject actionDisplay;
    [Tooltip("Name of the action.")]
    public GameObject actionText;
    [Tooltip("The gameobject that has the Animation component for door opening.")]
    public GameObject theDoor;
    [Tooltip("Cross that will apear while mouse is on the door.")]
    public GameObject extraCross;

    [Tooltip("The Sound of the door opening.")]
    public AudioSource creakSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        theDistance = PlayerCasting.distanceFromTarget;

    }

    private void OnMouseOver()
    {
        if(theDistance <= 3)
        {
            actionDisplay.SetActive(true);
            actionText.SetActive(true);
            extraCross.SetActive(true);
        }

        if (Input.GetButtonDown("Action"))
        {
            if(theDistance <= 2)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                actionDisplay.SetActive(false);
                actionText.SetActive(false);
                theDoor.GetComponent<Animation>().Play("FirstDoorOpenAnim");
                creakSound.Play();
                StartCoroutine(CloseDoor());
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

    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(5.0f);
        gameObject.GetComponent<BoxCollider>().enabled = true;
        theDoor.GetComponent<Animation>().Play("FirstDoorCloseAnim");
        creakSound.Play();
    }
}
