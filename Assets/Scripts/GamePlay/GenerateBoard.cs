using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFirstARGame
{
    public class GenerateBoard : MonoBehaviour
    {
        public GameObject piece;
        public float gridSizeX = 4.0f;
        public float gridSizeY = 8.0f;

        private Vector3 putPos;
        private void Update()
        {
            /*
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                SpawnPiece(ray);
            } */
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
        private void SpawnPiece(Ray ray)
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 hitPos = hit.collider.gameObject.transform.position;
                Debug.Log(hitPos);
                Instantiate(piece, hitPos, Quaternion.identity);
            }
        }
    }
}
