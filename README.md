//-------------------------------------------------------------------------------------------------------------------------------------\\

Learning the Dewey Decimal System
Part 1 : Shelf Order 
James Marx
ST10114442 

//-------------------------------------------------------------------------------------------------------------------------------------\\

---> Introduction <---

A learning application for library trainees. Helping them to become farmiliar with the dewey decimal system, and the sorting of books in caetgories.
Allowing them to interact with the app in a fun manner and play it in various different ways.

//-------------------------------------------------------------------------------------------------------------------------------------\\

---> Precautions  <---

> The 'Learning_Dewey_Decimals_JamesMarx_ST10114442'.zip within 'Prog3B_POE1_JamesMarx_ST10114442' is in a folder with a long set of folders.

> The app will only work if its (the vs project folder) extracted into the desktop preferably.

> If it gives an error about naming convension too long, please delete the half-extracted version -> then rename the .zip file on the desktop to something shorter -> then extract it. (The name is just too long, sorry).

> If you run the app and you get errors relating to "Couldn't process file resx due to its being in the Internet or Restricted zone or having the mark of the web on the file. Remove the mark of the web if you want to process these files."

> View https://stackoverflow.com/questions/51348919/couldnt-process-file-resx-due-to-its-being-in-the-internet-or-restricted-zone-o

> or go to the main 'project file' -> Learning_Dewey_Decimals_JamesMarx_ST10114442 -> & for each .resx file -> rightclick -> properties -> select the unblock tickbox -> ok

> Re-open and run the project

//-------------------------------------------------------------------------------------------------------------------------------------\\

---> Download and install (Steps) <---

1. This is a visual studio 2019 Windows Forms applications

2. Download the applications zip file and extract it

3. Open it through the app file or visual studios

4. Click the visual studios 'Start' button andthe first form will be displayed, which is described below

5. Here is an alternate githuib link to the project : https://github.com/JamesMarxTheThird/Learning_Dewey_Decimals_JamesMarx_ST10114442.git


//-------------------------------------------------------------------------------------------------------------------------------------\\

---> Starting the Finding call numbers activity <---
-> -> Home Page <- <-

> You are first presented with a home page that has 2 hyperlinks and 3 image buttons.

> The hyperlinks are extra information about the dewey decimal system as the user may need a referesher.

> The buttons will all link to a different activity, but as of now the only avalilable one is the shelf order.

> The user can click the Find Call Numbers button on the right and will be directed to the game page.
//-------------------------------------------------------------------------------------------------------------------------------------\\

---> How to play <---
-> -> Finding call numbers Page <- <-

> Pressing the start button once on the find call numbers page will generate a category description shown near the top left in the blue panel.

> Also 4 random toplevel call numbers will be generated onto the white rectangle, being the treeview.

> One of these categories, has 2 further sub categories that exactly match the description generated on start.

> To play the game the user needs to DOUBLE CLICK on the node suspected to hold the generated description.

> If the category is correct, the node will expand, otherwise the category is wrong and you must try again.

> If you click on the exact, correct bottom level category, you will be congratulated via message box.

> Clicking the start button can reset the game at any time! This applies if you want to reset, or you won the game.

> The game timer will default at 40 seconds, but the user can change that to any amount of time, on load to make it more challanging for themselves (Textbox only accepts ints).

> They can also stop / hide the timer with the button under other controls

> The button bottom right under other controls will close the program for the user.

//-------------------------------------------------------------------------------------------------------------------------------------\\

---> User help <---
-> -> Finding call numbers Page <- <-

> Its quite difficult to know or guess which category a bottom level description belongs to.

> This is why the game is set out to adapt to the user. If its wrong, it lets you know, you try again and learn.

> If its correct it expands, and if its gets easier you can challange yourself to learn all of the loaded categories.

> If all else fails, see either 1) The multi line word doc attatched to become more farmiliar with these entries or 2) The copy of the textfile used to load, included in the project folder (origional in debug of project).

//-------------------------------------------------------------------------------------------------------------------------------------\\
//--End-of-Finding-call-numbers--\\
//-------------------------------------------------------------------------------------------------------------------------------------\\

