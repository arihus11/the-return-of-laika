using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Laika.Utils;

public class AssembleShipPart : MonoBehaviour
{
    private Transform playerTransform;
    private Transform playerParentTransform;
    private GrabShipPart shipPartIDScript;

    private GameObject collidedShipObject = null;

    void Start()
    {
        playerTransform = this.gameObject.transform;
        playerParentTransform = playerTransform.root.transform;
        shipPartIDScript = this.gameObject.GetComponent<GrabShipPart>();
    }

    void Update()
    {
        if (shipPartIDScript.shipPartGrabbed != null && collidedShipObject != null && Input.GetKeyDown(KeyCode.X))
        {
            handleAssembly();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Methods.isShip(other.gameObject.tag))
        {
            collidedShipObject = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (Methods.isShip(other.gameObject.tag))
        {
            collidedShipObject = null;
        }
    }

    private void handleAssembly()
    {
        Debug.LogError("handleAssembly unimplemented!");
    }
}
