//***************************************************************************************************************************************
// Program name: "Traffic Light" This program simulates a traffic light, and we can change the speeds                                   *
// from slow or fast, depending on which we wanted to simulate.                                                                         *
// Copyright (C) 2020  Jared De Los Santos                                                                                              *
//                                                                                                                                      *
// This file is part of the software program "Traffic Lights".                                                                          *
// "Traffic Light" is free software: you can redistribute it and/or modify it under the terms of the GNU General Public                 *
// License version 3 as published by the Free Software Foundation.                                                                      *
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied                   *
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.               *
// A copy of the GNU General Public License v3 has been distributed with this software.  If not found it is available here:             *
// <https://www.gnu.org/licenses/>.   The copyright holder may be contacted here: jayred_dls@csu.fullerton.edu                          *
//***************************************************************************************************************************************


//Author: Jared De Los Santos
//Author's email: jayred_dls@csu.fullerton.edu
//Course: CPSC223N-02
//Assignment number: 2
//Title: Traffic Light
//Date last updated: 10/13/2020
//Source files in this program: TrafficInterface.cs, TrafficLogic.cs, TrafficMain.cs
//Purpose of this entire program: This demonstrates a simulation of a traffic light.  The program contains exactly one traffic light.
//The interval between tics changes depending on the "fast" or "slow" setting you choose while the program is executing.
//This program includes 3 source files.
//
//Name of this file: TrafficMain.cs
//Purpose of this file: Provide "computational" functions needed by the user interface class.
//
//
//Linux: The source files in this program should be compiled in the order specified below in order to satisfy dependencies.
//  1. TrafficLogic.cs       compiles into library file TrafficLogic.dll
//  1. TrafficInterface.cs   compiles into library file TrafficInterface.dll
//  2. TrafficMain.cs        compiles and links with the dll file above to create TrafficMain.exe

using System;
using System.Windows.Forms; //needed for "Application.Run" on the second to last line of main.

public class TrafficLight {
    public static void Main() {
      System.Console.WriteLine("The traffic light program will begin now.");
      TrafficInterface TrafficApp = new TrafficInterface();
      Application.Run(TrafficApp);
      System.Console.WriteLine("The traffic light program has ended. Bye.");
   }//end of main function
}//end of TrafficMain class
