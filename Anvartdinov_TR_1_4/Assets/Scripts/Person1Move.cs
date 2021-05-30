using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person1Move : MonoBehaviour
{
    public float speed;
    public float delay;

    private Coroutine _cor;
    private bool isSquareRoute = true;
    private Vector3[] squarePoint = {
        new Vector3(20, 0, 20),
        new Vector3(20, 0, -20),
        new Vector3(-20, 0, -20),
        new Vector3(-20, 0, 20),
    };
    private Vector3[] trianglePoint = {
        new Vector3(20, 0, 20),
        new Vector3(0, 0, -20),
        new Vector3(-20, 0, 20),
    };
    private GameObject[] cubes = new GameObject[4];

    void Start()
    {
        if (_cor == null)
        {
            _cor = StartCoroutine(MoveCoroutine(squarePoint));
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

            var cubeInVortex = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubeInVortex.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            cubeInVortex.transform.position = destination;
            cubes[count] = cubeInVortex;
            yield return new WaitForSeconds(delay);
            count++;
        }

        foreach (var _cube in cubes)
        {
            Destroy(_cube);
        }

        Vector3[] nextRoute = isSquareRoute ? trianglePoint : squarePoint;
        isSquareRoute = !isSquareRoute;
        _cor = StartCoroutine(MoveCoroutine(nextRoute));
    }
}

