using GameLogic;
using UnityEngine;

namespace GameObjects {
    
    /**
     * A cell in a grid.
     * Contains information about what is held here, etc
     */
    public class GridCell : MonoBehaviour {
        public GameObject tile;
        public GameObject contents;
        
        public GridTag gridTag => GetComponent<GridTag>();

        public void SetGridTag(GridType gridType, int x, int y) {
            if (!GetComponent<GridTag>()) {
                throw new MissingComponentException("GridTag is missing!");
            }
            
            gridTag.SetTag(gridType, x, y);
        }
        
        public bool HasContents() {
            return contents;
        }

        public override bool Equals(object other) {
            if (other == null || GetType() != other.GetType()) {
                return false;
            }

            return other is GridCell otherGridCell
                   && otherGridCell.tile == tile
                   && otherGridCell.contents == contents
                   && otherGridCell.GetComponent<GridTag>() == GetComponent<GridTag>();
        }
    }
}