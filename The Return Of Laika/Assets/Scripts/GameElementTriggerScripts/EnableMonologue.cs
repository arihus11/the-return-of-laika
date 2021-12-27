using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMonologue : MonoBehaviour
{
    public int numberOfChildToEnable;
    public float enableWalkingTime;
    public GameObject[] otherHoles;
    public static bool destroyHoleTriggers;
    // Start is called before the first frame update
    void Start()
    {
        destroyHoleTriggers = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Laika")
        {
            disableMovementWhileTalking();
            GameObject.Find("CanvasGameElementTriggers").gameObject.transform.GetChild(numberOfChildToEnable).gameObject.SetActive(true);
            Invoke("enableMovementAfterTalking", enableWalkingTime);

        }
    }

    public void disableMovementWhileTalking()
    {
        GameObject.Find("Player").gameObject.GetComponent<LaikaMovement>().enabled = false;
    }

    public void enableMovementAfterTalking()
    {
        GameObject.Find("Player").gameObject.GetComponent<LaikaMovement>().enabled = true;
        Invoke("destoryThisBox", 0.5f);
    }

    public void destoryThisBox()
    {
        Destroy(this.gameObject);
    }
}
