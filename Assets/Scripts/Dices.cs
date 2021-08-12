using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Dices : MonoBehaviour
{
    public Vector3 refVecUp = Vector3.up;
    Dictionary<Vector3, int> lookup = new Dictionary<Vector3, int>();
    float epsilon = 5f;//(float)Math.Sqrt(2/3);
    private void Awake()
    {
        lookup[new Vector3(0, 1, 0)] = 1;
        lookup[new Vector3(0, 0, 1)] = 2;
        lookup[new Vector3(1, 0, 0)] = 3;
        lookup[new Vector3(-1, 0, 0)] = 4;
        lookup[new Vector3(0, 0, -1)] = 5;
        lookup[new Vector3(0, -1, 0)] = 6;
    }

    public int getNumber(Vector3 v, float e)
    {
        Vector3 refObjSpace = transform.InverseTransformDirection(v);
        float min = float.MaxValue;
        Vector3 minKey = new Vector3(0,0,0);
        foreach (Vector3 key in lookup.Keys)
        {
            float a = Vector3.Angle(refObjSpace, key);
            if (a <= e && a < min)
            {
                min = a;
                minKey = key;
            }
        }
        return (min < e) ? lookup[minKey] : -1;
    }
    private void Update()
    {
        
    }
    private void LateUpdate()
    {
        int i = getNumber(refVecUp, epsilon);
        Debug.Log(i);
    }
}
