using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstARGame
{
    public class PlaceableGrid_Script : MonoBehaviourPun
    {
        public bool hasPiece;
        public GameObject tower;

        private void Start()
        {
            hasPiece = false;
        }
        /// <summary>
        /// set hasPiece = true
        /// </summary>
        public void setPiece(GameObject piece)
        {
            hasPiece = true;
            tower = piece;
        }
        
        /// <summary>
        /// set hasPiece = false
        /// </summary>
        public void removePiece()
        {
            hasPiece= false;
        }
        /// <summary>
        /// check if current grid has already been placed with a piece
        /// </summary>
        public bool getHasPiece()
        {
            return hasPiece;
        }
    }
}
