# pbPSCReAlpha

A little software to use with *PSC*lassic in order to view, edit and *Re*-sort *Alpha*betically the contents of an USB drive used with bleemsync.

Last version: 0.8

![Preview](https://i.imgur.com/V9GDoso.png)

## Viewer

### View
1. Select your "Games" directory with the textfield or the Browse button.
2. Click on Refresh.
3. Click on a game in the left-hand list (found errors are marked here with a star).
4. Information of the game display on the right-hand of the window. Several errors/warnings can be detected and are visible by icons near the files.

#### Detected errors and/or warnings
* Folder name is not a numeric value.
* GameData folder is missing.
* pcsx.cfg is missing.
* Game.ini is missing.
* Game.ini is incomplete.
* No cue files in the folder.
* No bin files in the folder.
* PNG file is missing.
* Several PNG files are in the folder.
* PNG filename and Discs information in Game.ini mismatch.
* Numbers of Cue files and Discs in Game.ini mismatch.
* Cue filenames and Discs information in Game.ini mismatch.
* Cue content and Bin filenames mismatch.
* For some PAL games, Sbi files are needed and you can be warned for that (if you keep Discs information like SLES-abcde).

### Sort
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
In case it is still locked somewhere, try to rename the locked folder in a windows explorer directly. Sometimes doing this can unlock files. If operation is interrupted, it is not necessary to rename manually folders from 1 to N. Even if there are missing numbers, the sort operation can be done.

**WARNING** bis !! Don't forget, you have to relaunch bleemsync after any modification. A "BleemSync" button is at the bottom of the window to be easier to launch.

### New
1. Create a new directory, with a gameData folder and a pcsx.cfg file.
2. The other files can be added by the different buttons.

### Compress png files
1. **NEW 0.8** Launch pngquant from this button in order to compress all .PNG files in your folders.

## Editor

### Direct edition
Once a game is selected, on the right-hand of the window, you can:
* Edit directly filenames by clicking again on a selected file (or press F2 on keyboard).
* Delete a file by pressing DEL on keyboard.
* Copy files (one or several) directly by drag and drop.
* Edit the picture by drag and drop (with automatic save and compression by pngquant)

**NEW 0.8** Auto-rename buttons can rename files automatically. They rename files according to the "Discs" field in the Game.ini file. Bin, cue, png and sbi files can be renamed automatically. Ask a user confirmation before really doing it.

### Edit Game.ini & Edit Image
![Preview](https://i.imgur.com/1nwPOLg.png)

**NEW 0.8** Game.ini edit window and picture edit window have been merged.

Default folder is the last selected in the main window. You can load/save other files if needed. For the picture box, you can load a png, bmp or jpg file and save to png.

Search at the bottom of the window can fill automatically Title and Discs fields. **NEW 0.8** Then, click on "View page here" to display the webpage of the game. You can now click on one of the blue arrows to fill Game.ini fields and/or picturebox.

For the picture, you can drag and drop a picture file (or directly from a webpage) instead of clicking the load button.

Added pngquant exe to the package. It is launched during the save operation.

### Edit cue file(s)
![Preview](https://i.imgur.com/z48e0XR.png)

Can edit all cue files of a folder in the same window.

**NEW 0.8** The bin filenames are on the left-hand list. Select one item and click on "copy bin filename" to copy the filename to your clipboard. You can also double-click on one item to do it.

One Save button for each file (if several cue files for the game).

**NEW 0.8** Click on the "Auto" button to edit automatically the textbox with the bin filenames (assuming that bin filenames contain cue filenames).
You have to save by clicking the Save button after that. If there are several cue files, you have to click on each button.

### Add pcsx.cfg file
The button appears only if the file is not detected in a folder. The file added is in the executable folder.

### Add files
Browse your folders to add files in the selected folder (multiple selection is possible). You can drag and drop files directly in the filelist instead of clicking here.

Progress bars will appear during copy operation. They will disappear when copy is ok. (don't close the program until it is complete or your files will be corrupted).

![Preview](https://i.imgur.com/DwZubjm.png)

### Refresh folder
Updating information about the current selected game is done automatically after the other operations but can be forced by this button.

### Open folder
Open Windows explorer directly in this folder.

## Debug and Readme Tabs
* The debug tab can display some information. Can be useful if something doesn't work as intended to take a look on this tab.
* The readme tab displays the readme.md file present with the exe file. As there are some pictures linked in this file, you can be prompted by your firewall that the program wants to access to the Internet.

## List of files in release pack
* pbPSCReAlpha.exe
* pcsx.cfg - the file to be copied when you are using the "add pcsx.cfg file" button or the "New" button.
* ps1games.xml - the game list for the search operation
* sbigames.xml - the game list with SBI needed
* Markdig.dll - library used to display MarkDown (and this file)
* Markdig-licence.txt - licence file for Markdig
* README.md - this file needs to be packed for display
* pngquant/COPYRIGHT - file from pngquant pack
* pngquant/pngquant.exe - file from pngquant pack
* pngquant/readme.txt - file from pngquant pack