using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MyFirstARGame
{
    public class BulletScript : MonoBehaviour
    {
        private GameManager GlobalGameManager;

        public int playerIdx;
        public int speed = 30;
        public int damage = 1;

        void Start()
        {
            GlobalGameManager = GameObject.Find("GlobalGamePlayManager").GetComponent<GameManager>();
            this.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        }

        void Update()
        {
            if (Mathf.Abs(this.transform.position.x) > 5)
            {
                PhotonNetwork.Destroy(gameObject);
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (playerIdx == 1 && collision.gameObject.tag == "Defense")
            {
                Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), this.GetComponent<Collider>());
                
            }
            else if (playerIdx == 1 && collision.gameObject.tag == "Defense_blue" && PhotonNetwork.LocalPlayer.ActorNumber == 1)
            {
                collision.gameObject.GetComponent<TowerScript>().DamageTower(damage);
                PhotonNetwork.Destroy(gameObject);
            }
            if (playerIdx == 2 && collision.gameObject.tag == "Defense_blue")
            {
                Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), this.GetComponent<Collider>());

            }
            else if (playerIdx == 2 && collision.gameObject.tag == "Defense" && PhotonNetwork.LocalPlayer.ActorNumber == 2)
            {
                collision.gameObject.GetComponent<TowerScript>().DamageTower(damage);
                PhotonNetwork.Destroy(gameObject);
            }
            if (collision.gameObject.tag == "Bullet")
            {
                Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), this.GetComponent<Collider>());
            }
        }
    }
}
