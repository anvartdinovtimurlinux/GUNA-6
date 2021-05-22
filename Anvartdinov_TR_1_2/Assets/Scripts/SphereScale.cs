using UnityEngine;

public class SphereScale : MonoBehaviour
{
    public bool isScale;

    const float scaleValue = 1.5f;

    // Update is called once per frame
    void Update()
    {
        if (isScale)
        {
            transform.localScale += new Vector3(scaleValue, scaleValue, scaleValue) * Time.deltaTime;
        }
    }
}
