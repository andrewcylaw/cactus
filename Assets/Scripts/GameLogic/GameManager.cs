using GameObjects;
using UnityEngine;
using Grid = GameObjects.Grid;

namespace GameLogic {
    
    // Responsible for game logic, manages multiple grids
    public class GameManager : MonoBehaviour {

        // Singleton GameManager
        private static GameManager _instance;
        public static GameManager Instance {
            get { return _instance;  }
        }
        
        public Grid gameGrid;

        private void Awake() {
            if (_instance != null && _instance != this) {
                Destroy(gameObject);
            } else {
                _instance = this;
            }
            
            gameGrid.InitializeGrid(gameGrid.tile, -7.5f, -3.5f);
            gameGrid.PrintTags();
        }

        
        // private Grid inventoryGrid; <-- this one will probably have to be made programatically?

    }
}
