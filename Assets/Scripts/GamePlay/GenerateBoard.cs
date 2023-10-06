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
        public float gridSizeX = 4.0f;
        public float gridSizeY = 8.0f;
        public bool hasSelectedPiece;
        public int pieceIndex;

        private void Start()
        {
            pieceIndex = 0; // 0 means put nothing
            hasSelectedPiece = false;
        }

        private void Update()
        {
            
            if (hasSelectedPiece)
            {
                //MouseClick();
                ScreenTouch();
            }
        }

        /// <summary>
        /// Spawn a piece on the Placeable Grid
        /// </summary>
        private void SpawnPiece(Ray ray)
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // check the tag && if the grid has piece already
                if (hit.collider.gameObject.CompareTag("PlaceableGrid"))
                {
                    GameObject curr = hit.collider.gameObject;
                    if (curr.GetComponent<PlaceableGrid_Script>().getHasPiece() == false)
                    {
                        curr.GetComponent<PlaceableGrid_Script>().setPiece();
                        Vector3 hitPos = hit.collider.gameObject.transform.position;

                        int player_num = PhotonNetwork.LocalPlayer.ActorNumber;
                        if (player_num == 0)
                        {
                            GameObject curr_piece = PhotonNetwork.Instantiate(pieces[pieceIndex].name, hitPos, Quaternion.Euler(0, -90, 0)) as GameObject;
                            curr_piece.GetComponent<TowerScript>().controller = 1;
                        }
                        else if (player_num == 1)
                        {
                            GameObject curr_piece = PhotonNetwork.Instantiate(pieces[pieceIndex].name, hitPos, Quaternion.Euler(0, 90, 0)) as GameObject;
                            curr_piece.GetComponent<TowerScript>().controller = 2;
                        }
                        ResetSelected();
                    }
                }
            }
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
            // when game starts, instantiate a gameboard
            GameObject board = PhotonNetwork.Instantiate("Board", new Vector3(0, 0, 0), Quaternion.Euler(0, 90, 0)) as GameObject;
            GameObject hitbox1 = PhotonNetwork.Instantiate("PlayerHitBox", new Vector3(1.0f, 0.3f, 0), Quaternion.identity) as GameObject;
            GameObject hitbox2 = PhotonNetwork.Instantiate("PlayerHitBox", new Vector3(-0.3f, 0.3f, 0), Quaternion.identity) as GameObject;

            hitbox1.GetComponent<PlayerHitBox>().controller = 1;
            hitbox2.GetComponent<PlayerHitBox>().controller = 2;
        }
        /// <summary>
        /// After user placed a piece, reset the select idx
        /// </summary>
        private void ResetSelected()
        {
            hasSelectedPiece = false;
            pieceIndex = 0;
        }
    }
}
