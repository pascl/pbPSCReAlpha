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
* YES, only PS1 games are managed. The PS1 games can be cue/bin files, pbp or chd files (except for BleemSync0.4.1).

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
* Use the "Edit Game.ini + picture" button to edit information. You will be able to look for it on Internet directly.

### [if AutoBleem0.6.0 or BleemSync1.0.0 selected] When I click on Sort, the list order is modified as I want in the app. But it is not visible plugged in my PSC.
* [AutoBleem0.6.0] The EvolutionUI sorts games alphabetically. And the alphatitle information is not used.
* [BleemSync1.0.0] By default, it's alphabetical too. Editing the link_alphabeticalise parameter and writing 0 in bleemsync_cfg.ini will respect your sorting options.

### When can I click on Recreate DataBase ?
* Once you did wished modifications, you have to regenerate the database. Be sure you have selected the right mod version before clicking on it.
* Then, unplug properly your USB drive, and plug it in your PSC.

### How can I replace internal games ?
* pbPscReAlpha can manage a folder on your USB drive in order to replace games on your PSC.
* Go to https://github.com/pascl/BleemSync_Mods and download the backupgames_launch, editgames_launch and restorebackup_launch launchers.
* Copy the backupgames_launch launcher on your USB drive. Plug your drive on your PSC, then launch that. You need about 14 GB to backup everything.
* After about 15 minutes (may be until 45 if your drive is a low speed one), the backup is done (present in "games_backup" folder).
* Go back to pbPSCReAlpha with your drive, and a "Goto internal" button would be visible in the top right corner.
* Click on it, and the font color will be red. A folder is set to contain games on your drive ("replaced_games" folder). [Just click again when you want to go back to your "normal" folder and font color will be black again]
* Add games as you wish (limited to 25 games, and limited by available internal size). Then, click on "Recreate DB".
* Copy now the editgames_launch launcher on your USB drive. Plug your drive on your PSC, then launch that. You need to wait some minutes. The first time you go over 20 games, pictures for games greater than 20 can be invisible, and these games won't start. Restart your PSC and these would be ok.
* You can go back to the original games by launching the "restorebackup_launch" launcher on the PSC.
* If you don't want to do a miss-click, you can delete the 3 launchers after that.
* If you don't want the "Goto internal" button appear in pbPSCReAlpha, delete the 4 log files at the root of your usb drive.
* To save space on your drive, you can backup the "games_backup" and "replaced_games" folders on your computer, then remove them from your USB drive.

#### Game.ini editor

### Is there an automated scraper ?
* Not automatic.

### Is there an easy way to add information in Game.ini ?
* Yes.
* Write the title you want in the Search field, then press ENTER (or click on Search).
* In the listbox below, you will find the different matching games. Double-click on one (or select one and click on View page here) to display the matching page on psxdatacenter.com on the right-side.
* Warning! Selecting a game in this list can change the two first fields in this window.
* Once loaded, the blue arrows in the middle of the screen can copy information from the webpage to the fields for the fist one, the second one copies the boxart.
* The curved arrows can go back to the saved information.
* The crossed arrows on the left-side of the fields can swap publisher and developer field contents.
* The Alphatitle, if not empty, is used instead of the title for alphabetical sorting. Clicking on the arrow next to this field copies the title field.
* Click on "Save" (if the file already exists) or "Save as" to save modifications.

#### Transformer Tab

### Folder modifications... Why all these buttons ?
* Folder structures are different between each mod, and sometimes between each version of a mod.
* Buttons permit to switch easily folder structure of your games folder (and also your saves folder).

### Databases... Why all these buttons ?
* Usually, you don't need those buttons. You have already been asked to do that on clicking on Refresh if there is a missing Game.ini file.
* It becomes necessary only if your folders (or your current db) are in mess. Read a previously saved db file to regenerate the Game.ini files.

### Before converting something...
* It is recommended to do a save of your USB key before any action.
* It is recommended to have already used AutoBleem and/or BleemSync. They create some folders at first start, that this tool doesn't create and assumes they exist. So, when you convert, don't copy from the release pack, but from another usb drive already used.

### I have an AutoBleem0.6 USB key, how can I convert for BleemSync1.0 ?
* First, be sure you don't have any detected errors by the app.
* Go in you explorer and remove all folders in your drive except games. And copy-paste folders from a BleemSync drive.
* Go to Transformer Tab, and click on "AB0.6.0 to BS1.0.0 folders".
* Go back to Explorer Tab, select BleemSync1.0.0 in the top-left corner.
* Click on Sort: all folders will be renamed from 1 to X.
* Click on Recreate Database et unplug your drive.

### I have a BleemSync1.0 USB key, how can I convert for AutoBleem0.6 ?
* First, be sure you don't have any detected errors by the app. If you have some missing Game.ini files, you can try reading the database clicking on the "Read a BS1.0 database" button.
* Go in you explorer and remove all folders in your drive except games. And copy-paste folders from an AutoBleem drive.
* Go to Transformer Tab, and click on "BS1.0.0 to AB0.6.0 folders".
* Go back to Explorer Tab, select AutoBleem0.6.0 in the top-left corner.
* Click on Sort: all folders will be renamed from 21 to X.
* Click on Recreate Database et unplug your drive.

### Savegames are also converted ?
* The save folders are moved at the default place for each mod.
* Savestate files are edited to be used with the two mods.
* BleemSync has only one savestate slot while AutoBleem has 4 ones. From BleemSync to AutoBleem, the BS savestate becomes the first AB savestate. From AutoBleem to BleemSync, the first existaing savestate becomes the BS savestate.

#### Configuration Tab

### What are the parameters for ?
* "Maximum files to be copied simultaneously": you have a queue when you copy files in the app. You can select a number between 1 and 6. Small-sized files bypass the queue and are copied directly.
* "Sorting Options": Alphabetic, Year, Publisher or Players are the 4 possible options, selecting ASCending or DEScending for each.
* Modifications have to be validated by clicking on OK.

### What is the Check Bin button for ?
* This can read a bin file to find the serial in its content, and display the gametitle (if known).

### What is the MemCard button for ?
* This can read the memcard files and copy/paste saves between 2 different files.

### [if BleemSync 1.0.0 only] What is the "Copy bleemsync_cfg.ini" button for ?
* Copy the file in the same folder of the executable of the app to the right folder on the USB drive.
* The packaged file was modified to be the nearest to the stock UI. You can edit it to match your preferences.
