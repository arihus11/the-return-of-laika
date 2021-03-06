using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlanetRange : MonoBehaviour
{
    public static bool insidePlanetRange1, insidePlanetRange2, insidePlanetRange3, insidePlanetRange4,
    insidePlanetRange5, insidePlanetRange6, insidePlanetRange7, insidePlanetRange8, insidePlanetRange9, insidePlanetRange10,
    insidePlanetRange11, insidePlanetRange12, insidePlanetRange13;
    // Start is called before the first frame update
    void Start()
    {
        insidePlanetRange1 = false;
        insidePlanetRange2 = false;
        insidePlanetRange3 = false;
        insidePlanetRange4 = false;
        insidePlanetRange5 = false;
        insidePlanetRange6 = false;
        insidePlanetRange7 = false;
        insidePlanetRange8 = false;
        insidePlanetRange9 = false;
        insidePlanetRange10 = false;
        insidePlanetRange11 = false;
        insidePlanetRange12 = false;
        insidePlanetRange13 = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "basicplanet1" && GrabShipPart.holdingPart == false)
        {
            insidePlanetRange1 = true;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("PushHintDisplay", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet2" && GrabShipPart.holdingPart == false)
        {
            insidePlanetRange2 = true;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("PushHintDisplay", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet3" && GrabShipPart.holdingPart == false)
        {
            insidePlanetRange3 = true;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("PushHintDisplay", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet4" && GrabShipPart.holdingPart == false)
        {
            insidePlanetRange4 = true;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("PushHintDisplay", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet5" && GrabShipPart.holdingPart == false)
        {
            insidePlanetRange5 = true;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("PushHintDisplay", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet6" && GrabShipPart.holdingPart == false)
        {
            insidePlanetRange6 = true;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("PushHintDisplay", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet7" && GrabShipPart.holdingPart == false)
        {
            insidePlanetRange7 = true;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("PushHintDisplay", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet8" && GrabShipPart.holdingPart == false)
        {
            insidePlanetRange8 = true;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("PushHintDisplay", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet9" && GrabShipPart.holdingPart == false)
        {
            insidePlanetRange9 = true;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("PushHintDisplay", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet10" && GrabShipPart.holdingPart == false)
        {
            insidePlanetRange10 = true;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("PushHintDisplay", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet11" && GrabShipPart.holdingPart == false)
        {
            insidePlanetRange11 = true;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("PushHintDisplay", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet12" && GrabShipPart.holdingPart == false)
        {
            insidePlanetRange12 = true;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("PushHintDisplay", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet13" && GrabShipPart.holdingPart == false)
        {
            insidePlanetRange13 = true;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("PushHintDisplay", -1, 0f);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "basicplanet1")
        {
            insidePlanetRange1 = false;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet2")
        {
            insidePlanetRange2 = false;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet3")
        {
            insidePlanetRange3 = false;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet4")
        {
            insidePlanetRange4 = false;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet5")
        {
            insidePlanetRange5 = false;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet6")
        {
            insidePlanetRange6 = false;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet7")
        {
            insidePlanetRange7 = false;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet8")
        {
            insidePlanetRange8 = false;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet9")
        {
            insidePlanetRange9 = false;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet10")
        {
            insidePlanetRange10 = false;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet11")
        {
            insidePlanetRange11 = false;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet12")
        {
            insidePlanetRange12 = false;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet13")
        {
            insidePlanetRange13 = false;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
    }
}
