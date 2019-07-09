using UnityEngine;

namespace GameLogic {
    
    // Responsible for game logic, manages multiple grids
    public class GameManager : MonoBehaviour {
        
        private Grid gameGrid;
        // private Grid inventoryGrid;

        void Start() {
            // Testing code - draw gameGrid
            gameGrid = new Grid();    
        }
        
    }
}
