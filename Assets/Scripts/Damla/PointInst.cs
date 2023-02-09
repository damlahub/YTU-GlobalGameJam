using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=System.Random;
public class PointInst : MonoBehaviour
{
    public List<Transform> points = new List<Transform>();
    [SerializeField] private GameObject point;
    private void Start()
    {
        var random= new Random();
        int piece=(int) Math.Ceiling(points.Count/2f);
        HashSet<int> randomValues = new HashSet<int>();
        while (randomValues.Count < piece)
        {
            randomValues.Add(random.Next(0, points.Count - 1));
        }
        foreach(var x in randomValues)
        {
            Instantiate(point, points[x]);
        }
    }
}
