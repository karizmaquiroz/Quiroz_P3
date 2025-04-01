# Quiroz_P3
CGDD 3103App Extentsion and Scripting Project 3

# Explanation of ReadMe-Table of Contents
-[How To Play](how-to-play)

-[List of Requirements Met](list-of-requirements-met)


# How To Play


# List of Requirments Met

# Checklist of Project 3 Requirements-Table of Contents
-[Objectives](#objectives)

-[Mandatory Requirements](mandatory-requirements)

-[Optional Requirements](optional-requirements)

-[Extra Credit](extra-credit)

-[Notes](notes)

-[Submission Instructions](submission-instructions)
 
 
# Objectives

Practice using scripts to extend a game to be a more user-friendly game!

# Mandatory Requirements

Using Unity, create any game you want to. Only a playable game will be counted!

- [x]Create at least one background sound AND one sound effect for the game. (10%)
-  Make sure the audio clips can be managed by your scripts. 
- [x]Create a game setting menu to configure the volume for all the audios used in the game, change resolutions, switch fullscreen/window, shadow types, etc. (10%)
-  No less than 5 different configurable options. 
- [x]Save inventory information into a file and make the game read it before running. (10%)
- [x]Save the game settings to a file and make the game read it before running. (10%)
- [x]When starting the game, provide the player with an option to start a new game or resume the last saved game. (10%)
-  If it is a new game, load the appropriate settings and information from new game files.
- If it is a resume game situation, load the inventory information and game settings from the most recent time the game was quit. 

# Notes:

For the file processing, you may use text files with stream reader/writer, XML file processing or the binary formatter with serialized/de-serialized files. You may also use JSON file processing.  PlayerPrefs is not considered to be file processing. 

# Optional Requirements (Maximum 50%. You can do more than 50%, I will choose the best 50% ones for you.)

- [x]Create a first-person or third-person camera controlled by a keyboard and/or mouse. The camera needs to be able to translate and rotate. Make sure you create a health display for your character. (10%)
- [ ]Create 2D GUIs to change the keys for controlling the camera. (10%)
- NOT changing the profile, you need to be able to change each key individually in the game 
- [x]Create at least one 3D GUI menu. The menu could be a health bar, a button, etc. (5%)
- A 3D GUI menu needs to face the camera all the time. 
- [x]Use a script to create an inventory storage system with a minimum of 6 different items. (10%)
- The script should use a linked list to store the inventory items.
- You can decide the maximum size of the storage and how many items you want to show on screen.
- In the storage, you need to show the name and amount of the items collected.
- If all of the one collected items are used, you should delete that item from the inventory storage, and shift the rest of the items to fill the empty spot. 
- [x]The inventory storage menu should be controlled by the user to show and close on the screen. (5%)
- [x]Use a script to create a customizable quick item storage with no less than 3 items. (10%)
- Users can choose any 3 different items stored in the inventory storage and put them into the quick item storage.
- Users should be able to define and change the order of the quick item storage.
- The script should use a linked list to store the inventory items. You also need to show the item name and amount in the quick item storage.
- The items in the quick item storage should be able to be accessed (used) by pressing 1, 2, or 3 keys on the keyboard or mouse click. The quick item storage menu should stay on the screen all the time.
- After accessing (using) on quick item, you need to update the amount of the item in both quick item storage and inventory storage. If all of one quick item is used, you should delete that item from the quick item storage, and show empty on that spot. You also need to delete that item from the inventory storage, see the above requirements. 
- [x]You need to have at least 3 different healthcare items that can increase health, such as increase 10, 20, or 30, and 3 different weapon items, such as bullets with colors of red, green, or blue. (5%)
- When accessing/using health items, you should update your health. When accessing/using weapon items, you should be able to shoot different bullets. 
- [x]Create at least 8 waypoints for AI characters and 15 different obstacles on the floor and BAKE the navigation mesh. (5%)
- The floor should be a terrain object that is between 300x300 and 500x500 and must be appropriately painted. 
- [ ]Create at least 2 AI enemies. (20%)
- One of them will be idle when it is more than 10 units from your character. If it is less than 4 units from your character, it will shoot 2 bullets at you. Your health will be decreased if the bullets hit. If your character escapes and the distance between the enemy and the player is greater than 10, the AI enemy will return to its original guard position.
- The other AI enemy will guard along the 5 waypoints when it is more than 10 units from your character. If it is less than 2 units from you it will attack your character by punching, your health will be decreased. If your character escapes, the enemy AI will resume its course.  
- [x]Create at least 1 AI friend. It will always follow your character and help you attack the enemies when the enemies are closer than 5 units from YOUR character. (15%)
- Create a health bar for your AI friend and make the enemies attack your AI friend first. Your AI friend will die when the health is all gone. 
- [ ]Create 2 or more levels for the game. (10%)

If you missed the Demo, you may lose up to 10%
You will lose up to 10% if an incorrect Unity version is used.


# Extra Credit (Maximum 20%, You can do more than 20%, I will choose the best 20% for you.)

- [x]Make a login menu for different players. ONLY use ONE file to store the inventory information for different players, and another ONE file to store the game settings for different players. (10%)
Use a script to create another player in the game at any time. Split the screen by half for two players, and allow the players to set the keyboards or mouse for the game. (10%)
- [x]Published in Google Play. (10%)
- [x]Use at least 2 different video player effects, 1 as a component of the camera, and another as a texture component on a game object.  (5%)


# Submission Instructions

The .zip file you submit should include:

  A Windows executable file (a build with the associated files)
  Your source files (Unity and C#)
  A video of your game demo with explanations of which requirements you have met.
  A readme file to explain how to play your game, and list the requirements you have met.
  *You will lose up to 10% if you miss any of these required components.
