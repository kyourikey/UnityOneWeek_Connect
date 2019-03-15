using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeFactory
{
    private GameObject _ropeRedPrefab;
    private GameObject _ropeBluePrefab;
    private GameObject _ropeGreenPrefab;
    private Material _redMaterial;
    private Material _blueMaterial;
    private Material _greenMaterial;

    public RopeFactory()
    {
        _ropeRedPrefab = Resources.Load<GameObject>("Prefabs/RopeRedPrefab");
        _ropeBluePrefab = Resources.Load<GameObject>("Prefabs/RopeBluePrefab");
        _ropeGreenPrefab = Resources.Load<GameObject>("Prefabs/RopeGreenPrefab");
    }

    public Rope Create(RopeType ropeType)
    {
        var rope = GetRopeByType(ropeType);
        rope = SetupRope(rope, ropeType);
        return rope;
    }
    private Rope GetRopeByType(RopeType ropeType)
    {
        Rope rope = null;

        switch (ropeType)
        {
            case RopeType.Red:
                rope = GameObject.Instantiate(_ropeRedPrefab).AddComponent<Rope>();
                break;
            case RopeType.Blue:
                rope = GameObject.Instantiate(_ropeBluePrefab).AddComponent<Rope>();
                break;
            case RopeType.Green:
                rope = GameObject.Instantiate(_ropeGreenPrefab).AddComponent<Rope>();
                break;
        }

        return rope;
    }

    private Rope SetupRope(Rope rope, RopeType ropeType)
    {
        switch (ropeType)
        {
            case RopeType.Red:
                rope.RopeType = RopeType.Red;
                break;
            case RopeType.Blue:
                rope.RopeType = RopeType.Blue;
                break;
            case RopeType.Green:
                rope.RopeType = RopeType.Green;
                break;
        }
        
        ((Component)rope).transform.position = Vector3.zero;
        
        return rope;
    }
}
