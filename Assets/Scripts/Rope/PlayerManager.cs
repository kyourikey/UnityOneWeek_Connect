using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    
    public int NowPosition = 10;
    public int StartPosition = 10;

    void Awake()
    {
        ResetPosition();
    }

    void Update()
    {
        _player.transform.position = new Vector3(0, -NowPosition, 0);
    }

    public void ResetPosition()
    {
        NowPosition = StartPosition;
    }
}
