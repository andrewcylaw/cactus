using GameObjects;
using UnityEngine;
using Grid = GameObjects.Grid;

namespace GameLogic {
    
    // Is reponsible for methods that interact with specific grids
    // Eg, checking which grid a GridCell belongs to, etc 
    public class GridManager : MonoBehaviour {
        public Grid gameGrid;
        public Grid inventoryGrid;

        public GameObject gameGridCell;
        public GameObject inventoryGridCell;

        public void InitializeGrids() {
            gameGrid.InitializeGrid(gameGridCell, GridType.GameGrid, -7.5f, -3.5f);
            inventoryGrid.InitializeGrid(inventoryGridCell, GridType.InventoryGrid, 5.5f, -3.5f);
        }

        // Returns whether or not the otherCollider is a GridCell in either grid
        public bool IsGridCell(Collider2D otherCollider) {
            return gameGrid.IsGridCell(otherCollider) || inventoryGrid.IsGridCell(otherCollider);
        }

        public GridCell GetGridCell(Collider2D otherCollider) {
            return gameGrid.GetGridCell(otherCollider) ?? inventoryGrid.GetGridCell(otherCollider);
        }

        public bool IsGameGridCell(Collider2D otherCollider) {
            return default; // TODO
            // return gameGrid.GetGridCell(otherCollider). == null;
        }
        
    }
}
