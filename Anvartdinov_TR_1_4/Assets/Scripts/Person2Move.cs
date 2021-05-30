using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person2Move : MonoBehaviour
{
    public float speed;
    public float delay;

    private static float sin72 = (float)Math.Sin(72 * Mathf.PI / 180);
    private static float cos72 = (float)Math.Cos(72 * Mathf.PI / 180);
    private static float sin36 = (float)Math.Sin(36 * Mathf.PI / 180);
    private static float cos36 = (float)Math.Cos(36 * Mathf.PI / 180);
    private static float sin30 = (float)Math.Sin(30 * Mathf.PI / 180);
    private static float cos30 = (float)Math.Cos(30 * Mathf.PI / 180);

    private Coroutine _cor;
    private bool isStarRoute = true;
    private Vector3[] starPoint = {
        new Vector3(sin36 * 15, 0, -cos36 * 15),
        new Vector3(-sin72 * 15, 0, cos72 * 15),
        new Vector3(sin72 * 15, 0, cos72 * 15),
        new Vector3(-sin36 * 15, 0, -cos36 * 15),
        new Vector3(0, 0, 15),
    };
    private Vector3[] hexagonPoint = {
        new Vector3(cos30 * 15, 0, sin30 * 15),
        new Vector3(cos30 * 15, 0, -sin30 * 15),
        new Vector3(0, 0, -15),
        new Vector3(-cos30 * 15, 0, -sin30 * 15),
        new Vector3(-cos30 * 15, 0, sin30 * 15),
        new Vector3(0, 0, 15),
    };
    private GameObject[] spheres = new GameObject[6];

    void Start()
    {
        if (_cor == null)
        {
            _cor = StartCoroutine(MoveCoroutine(starPoint));
        }
    }

    private IEnumerator MoveCoroutine(Vector3[] points)
    {
        int count = 0;
        foreach (var destination in points)
        {
            transform.LookAt(destination);
            while ((destination - transform.position).sqrMagnitude > speed * speed * Time.deltaTime * Time.deltaTime)
            {
                transform.Translate(0, 0, speed * Time.deltaTime);
                yield return null;
            }
            transform.position = destination;

            var sphereInVortex = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphereInVortex.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            sphereInVortex.transform.position = destination;
            spheres[count] = sphereInVortex;
            yield return new WaitForSeconds(delay);
            count++;
        }

        foreach (var _sphere in spheres)
        {
            Destroy(_sphere);
        }

        Vector3[] nextRoute = isStarRoute ? hexagonPoint : starPoint;
        isStarRoute = !isStarRoute;
        _cor = StartCoroutine(MoveCoroutine(nextRoute));
    }
}
