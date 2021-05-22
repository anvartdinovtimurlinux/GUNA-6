using UnityEngine;

public class CylinderRotate : MonoBehaviour
{
    public bool isRotateX;

    const float RotateValue = -5;

    // Update is called once per frame
    void Update()
    {
        if (isRotateX)
        {
            transform.eulerAngles += new Vector3(RotateValue, 0, 0) * Time.deltaTime;
        }
    }
}
