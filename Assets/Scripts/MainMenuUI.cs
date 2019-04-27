using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LD44Game
{
    public class MainMenuUI : MonoBehaviour
    {
        public void ChangeScene(int sceneBuildIndex)
        {
            GameManager.Instance.AsyncChangeScene(sceneBuildIndex);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}