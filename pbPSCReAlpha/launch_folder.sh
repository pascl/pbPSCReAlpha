#!/bin/sh

echo 2 > /data/power/disable
echo XXXXXYYYYY > "/media/bleemsync/etc/bleemsync/CFG/selected_folder"
cd "/var/volatile/launchtmp"
echo "launch_StockUI" > "/tmp/launchfilecommand"
echo 0 > /data/power/disable
