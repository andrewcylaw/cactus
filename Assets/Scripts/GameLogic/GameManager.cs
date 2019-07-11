using UnityEngine;


namespace GameLogic {
    
    // Responsible for game logic, manages multiple grids
    public class GameManager : MonoBehaviour {

        // TODO - singleton instances
        public GameObject gridManager;

        private void Awake() {
            gridManager.GetComponent<GridManager>().InitializeGrids();
        }

    }
}
