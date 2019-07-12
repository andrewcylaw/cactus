using System;
using System.Collections.Generic;
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

        private Dictionary<GridTag, GridCell> lookup; // GridTag -> GridCell
        private GridCell[,] cells { get; set; }

        void Awake() {
            lookup = new Dictionary<GridTag, GridCell>();
            cells = new GridCell[rows, cols];
        }
        
        // Initialize the grid 
        public void InitializeGrid(GameObject gridCell, GridType gridType, float xOffset=0, float yOffset=0) {
            for (int x = 0; x < rows; x++) {
                for (int y = 0; y < cols; y++) {
                    /*
                     *  1. Instantiate new GridCell + set it as child of Grid
                     *  2. Instantiate the tile associated with the GridCell + set it as child of GridCell
                     *  3. Set our tile as a property of the GridCell
                     *  4. Set GridCell's GridTag to our new tag
                     *  5. Add the new GridCell to the 2D array
                     */
                    // TODO - instantiate contents if necessary
                    
                    Vector3 spawnLoc = new Vector3(x + xOffset, y + yOffset, 0);
                    GameObject instantiatedCell = Instantiate(gridCell, spawnLoc, Quaternion.identity);
                    GameObject instantiatedTile = Instantiate(instantiatedCell.GetComponent<GridCell>().tile, spawnLoc, Quaternion.identity);
                    instantiatedCell.transform.parent = gameObject.transform;
                    instantiatedTile.transform.parent = instantiatedCell.transform;
                    
                    instantiatedCell.AddComponent<GridTag>();
                    GridCell newCell = instantiatedCell.GetComponent<GridCell>();
                    newCell.SetGridTag(gridType, x, y);
                    newCell.tile = instantiatedTile;
                    cells[x, y] = newCell;
                    lookup.Add(newCell.gridTag, cells[x, y]);
                }
            }
        }

        // Use the given Collider2D to retrieve the appropriate GridCell
        public GridCell GetGridCell(Collider2D gridCellCollider) {
            if (lookup.TryGetValue(gridCellCollider.GetComponentInParent<GridCell>().gridTag,
                out GridCell outGridCell)) {
                return outGridCell;
            }

            return null;
        }

        public Boolean IsGridCell(Collider2D otherCollider) {
            return otherCollider.GetComponentInParent<GridCell>().gridTag != null;
        }
 
        public void PrintTags() {
            for (int x = 0; x < rows; x++) {
                for (int y = 0; y < cols; y++) {
                    Debug.Log("GridCell with tag: " + cells[x,y].gridTag);
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