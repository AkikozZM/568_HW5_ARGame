using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstARGame
{
    public class BulletScript : MonoBehaviour
    {
        private GameManager GlobalGameManager;

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
                Destroy(gameObject);
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Defense")
            {
                collision.gameObject.GetComponent<TowerScript>().DamageTower(damage);
                Destroy(gameObject);
            }
        }
    }
}
