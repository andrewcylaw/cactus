using System;
using UnityEngine;

namespace GameLogic {
    
    // Custom component used to tag Grid GameObjects
    public class GridTag : MonoBehaviour {

        private int x;
        private int y;

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
    }
}
