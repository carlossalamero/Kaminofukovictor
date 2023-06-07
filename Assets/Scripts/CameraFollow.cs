using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [SerializeField]Vector3 offset;
    
    // Update is called once per frame
    void Update()
    {

        Vector3 DesiredPosition = target.position + offset;
        transform.position = DesiredPosition;

        
    }
}
