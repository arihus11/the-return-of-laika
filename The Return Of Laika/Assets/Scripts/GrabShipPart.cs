using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Laika.Utils;

public class GrabShipPart : MonoBehaviour
{
    private bool isInGrabRange = false;
    private GameObject shipPartInRange = null;

    public GameObject shipPartGrabbed = null;

    private Transform playerTransform;
    private Transform grabbableParentTransform;
    public static bool holdingPart;
    public static bool firstGrabEver;
    public static ShipPartEnum grabbedPartID;

    public static bool newPartGrabForShower;

    public static List<string> alredyGrabbedParts;

    void Start()
    {
        alredyGrabbedParts = new List<string>();
        newPartGrabForShower = false;
        grabbedPartID = ShipPartEnum.None;
        firstGrabEver = false;
        holdingPart = false;
        playerTransform = this.gameObject.transform;
        grabbableParentTransform = GameObject.Find("GrabbableParts").transform;

        shipPartGrabbed = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInGrabRange)
            {
                handleGrab();
            }
            else
            {
                handleRelease();
            }
        }

        if (shipPartGrabbed != null)
        {
            if (Shield.shieldActive == true || (GameObject.FindGameObjectWithTag("shower1") != null && GameObject.FindGameObjectWithTag("shower2") != null))
            {
                Color tmp = shipPartGrabbed.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color;
                tmp.a = 0f;
                shipPartGrabbed.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = tmp;
            }
            else if (Shield.shieldActive == false || (GameObject.FindGameObjectWithTag("shower1") == null && GameObject.FindGameObjectWithTag("shower2") == null))
            {
                Color tmp1 = shipPartGrabbed.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color;
                tmp1.a = 1f;
                shipPartGrabbed.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = tmp1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Methods.isGrabbableShip(other.gameObject.tag))
        {
            isInGrabRange = true;
            shipPartInRange = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (Methods.isGrabbableShip(other.gameObject.tag))
        {
            isInGrabRange = false;
            shipPartInRange = null;
        }
    }

    private void handleGrab()
    {
        if (Shield.shieldActive == false)
        {
            handleRelease();
            firstGrabEver = true;
            PlayerPrefs.SetInt("FirstMeteorShowerPref", 1);
            shipPartGrabbed = shipPartInRange;
            if (!(alredyGrabbedParts.Contains((shipPartGrabbed.gameObject.GetComponent<ShipPartID>().returnPartID()).ToString())))
            {
                alredyGrabbedParts.Add((shipPartGrabbed.gameObject.GetComponent<ShipPartID>().returnPartID()).ToString());
                newPartGrabForShower = true;
            }
            GameObject.Find("ShipPartName").gameObject.GetComponent<Text>().text = shipPartGrabbed.gameObject.GetComponent<ShipPartID>().returnPartName();
            GameObject.Find("ShipPartNameContainer").gameObject.GetComponent<Animator>().Play("ShipPartMessage", -1, 0f);
            shipPartGrabbed.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            shipPartGrabbed.gameObject.GetComponent<Animator>().enabled = false;
            grabbedPartID = shipPartGrabbed.gameObject.GetComponent<ShipPartID>().returnPartID();
            SoundManagerScript.PlaySound("grab");
            holdingPart = true;
            shipPartInRange = null;

            attachShipPart();
        }
    }

    public void handleRelease(bool playSound = true)
    {
        if (shipPartGrabbed != null && shipPartGrabbed != shipPartInRange && Shield.shieldActive == false)
        {
            shipPartGrabbed.gameObject.GetComponent<Animator>().enabled = true;
            grabbedPartID = ShipPartEnum.None;
            shipPartGrabbed.transform.SetParent(grabbableParentTransform);
            shipPartGrabbed.gameObject.GetComponent<CircleCollider2D>().enabled = true;
            holdingPart = false;
            if (playSound) SoundManagerScript.PlaySound("grab");
            shipPartGrabbed = null;
        }
    }

    private void attachShipPart()
    {
        shipPartGrabbed.transform.SetParent(playerTransform);

        shipPartGrabbed.transform.localPosition = Vector3.zero;
    }
}
