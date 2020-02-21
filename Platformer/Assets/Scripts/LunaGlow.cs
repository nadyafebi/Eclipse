using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunaGlow : MonoBehaviour
{
    public GameObject luna;

    void Update()
    {
        Vector3 lunaPos = luna.transform.position;
        transform.position = new Vector3(lunaPos.x, lunaPos.y, transform.position.z);
    }
}
