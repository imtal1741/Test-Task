using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtToObject : MonoBehaviour
{
    public Transform objectToLook;

    void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - objectToLook.position);
    }
}
