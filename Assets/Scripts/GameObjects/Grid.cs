using System;
using System.Collections.Generic;
using System.Numerics;
using GameLogic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace GameObjects {
    
    /**
     * A grid space.
     */
    public class Grid : MonoBehaviour {
        public int rows;
        public int cols;
        public GameObject tile;

        private Dictionary<String, GridCell> lookup; // GridTag -> GridCell
        private GridCell[,] cells { get; set; }

        void Awake() {
            lookup = new Dictionary<String, GridCell>();
            cells = new GridCell[rows, cols];
        }
        
        // Initialize the grid 
        public void InitializeGrid(GameObject tile, float xOffset=0, float yOffset=0) {
            for (int x = 0; x < rows; x++) {
                for (int y = 0; y < cols; y++) {
                    // Instantiate first, then set it to the grid
                    GameObject newTile = Instantiate(tile, new Vector3(x + xOffset, y + yOffset, 0), Quaternion.identity);
                    newTile.GetComponent<GridTag>().SetTag(x, y);
                    cells[x, y] = new GridCell(newTile);
                    lookup.Add(newTile.GetComponent<GridTag>().GetTag(), cells[x, y]);
                }
            }
        }

        // Use the given Collider2D to retrieve the appropriate GridCell
        public GridCell GetGridCell(Collider2D gridCellCollider) {
            return lookup[gridCellCollider.transform.gameObject.GetComponent<GridTag>().GetTag()];
        }

        public void PrintTags() {
            for (int x = 0; x < rows; x++) {
                for (int y = 0; y < cols; y++) {
                    Debug.Log("GridCell with tag: " + cells[x,y].Contents.GetComponent<GridTag>());
                }
            }
        }
        
        // Future methods
        /**
         * Insert x,y,GameObject 
         * Retrieve x,y
         * Delete x,y
         */
    }
}