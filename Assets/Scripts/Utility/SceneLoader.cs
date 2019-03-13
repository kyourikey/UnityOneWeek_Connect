using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utility
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance; // easy singleton.

        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            Debug.Log(SceneManager.sceneCountInBuildSettings);
        }

        public void LoadNextScene()
        {
            var nowSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
            if (nowSceneBuildIndex >= SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(nowSceneBuildIndex + 1);
            }
        }
    }
}
