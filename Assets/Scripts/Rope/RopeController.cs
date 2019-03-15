using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RopeController : MonoBehaviour
{
    void OnGUI()
    {
        GUILayout.TextArea("Game Turn : " + _turn);

        if (_turn == GameTurn.Create)
        {
            GUILayout.TextArea("Next Rope Type : " + _ropeManager.NextRopeType);
        }
        else if (_turn == GameTurn.Climb)
        {
            GUILayout.TextArea("Next Rope Type : " + _ropeManager.Ropes[_playerManager.NowPosition - 1].RopeType);
        }
        
    }



    [SerializeField]
    private RopeManager _ropeManager;
    [SerializeField]
    private PlayerManager _playerManager;

    private GameTurn _turn = GameTurn.Create;
    
    private int _nowRopeLength
    {
        get { return _ropeManager.Ropes.Count; }
    }

    void Awake()
    {
        _ropeManager.ChangeNextRopeType();
    }

    void OnEnable()
    {
        InputManager.OnRedClick += RedClick;
        InputManager.OnBlueClick += BlueClick;
        InputManager.OnGreenlick += GreenClick;
    }

    void OnDisable()
    {
        InputManager.OnRedClick -= RedClick;
        InputManager.OnBlueClick -= BlueClick;
        InputManager.OnGreenlick -= GreenClick;
    }

    void Update()
    {
        for (var i = 0; i < _ropeManager.Ropes.Count; i++)
        {
            var rope = _ropeManager.Ropes[i];
            rope.gameObject.transform.position = -Vector3.up*i;
        }
    }

    private void RedClick()
    {
        if (EqualNextRope(RopeType.Red))
        {
            Success();
        }
        else
        {
            Failure();
        }
    }

    private void BlueClick()
    {
        if (EqualNextRope(RopeType.Blue))
        {
            Success();
        }
        else
        {
            Failure();
        }
    }

    private void GreenClick()
    {
        if (EqualNextRope(RopeType.Green))
        {
            Success();
        }
        else
        {
            Failure();
        }
    }

    private void Success()
    {
        if (_turn == GameTurn.Create)
        {
            _ropeManager.CreateRopeFirst(_ropeManager.NextRopeType);
            _ropeManager.ChangeNextRopeType();
            
            if (_nowRopeLength >= _playerManager.StartPosition)
            {
                _turn = GameTurn.Climb;
            }
        }
        else if (_turn == GameTurn.Climb)
        {
            _playerManager.NowPosition -= 1;

            if (_playerManager.NowPosition <= 0)
            {
                _turn = GameTurn.Create;
                _ropeManager.ResetRopes();
                _playerManager.ResetPosition();
            }
        }
    }

    private void Failure()
    {
        if (_turn == GameTurn.Create)
        {
            Debug.Log("Create Fail");
        }
        else if (_turn == GameTurn.Climb)
        {
            Debug.Log("Climb Fail");
        }
    }

    private bool EqualNextRope(RopeType ropeType)
    {
        if (_turn == GameTurn.Create)
        {
            return ropeType == _ropeManager.NextRopeType;
        }
        else if (_turn == GameTurn.Climb)
        {
            return _ropeManager.Ropes[_playerManager.NowPosition - 1].RopeType == ropeType;
        }

        return false;
    }
}
