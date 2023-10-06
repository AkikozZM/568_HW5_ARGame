namespace MyFirstARGame
{
    using Photon.Pun;
    using UnityEngine;
    
    /// <summary>
    /// You can use this class to make RPC calls between the clients. It is already spawned on each client with networking capabilities.
    /// </summary>
    public class NetworkCommunication : MonoBehaviourPun
    {
        [SerializeField] private Scoreboard scoreboard;

        public void IncrementScore()
        {
            var playerName = $"Player {PhotonNetwork.LocalPlayer.ActorNumber}";
            var currentScore = this.scoreboard.GetScore(playerName);
            this.photonView.RPC("Network_SetPlayerScore", RpcTarget.All, playerName, currentScore + 1);
        }

        [PunRPC]
        public void Network_SetPlayerScore(string playerName, int newScore)
        {
            Debug.Log($"Player {playerName} scored!");
            this.scoreboard.SetScore(playerName, newScore);
        }

        public void IncrementHealth(int damage1, int damage2)
        {
            var health = this.scoreboard.GetHealth();

            int currentHealth1 = health[0];
            int currentHealth2 = health[1];

            currentHealth1 -= damage1;
            currentHealth2 -= damage2;

            this.photonView.RPC("Network_IncrementHealth", RpcTarget.All, currentHealth1, currentHealth2);
        }

        [PunRPC]
        public void Network_IncrementHealth(int health1, int health2)
        {
            this.scoreboard.SetHealth(health1, health2);
        }
    }

}