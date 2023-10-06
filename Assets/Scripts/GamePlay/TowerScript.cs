using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MyFirstARGame
{
    public class TowerScript : MonoBehaviour
    {
        private NetworkCommunication netComm;

        public int controller = 0;
        public int playerIdx;
        private int attackDelay;

        private int currentDelay;

        public int towerHealth;

        private bool firstMoment;

        void Start()
        {
            netComm = FindObjectOfType<NetworkCommunication>();

            attackDelay = 500;
            currentDelay = 0;

            towerHealth = 10;

            firstMoment = true;
        }

        void Update()
        {
            if (firstMoment)
            {
                if (this.tag == "Income")
                {
                    if (controller == 1)
                    {
                        netComm.IncrementIncome(5, 0);
                    }
                    else if (controller == 2)
                    {
                        netComm.IncrementIncome(0, 5);
                    }
                }

                firstMoment = false;
            }

            if (this.tag == "Attack" && currentDelay > attackDelay)
            {
                if (playerIdx == 1)
                {
                    PhotonNetwork.Instantiate("Bullet", this.transform.position + new Vector3(0.0f, 0.12f, 0.0f), this.transform.rotation);
                    currentDelay = 0;
                }
                else if (playerIdx == 2)
                {
                    PhotonNetwork.Instantiate("Bullet_blue", this.transform.position + new Vector3(0.0f, 0.12f, 0.0f), this.transform.rotation);
                    currentDelay = 0;
                }
                
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