---> Starting the Book Areas activity <---
-> -> Home Page <- <-

> You are first presented with a home page that has 2 hyperlinks and 3 image buttons.

> The hyperlinks are extra information about the dewey decimal system as the user may need a referesher.

> The buttons will all link to a different activity, but as of now the only avalilable one is the shelf order.

> The user can click the Book Areas button on the right and will be directed to the game page.

//-------------------------------------------------------------------------------------------------------------------------------------\\

---> How to play <---
-> -> Book Areas Page <- <-

> Our goal is to match the 4 left columns with the 4 corresponding ones on the right.

> To do this, once our page has loaded up the user can click the green start button on the button panel on the left of the page.

> This displays either call numbers (left) and descriptions (right), or visa versa, randomly.

> Simply click one item on the left side, and then the matching one on the right. 
	-> Please note that the lines drawn may looks short between the labels but I had to sacrafice that to be able to fit in the descriptions either side. 

> You can match in any order as long as you first click the left item, then the right.

> A blue reset button can also be used at any time to reset the current selections, but the start button also restarts to avoid confusion.

> Once you have matched the 4 left items with 4 on the right, the progress bar will be filled and the other labels will also be disabled to avoid further choices.

> The user must then press the orange tick button and will recieve feedback depending if they matched correctly or not.

> The first button, the home, takes the user back home if they would like to play another game.

> The red cross button will close the application at anytime.

> The textbox and button bottom left can be used to set the timer before you start the game.
	-> The timer can be set to anytime, depending on the users confidence, but it will default to 40 otherwise.

//-------------------------------------------------------------------------------------------------------------------------------------\\

---> User help <---
-> -> Book Areas Page <- <-

> The bottom right of the page has a question mark button.

> Once clicked the user will get a breakdown on how exactly to play the game.

//-------------------------------------------------------------------------------------------------------------------------------------\\
//--End-of-Book-Areas--\\
//-------------------------------------------------------------------------------------------------------------------------------------\\

---> Starting the Shelf Order activity <---
-> -> Home Page <- <-

> You are first presented with a home page that has 2 hyperlinks and 3 image buttons.

> The hyperlinks are extra information about the dewey decimal system as the user may need a referesher.

> The buttons will all link to a different activity, but as of now the only avalilable one is the shelf order.

> The user can click the shelf order button and will be directed to the activity page.

//-------------------------------------------------------------------------------------------------------------------------------------\\

---> How to play <---
-> -> Shelf Order Page <- <-

> The main objective is to re-order the books, ascending, according to the dewey decimal system.

> On the shelf in the center of the screen, 10 books with random call numbers will be displayed.

> The aim is the click on a book, and then click either the right or left arrow button below the books (or A and D keys) to shift it.

> After clicking all the books and moving them to their correct place, the user would click the check button at the bottom center.

> This button will prompt the user on their outcome and hint at the next, advised action to take based on the result.

> The reset button, next to the check button is there for simplicity and ease of use. It will reset the call numbers displayed at any given time
and even will reset based on what game mode is currently selected. It can also be trigered with the F5 key, as if its refreshing.
(It is not cheating to restart, its there incase anything goes wrong during the gameplay, and the user may want to reset.)

//-------------------------------------------------------------------------------------------------------------------------------------\\

---> User Help <---
-> -> Shelf Order Page <- <-

There are 3 in-app help features designed for ease-of-use.

The first two are under the options panel and are labelled:

> What to do

This is a smaller form that shows over the main describing all aspects of this game so users know exactly what to do.

> How to play

This is another, smaller form displayed to show the user a table of all the input controls to use the app.

Lastly there is the "toggle label hints"

This is a toggle button that hides and shows label hinting at components' features and hotkeys incase the user is in a game and quickly wants to understand something
better and without losing focus.

//-------------------------------------------------------------------------------------------------------------------------------------\\
//-End-of-Shelf-Order-\\
//-------------------------------------------------------------------------------------------------------------------------------------\\
