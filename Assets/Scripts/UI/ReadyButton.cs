using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstARGame
{
    public class ReadyButton : MonoBehaviour
    {
        private NetworkCommunication netComm;
        public GameObject ready_button;
        public void ReadyButtonPress()
        {
            netComm = FindObjectOfType<NetworkCommunication>();
            if (netComm != null)
            {
                netComm.ReadyMethod();
            }
        }

        public void StartGame()
        {
            GameObject.Find("GlobalGamePlayManager").GetComponent<GameManager>().StartGameManager();
            Destroy(gameObject);
        }
    }
}
