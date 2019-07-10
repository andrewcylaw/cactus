using System;
using UnityEngine;

namespace GameLogic {
    
    // Custom component used to tag Grid GameObjects
    public class GridTag : MonoBehaviour {

        public int x { get; set; }
        public int y { get; set; }

        public GridTag(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public void SetTag(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public String GetTag() {
            return $"[GridTag] x:{x}, y:{y}";
        }

        public override string ToString() {
            return GetTag();
        }

        public override bool Equals(object other) {
            if (other == null || GetType() != other.GetType()) {
                return false;
            }
            
            return other is GridTag otherAsGridTag 
                   && x == otherAsGridTag.x 
                   && y == otherAsGridTag.y;
        }
    }
}
