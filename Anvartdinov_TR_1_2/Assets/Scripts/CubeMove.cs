using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public bool isMoveZ;

    const float MOVE_VALUE = 2;

    // Update is called once per frame
    void Update()
    {
        if (isMoveZ)
        {
            transform.position += new Vector3(0, 0, MOVE_VALUE) * Time.deltaTime;
        }
    }
}
