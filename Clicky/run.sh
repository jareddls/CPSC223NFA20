rm *.dll #removes previous .dll files
rm *.exe #removes previous .exe files

ls -l #views the list of source files

mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -out:ClickUI.dll ClickUI.cs

mcs -r:System -r:System.Windows.Forms -r:ClickUI.dll -out:Clicky.exe ClickMAIN.cs

ls -l

./Clicky.exe

echo The script has terminated.
