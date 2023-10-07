using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstARGame
{
    public class GameManager : MonoBehaviour
    {
        private NetworkCommunication netComm;

        public int player_1_health;
        public int player_2_health;

        public int player_1_money;
        public int player_2_money;

        public int player_1_income;
        public int player_2_income;

        private int income_delay;
        private int income_delay_count;

        private bool start_game;

        public int player_1_damage;
        public int player_2_damage;

        public int player_1_tower_health;
        public int player_2_tower_health;

        public int player_1_tower_income;
        public int player_2_tower_income;

        void Start()
        {
            player_1_health = 5;
            player_2_health = 5;

            player_1_income = 10;
            player_2_income = 10;

            player_1_money = 100;
            player_2_money = 100;

            income_delay = 800;
            income_delay_count = 0;

            start_game = false;

            player_1_damage = 1;
            player_2_damage = 1;

            player_1_tower_health = 10;
            player_2_tower_health = 10;

            player_1_tower_income = 5;
            player_2_tower_income = 5;
        }

        void Update()
        {
            if (start_game)
            {
                if (income_delay_count > income_delay)
                {
                    netComm.IncrementMoney();

                    income_delay_count = 0;
                }
                income_delay_count++;
            }
        }

        public void StartGameManager()
        {
            netComm = FindObjectOfType<NetworkCommunication>();
            start_game = true;
        }
    }
}
