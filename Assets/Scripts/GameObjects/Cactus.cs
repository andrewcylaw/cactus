using UnityEngine;

namespace GameObjects {
    public class Cactus {
    
        private GridCell origPosition; // To snap back into place

        public Cactus(GridCell origPosition) {
            this.origPosition = origPosition;
        }
    
    }
}
