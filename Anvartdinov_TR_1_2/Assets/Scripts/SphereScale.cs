using UnityEngine;

public class SphereScale : MonoBehaviour
{
    public bool isScale;

    const float SCALE_VALUE = 1.5f;

    // Update is called once per frame
    void Update()
    {
        if (isScale)
        {
            transform.localScale += new Vector3(SCALE_VALUE, SCALE_VALUE, SCALE_VALUE) * Time.deltaTime;
        }
    }
}
