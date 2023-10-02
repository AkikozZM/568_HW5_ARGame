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

        // Start is called before the first frame update
        void Start()
        {
            PhotonNetwork.Instantiate("ManipulatorCubeNetwork", new Vector3(0, 0, 0), Quaternion.identity);
            Debug.Log("Instantiated");
        }

        // Update is called once per frame
        void Update()
        {

        }

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
    }

}