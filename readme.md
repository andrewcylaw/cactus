## Description

## Controls

## Design
`Controls/`
	Contains code that determines how users interact with objects. For example, edge-based mouse camera movement, mouse hover detection, or the ability to click and drag, etc.

`GameLogic/`
	Logic in terms of game rules, AI, and level generation, etc.

`GameObjects/`
	Class definitions in terms of individual objects in the game. For example, the cacti, the grids, timers, etc.

## Class Hierarchy
```
GridManager
 > Grid - GameGrid
 	> GridCell    (GameObject and Component)
 	   > Tile     (GameObject)
 	   > Contents (GameObject)
 	   > GridTag  (Component)
 	   > ...
 	> GridCell
 	> ...
 	> ...

 > Grid - Inventory Grid
    > GridCell    (GameObject and Component)
 	   > Tile     (GameObject)
 	   > Contents (GameObject)
 	   > GridTag  (Component)
 	   > ...
 	> GridCell
 	> ...    
 	> ...
```

goal:
- more than one cactus cannot occupy the same grid
- perhaps cannot move the cactus after it has been snapped to place?

- more than one cactus - replace? displace? prevent? 
- should be replace ?


## Sample Level Design
```
// Sample level design via text file    
[GameGrid] // size of game grid 
rows=4
cols=8

[InventoryGrid] // these should be fixed, right?
rows=8
cols=4         

[GameGridObjects]  // prepopulate the grid with immovable objects of type=coordinates
cactus=(1,2),(2,4),(3,4)

[InventoryGridObjects] // these just fill the inventory from start to finish L->R, U->D
bramble=3
cactus=4
```

## TODO Workflow
    1) load levels from external file
    2) implement drag and drop properly (ie, objects are ALWAYS stuck to a gridCell)
    3) some actual pricking logic
    4) enemy that walks in a straight line from an invisible grid to game grid? partially invisible game grid?
    5) start/stop interactions
