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
        private (GridCell, float) prevOverlappedCell;


        public void Start() {
            gameManager = FindObjectOfType<GameManager>();
            mainCollider = GetComponent<Collider2D>();
            noFilter = new ContactFilter2D();
        }

        public void OnMouseDown() {
            initClickPosition = gameObject.transform.position - GetMousePosition();
        }

        public void OnMouseDrag() {
            gameManager.gameGrid.PrintTags();
            
            List<Collider2D> overlap = new List<Collider2D>();
            transform.position = GetMousePosition() + initClickPosition;
            
            // Detect the GridCell that this object is currently hovering over
            // TODO - filter that checks for the class GridCell and other game logic later
            int numOverlap = mainCollider.OverlapCollider(noFilter.NoFilter(), overlap);
            
            // send gridcell for dehighlight/newhighlight etc
            (GridCell, float) newOverlappedCell = default; 
            if (numOverlap > 0) {
                
                for (int i = 0; i < numOverlap; i++) {
                    float overlapAmount = mainCollider.Distance(overlap[i]).distance;
                
                    // Find the Collider2D with the most overlap
                    if (prevOverlappedCell.Item1 == null || overlapAmount < prevOverlappedCell.Item2 && overlapAmount < newOverlappedCell.Item2) {
                        newOverlappedCell = (gameManager.gameGrid.GetGridCell(overlap[i]), overlapAmount);
                    }
                }
            
                // Deselect our old cell
                if (prevOverlappedCell.Item1 != null) {
                    prevOverlappedCell.Item1.Contents.GetComponent<SpriteRenderer>().color = Color.white;
                }
                
                // If there was no new majority overlap -> nothing to colour
                if (newOverlappedCell.Item1 != null) {
                    newOverlappedCell.Item1.Contents.GetComponent<SpriteRenderer>().color = Color.green;    
                }
                
                prevOverlappedCell = newOverlappedCell;
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
