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

// Purpose: This program will convert an Imperial number (in inches) and convert it to metric units.
//
// Files in project: ImpToMetMain.cs, ImpToMetLogic.cs, ImpToMetInterface.cs, build.sh
//
// This file's name: ImpToMetInterface.cs
// File's purpose: Enter a non-negative unit in inches in the input field, then click on the convert
// button, and the result will end up being a conversion to the metric system.
//
// Example:
// Input ImpToMetConversion
//  0           0
//  12          0.3048
//  36          0.9144

using System;
using System.Drawing;
using System.Windows.Forms;

public class ImpToMetInterface: Form{
  private Label welcome = new Label();
  private Label author = new Label();
  private Label sequenceMessage = new Label();
  private Label outputInfo = new Label();
  private Label eightBallInfo = new Label();

  private TextBox sequenceInputArea = new TextBox();

  private Button convertButton = new Button();
  private Button clearButton = new Button();
  private Button exitButton = new Button();
  private Button eightButton = new Button();

  private Panel headerPanel = new Panel();
  private Panel displayPanel = new Panel();
  private Panel controlPanel = new Panel();
  private Panel controlPanel2 = new Panel();
  private Panel controlPanel3 = new Panel();

  private Size maxInterfaceSize = new Size(960,720);
  private Size minInterfaceSize = new Size(960,720);

  public ImpToMetInterface(){ //constructor
    MaximumSize = maxInterfaceSize; //setting size of the UI box
    MinimumSize = minInterfaceSize;

    //initialize text strings
    Text = "Imperial To Metric Converter";
    welcome.Text = "Imperial to Metric Converter";
    author.Text = "Author: Jared De Los Santos";
    sequenceMessage.Text = "Enter value below in inches:";
    sequenceInputArea.Text = "Enter value here";
    outputInfo.Text = "Results will show here.";
    convertButton.Text = "Convert";
    clearButton.Text = "Clear";
    exitButton.Text = "Exit";
    eightButton.Text = "8ball";
    eightBallInfo.Text = "Ask me a yes/no question!";

    //set the sizes of the strings above
    Size = new Size(960,720); //ASK PROFESSOR WHAT THIS DOES; he doesn't know either
    welcome.Size = new Size(760,50);
    author.Size = new Size(960,34); // (x,y) x ->, y ^
    sequenceMessage.Size = new Size(720,80);
    sequenceInputArea.Size = new Size(200,30);
    outputInfo.Size = new Size(500,120);   //This label has a large height to accommodate 2 lines output text.
    convertButton.Size = new Size(120,60);
    clearButton.Size = new Size(120,60);
    exitButton.Size = new Size(120,60);
    headerPanel.Size = new Size(720,240);
    displayPanel.Size = new Size(720,500);
    controlPanel.Size = new Size(240,240);
    controlPanel2.Size = new Size(240,240);
    controlPanel3.Size = new Size(240,240);
    eightButton.Size = new Size(120,60);
    eightBallInfo.Size = new Size(500,40);


    headerPanel.BackColor = Color.Silver;
    displayPanel.BackColor = Color.MistyRose;
    controlPanel.BackColor = Color.Lavender;
    controlPanel2.BackColor = Color.LightPink;
    controlPanel3.BackColor = Color.LightBlue;
    convertButton.BackColor = Color.Gold;
    clearButton.BackColor = Color.LightGreen;
    exitButton.BackColor = Color.IndianRed;
    eightButton.BackColor = Color.Purple;

    //set fonts
    welcome.Font = new Font("Times New Roman",33,FontStyle.Bold); //does the user have to have this font installed?
    author.Font = new Font("Times New Roman",26,FontStyle.Regular);
    sequenceMessage.Font = new Font("Arial",26,FontStyle.Underline);
    sequenceInputArea.Font = new Font("Arial",19,FontStyle.Italic);
    outputInfo.Font = new Font("Arial",26,FontStyle.Regular);
    convertButton.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    clearButton.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    exitButton.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    eightButton.Font = new Font("Liberation Serif",15,FontStyle.Regular);
    eightBallInfo.Font = new Font("Arial",20,FontStyle.Bold);

    //set locations
    headerPanel.Location = new Point(240,0);
    welcome.Location = new Point(80,50);
    author.Location = new Point(125,125);
    sequenceMessage.Location = new Point(150,60);
    sequenceInputArea.Location = new Point(250,150);
    outputInfo.Location = new Point(25,250);
    convertButton.Location = new Point(65,85);
    clearButton.Location = new Point(65,85);
    exitButton.Location = new Point(65,75);
    displayPanel.Location = new Point(240,200);
    controlPanel.Location = new Point(0,0);
    controlPanel2.Location = new Point(0,240);
    controlPanel3.Location = new Point(0,480);
    eightButton.Location = new Point(50,400);
    eightBallInfo.Location = new Point(200,415);

    AcceptButton = convertButton; //AcceptButton = Enter; we're associating convert with enter key

    //add controls to form
    Controls.Add(headerPanel);
    headerPanel.Controls.Add(welcome);
    headerPanel.Controls.Add(author);

    Controls.Add(displayPanel);
    displayPanel.Controls.Add(sequenceMessage);
    displayPanel.Controls.Add(sequenceInputArea);
    displayPanel.Controls.Add(outputInfo);
    displayPanel.Controls.Add(eightButton);
    displayPanel.Controls.Add(eightBallInfo);

    Controls.Add(controlPanel);
    controlPanel.Controls.Add(convertButton);

    Controls.Add(controlPanel2);
    controlPanel2.Controls.Add(clearButton);

    Controls.Add(controlPanel3);
    controlPanel3.Controls.Add(exitButton);

    //regist event handler. each button HAS an event handler, but no other controls do
    convertButton.Click += new EventHandler(convertImpToMet);
    clearButton.Click += new EventHandler(cleartext);
    exitButton.Click += new EventHandler(stoprun); //+ is required.
    eightButton.Click += new EventHandler(eightBall);

    CenterToScreen();

  } //end of constructor for ImpToMetInterface

  protected void convertImpToMet(Object sender, EventArgs events){
    double sequenceNum;        //Formerly: uint sequencenum;
     string output;
     try{
        sequenceNum = double.Parse(sequenceInputArea.Text);
         if(sequenceNum < 0){
             Console.WriteLine("Negative value input received. Please try again.");
             output = "Negative value received. Please try again.";
             }
         else{
             double ImpToMetNum = ImpToMetLogic.convertImpToMet(sequenceNum);
                    output = "The coversion to metric units is: \n" + ImpToMetNum + " meters.";
             }
        }//End of try
     catch(FormatException malformed_input){
        Console.WriteLine("Non-number value input received. Please try again.\n{0}",malformed_input.Message);
         output = "Invalid input: no valid positive number converted.";
        }//End of catch
      catch(OverflowException too_big){
        Console.WriteLine("The value inputted is greater than the largest 32-bit integer.  Try again.\n{0}",too_big.Message);
         output = "The input number was too large for 32-bit integers.";
        }//End of catch
     outputInfo.Text = output;
   }//End of convertImpToMet


  //Method to execute when the clear button receives an event, namely: receives a mouse click
  protected void cleartext(Object sender, EventArgs events){
    sequenceInputArea.Text = ""; //Empty string
     outputInfo.Text = "Result will display here.";
    }//End of cleartext

  //Method to execute when the exit button receives an event, namely: receives a mouse click
  protected void stoprun(Object sender, EventArgs events){
    Close();
    }//End of stoprun

  protected void eightBall(Object sender, EventArgs events){
    eightBallInfo.Text = ImpToMetLogic.eightBallFun();
  }

}
