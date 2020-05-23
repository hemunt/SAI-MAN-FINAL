using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offSet;

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = Camera.main.ScreenToViewportPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + offSet);
    }
}
