using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectShipPartTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Laika" && EnableMonologue.insideMonologue == false && BlackHoleMagnet.takenByHole == false)
        {
            EnableMonologue.destroyShipPartTriggers = true;

        }
    }
}