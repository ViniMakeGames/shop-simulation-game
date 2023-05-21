using System;
using PlayerComponents;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenuUI : MonoBehaviour
    {
        private void Start()
        {
            GameObject.Find("Player").GetComponent<InputController>().EnablePlayer(false);
        }

        public void StartGame()
        {
            gameObject.SetActive(false);
            GameObject.Find("Player").GetComponent<InputController>().EnablePlayer(true);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}
