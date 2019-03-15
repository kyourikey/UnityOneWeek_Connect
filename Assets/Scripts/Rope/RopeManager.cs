using System;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

public class RopeManager : MonoBehaviour
{
    public List<Rope> Ropes = new List<Rope>();
    private RopeType _nextRopeType = RopeType.Red;
    public RopeType NextRopeType
    {
        get { return _nextRopeType; }
    }
    
    private RopeFactory _ropeFactory;

    void Awake()
    {
        if (_ropeFactory == null)
            _ropeFactory = new RopeFactory();
    }

    public void CreateRopeFirst(RopeType ropeType)
    {
        if (_ropeFactory == null)
            _ropeFactory = new RopeFactory();

        var rope = _ropeFactory.Create(ropeType);
        Ropes.Insert(0, rope);
        rope.transform.SetParent(transform);
    }

    public void CreateRopeLast(RopeType ropeType)
    {
        if (_ropeFactory == null)
            _ropeFactory = new RopeFactory();

        var rope = _ropeFactory.Create(ropeType);
        Ropes.Add(rope);
        rope.transform.SetParent(transform);
    }

    public void CreateRopesRandom(int ropeLength)
    {
        var ropeTypeLength = Enum.GetNames(typeof(RopeType)).Length;

        for (var i = 0; i < ropeLength; i++)
            CreateRopeLast((RopeType)Random.Range(0, ropeTypeLength));
    }

    public void DeleteFirstRope()
    {
        var deleteRope = Ropes[0];
        Ropes.RemoveAt(0);
        Destroy(deleteRope.gameObject);
    }

    public void ResetRopes()
    {
        var ropeArray = Ropes.ToArray();
        Ropes.Clear();
        foreach (var rope in ropeArray)
        {
            Destroy(rope.gameObject);
        }
    }

    public void ChangeNextRopeType()
    {
        var ropeTypeLength = Enum.GetNames(typeof(RopeType)).Length;
        _nextRopeType = (RopeType) Random.Range(0, ropeTypeLength);
    }
}
