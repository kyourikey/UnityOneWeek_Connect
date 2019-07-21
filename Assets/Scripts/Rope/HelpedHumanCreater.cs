using System.Collections.Generic;
using UnityEngine;

public class HelpedHumanCreater : MonoBehaviour
{
    [SerializeField] private GameObject _helpedHumanPrefab;

    [SerializeField] private List<GameObject> _helpedHumans;

    [SerializeField] private Vector3 _instantiatePosition;

    public void Create()
    {
        var obj = Instantiate(_helpedHumanPrefab, transform);
        obj.transform.localPosition = _instantiatePosition;

        _helpedHumans.Add(obj);
        Debug.Log(transform.position);
        var hash = iTween.Hash("position", this.transform.position + GetRandomPosition(3),
            "time", 1.0f,
            "oncomplete", "CompleteHandler",
            "oncompletetarget", gameObject,
            "oncompleteparams", obj);
        iTween.MoveTo(obj, hash);

    }

    private Vector3 GetRandomPosition(float range)
    {
        return new Vector3(Random.Range(-range, range), 0, 0);
    }

    void CompleteHandler(object cmpParams)
    {
        var obj = (GameObject)cmpParams;

        var hash = iTween.Hash("y",transform.position.y + 0.5f,
        "time", 0.3f,
        "loopType", iTween.LoopType.pingPong);
        iTween.MoveTo(obj, hash);
    }
}
