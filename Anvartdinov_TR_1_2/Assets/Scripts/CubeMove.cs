﻿using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public bool isMoveZ;

    const float moveValue = 2;

    // Update is called once per frame
    void Update()
    {
        if (isMoveZ)
        {
            transform.position += new Vector3(0, 0, moveValue) * Time.deltaTime;
        }
    }
}
