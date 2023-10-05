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
        private bool[] buttonSelected;

        void Start()
        {
            buttonSelected = new bool[3];
            buttonSelected[0] = false; // attk
            buttonSelected[1] = false; // defense
            buttonSelected[2] = false; // income
        }

        /// <summary>
        /// when user touches tower buttons on screen
        /// set pieceIndex to the current tower index
        /// Attk: 1, Defense: 2, Income: 3
        /// </summary>
        /// <param name="i"></param>
        public void SelectPieces(int i)
        {
            gb.pieceIndex = i;
            gb.hasSelectedPiece = true;
        }
        public void SelectAttkButton()
        {
            if (buttonSelected[0] == false)
            {
                SelectPieces(1);
                buttonSelected[0] = true;
                buttonSelected[1] = false;
                buttonSelected[2] = false;
            }
        }
        public void SelectDefenseButton()
        {
            if (buttonSelected[1] == false)
            {
                SelectPieces(2);
                buttonSelected[0] = false;
                buttonSelected[1] = true;
                buttonSelected[2] = false;
            }
        }
        public void SelectIncomeButton()
        {
            if (buttonSelected[2] == false)
            {
                SelectPieces(3);
                buttonSelected[0] = false;
                buttonSelected[1] = false;
                buttonSelected[2] = true;
            }
        }
    }
}
