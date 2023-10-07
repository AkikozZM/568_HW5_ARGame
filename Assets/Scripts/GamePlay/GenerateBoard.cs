using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MyFirstARGame
{
    public class GenerateBoard : MonoBehaviour
    {
        public GameObject[] pieces;
        public NetworkLauncher networkLauncher;
        private NetworkCommunication netComm;
        public float gridSizeX = 4.0f;
        public float gridSizeY = 8.0f;
        public bool hasSelectedPiece;
        public int pieceIndex;

        public bool canCreate;
        GameObject board;
        GameObject hitbox1;
        GameObject hitbox2;

        public bool startGame;

        private GameManager GlobalGameManager;

        private void Start()
        {
            pieceIndex = 0; // 0 means put nothing
            canCreate = false;
            hasSelectedPiece = false;
            startGame = false;

            GlobalGameManager = FindObjectOfType<GameManager>();
        }

        private void Update()
        {
            if (canCreate)
            {
                GenerateGameBoard();
            }

            if (hasSelectedPiece && startGame)
            {
                MouseClick();
                //ScreenTouch();
            }
        }

        /// <summary>
        /// Spawn a piece on the Placeable Grid
        /// </summary>
        private void SpawnPiece(Ray ray)
        {
            int player_num = PhotonNetwork.LocalPlayer.ActorNumber;
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // check the tag && if the grid has piece already
                // Player 1 places pieces on green grid
                if (player_num == 2 || player_num == 1 && hit.collider.gameObject.CompareTag("PlaceableGrid") && netComm.SpendMoney(50, 0))
                {
                    GameObject curr = hit.collider.gameObject;
                    if (curr.GetComponent<PlaceableGrid_Script>().getHasPiece() == false)
                    {
                        curr.GetComponent<PlaceableGrid_Script>().setPiece();
                        Vector3 hitPos = hit.collider.gameObject.transform.position;
                        GameObject curr_piece = PhotonNetwork.Instantiate(pieces[pieceIndex].name, hitPos, Quaternion.Euler(0, 90, 0)) as GameObject;
                        TowerScript tower = curr_piece.GetComponent<TowerScript>();
                        tower.controller = 1;
                        tower.towerDamage = GlobalGameManager.player_1_damage;
                        tower.towerHealth = GlobalGameManager.player_1_tower_health;
                        tower.towerIncome = GlobalGameManager.player_1_tower_income;
                        tower.createDelay = true;
                        //ResetSelected();
                    }
                }
                // Player 2 places pieces on red grid
                else if (player_num == 3 && hit.collider.gameObject.CompareTag("PlaceableGrid_red") && netComm.SpendMoney(0, 50))
                {
                    GameObject curr = hit.collider.gameObject;
                    if (curr.GetComponent<PlaceableGrid_Script>().getHasPiece() == false)
                    {
                        curr.GetComponent<PlaceableGrid_Script>().setPiece();
                        Vector3 hitPos = hit.collider.gameObject.transform.position;
                        GameObject curr_piece = PhotonNetwork.Instantiate(pieces[pieceIndex + 3].name, hitPos, Quaternion.Euler(0, -90, 0)) as GameObject;
                        TowerScript tower = curr_piece.GetComponent<TowerScript>();
                        tower.controller = 2;
                        tower.towerDamage = GlobalGameManager.player_2_damage;
                        tower.towerHealth = GlobalGameManager.player_2_tower_health;
                        tower.towerIncome = GlobalGameManager.player_2_tower_income;
                        tower.createDelay = true;
                        //ResetSelected();
                    }
                }
            }
            ResetSelected();
        }

        private void ScreenTouch()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    SpawnPiece(ray);
                }
            }
        }
        private void MouseClick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                SpawnPiece(ray);
            }
        }
        /// <summary>
        /// NetworkLauncher class will call this function, when server detects the first player joins the room
        /// </summary>
        public void GenerateGameBoard()
        {
            
            if (board == null)
            {
                // when game starts, instantiate a gameboard
                board = PhotonNetwork.Instantiate("Board", new Vector3(0, 0, 0), Quaternion.Euler(0, 90, 0));
                hitbox1 = PhotonNetwork.Instantiate("PlayerHitBox", new Vector3(1.0f, 0.3f, 0), Quaternion.identity);
                hitbox2 = PhotonNetwork.Instantiate("PlayerHitBox", new Vector3(-0.3f, 0.3f, 0), Quaternion.identity);

                hitbox1.GetComponent<PlayerHitBox>().controller = 1;
                hitbox2.GetComponent<PlayerHitBox>().controller = 2;
            }
            else if (board != null)
            {
                board.transform.position = new Vector3(0, 0, 0);
                hitbox1.transform.position = new Vector3(1.0f, 0.3f, 0);
                hitbox2.transform.position = new Vector3(-0.3f, 0.3f, 0);
            }
            
        }
        /// <summary>
        /// After user placed a piece, reset the select idx
        /// </summary>
        private void ResetSelected()
        {
            hasSelectedPiece = false;
            pieceIndex = 0;
        }

        public void StartGameBoard()
        {
            Debug.Log("Board Connected");
            netComm = FindObjectOfType<NetworkCommunication>();
            startGame = true;
        }
    }
}
