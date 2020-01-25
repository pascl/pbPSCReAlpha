#!/bin/sh

echo 2 > /data/power/disable
source "/var/volatile/bleemsync.cfg"
PATH="$PATH:$bleemsync_path/bin"
mkdir -p "/tmp/ra_cache"
chmod +x /media/bleemsync/opt/retroarch/retroarch
HOME=/media/bleemsync/opt/retroarch /media/bleemsync/opt/retroarch/retroarch --config "/media/bleemsync/opt/retroarch/config/retroarch/retroarch.cfg" -L"/media/bleemsync/opt/retroarch/config/retroarch/cores/XXXXXYYYYY" "/var/volatile/launchtmp/YYYYYXXXXX" -v &> "/media/logs/retroarch.log"
rm -rf "tmp/ra_cache"
echo 0 > /data/power/disable
