//***************************************************************************************************************************************
// Program name: "Skateboard" This program simulates a "skateboarder" going down a hill, and we can stop the                            *
// skateboarder from moving and continue from his last position.                                                                        *
// Copyright (C) 2020  Jared De Los Santos                                                                                              *
//                                                                                                                                      *
// This file is part of the software program "Skateboard".                                                                              *
// "Skateboard" is free software: you can redistribute it and/or modify it under the terms of the GNU General Public                    *
// License version 3 as published by the Free Software Foundation.                                                                      *
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied                   *
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.               *
// A copy of the GNU General Public License v3 has been distributed with this software.  If not found it is available here:             *
// <https://www.gnu.org/licenses/>.   The copyright holder may be contacted here: jayred_dls@csu.fullerton.edu                          *
//***************************************************************************************************************************************


//Author: Jared De Los Santos
//Author's email: jayred_dls@csu.fullerton.edu
//Course: CPSC223N-02
//Assignment number: 3
//Title: Skateboard
//Date last updated: 10/18/2020
//Source files in this program: skateboardInterface.cs, skateboardMain.cs
//Purpose of this entire program: This demonstrates a "skateboarder" (in this case, a ball) going down a "hill" (in this
//case, a triangle), and at any point we can stop the skateboarder and resume from the point we stopped them.
//This program includes 2 source files and a bash file to run the program.
//
//Name of this file: skateboardMain.cs
//Purpose of this file: Activates the program to show our user interface.


using System;
using System.Windows.Forms;            //Needed for "Application" near the end of the main function.
public class Skateboard {
  public static void Main() {
      System.Console.WriteLine("The Skateboard program has begun.");
      skateboardInterface roll = new skateboardInterface();
      Application.Run(roll);
      System.Console.WriteLine("The Skateboard program has ended. Bye.");
   } //End of Main function
} //End of Skateboard class
