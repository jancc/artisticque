using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    public float damping;
    public Vector3 mod;

    // Update is called once per frame
    void LateUpdate()
    {
        if(!target) return;

        Vector3 targetPos = target.position + mod;
        transform.position = Vector3.Lerp(transform.position, targetPos, damping * Time.deltaTime);
    }
}
