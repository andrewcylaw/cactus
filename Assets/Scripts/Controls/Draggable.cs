using System.Collections.Generic;
using GameLogic;
using GameObjects;
using UnityEngine;

namespace Controls {
    public class Draggable : MonoBehaviour {
        
        public Camera mainCamera;

        private GameManager gameManager;
        private static ContactFilter2D noFilter;
        private Vector3 initClickPosition;
        private Collider2D mainCollider;

        // Detects whether something is being highlighted (and what it is)
        private GridCell overlappedCell;


        public void Start() {
            gameManager = FindObjectOfType<GameManager>();
            mainCollider = GetComponent<Collider2D>();
            noFilter = new ContactFilter2D();
        }

        public void OnMouseDown() {
            initClickPosition = gameObject.transform.position - GetMousePosition();
        }

        public void OnMouseDrag() {
            List<Collider2D> overlap = new List<Collider2D>();
            transform.position = GetMousePosition() + initClickPosition;
            
            // Detect the GridCell that this object is currently hovering over
            // TODO - filter that checks for the class GridCell and other game logic later
            int numOverlap = mainCollider.OverlapCollider(noFilter.NoFilter(), overlap);
            
            GridCell newOverlappedCell = default;
            float largestOverlapAmt = default; // "largest" = most negative number
            if (numOverlap > 0) {
                // Find the Collider2D with the most overlap
                for (int i = 0; i < numOverlap; i++) {
                    float overlapAmount = mainCollider.Distance(overlap[i]).distance;
                    if (overlappedCell == null || overlapAmount < largestOverlapAmt) {
                        newOverlappedCell = gameManager.gameGrid.GetGridCell(overlap[i]);
                        largestOverlapAmt = overlapAmount;
                    }
                }

                if (overlappedCell != null && !overlappedCell.Equals(newOverlappedCell)) {
                    overlappedCell.Contents.GetComponent<SpriteRenderer>().color = Color.white;
                }

                if (newOverlappedCell != null) {
                    newOverlappedCell.Contents.GetComponent<SpriteRenderer>().color = Color.green;    
                }
                
                overlappedCell = newOverlappedCell;
            }
        }

        public void OnMouseUp() {
            Debug.Log("Mouse was released");
        }

        // Returns the position of the mouse on the screen right now
        private Vector3 GetMousePosition() {
            return mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        }
    }
}
