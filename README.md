# Vertcal Jump game level Generator 
Generating an infinite vertical level by gradually increasing the complexity of the created elements, taking into account entry and exit points

## Block
The smallest unit of level generation, at this stage the shape, visuals and properties of the block are defined

### Visual 
The development of the visual of the block begins with separating the image of the sides from the internal component in the sprite
In the «Sprite editor» separate the borders by length and in «Draw Mode» select Tiled. 

*** I found this part a little more difficult to understand than I would have liked, so I'll write down the solution I came up with right away. This is convenient because the size of the borders does not change when the block size is changed, and the triangles are immediately created with empty space inside. ***


### Form
There are two types here - triangles and rectangles

### Properties
