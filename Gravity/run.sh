rm *.dll #removes previous .dll files
rm *.exe #removes previous .exe files

ls -l #views the list of source files

mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -out:gravityUI.dll gravityUI.cs

mcs -r:System -r:System.Windows.Forms -r:gravityUI.dll -out:Gravity.exe gravityMain.cs

ls -l

./Gravity.exe

echo The script has terminated.
