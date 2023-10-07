using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MyFirstARGame
{
    internal class Scoreboard : MonoBehaviour
    {
        private GameManager GlobalGameManager;
        private GenerateBoard GeneratedBoard;

        private Dictionary<string, int> scores;

        private List<int> connected_players = new List<int>();

        private void Start()
        {
            this.scores = new Dictionary<string, int>();

            GlobalGameManager = GameObject.Find("GlobalGamePlayManager").GetComponent<GameManager>();
            GeneratedBoard = GameObject.Find("GlobalGamePlayManager").GetComponent<GenerateBoard>();
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

        public void SetHealth(int health_1, int health_2)
        {
            GlobalGameManager.player_1_health = health_1;
            GlobalGameManager.player_2_health = health_2;

            if (health_1 <= 0)
            {
                Debug.Log("Game Over Player 2 Wins");
            }
            else if (health_2 <= 0)
            {
                Debug.Log("Game Over Player 1 Wins");
            }
        }

        public int[] GetHealth()
        {
            int[] health = {GlobalGameManager.player_1_health, GlobalGameManager.player_2_health};
            return health;
        }

        public void SetIncome(int income_1, int income_2)
        {
            GlobalGameManager.player_1_income = income_1;
            GlobalGameManager.player_2_income = income_2;
        }

        public int[] GetIncome()
        {
            int[] income = { GlobalGameManager.player_1_income, GlobalGameManager.player_2_income };
            return income;
        }

        public void SetMoney(int money_1, int money_2)
        {
            GlobalGameManager.player_1_money = money_1;
            GlobalGameManager.player_2_money = money_2;
        }

        public int[] GetMoney()
        {
            int[] money = { GlobalGameManager.player_1_money, GlobalGameManager.player_2_money };
            return money;
        }

        public void SetDamage(int damage_1, int damage_2)
        {
            GlobalGameManager.player_1_damage = damage_1;
            GlobalGameManager.player_2_damage = damage_2;
        }

        public int[] GetDamage()
        {
            int[] damage = { GlobalGameManager.player_1_damage, GlobalGameManager.player_2_damage };
            return damage;
        }
        public void SetTowerHealth(int tower_health_1, int tower_health_2)
        {
            GlobalGameManager.player_1_tower_health = tower_health_1;
            GlobalGameManager.player_2_tower_health = tower_health_2;
        }

        public int[] GetTowerHealth()
        {
            int[] damage = { GlobalGameManager.player_1_damage, GlobalGameManager.player_2_damage };
            return damage;
        }

        public void ReadyMethod(int player_num)
        {
            if (!connected_players.Contains(player_num))
            {
                Debug.Log("Player: " + player_num + " joined");
                connected_players.Add(player_num);
            }

            if (connected_players.Contains(2) && connected_players.Contains(3))
            {
                Debug.Log("All Players Joined");
                if (GameObject.Find("ReadyButton") != null)
                {
                    GameObject.Find("ReadyButton").GetComponent<ReadyButton>().StartGame();
                }
                else
                {
                    GlobalGameManager.StartGameManager();
                }

                GeneratedBoard.StartGameBoard();
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
            int player_num = PhotonNetwork.LocalPlayer.ActorNumber;
            GUILayout.Label("Player ID: " + player_num, new GUIStyle { normal = new GUIStyleState { textColor = Color.black }, fontSize = 22 });

            GUILayout.Label("Player 1 Health: " + GlobalGameManager.player_1_health, new GUIStyle { normal = new GUIStyleState { textColor = Color.black }, fontSize = 22 });
            GUILayout.Label("Player 1 Money: $" + GlobalGameManager.player_1_money, new GUIStyle { normal = new GUIStyleState { textColor = Color.black }, fontSize = 22 });
            GUILayout.Label("Player 1 Income: $" + GlobalGameManager.player_1_income, new GUIStyle { normal = new GUIStyleState { textColor = Color.black }, fontSize = 22 });
            GUILayout.FlexibleSpace();

            GUILayout.Label("Player 2 Health: " + GlobalGameManager.player_2_health, new GUIStyle { normal = new GUIStyleState { textColor = Color.black }, fontSize = 22 });
            GUILayout.Label("Player 2 Money: $" + GlobalGameManager.player_2_money, new GUIStyle { normal = new GUIStyleState { textColor = Color.black }, fontSize = 22 });
            GUILayout.Label("Player 2 Income: $" + GlobalGameManager.player_2_income, new GUIStyle { normal = new GUIStyleState { textColor = Color.black }, fontSize = 22 });
            GUILayout.FlexibleSpace();

            GUILayout.EndVertical();
            GUILayout.EndArea();
        }
    }
}
