# pbPSCReAlpha

A little software to view the contents and sort the directories on an USB drive used with bleemsync.

Last version: 0.5

![Preview](https://i.imgur.com/ZRmWp63.png)

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

During the process, the directories are renamed with (number+3000), then renamed from 1 to your max.

For some convenience, a facultative parameter **AlphaTitle** can be added into Game.ini files to be sorted instead of the *Title*.
For example:
* for "The Legend Of Dragoon" as *Title*, you can put only "Legend Of Dragoon" as *AlphaTitle* to insert it in L games and not T games.
* for "Final Fantasy IX" as *Title*, you can put "Final Fantasy VIIII" as *AlphaTitle* to insert the game after FFVII and VIII.

**WARNING** !! To be ok until the end, don't open any files from the usb key before or during the process.
Eject the usb key before reconnecting it (without opening anything) and launch the software.
In case it is still locked somewhere, try to rename the locked folder in a windows explorer directly. Sometimes doing this can unlock files.

**WARNING** bis !! Don't forget, you have to relaunch bleemsync after any modification. A "BleemSync" button was added in the window to be easier to launch.

### New
1. Create a new directory, with a gameData folder and a pcsx.cfg file. The game.ini and picture files can be added by the buttons "Edit Game.ini" and "Edit Image".

### Edit Game.ini
![Preview](https://i.imgur.com/S9ZlsvP.png)
Search at the bottom can fill Title and Discs fields. You can load/save files.

### Edit Image
![Preview](https://i.imgur.com/QIC1BVA.png)
Load a png, bmp or jpg file and save to png.
Added pngqwant exe to the package. It is launched during the save operation. Can be launched on all folders by the "Compress..." button.

### Edit cue file(s)
![Preview](https://i.imgur.com/hEp7sSC.png)
Rather a viewer for now (read-only). Available in a future version.

### Add pcsx.cfg file
The button appears only if the file is not detected in a folder. Copy the file which is in the exe path to the GameData path of the selected game.