#### General

### How to use this ?
* Plug an USB drive with BleemSync or AutoBleem directly on your computer.

### How to read a BleemSync or an AutoBleem drive ?
* Set the version of the mod on the top-left corner (click on "Currently use ...") and set games folder on the top-right corner of the first tab.
* Then, click on Refresh.

### After clicking on Refresh, a box appears telling me I have missing game.ini file(s) and asks me to read the database.
* Only BleemSync 1.0.0 doesn't need any Game.ini file in the game folders, and BleemSyncUI doesn't create them. But this tool needs them, and reading the database can generate these files.
* This box can also appear when you have a wrong selected mod version. Don't read the database if the wrong version is selected, files would be created in the wrong folders.

### Is it only for PS1 games ? What file types are possible ?
* YES, only PS1 games are managed. The PS1 games can be cue/bin files or pbp files (except for BleemSync0.4.1).

#### Explorer Tab

### How to add a game in the app ?
* Click on New to create a new folder in the games folder. Select this new line on the left list.
* Click on Add files (or drag and drop files in the white box containing the file list) to add files. You can add any files of any extensions, but some files will be checked to be as expected.

### Can I remove a game ?
* Yes, click on it on the left-side list. Then, press DEL on keyboard. A user confirmation is necessary.
* To bypass the user confirmation, press Shift+DEL instead of DEL only.

### On the right-side, I have infomation from a game when I click it, but what is AlphaTitle ?
* It is a sorting name, used instead of the title if it is not empty.
* For example, for "Final Fantasy IX" as *Title*, you can put "Final Fantasy VIIII" as *AlphaTitle* to insert the game after FFVII and VIII if you sort alphabetically.

### Can I edit information of a game ?
* You can edit filenames by clicking twice on a file (or press F2 on keyboard when selected)
* You can delete a file by pressing DEL
* You can copy/paste files by drag and drop
* You can change the picture by drag and drop.
* Auto-rename buttons can rename files according to the "Discs" field in the Game.ini file. A user confirmation is necessary.
* Use the "Edit Game.ini + picture" button to edit information. You can look for it on Internet.

### [if AutoBleem0.6.0 or BleemSync1.0.0 selected] When I click on Sort, the list order is modified as I want in the app. But it is not visible plugged in my PSC.
* [AutoBleem0.6.0] The EvolutionUI sorts games alphabetically. And the alphatitle information is not used.
* [BleemSync1.0.0] By default, it's alphabetical too. Editing the link_alphabeticalise parameter and writing 0 in bleemsync_cfg.ini will respect your sorting options.

### When can I click on Recreate DataBase ?
* Once you did wished modifications, you have to regenerate the database. Be sure you have selected the right mod version before clicking on it.
* Then, unplug properly your USB drive, and plug it in your PSC.

#### Transformer Tab

### Folder modifications... Why all these buttons ?
* Folder structures are different between each mod, and sometimes between each version of a mod.
* Buttons permit to switch easily folder structure of your games folder (and also your saves folder).

### Databases... Why all these buttons ?
* Usually, you don't need those buttons. You have already been asked to do that on clicking on Refresh if there is a missing Game.ini file.
* It becomes necessary only if your folders (or your current db) are in mess. Read a previously saved db file to regenerate the Game.ini files.

#### Configuration Tab

### What are the parameters for ?
* "Maximum files to be copied simultaneously": you have a queue when you copy files in the app. You can select a number between 1 and 6. Small-sized files bypass the queue and are copied directly.
* "Sorting Options": Alphabetic, Year, Publisher or Players, and ASCending or DEScending are the 4 possible options.
* Modifications have to be validated by clicking on OK.

### What is the Check Bin button for ?
* This can read a bin file to find the serial in its content, and display the gametitle (if known).

### What is the MemCard button for ?
* This can read the memcard files and copy/paste saves between 2 different files.

### [if BleemSync 1.0.0 only] What is the "Copy bleemsync_cfg.ini" button for ?
* Copy the file in the same folder of the executable of the app to the right folder on the USB drive.
* The packaged file was modified to be the nearest to the stock UI. You can edit it to match your preferences.
