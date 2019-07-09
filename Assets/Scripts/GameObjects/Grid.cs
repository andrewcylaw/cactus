using UnityEngine;

namespace GameObjects {
    
    /**
     * A grid space.
     */
    public class Grid : MonoBehaviour {
        public int rows;
        public int cols;
        public GameObject tile;
        
        private GridCell[,] cells { get; set; }

        void Start() {
            cells = new GridCell[rows, cols];
            InsertAll(tile);
            DrawGrid();
        }
        
        // Draws the current grid using whatever is in each GridCell
        public void DrawGrid(int xOffset=0, int yOffset=0) {
            for (int x = 0; x < rows; x++) {
                for (int y = 0; y < cols; y++) {
                    cells[x, y].Contents.transform.position = new Vector3(x + xOffset, y + yOffset, 0);
                    Instantiate(cells[x, y].Contents);
                }
            }
        }
        
        // Inserts the given GameObject into all cells in this grid
        public void InsertAll(GameObject obj) {
            for (int x = 0; x < rows; x++) {
                for (int y = 0; y < cols; y++) {
                    Insert(x, y, obj);
                }
            }
        }
        
        // Inserts the given GameObject into the cell located at x, y on the grid
        public void Insert(int x, int y, GameObject obj) {
            GridCell gridCell = cells[x, y] == null ? new GridCell() : cells[x, y];
            gridCell.Contents = obj;
            cells.SetValue(gridCell, x, y);
        }
        
        // Future methods
        /**
         * Insert x,y,GameObject 
         * Retrieve x,y
         * Delete x,y
         */
    }
}