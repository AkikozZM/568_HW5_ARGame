using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MyFirstARGame
{
    public class PlayerHitBox : MonoBehaviour
    {
        private NetworkCommunication netComm;

        public int controller;

        void Start()
        {
            netComm = FindObjectOfType<NetworkCommunication>();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                int damage = collision.gameObject.GetComponent<BulletScript>().damage;

                int damage1 = 0;
                int damage2 = 0;

                if (controller == 1)
                {
                    //GlobalGameManager.player_1_health -= collision.gameObject.GetComponent<BulletScript>().damage;
                    damage1 = damage;
                }
                else if (controller == 2)
                {
                    //GlobalGameManager.player_2_health -= collision.gameObject.GetComponent<BulletScript>().damage;
                    damage2 = damage;
                }

                netComm.IncrementHealth(damage1, damage2);

                Destroy(collision.gameObject);
            }
        }
    }
}
