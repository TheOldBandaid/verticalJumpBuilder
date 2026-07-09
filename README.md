# Vertcal Jump game level Generator 
Generating an infinite vertical level by gradually increasing the complexity of the created elements, taking into account entry and exit points

в планах: сделать русский и английский readme. может написать в одном файле и сделать навигацию по нему или же два разных.

реализация визуала:
1. вырезка меша по границам, обнуление границ
2. изначальный спрайт с двумя бортами, растягиваемый мэш, переворот спрайта
3. бортики и внутренность отрисовывается двумя разными спрайтами

[] Russian Readme.md

## Block
The smallest unit of level generation, at this stage the shape, visuals and properties of the block are defined

### Visual 
The development of the visual of the block begins with separating the image of the sides from the internal component in the sprite
In the «Sprite editor» separate the borders by length and in «Draw Mode» select Tiled. 

⋅⋅⋅ *I found this part a little more difficult to understand than I would have liked, so I'll write down the solution I came up with right away. This is convenient because the size of the borders does not change when the block size is changed, and the triangles are immediately created without borders*

Using mesh technology made it possible to cut the sprite to fit the collider's dimensions.

### Form
There are two types here - triangles and rectangles. Both work according to the Polygon Collider 2D principle, but the triangle's random point is reset to zero.

### Properties
There are two types: sticky and repulsive. Sticky properties are indicated by the sprite's boundaries. Repulsive are not.

## Stage 
