using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeFactory
{
    private GameObject _ropePrefab;
    private Material _redMaterial;
    private Material _blueMaterial;
    private Material _greenMaterial;

    public RopeFactory()
    {
        _ropePrefab = Resources.Load<GameObject>("Prefabs/RopePrefab");
    }

    public Rope Create(RopeType ropeType)
    {
        var rope = GameObject.Instantiate(_ropePrefab).AddComponent<Rope>();
        rope = SetupRope(rope, ropeType);
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
