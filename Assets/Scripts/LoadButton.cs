using UnityEngine;
using UnityEngine.UI;
using Utility;

public class LoadButton : MonoBehaviour
{
    public Button SceneLoadButton;

    void Start()
    {
        SceneLoadButton.OnPointerDown(SceneLoader.Instance.LoadNextScene);
    }
}
