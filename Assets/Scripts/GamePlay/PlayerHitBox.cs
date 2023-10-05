using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstARGame
{
    public class PlayerHitBox : MonoBehaviour
    {
        private GameManager GlobalGameManager;

        public int controller;

        void Start()
        {
            GlobalGameManager = GameObject.Find("GlobalGamePlayManager").GetComponent<GameManager>();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Bullet")
            {
                if (controller == 1)
                {
                    GlobalGameManager.player_1_health -= collision.gameObject.GetComponent<BulletScript>().damage;
                }
                else if (controller == 2)
                {
                    GlobalGameManager.player_2_health -= collision.gameObject.GetComponent<BulletScript>().damage;
                }
            }
        }
    }
}
