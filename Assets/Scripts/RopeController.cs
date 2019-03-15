using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    public List<Rope> Ropes = new List<Rope>();

    private RopeFactory _ropeFactory;
    private int _ropeLength = 10;

    void Awake()
    {
        _ropeFactory = new RopeFactory();
        var ropeTypeLength = Enum.GetNames(typeof(RopeType)).Length;

        for (var i = 0; i < _ropeLength; i++)
            CreateRope((RopeType) (i % ropeTypeLength));
    }

    private void CreateRope(RopeType ropeType)
    {
        var rope = _ropeFactory.Create(ropeType);
        Ropes.Add(rope);
    }
}
