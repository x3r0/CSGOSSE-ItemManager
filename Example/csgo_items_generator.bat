@echo off
del items_730.bin
for /F "tokens=*" %%A in (csgo_items.txt) do itemsextractor append %%A
rem for /F "eol=; tokens=2,3* delims=," %%A in (csgo_items.txt) do itemsextractor append %%A