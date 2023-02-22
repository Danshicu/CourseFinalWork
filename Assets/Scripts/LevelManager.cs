using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pramchuk
{
    public class LevelManager : MonoBehaviour
    {

        public void LoadMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }

        public void CloseGame()
        {
            Application.Quit();
        }

    }
}