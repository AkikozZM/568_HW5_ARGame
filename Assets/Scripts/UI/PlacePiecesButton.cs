using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MyFirstARGame
{
    public class PlacePiecesButton : MonoBehaviour
    {
        public GenerateBoard gb;
        public GameObject attk;
        public GameObject defense;
        public GameObject income;

        /// <summary>
        /// when user touches tower buttons on screen
        /// set pieceIndex to the current tower index
        /// Attk: 1, Defense: 2, Income: 3
        /// </summary>
        /// <param name="i"></param>
        public void SelectPieces(int i)
        {
            gb.pieceIndex = i;
        }
        public void SelectAttkButton()
        {
            gb.hasSelectedPiece = true;
            SelectPieces(1);
        }
        public void SelectDefenseButton()
        {
            gb.hasSelectedPiece = true;
            SelectPieces(2);
        }
        public void SelectIncomeButton()
        {
            gb.hasSelectedPiece = true;
            SelectPieces(3);
        }
    }
}
