using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstARGame
{
    public class PlaceableGrid_Script : MonoBehaviour
    {
        public bool hasPiece;
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
            piece.transform.parent = transform;
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
