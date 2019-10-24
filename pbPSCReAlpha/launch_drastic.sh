#!/bin/sh

echo 2 > /data/power/disable
chmod +x "/media/bleemsync/etc/bleemsync/SUP/launchers/psc_drastic/drastic"
echo "launch_StockUI" > "/tmp/launchfilecommand"
LD_PRELOAD=/media/bleemsync/etc/bleemsync/SUP/launchers/psc_drastic/drastic_sdl_remap.so /media/bleemsync/etc/bleemsync/SUP/launchers/psc_drastic/drastic "/var/volatile/launchtmp/XXXXXYYYYY" > /media/logs/drastic.log 2>&1
echo 0 > /data/power/disable
