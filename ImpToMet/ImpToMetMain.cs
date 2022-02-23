//***************************************************************************************************************************************
// Program name: "Imperial to Metric Converter" This program converts inches to meters,                                                 *
// but only accepts positive numbers because negative units does not exist.                                                             *
// Copyright (C) 2020  Jared De Los Santos                                                                                              *
//                                                                                                                                      *
// This file is part of the software program "Imperial to Metric Converter".                                                            *
// "Imperial to Metric Converter" is free software: you can redistribute it and/or modify it under the terms of the GNU General Public  *
// License version 3 as published by the Free Software Foundation.                                                                      *
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied                   *
// warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more details.               *
// A copy of the GNU General Public License v3 has been distributed with this software.  If not found it is available here:             *
// <https://www.gnu.org/licenses/>.   The copyright holder may be contacted here: jayred_dls@csu.fullerton.edu                          *
//***************************************************************************************************************************************

// Author: Jared De Los Santos
// Mail: jayred_dls@csu.fullerton.edu
//
// Program name: Imperial to Metric Converter
// Programming language: C Sharp
// Course ID: CPSC 223N-01
// Date development of program began: 08/30/2020
// Date of last update: 09/28/2020

// Purpose: This program will compute an Imperial number (in inches) and convert it to metric units.
//
// Files in project: ImpToMetMain.cs, ImpToMetLogic.cs, ImpToMetInterface.cs, build.sh
//
// This file's name: ImpToMetMain.cs
// File's purpose: This will activate the user interfaces

using System;
using System.Windows.Forms; //needed for "Application" on the second to last line of main.

public class ImpToMet{
    static void Main(String[] args){
      System.Console.WriteLine("Welcome to the Main method of the  Imperial to Metric Converter program.");
      ImpToMetInterface ImpApp = new ImpToMetInterface();
      Application.Run(ImpApp);
      System.Console.WriteLine("Main method will now shutdown");
    } //end of main

}//end of ImpToMetMain
