using System.Collections;
using UnityEngine;

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
        var hash = iTween.Hash("position", new Vector3(0, -NowPosition, 0),
                               "time", 1.0f);
        iTween.MoveUpdate(_player, hash);
    }

    public void ResetPosition()
    {
        NowPosition = StartPosition;
        gameObject.SetActive(false);
        _player.transform.position = new Vector3(1, -NowPosition, 0);
        var hash = iTween.Hash("position", new Vector3(0, -NowPosition, 0),
            "time", 1.0f);
        iTween.MoveTo(_player, hash);
        gameObject.SetActive(true);
    }
}
