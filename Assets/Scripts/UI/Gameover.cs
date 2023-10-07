using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFirstARGame
{
    public class Gameover : MonoBehaviour
    {
        public GameObject winner;
        public GameObject loser;

        private void Start()
        {
            int playerIdx = PlayerPrefs.GetInt("PlayerIdx", 0); // PlayerIdx should be either 1 or 2
            if (playerIdx == 1)
            {
                // player win, should display winner banner
                winner.SetActive(true);
                loser.SetActive(false);
            }
            else
            {
                // other cases, player must be loser
                loser.SetActive(true);
                winner.SetActive(false);
            }
        }
        public void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}
