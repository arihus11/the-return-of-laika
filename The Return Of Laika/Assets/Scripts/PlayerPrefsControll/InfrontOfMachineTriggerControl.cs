using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfrontOfMachineTriggerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Awake()
    {
        if (PlayerPrefs.GetInt("InfrontOfMachineTriggerPref") == 1)
        {
            this.gameObject.SetActive(false);
        }
    }

}