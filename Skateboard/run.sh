#Author: Jared De Los Santos
#Class: CPSC 223N
#Semester: Fall 2020
#Assignment: 3
#Due: October 19, 2020.

#This is a bash shell script to be used for compiling, linking, and executing the C sharp files of this assignment.
#Execute this file by navigating the terminal window to the folder where this file resides, and then enter the command: sh run.sh

rm *.dll #removes previous .dll files
rm *.exe #removes previous .exe files

ls -l #views the list of source files

mcs -target:library -r:System.Drawing.dll -r:System.Windows.Forms.dll -out:skateboardInterface.dll skateboardInterface.cs

mcs -r:System -r:System.Windows.Forms -r:skateboardInterface.dll -out:Skateboard.exe skateboardMain.cs

ls -l

./Skateboard.exe

echo The script has terminated.
