# pbPSCReAlpha

A little software to use with *PSC*lassic in order to view, edit and *Re*-sort *Alpha*betically the contents of an USB drive used with bleemsync or autobleem. Plug your USB drive on your computer to add/edit/delete games with this app.

Download Link: https://github.com/pascl/pbPSCReAlpha/releases

Last version: 1.6

![Preview](https://i.imgur.com/o2wNqJl.png)

**NEW 1.4**
* CHD files are managed.
* With some launchers, you can replace internal games

**NEW 1.5**
* BleemSync1.2 is managed (reset your folders in this version)

**NEW 1.6**
* Folders and non-PS1 games are managed with BleemSync1.2
* Folders were previously possible by modding some files in BleemSync1.1. With BleemSync1.2, there is not any file modifications to do.


## General

An USB drive configured by Bleemsync (example of 1.2 version) contains several folders:
* bleemsync
* d8781dae-c45c-4fc1-b961-e03eedebbffb
* games
* logs
* transfer

In the games folder, some numeroted folders (one per game) containing:
* png file (only one)
* cue file(s) (one per disc if several)
* bin file(s) (at least one per disc but can be more)
* instead of bin & cue files, pbp or chd file(s) (one per disc if several)
* sbi file(s) necessary fo some PAL games
* game.ini file or not, depending on the bleemsync version (or if you have already run this app).
* **NEW 1.6** for non-PS1 games, launch.sh file

For BleemSync1.0.0/1.1.0/1.2.0 users : This app needs a Game.ini file for each game. These files were necessary in the older versions of bleemsync but not present anymore since 1.0 version. This software can create these files by reading the database file on the usb drive (after a click on Refresh or in the Tranformer tab).

After modifications in the app, you have to click on Recreate database to have these modifications available on the PSC.


## Viewer

### View
1. Select your "Games" directory with the textfield or the Browse button.
2. In the top-left corner, select the used mod by clicking on "Currently use ...". You can choose BleemSync0.4.1, BleemSync1.0.0/1.1.0 or AutoBleem0.6.0.
3. Or click on Refresh.
4. If a game.ini is missing in a folder, ask user to read database and create these files (if possible).
5. Click on a game in the left-hand list (found errors are marked here with a star).
6. Information of the game display on the right-hand of the window. Several errors/warnings can be detected and are visible by icons near the files.

#### Detected errors and/or warnings
* Folder name is not a numeric value.
* GameData folder is missing.
* pcsx.cfg is missing. (Only a warning if a BleemSync1.0.0/1.1.0 drive is used)
* Game.ini is missing.
* Game.ini is incomplete.
* No cue (or pbp or chd) files in the folder.
* No bin files in the folder.
* PNG file is missing.
* Several PNG files are in the folder.
* PNG filename and Discs information in Game.ini mismatch.
* Numbers of Cue (or pbp or chd) files and Discs in Game.ini mismatch.
* Cue (or pbp or chd) filenames and Discs information in Game.ini mismatch.
* Cue content and Bin filenames mismatch.
* For some PAL games, Sbi files are needed and you can be warned for that (if you keep Discs information like SLES-abcde).
* Comma in filenames are forbidden. Several special characters are also forbidden.
* Detection of a 'p', 'u' or 'e' in the 3rd position which can start a wrong bios in the PSC (only a warning, maybe you did it intentionnaly).

An error is symbolized by a '*' before the folder number and the title in the left-side list. A warning is symbolized by a '!' before the folder number and the title in the left-side list.
An error will prevent you from sorting, not the warnings.

**NEW 1.6** If a launch.sh is detected in the folder, some errors are bypassed.

For now, you can add all files you want, but only cue, bin, pbp, chd, png, game.ini and pcsx.cfg are managed by the app. The content of pbp, chd or bin files are not read by the app, the app only checks filenames.

PBP files are for PS1 games only and not for BleemSync0.4.1.

### Sort
1. Select your "Games" directory with the textfield or the Browse button.
2. Click on Sort (click first on Refresh if disabled).
3. Games will now be sorted alphabetically.

During the process, the directories are renamed temporarily, then renamed from 1 to your gamecount, (or 31 to your gamecount+30 whith AutoBleem0.6.0).

For some convenience, a facultative parameter **AlphaTitle** can be added into Game.ini files to be sorted instead of the *Title*.
For example:
* for "The Legend Of Dragoon" as *Title*, you can put only "Legend Of Dragoon" as *AlphaTitle* to insert it in L games and not T games.
* for "Final Fantasy IX" as *Title*, you can put "Final Fantasy VIIII" as *AlphaTitle* to insert the game after FFVII and VIII.

**WARNING** !! To be ok until the end, don't open any files from the usb key before or during the process.
Eject the usb key before reconnecting it (without opening anything) and launch the software.
In case it is still locked somewhere, try to rename the locked folder in an explorer window directly. Sometimes doing this can unlock files. If operation is interrupted, it is not necessary to rename manually folders, the sort operation can be done again.

**WARNING** bis !! Don't forget, you have to recreate database before disconnecting your drive and play.

### New
1. Create a new directory, with structure and content depending on the used mod version.
2. The other files can be added by the different buttons.

### Compress png files
* Launch pngquant from this button in order to compress all .PNG files in your folders. Resize the files in 226*226 in the same time.

### Recreate database
* **NEW 1.3** A refresh is now done by clicking on this button. You can't regenerate database if errors are detected.
* **NEW 1.3** You have now 2 options to re-generate the database:
   * click on the button as in the previous versions. You will be warned if all is ok or not after a few seconds.
     * **NEW 1.6** if you have selected BleemSync1.2, the folder manager will appear before recreating the database. You can now create folders on the left-side, select one, then choose games in the "all games list" and click the double-arrow to have them in the folder.
![Preview](https://i.imgur.com/7ocRrKV.png)
	 
   * * [**NEW 1.6** deprecated with BleemSync1.2] if you have a drive with a **modded BleemSync1.1**] with the **Shift key** pressed, click on the button to go to the advanced options.
     * You can choose different options to generate several DB files in order to be used in different folders.
	 * An empty DB file is generated too, if you don't want any ps1 games in a folder.
     * Going to this advanced form if you have another version, or a not-modified BleemSync 1.1 version, only the first option will do something useful for you.
	 
	 ![Preview](https://i.imgur.com/9CJbYA8.png)

PS: For the modded BleemSync1.1, go to https://github.com/pascl/BleemSync_Mods/tree/BleemSync1.1
   
## Editor

### Direct edition
Once a game is selected, on the right-hand of the window, you can:
* Edit directly filenames by clicking again on a selected file (or press F2 on keyboard).
* Delete a file by pressing DEL on keyboard.
* Copy files (one or several) directly by drag and drop.
* Edit the picture by drag and drop (with automatic save and compression by pngquant). **NEW 1.6** Drag and drop with Shift clicked to keep aspect ratio.

In the left-side list, you can delete an entire folder with DEL key on keyboard (confirmtion needed) or Shif+DEL (no confirmation).

Auto-rename buttons can rename files automatically. They rename files according to the "Discs" field in the Game.ini file. Bin, cue, pbp, chd, png and sbi files can be renamed automatically. Ask a user confirmation before really doing it.

### Edit Game.ini & Edit Image
![Preview](https://i.imgur.com/U9RsnCW.png)

Game.ini edit window and picture edit window have been merged.

Default folder is the last selected in the main window. You can load/save other files if needed. For the picture box, you can load a png, bmp or jpg file and save to png.

Search at the bottom of the window can fill automatically Title and Discs fields. Then, click on "View page here" to display the webpage of the game. You can now click on one of the blue arrows to fill Game.ini fields and/or picturebox (**NEW 1.6** for the picturebox, click on the green arrow to keep aspect ratio). **NEW 1.6** Search can now be done on 2 websites.

For the picture, you can drag and drop a picture file (or directly from a webpage) instead of clicking the load button (**NEW 1.6** With Shift clicked during the drag and drop, you will keep the aspect ratio).

Added pngquant exe to the package. It is launched during the save operation.

You can exit this window by pressing ESC on keyboard.

This window can directly be opened by adding parameter "-e" in a shortcut.

### Edit cue file(s)
![Preview](https://i.imgur.com/z48e0XR.png)

Can edit all cue files of a folder in the same window.

The bin filenames are on the left-hand list. Select one item and click on "copy bin filename" to copy the filename to your clipboard. You can also double-click on one item to do it.

One Save button for each file (if several cue files for the game).

Click on the "Auto" button to edit automatically the textbox with the bin filenames (assuming that bin filenames contain cue filenames).
You have to save by clicking the Save button after that. If there are several cue files, you have to click on each button.

You can exit this window by pressing ESC on keyboard.

### Add pcsx.cfg file
The button appears only if the file is not detected in a folder. The file added is in the executable folder.

This file becomes not necessary when you use BlemSync1.0.0. So the button will not appear anymore.

### Add launch.sh file **NEW 1.6**
![Preview](https://i.imgur.com/WSk8DUZ.png)
The button permits to add and/or edit a launch.sh file.

You can write directly to edit the file content. On the left-side, you have the list of the files which are present in the folder. You can select one and click on copy filename (or double-click in the list) to have it in the clipboard.

The Reload button permits to have the content as it was at the window creation.

The Template button permits to have helps to write the content. The new form allows you to use the launch*.sh files in the same folder of the executable and fills them (click on arrows). Use the Complete button to export the content of this from in the previous one.
![Preview](https://i.imgur.com/PUdfZq9.png)

The Save button saves the file (don't forget to use it).

You can exit this window by pressing ESC on keyboard.

### Generate m3u file
The button appears only for multidisc games. Creating a m3u file is not necessary if you use only the stock emulator. It is recommended if you use retroarch with a psx core.

### Add files
Browse your folders to add files in the selected folder (multiple selection is possible). You can drag and drop files directly in the filelist instead of clicking here.

Progress bars will appear during copy operation. They will disappear when copy is ok. (don't close the program until it is complete or your files will be corrupted).

Number of simultaneous files are user-defined in the configuration tab, others will be in queue. Files lesser than 500kb are directly copied, without going to this queue.

![Preview](https://i.imgur.com/DwZubjm.png)

### Refresh folder
Updating information about the current selected game is done automatically after the other operations but can be forced by this button.

If a game.ini is missing in a folder, ask user to read database and create these files (if possible).

### Open folder
Open Windows explorer directly in this folder.


## Tranformer Tab
![Preview](https://i.imgur.com/9yd7e2t.png)
1. The folder structures are different between BleemSync0.4.1, BleemSync1.0.0/1.1.0 and AutoBleem0.6.0.
2. You can read the database files regional.db. If you want to read a database in the same version you are using, the default directory is supposed to be the right one.
3. If you are using BleemSync1.0/1.1 and BleemSyncUI, you need to read the BS1.0.0/1.1.0 database to (re-)create Game.ini files. If a Game.ini is present and different, the next window will appear to choose a file or merge data.
![Preview](https://i.imgur.com/ZpjKCoL.png)

## Configuration Tab
![Preview](https://i.imgur.com/s2TiEMC.png)
* You can select the maximal simultaneous files to be copied. Files lesser than 500kB are not concerned by this limit. If more files than selected are currently copied, the new limit will be applied at the end of the current files.
* You can select the sorting options used during sorting operation (Sort button in Explorer tab).

### Copy bleemsync_cfg.INI file
A file is included with the executable. This button will copy this file to your drive (path in the first tab) if you are currently using BS1.0.0.

### Check bin
![Preview](https://i.imgur.com/vWicRIu.png)
1. Browse a bin file (or write the filename or drag and drop a file in the textbox), then click "Find serial" to read the file looking for a serial.
2. If found, the gametitle will be displayed too.

You can exit this window by pressing ESC on keyboard.

This window can directly be opened by adding parameter "-b" in a shortcut.

### MemCard
![Preview](https://i.imgur.com/PQ29nYy.png)
1. Browse or use the combobox to choose a file on your drive. You have to check the button at the beginning of the line first.
2. Click on one of the Open buttons to open the file on the left or right side.
3. Select a slot in one of the opened memcards and click on one of the arrows to copy a slot from left to right or right to left.
4. Don't forget to click on Save before opening another memory card file.

You can exit this window by pressing ESC on keyboard.

This window can directly be opened by adding parameter "-m" in a shortcut (in this case the combobox will be empty).

## Debug, Readme and FAQ Tabs
* The debug tab can display some information. Can be useful if something doesn't work as intended to take a look on this tab.
* The readme tab displays the readme.md file present with the exe file. As there are some pictures linked in this file, you can be prompted by your firewall that the program wants to access to the Internet.
* The FAQ tab displays the FAQ.md file present with the exe file.


## List of files in release pack
* pbPSCReAlpha.exe
* pcsx.cfg - the file to be copied when you are using the "add pcsx.cfg file" button or the "New" button.
* ps1games.xml - the game list for PSXdatacenter research
* sbigames.xml - the game list with SBI needed
* Markdig.dll - library used to display MarkDown (and this file)
* Markdig-licence.txt - licence file for Markdig
* README.md - this file needs to be packed for display
* pngquant/COPYRIGHT - file from pngquant pack
* pngquant/pngquant.exe - file from pngquant pack
* pngquant/readme.txt - file from pngquant pack
* x64/SQLite.Interop.dll 
* x86/SQLite.Interop.dll
* EntityFramework.dll
* EntityFramework.SqlServer.dll
* System.Data.SQLite.dll
* System.Data.SQLite.EF6.dll
* System.Data.SQLite.Linq.dll
* bleemsync_cfg.INI
* FAQ.md - some FAQ
* launch_drastic.sh - **NEW 1.6** for launch.sh template form
* launch_folder.sh - **NEW 1.6** for launch.sh template form
* launch_retroarch.sh - **NEW 1.6** for launch.sh template form
* tgdbgames.xml - **NEW 1.6** the game list for TGDB research
* tgdbplatforms.xml - **NEW 1.6** the game platforms for TGDB research
