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
//Name of this file: skateboardInterface.cs
//Purpose of this file: Provides the structure for our user interface.

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class skateboardInterface: Form {

  private Label welcomeAuthor = new Label();
  private Label time = new Label();
  private Label timeElapsed = new Label();

  private Button startButton = new Button();
  private Button pauseButton = new Button();
  private Button exitButton = new Button();

  private Panel headerPanel = new Panel();
  private Panel controlPanel = new Panel();

  private Rectangle display = new Rectangle(0,70,1820,750);

  private Size maximumTrafficInterfaceSize = new Size(1820,950);
  private Size minimumTrafficInterfaceSize = new Size(1820,950);

 private const double speedOfSkate = 140; //pixels per second.
 private const double animSpeedOfClock = 60.0;   //Hz (hertz), which means number of updates of coordinates per second.
 private const double delta = speedOfSkate/animSpeedOfClock; //pixels per tic.
 private const double animClockInterval = 1000.0/animSpeedOfClock; //Millisec

 int animSpeedOfClockInteger = (int)System.Math.Round(animClockInterval);

 private const double refreshClockSpeed = 24.0;   //Hz (hertz); how many times per second the UI is re-painted.
 private const double refreshClockInterval = 1000.0/refreshClockSpeed; //Units are milliseconds.

 int refreshClockSpeedInteger = (int)System.Math.Round(refreshClockInterval);

 private const double radius = 20;    //Radius measured in pixels
 private double x;  //This is x-coordinate of the upper left corner of the skateboard.
 private double y;  //This is y-coordinate of the upper left corner of the skateboard.

 private double elapsedTime = 0.0;

 public skateboardInterface(){  //constructor

   //Set the size of the user interface box.
    MaximumSize = maximumTrafficInterfaceSize;
    MinimumSize = minimumTrafficInterfaceSize;

    //Initialize text strings
    Text = "Skateboard";
    welcomeAuthor.Text = "Skateboard by Jared De Los Santos";
    time.Text = "Elapsed Time (seconds):";
    timeElapsed.Text = "000.00";
    startButton.Text = "Start";
    pauseButton.Text = "Pause";
    exitButton.Text = "Exit";

    //Set sizes
    Size = new Size(400,240);
    welcomeAuthor.Size = new Size(800,45);
    time.Size = new Size(220,45);
    timeElapsed.Size = new Size(300,45);
    startButton.Size = new Size(150,70);
    pauseButton.Size = new Size(150,70);
    exitButton.Size = new Size(150,70);
    headerPanel.Size = new Size(1820,70);
    controlPanel.Size = new Size(1820,150);

    //Set colors
    headerPanel.BackColor = Color.LightCoral;
    controlPanel.BackColor = Color.LightCoral;
    startButton.BackColor = Color.LightGreen;
    pauseButton.BackColor = Color.LightGreen;
    exitButton.BackColor = Color.LightGreen;

    //Set fonts
    welcomeAuthor.Font = new Font("Times New Roman",22,FontStyle.Bold);
    time.Font = new Font("Times New Roman",20,FontStyle.Regular);
    timeElapsed.Font = new Font("Times New Roman",20,FontStyle.Regular);
    startButton.Font = new Font("Times New Roman",20,FontStyle.Regular);
    pauseButton.Font = new Font("Times New Roman",20,FontStyle.Regular);
    exitButton.Font = new Font("Times New Roman",20,FontStyle.Regular);

    //Set locations
    welcomeAuthor.Location = new Point(650,18);
    time.Location = new Point(780,50);
    timeElapsed.Location = new Point(1000,50);
    startButton.Location = new Point(100,30);
    pauseButton.Location = new Point(400,30);
    exitButton.Location = new Point(1500,30);
    headerPanel.Location = new Point(0,0);
    controlPanel.Location = new Point(0,800);

    //Associate the start button with the Enter key of the keyboard
    AcceptButton = startButton;

    //Add controls to the form
    Controls.Add(headerPanel);
    headerPanel.Controls.Add(welcomeAuthor);

    Controls.Add(controlPanel);
    controlPanel.Controls.Add(startButton);
    controlPanel.Controls.Add(pauseButton);
    controlPanel.Controls.Add(exitButton);
    controlPanel.Controls.Add(time);
    controlPanel.Controls.Add(timeElapsed);

    startButton.Click += new EventHandler(start);
    pauseButton.Click += new EventHandler(pause);
    exitButton.Click += new EventHandler(exitProgram);

    //Prepare the refresh clock
    refreshClock.Enabled = false;
    refreshClock.Interval = refreshClockSpeedInteger;
    refreshClock.Elapsed += new ElapsedEventHandler(Refresh_user_interface);

    //Prepare the skateboard clock
    skateboardClock.Enabled = false;
    skateboardClock.Interval = animSpeedOfClockInteger;
    skateboardClock.Elapsed += new ElapsedEventHandler(Update_skateboard_coordinates);

    //Initialize the ball at the starting point: subtract ball's radius so that (x,y) is the upper corner of the ball.
    x = (double)400-radius;
    y = (double)200-radius;

    //Open this user interface window in the center of the display.
    CenterToScreen();

  }//End of constructor skateboardInterface

  Point A = new Point(400,200);
  Point B = new Point(60,700);
  Point C = new Point(1400,700);

  private static System.Timers.Timer refreshClock = new System.Timers.Timer();
  private static System.Timers.Timer skateboardClock = new System.Timers.Timer();

  bool started = false;

 protected override void OnPaint(PaintEventArgs ee) {
   Graphics graph = ee.Graphics;

   graph.FillRectangle(Brushes.Lavender,display); // displays background

   Point[] triangle = { A,B,C }; // creates triangle
   graph.DrawPolygon(Pens.Black,triangle);
   graph.FillPolygon(Brushes.Pink,triangle);

   graph.FillEllipse (Brushes.Black,
                     (int)System.Math.Round(x),
                     (int)System.Math.Round(y),
                     (int)System.Math.Round(2.0*radius),
                     (int)System.Math.Round(2.0*radius));

   base.OnPaint(ee);
 } // End of OnPaint

 // starts the traffic light
 protected void start(Object sender, EventArgs events) {
  System.Console.WriteLine("The animation has begun.");
  refreshClock.Enabled = true;
  skateboardClock.Enabled = true;
  if (started == false) {
    started = true;
  }
  Invalidate();
} // End of start

 // pause the traffic light
 protected void pause(Object sender, EventArgs events) {
   System.Console.WriteLine("The animation has been paused.");
   refreshClock.Enabled = false;
   skateboardClock.Enabled = false;
   Invalidate();
 }

 // updates time accumulated
 protected void Refresh_user_interface(System.Object sender, ElapsedEventArgs even) {
   timeElapsed.Text = String.Format("{0:000.00}",elapsedTime);
  Invalidate();
 }//End of Refresh_user_interface

 protected void Update_skateboard_coordinates(System.Object sender, ElapsedEventArgs even) {
   if(System.Math.Abs(x+radius-(double)60)>delta && System.Math.Abs(y+radius-(double)700)>delta) {
     x -= delta*(400-60)/(700-200)/1.5;
     y += delta/1.5;
   }
   else {
     refreshClock.Enabled = false;
     skateboardClock.Enabled = false;
     startButton.Enabled = false;
     pauseButton.Enabled = false;
     System.Console.WriteLine("The program has completed. You may close now exit the program.");
   }
   elapsedTime += (double)animSpeedOfClockInteger/1000.0;
 }// end of Update_skateboard_coordinates

 // closes the program
 protected void exitProgram(Object sender, EventArgs events) {
   Close();
 }//end of exitProgram

}//end of skateboardInterface
