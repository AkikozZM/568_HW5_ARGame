using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstARGame
{
    public class TowerScript : MonoBehaviour
    {
        public int controller;

        private int attackDelay;

        private int currentDelay;

        void Start()
        {
            attackDelay = 50;
            currentDelay = 0;
        }

        void Update()
        {
            if (this.tag == "Attack" && currentDelay > attackDelay)
            {
                currentDelay = 0;
            }

            currentDelay++;
        }
    }
}
