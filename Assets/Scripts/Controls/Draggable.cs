using System.Collections.Generic;
using GameLogic;
using GameObjects;
using UnityEngine;
using Grid = GameObjects.Grid;

namespace Controls {
    public class Draggable : MonoBehaviour {
        
        public Camera mainCamera;

        // Cactus objects can snap between either grid and have different properties
        // depending on which grid they snap to
        private GridManager gridManager;
        private Grid gameGrid;
        private Grid inventoryGrid;
        
        private static ContactFilter2D noFilter;
        private Vector3 initClickPosition;
        private Collider2D mainCollider;

        // Detects whether something is being highlighted (and what it is)
        private GridCell overlappedCell;

        // TODO:
        /*   - remove highlight upon snapping
         *   - filter to not highlight squares that are already occupied
         *   - cannot re-drag after specific scenarios (eg, day is over)
         */

        public void Start() {
            gridManager = FindObjectOfType<GridManager>();
            gameGrid = gridManager.gameGrid;
            inventoryGrid = gridManager.inventoryGrid;
            mainCollider = GetComponent<Collider2D>();
            noFilter = new ContactFilter2D();
        }

        // Allows for dragging anywhere on the clicked GameObject
        public void OnMouseDown() {
            initClickPosition = gameObject.transform.position - GetMousePosition();
        }

        // Allows for dragging + showing the GridCell that this GameObject will snap to
        public void OnMouseDrag() {
            transform.position = GetMousePosition() + initClickPosition;
            
            List<Collider2D> overlap = new List<Collider2D>();
            int numOverlap = mainCollider.OverlapCollider(noFilter.NoFilter(), overlap);
            GridCell newOverlappedCell = default;
            float largestOverlapAmt = default; // "largest" = most negative number
            
            // TODO ! --- FIX ME
            if (numOverlap > 0) {
                // Find the Collider2D with the most overlap
                for (int i = 0; i < numOverlap; i++) {
                    Collider2D curCollider = overlap[i];

                    if (!gridManager.IsGridCell(curCollider)) {
                        continue;
                    }
                    
                    float overlapAmount = mainCollider.Distance(curCollider).distance;
                    if (overlappedCell == null || overlapAmount < largestOverlapAmt) {
                        // Have to check if GridCell or not 
                        newOverlappedCell = gridManager.GetGridCell(curCollider);
                        largestOverlapAmt = overlapAmount;
                    }
                }

                if (overlappedCell != null && !overlappedCell.Equals(newOverlappedCell)) {
                    DeselectGridCell(overlappedCell);
                }

                if (newOverlappedCell != null) {
                    newOverlappedCell.tile.GetComponent<SpriteRenderer>().color = Color.grey;    
                }
                
                overlappedCell = newOverlappedCell;
            }
        }

        // Snaps the dragged object to the nearest GridCell on mouse release
        public void OnMouseUp() {
            DeselectGridCell(overlappedCell);

            // Replace the contents if already occupied (ie, they switch spots)
            if (overlappedCell.HasContents()) {
                overlappedCell.contents.transform.position = transform.position;
            }
            
            transform.position = overlappedCell.tile.transform.position;
            overlappedCell.contents = transform.gameObject;
        }

        private static void DeselectGridCell(GridCell gridCell) {
            gridCell.tile.GetComponent<SpriteRenderer>().color = Color.white;
        }

        // Returns the position of the mouse on the screen right now
        private Vector3 GetMousePosition() {
            return mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        }
    }
}
