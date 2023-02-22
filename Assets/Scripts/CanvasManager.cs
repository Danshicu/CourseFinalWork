using System;
using UnityEngine;
using UnityEngine.UI;

namespace Pramchuk
{
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] private Text inGameMoneyCounter;
        [SerializeField] private Text pauseMoneyCounter;
        [SerializeField] private Text winMoneyCounter;
        [SerializeField] private Canvas loseCanvas;
        [SerializeField] private Canvas winCanvas;
        [SerializeField] private Canvas pauseCanvas;
        [SerializeField] private Canvas inGameCanvas;
        public Action resumeGame;
        public Action pauseGame;


        public void Lose()
        {
            loseCanvas.gameObject.SetActive(true);
        }

        public void Win()
        {
            ShowTotalMoney();
            winCanvas.gameObject.SetActive(true);
        }

        public void Pause()
        {
            pauseGame?.Invoke();
            inGameCanvas.gameObject.SetActive(false);
            pauseMoneyCounter.text = inGameMoneyCounter.text;
            pauseCanvas.gameObject.SetActive(true);
        }

        public void Resume()
        {
            resumeGame?.Invoke();
            pauseCanvas.gameObject.SetActive(false);
            inGameCanvas.gameObject.SetActive(true);
        }

        public void SetCurrentMoney(int value)
        {
            inGameMoneyCounter.text = $"{value}$";
        }

        private void ShowTotalMoney()
        {
            int value = PlayerPrefs.GetInt("TotalMoney");
            winMoneyCounter.text = $"{value}$";
        }
    }
}