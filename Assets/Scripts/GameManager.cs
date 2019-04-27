using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD44Game
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            // Ensure overlay is opaque
            overlay.SetFade(1);
        }

        public static GameManager Instance { get { return instance; } }

        [SerializeField] TransitionOverlay overlay;

        int currentSceneIdx;

        private void Start()
        {
            AsyncLoadIntro();
        }

        // Load the opening sequence
        public void AsyncLoadIntro()
        {
            StartCoroutine(AsyncLoadIntroCoroutine());
        }

        IEnumerator AsyncLoadIntroCoroutine()
        {
            AsyncOperation asyncOp = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

            // Wait for scene to load
            while (asyncOp.progress < 1)
            {
                yield return null;

                if (asyncOp.isDone)
                    break;
            }

            // Cache the scene index
            currentSceneIdx = 1;

            yield return overlay.Fade(0);
        }

        // Fade out, load new scene then fade in
        public void AsyncChangeScene(int sceneBuildIdx)
        {
            StartCoroutine(AsyncChangeSceneCoroutine(sceneBuildIdx));
        }

        private IEnumerator AsyncChangeSceneCoroutine(int sceneBuildIdx)
        {
            // Wait for fade out
            yield return overlay.Fade(1);

            // Begin loading the scene asyncrounsly
            AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneBuildIdx, LoadSceneMode.Additive);

            // Wait for scene to load
            while (asyncOp.progress < 1)
            {
                yield return null;

                if (asyncOp.isDone)
                    break;
            }

            // Begin unloading the old scene
            asyncOp = SceneManager.UnloadSceneAsync(currentSceneIdx);

            while (asyncOp.progress < 1)
            {
                yield return null;

                if (asyncOp.isDone)
                    break;
            }

            // Cache the new scene idx
            currentSceneIdx = sceneBuildIdx;

            // Wait for fade in
            yield return overlay.Fade(0);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}