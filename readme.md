## Description

## Controls

## Design
Controls/
	Contains code that determines how users interact with objects. For example, edge-based mouse camera movement, mouse hover detection, or the ability to click and drag, etc.

GameLogic/
	Logic in terms of game rules, AI, and level generation, etc.

GameObjects/
	Class definitions in terms of individual objects in the game. For example, the cacti, the grids, timers, etc.

## Development Roadmap

#### 06 July, 2019
* Relearning Unity, digging through old projects and watching tutorials
* Project setup, writing basic scripts to generate grid, basic camera movement, planning.


Hierarchy:
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