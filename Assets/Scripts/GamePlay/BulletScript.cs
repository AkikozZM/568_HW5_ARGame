using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstARGame
{
    public class BulletScript : MonoBehaviour
    {
        public float direction = -1;
        private float speed = 30;

        void Start()
        {
            this.GetComponent<Rigidbody>().AddForce(direction * transform.forward * speed);
        }

        void Update()
        {
            //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + direction * speed);
        }
    }
}
