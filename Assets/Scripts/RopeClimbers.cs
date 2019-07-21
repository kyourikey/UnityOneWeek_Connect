using System.Collections.Generic;
using UnityEngine;

public class RopeClimbers : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _climbers;

    public void Next()
    {
        if (_climbers.Count <= 0)
            return;

        var delItem = _climbers[0];
        _climbers.Remove(delItem);
        Destroy(delItem);

        foreach (var climber in _climbers)
        {
            var position = climber.transform.position;
            position.x -= 1;
            var hash = iTween.Hash("position", position,
                "time", 1.0f);
            iTween.MoveTo(climber, hash);
        }
    }
}
