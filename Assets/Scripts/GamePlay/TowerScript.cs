using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MyFirstARGame
{
    public class TowerScript : MonoBehaviour
    {
        private GameManager GlobalGameManager;

        public int controller = 0;

        private int attackDelay;

        private int currentDelay;

        public int towerHealth;
        public int towerCost;

        void Start()
        {
            GlobalGameManager = GameObject.Find("GlobalGamePlayManager").GetComponent<GameManager>();

            attackDelay = 500;
            currentDelay = 0;

            towerHealth = 10;
            towerCost = 50;

            if (this.tag == "Income")
            {
                if (controller == 1)
                {
                    GlobalGameManager.player_1_income += 5;
                }
                else if (controller == 2)
                {
                    GlobalGameManager.player_2_income += 5;
                }
            }
        }

        void Update()
        {
            if (this.tag == "Attack" && currentDelay > attackDelay)
            {
                PhotonNetwork.Instantiate("Bullet", this.transform.position + new Vector3(0.0f, 1.05f, 0.0f), this.transform.rotation);
                currentDelay = 0;
            }

            currentDelay++;
        }

        public void DamageTower(int damage)
        {
            towerHealth -= damage;
            if (towerHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
