using UnityEngine;

namespace GameObjects {
    
    /**
     * A cell in a grid.
     * Contains information about what is held here, etc
     */
    public class GridCell {
        public GameObject Contents { get; set; }

        public GridCell(GameObject contents) {
            Contents = contents;
        }

        public override bool Equals(object other) {
            if (other == null || GetType() != other.GetType()) {
                return false;
            }

            return other is GridCell otherAsGridCell && otherAsGridCell.Contents == Contents;
        }
    }
}