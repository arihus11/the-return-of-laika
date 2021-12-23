using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    private bool doOnce;
    // Start is called before the first frame update
    void Start()
    {
        doOnce = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("MeteorShower") != null)
        {
            if (GameObject.Find("ShieldPlaceLeft") != null || GameObject.Find("ShieldPlaceRight") != null)
            {
                GameObject.Find("ArrowShieldMessageContainer").gameObject.GetComponent<Animator>().Play("ArrowShieldMessageDisplay");
                GameObject.Find("UseShieldMessageContainer").gameObject.GetComponent<Animator>().Play("Base");
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (!doOnce)
                    {
                        this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                        this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
                        doOnce = true;
                        Invoke("changeSwitch", 0.3f);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (!doOnce)
                    {
                        this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                        this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                        doOnce = true;
                        Invoke("changeSwitch", 0.3f);
                    }
                }
                else if (Input.GetKeyDown(KeyCode.O))
                {
                    if (!doOnce)
                    {

                        this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                        this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
                        doOnce = true;
                        Invoke("changeSwitch", 0.3f);
                    }
                }
            }
            else if (GameObject.Find("ShieldPlaceLeft") == null && GameObject.Find("ShieldPlaceRight") == null)
            {
                GameObject.Find("ArrowShieldMessageContainer").gameObject.GetComponent<Animator>().Play("Base");
                GameObject.Find("UseShieldMessageContainer").gameObject.GetComponent<Animator>().Play("UseShieldDisplayMessage");
                if (Input.GetKeyDown(KeyCode.O))
                {
                    if (!doOnce)
                    {

                        this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                        this.gameObject.transform.GetChild(3).gameObject.SetActive(false);

                        doOnce = true;
                        Invoke("changeSwitch", 0.3f);
                    }
                }
            }


        }
        else if (GameObject.Find("MeteorShower") == null)
        {
            GameObject.Find("UseShieldMessageContainer").gameObject.GetComponent<Animator>().Play("Base");
            GameObject.Find("ArrowShieldMessageContainer").gameObject.GetComponent<Animator>().Play("Base");
        }

    }

    public void changeSwitch()
    {
        doOnce = false;

    }
}