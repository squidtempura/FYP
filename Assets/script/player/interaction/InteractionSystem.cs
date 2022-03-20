using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractionSystem : MonoBehaviour
{
    public Transform detectionPoint;
    private const float detectionRadius = 0.2f;
    public LayerMask detectionLayer;
    public GameObject detectedObject;

    // Update is called once per frame
    void Update()
    {
        if(DetectObject())
        {
            detectedObject.GetComponent<Item>().Interact();
        }
    }

    bool DetectObject()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position,detectionRadius,detectionLayer);
        if(obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }
    }

}

