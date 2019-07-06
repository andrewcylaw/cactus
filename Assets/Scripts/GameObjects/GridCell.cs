using UnityEngine;

namespace GameObjects {
    
    /**
     * A cell in a grid.
     * Contains information about what is held here, etc
     */
    public class GridCell {
        public GameObject Contents { get; set; }

        public GridCell(GameObject contents = null) {
            Contents = contents;
        }
        
    }
}