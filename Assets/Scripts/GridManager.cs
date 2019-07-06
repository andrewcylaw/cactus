using GameObjects;
using UnityEngine;
using Grid = GameObjects.Grid; // UnityEngine has their own grid class

/**
 * Manages a given grid using of the given dimensions with the instantiated prefabs.
 */
public class GridManager : MonoBehaviour {
    [SerializeField] 
    private Grid grid;

    public int rows;
    public int cols;
    public GameObject prefab;

    void Start() {
        grid = new Grid(rows, cols, prefab);
        
        grid.DrawGrid();
    }

    void Update() {
    }
}
