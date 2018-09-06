---INTRODUCTION---
This application is a .NET implementation of Mega Man Battle Network's Navi Customizer. The .exe can be found in the NaviCustomizer/bin/Debug directory.

---WHAT IS NAVI CUSTOMIZER?---
The Navi Customizer is a feature in the Mega Man Battle Network (MMBN) series that allows you to enhance MegaMan (the character you play as)'s capabilities.
It starts off as a 4*4 grid, but eventually becomes a 5*5 grid as you progress through the game. How the Navi Customizer works is listed below:
-You can put pieces on the grid. These pieces are Tetris-like in nature; they are made up of squares adjacent to each other.
 These pieces can come in multiple colors, and can either be plain or textured. Pieces are rotatable.
-The grid has a command line. Plain parts must be on the line; textured parts must NOT be on the line.
-Pieces of the same color cannot be touching.
-A maximum of four colors can be placed on the grid.

If any of the above rules are broken, MegaMan becomes bugged. In MMBN, bugs make MegaMan act differently in normal. These bugs are mostly negative in nature, so
it is important to adhere to the rules of the Navi Customizer in design.

---HOW TO USE THIS APPLICATION---
This application is split into two main parts: the Main Window and the Piece Editor.

---MAIN WINDOW---
This is where you can select pieces and move them onto the grid, as well as remove pieces from the grid and delete them entirely. The list of your created pieces
can be found immediately below the text that says "Select a piece to insert: " This text is somewhat misleading, as once a piece is selected from the menu, you can
do one of three things:

-INSERT:
 When a piece is selected and you move your mouse over the grid, a projection of the piece appears. From here, you can rotate the projection using the LEFT and RIGHT
 arrow keys. If any square of the projection is already occupied by another piece, then each square in the projection will have a red X over it, indicating that you
 cannot put the piece there. Otherwise, the placement is valid, and you simply click the left mouse button to insert the piece onto the grid.

-DELETE:
 To delete a piece, either click the "Delete Selected Piece" button or press the DELETE key.

-EDIT:
 To edit a piece, click the "Edit Selected Piece" button. This opens up the Piece Editor with the settings of the selected piece.

-REMOVING PIECES FROM THE GRID-
To remove a piece from the grid, make sure no piece on the menu is selected. This can be accomplished by clicking outside of the menu. From there, click on a piece.
It should turn gold. Then press the DELETE key. The piece is removed from the grid, and its name appears in the menu again. Note that a piece on the grid cannot
be directly deleted; it must be removed from the grid then deleted from the piece menu.

-CHECKING FOR BUGS-
To check your piece configuration for bugs, simply click the "Check For Bugs" button. A list of all bugs is displayed.

-FILE MENU-
The 3 options on the File menu are described as follows:

-Create New Piece:
 Opens up the piece editor.

-Clear Navi Customizer:
 Removes all pieces from the grid.

-Delete All Pieces:
 Deletes all pieces. This can only be done if the grid is empty.


---PIECE EDITOR---
This is where pieces are created and modified. The piece editor can be opened in two ways:
1. Clicking "Create New Piece" in the File menu from the Main Window.
2. Clicking "Edit Selected Piece" when a piece is selected in the Main Window's piece list.

In the Piece Editor, you can choose the name of your piece (must be unique), its color, and whether it is textured or not. To decide the shape of your piece, simply
click the squares on the grid that you wish to be part of your piece. Note that at least one square must be selected, and all the squares must be touching.

When you are satisfied with your creation (or changes), click the button at the bottom of the window. It will either say "Create Piece" or "Save Changes," depending
on whether you are creating or modifying a piece.