# pbPSCReAlpha

A little software to view the contents and sort the directories on an USB drive used with bleemsync.

Last version: 0.41

![Preview](https://i.imgur.com/pvrsqh9.png)

## Tab 1 - Explorer

### Viewer
1. Select your "Games" directory with the textfield or the Browse button.
2. Click on Refresh.
3. Click on a game in the left-hand list (found errors are marked with a star).
4. Information of the game display on the right-hand of the window.

### Sorter
1. Select your "Games" directory with the textfield or the Browse button.
2. Click on Sort (click first on Refresh if disabled).
3. Games will now be sorted alphabetically.

During the process, the directories are renamed with (number+1000), then renamed from 1 to your max.

For some convenience, a facultative parameter **AlphaTitle** can be added into Game.ini files to be sorted instead of the *Title*.
For example:
* for "The Legend Of Dragoon" as *Title*, you can put only "Legend Of Dragoon" as *AlphaTitle* to insert it in L games and not T games.
* for "Final Fantasy IX" as *Title*, you can put "Final Fantasy VIIII" as *AlphaTitle* to insert the game after FFVII and VIII.

**WARNING** !! To be ok until the end, don't open any files from the usb key before or during the process.
Eject the usb key before reconnecting it (without opening anything) and launch the software.

**WARNING** bis !! Don't forget, you have to relaunch bleemsync after any modification.

## Tab 2 - Game.ini Generator

### Load a ini
* Click on Load and choose a file. The fields will print the content of the file.

### Save a ini
* You can edit fields then save parameters in a file.
* The arrow button at the right of the *AlphaTitle* field will copy the *Title* field in AlphaTitle.

### Pre-fill

* The fields at the bottom of the window can search games
* When you execute a search, all found games are printed in a list below.
* Select one by clicking and the 2 first fields (Title and Discs) will be updated.
* The other information are left untouched.

**WARNING** ter !! Don't forget, you have to relaunch bleemsync after any modification.
