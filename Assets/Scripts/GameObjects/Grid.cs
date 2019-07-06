using UnityEngine;

namespace GameObjects {
    
    /**
     * A grid space.
     */
    public class Grid {
        private int rows  { get; set; }
        private int cols  { get; set; }
        
        public GridCell[,] cells { get; set; }
        
        public Grid(int rows, int cols, GameObject prefab) {
            this.rows = rows;
            this.cols = cols;
            cells = new GridCell[this.rows, this.cols];

            InsertAll(prefab);
        }
        
        // Draws the current grid using whatever is in each GridCell
        public void DrawGrid() {
            for (int x = 0; x < rows; x++) {
                for (int y = 0; y < cols; y++) {
                    cells[x, y].Contents.transform.position = new Vector3(x, y, 0);
                    Object.Instantiate(cells[x, y].Contents);
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