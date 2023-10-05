using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstARGame
{
    internal class Scoreboard : MonoBehaviour
    {
        private Dictionary<string, int> scores;
        private GameManager GlobalGameManager;

        private void Start()
        {
            this.scores = new Dictionary<string, int>();
            GlobalGameManager = GameObject.Find("GlobalGamePlayManager").GetComponent<GameManager>();
        }

        public void SetScore(string playerName, int score)
        {
            if (this.scores.ContainsKey(playerName))
            {
                this.scores[playerName] = score;
            }
            else
            {
                this.scores.Add(playerName, score);
            }
        }

        public int GetScore(string playerName)
        {
            if (this.scores.ContainsKey(playerName))
            {
                return this.scores[playerName];
            }
            else
            {
                return 0;
            }
        }

        private void OnGUI()
        {
            GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            GUILayout.BeginVertical();
            GUILayout.FlexibleSpace();

            foreach (var score in this.scores)
            {
                GUILayout.Label($"{score.Key}: {score.Value}", new GUIStyle { normal = new GUIStyleState { textColor = Color.black }, fontSize = 22 });
            }

            GUILayout.Label("Player 1 Health: " + GlobalGameManager.player_1_health, new GUIStyle { normal = new GUIStyleState { textColor = Color.black }, fontSize = 22 });
            GUILayout.Label("Player 1 Money: $" + GlobalGameManager.player_1_money, new GUIStyle { normal = new GUIStyleState { textColor = Color.black }, fontSize = 22 });
            GUILayout.FlexibleSpace();

            GUILayout.Label("Player 2 Health: " + GlobalGameManager.player_2_health, new GUIStyle { normal = new GUIStyleState { textColor = Color.black }, fontSize = 22 });
            GUILayout.Label("Player 2 Money: $" + GlobalGameManager.player_2_money, new GUIStyle { normal = new GUIStyleState { textColor = Color.black }, fontSize = 22 });


            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
            GUILayout.EndArea();
        }
    }
}
