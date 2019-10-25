#!/bin/sh

echo 2 > /data/power/disable
cd "/media/bleemsync/etc/bleemsync/SUP/launchers/psc_drastic"
chmod +x "drastic"
echo "launch_StockUI" > "/tmp/launchfilecommand"
LD_PRELOAD=./drastic_sdl_remap.so ./drastic "/var/volatile/launchtmp/XXXXXYYYYY" > /media/logs/drastic.log 2>&1
echo 0 > /data/power/disable
