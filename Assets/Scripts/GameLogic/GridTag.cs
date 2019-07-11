using System;
using GameObjects;
using UnityEngine;

namespace GameLogic {
    
    // Custom component used to tag Grid GameObjects.
    // The tag should not change after the object is instantiated
    public class GridTag : MonoBehaviour {

        public GridType gridType { get; private set; }
        public int x { get; private set; }
        public int y { get; private set; }

        public void SetTag(GridType gridType, int x, int y) {
            this.gridType = gridType;             
            this.x = x;
            this.y = y;
        }

        public String GetTag() {
            return $"[GridTag] type:{gridType}, x:{x}, y:{y}";
        }

        public override string ToString() {
            return GetTag();
        }

        public override bool Equals(object other) {
            if (other == null || GetType() != other.GetType()) {
                return false;
            }
            
            return other is GridTag otherGridTag 
                   && otherGridTag.gridType == gridType
                   && otherGridTag.x == x 
                   && otherGridTag.y == y;
        }
    }
}
