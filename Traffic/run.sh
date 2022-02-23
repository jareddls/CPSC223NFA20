#Author: Jared De Los Santos
#Class: CPSC 223N
#Semester: Fall 2020
#Assignment: 2
#Due: October 14, 2020.

#This is a bash shell script to be used for compiling, linking, and executing the C sharp files of this assignment.
#Execute this file by navigating the terminal window to the folder where this file resides, and then enter the command: sh run.sh

rm *.dll #removes previous .dll files
rm *.exe #removes previous .exe files

ls -l #views the list of source files

mcs -target:library -r:System.Drawing.dll -out:TrafficLogic.dll TrafficLogic.cs

mcs -target:library -r:System.Windows.Forms.dll -r:System.Drawing.dll -r:TrafficLogic.dll -out:TrafficInterface.dll TrafficInterface.cs

mcs -r:System.Windows.Forms -r:System.Drawing.dll -r:TrafficInterface.dll -out:TrafficLight.exe TrafficMain.cs

ls -l

./TrafficLight.exe

echo The script has terminated.
