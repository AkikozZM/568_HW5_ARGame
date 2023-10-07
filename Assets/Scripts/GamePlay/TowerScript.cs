using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

namespace MyFirstARGame
{
    public class TowerScript : MonoBehaviourPun
    {
        private NetworkCommunication netComm;

        public int controller = 0;
        public int playerIdx;
        private int attackDelay = 500;

        private int currentDelay;

        public int towerHealth = 10;
        public int towerDamage = 1;
        public int towerIncome = 5;

        private bool firstMoment = true;
        public bool createDelay = false;

        public PlaceableGrid_Script placeableGrid = null;

        void Start()
        {
            netComm = FindObjectOfType<NetworkCommunication>();
        }

        void Update()
        {
            if (firstMoment && createDelay)
            {
                SynchronizeValues();

                if (this.tag == "Income")
                {
                    if (controller == 1)
                    {
                        netComm.IncrementIncome(towerIncome, 0);
                    }
                    else if (controller == 2)
                    {
                        netComm.IncrementIncome(0, towerIncome);
                    }
                }

                firstMoment = false;
            }

            if (this.tag == "Attack" && currentDelay > attackDelay && createDelay)
            {
                if (controller == 1)
                {
                    GameObject bull = PhotonNetwork.Instantiate("Bullet", this.transform.position + new Vector3(0.0f, 0.12f, 0.0f), this.transform.rotation) as GameObject;
                    bull.GetComponent<BulletScript>().Initialize(towerDamage);
                    currentDelay = 0;
                }
                else if (controller == 2)
                {
                    GameObject bull = PhotonNetwork.Instantiate("Bullet_blue", this.transform.position + new Vector3(0.0f, 0.12f, 0.0f), this.transform.rotation) as GameObject;
                    bull.GetComponent<BulletScript>().Initialize(towerDamage);
                    currentDelay = 0;
                }
                
            }

            currentDelay++;
        }

        public void DamageTower(int damage)
        {
            towerHealth -= damage;
            if (towerHealth <= 0 && placeableGrid != null)
            {
                placeableGrid.removePiece();
                PhotonNetwork.Destroy(gameObject);
            }
        }

        public void SynchronizeValues()
        {

            int curr_controller = controller;
            PlaceableGrid_Script curr_placeableGrid = placeableGrid;

            int curr_towerHealth = towerHealth;
            int curr_towerDamage = towerDamage;
            int curr_towerIncome = towerIncome;

            this.photonView.RPC("Network_SynchronizeValues", RpcTarget.All, curr_controller, curr_placeableGrid, curr_towerHealth, curr_towerDamage, curr_towerIncome);
        }

        [PunRPC]
        public void Network_SynchronizeValues(int currController, PlaceableGrid_Script currPlaceable, int currHealth, int currDamage, int currIncome)
        {
            controller = currController;
            placeableGrid = currPlaceable;

            towerHealth = currHealth;
            towerDamage = currDamage;
            towerIncome = currIncome;
        }
    }
}
