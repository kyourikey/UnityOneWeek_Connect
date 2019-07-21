using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RopeController : MonoBehaviour
{
    void OnGUI()
    {
        GUILayout.TextArea("Game Turn : " + _turn);

        if (_turn == RopeState.Create)
        {
            GUILayout.TextArea("Wait for create.");
        }
        else if (_turn == RopeState.Climb)
        {
            GUILayout.TextArea("Next Rope Type : " + _ropeManager.Ropes[_playerManager.NowPosition - 1].RopeType);
        }
    }

    [SerializeField]
    private RopeManager _ropeManager;
    [SerializeField]
    private PlayerManager _playerManager;
    [SerializeField]
    private HelpedHumanCreater _helpedHumanCreater;
    [SerializeField]
    private RopeClimbers _ropeClimbers;

    private RopeState _turn = RopeState.Create;

    private int _nowRopeLength
    {
        get { return _ropeManager.Ropes.Count; }
    }

    void Awake()
    {
        _ropeManager.ChangeNextRopeType();
        ChangeRopeState(RopeState.Create);

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
        if (_nowRopeLength <= 0)
            return;
        
        for (var i = 0; i < _nowRopeLength; i++)
        {
            var rope = _ropeManager.Ropes[i];

            var hash = iTween.Hash("position", -Vector3.up * i,
                "time", 1.0f);
            iTween.MoveUpdate(rope.gameObject, hash);

            rope.gameObject.transform.rotation = Quaternion.identity;
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
        if (_turn == RopeState.Climb)
        {
            _playerManager.NowPosition -= 1;
            if (_playerManager.NowPosition <= 0)
                _playerManager.NowPosition = 0;

            _ropeManager.DeleteFirstRope();

            if (_playerManager.NowPosition <= 0)
            {
                _helpedHumanCreater.Create();
                _ropeClimbers.Next();
                _playerManager.ResetPosition();
                ChangeRopeState(RopeState.Create);
            }
        }
    }

    private void Failure()
    {
        if (_turn == RopeState.Climb)
        {
            Debug.Log("Climb Fail");
        }
    }

    private bool EqualNextRope(RopeType ropeType)
    {
        if (_turn == RopeState.Create)
        {
            return ropeType == _ropeManager.NextCreateRopeType;
        }
        else if (_turn == RopeState.Climb)
        {
            return _ropeManager.Ropes.First().RopeType == ropeType;
        }

        return false;
    }

    private void ChangeRopeState(RopeState ropeState)
    {
        _turn = ropeState;

        if (ropeState == RopeState.Create)
        {
            _ropeManager.ResetRopes();
            StartCoroutine("CreateRopesCoroutine", 10);
        }
        else if (ropeState == RopeState.Climb)
        {

        }
    }

    private IEnumerator CreateRopesCoroutine(int ropeLength)
    {
        for (var i = 0; i < ropeLength; i++)
        {
            if (_turn == RopeState.Create)
            {
                _ropeManager.CreateRopeFirst(_ropeManager.NextCreateRopeType);
                _ropeManager.ChangeNextRopeType();
            }

            yield return new WaitForSeconds(0.1f);
        }

        ChangeRopeState(RopeState.Climb);
    }
}
