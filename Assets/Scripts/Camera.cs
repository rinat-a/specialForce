using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject target;

    public float smothSpeed = 1f;
    void Update()
    {
        Vector3 lerpPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, lerpPos, Time.deltaTime * smothSpeed);
    }
}
