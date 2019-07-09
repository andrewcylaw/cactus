using System;
using System.Collections.Generic;
using GameObjects;
using UnityEngine;

namespace Controls {
    public class Draggable : MonoBehaviour {
        
        public Camera mainCamera;
        
        private static ContactFilter2D noFilter;
        private Vector3 initClickPosition;
        private Collider2D mainCollider;
        private List<Collider2D> overlap;
        
        // Detects whether something is being highlighted (and what it is)
        private (GridCell, ColliderDistance2D) prevOverlappedCell;


        public void Start() {
            mainCollider = GetComponent<Collider2D>();
            overlap = new List<Collider2D>();
            noFilter = new ContactFilter2D();
        }

        public void OnMouseDown() {
            initClickPosition = gameObject.transform.position - GetMousePosition();
        }

        public void OnMouseDrag() {
            transform.position = GetMousePosition() + initClickPosition;
            
            // Detect the GridCell that this object is currently hovering over
            // TODO - filter that checks for the class GridCell and other game logic later
            int numOverlap = mainCollider.OverlapCollider(noFilter.NoFilter(), overlap);
            
            // Find largest overlap
            // send gridcell for dehighlight/newhighlight etc
            (GridCell, ColliderDistance2D) newOverlappedCell = default; 
            if (numOverlap > 0) {
                for (int i = 0; i < numOverlap; i++) {
                    ColliderDistance2D overlapAmount = mainCollider.Distance(overlap[i]);
                
                    if (prevOverlappedCell.Item1 == null || overlapAmount.distance < prevOverlappedCell.Item2.distance) {
                        newOverlappedCell = (overlap[i].GetComponent<GridCell>(), overlapAmount);
                    }
                }
            
                // Now we have our GridCell with the highest overlap: select the new one, and deselect the old one
                // if it exists. Also guaranteed at least 1 overlap here
                if (prevOverlappedCell.Item1 != null) {
                    prevOverlappedCell.Item1.Contents.GetComponent<SpriteRenderer>().color = Color.clear;
                }

                newOverlappedCell.Item1.Contents.GetComponent<SpriteRenderer>().color = Color.green;
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
