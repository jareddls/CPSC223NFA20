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
//Name of this file: TrafficInterface.cs
//Purpose of this file: Provide "computational" functions needed by the user interface class.
//
//
//Linux: The source files in this program should be compiled in the order specified below in order to satisfy dependencies.
//  1. TrafficLogic.cs       compiles into library file TrafficLogic.dll
//  1. TrafficInterface.cs   compiles into library file TrafficInterface.dll
//  2. TrafficMain.cs        compiles and links with the dll file above to create TrafficMain.exe

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

//creation of buttons/panels/etc. for what I need for this program
public class TrafficInterface : Form {
  private const int formwidth = 600;  //using these for the dimensions of my form
   private const int formheight = 1000;

   private static System.Timers.Timer trafficTimer = new System.Timers.Timer();
   private Brush paint_brush = new SolidBrush(System.Drawing.Color.White); //default color for empty traffic lights

   private Panel headerPanel = new Panel();
   private Panel displayPanel = new Panel();
   private Panel controlPanel = new Panel();

   private Label titleAuthor = new Label();

   private Button startButton = new Button();
   private Button pauseButton = new Button();
   private Button exitButton = new Button();

   //the radio box
   private RadioButton fast = new System.Windows.Forms.RadioButton();
   private RadioButton slow = new System.Windows.Forms.RadioButton();
   private GroupBox backgroundBox = new GroupBox();

      public TrafficInterface() {

         //initilize text strings
            Text = "Traffic Light Signal";
            System.Console.WriteLine("formwidth = {0}. formheight = {1}.",formwidth,formheight);
            titleAuthor.Text = "Traffic Light Signal by Jared De Los Santos";
            startButton.Text = "Start";
            pauseButton.Text = "Pause";
            exitButton.Text = "Exit";
            fast.Text = "Fast";
            slow.Text = "Slow";
            backgroundBox.Text = "Speed";

          //set the sizes of the strings above
            Size = new Size(formwidth, formheight);

            titleAuthor.Size = new Size(600, 50);
            startButton.Size = new Size(100, 50);
            pauseButton.Size = new Size(100, 50);
            exitButton.Size = new Size(100, 50);

            fast.Size = new Size (50,15);
            slow.Size = new Size (50,15);
            backgroundBox.Size = new Size(100,55);

            headerPanel.Size = new Size(600, 50);
            controlPanel.Size = new Size(600, 100);

          //set colors
            BackColor = Color.Black;
            headerPanel.BackColor = Color.LightCoral;
            controlPanel.BackColor = Color.LightCoral;

            startButton.BackColor = Color.LightGreen;
            pauseButton.BackColor = Color.LightGreen;
            exitButton.BackColor = Color.LightGreen;
            backgroundBox.BackColor = Color.LightGreen;
            fast.BackColor = Color.LightGreen;
            slow.BackColor = Color.LightGreen;

          //set fonts
           titleAuthor.Font = new Font("Times New Roman",15,FontStyle.Regular);
           startButton.Font = new Font("Times New Roman",10,FontStyle.Regular);
           pauseButton.Font = new Font("Times New Roman",10,FontStyle.Regular);
           exitButton.Font = new Font("Times New Roman",10,FontStyle.Regular);
           fast.Font = new Font("Times New Roman",10,FontStyle.Regular);
           slow.Font = new Font("Times New Roman",10,FontStyle.Regular);

          //set locations
           headerPanel.Location = new Point(0,0);
           controlPanel.Location = new Point(0,900);

           titleAuthor.Location = new Point(120,15);

           startButton.Location = new Point (40, 15);
           pauseButton.Location = new Point (180, 15);
           fast.Location = new Point(10,15);
           slow.Location = new Point(10,35);
           backgroundBox.Location = new Point(320, 15);


           exitButton.Location = new Point (460, 15);

          //not needed but could be for convenience to start traffic light
           AcceptButton = startButton;

          //adding controls to the form
           Controls.Add(headerPanel);
           headerPanel.Controls.Add(titleAuthor);

           Controls.Add(controlPanel);
           controlPanel.Controls.Add(startButton);
           controlPanel.Controls.Add(pauseButton);
           controlPanel.Controls.Add(backgroundBox);
           controlPanel.Controls.Add(exitButton);

           backgroundBox.Controls.Add(fast); //adding it to the groupbox to prevent overlapping of the radio button and the box
           backgroundBox.Controls.Add(slow);

          //registers event handler, so that each of these buttons do something when an event occurs
           startButton.Click += new EventHandler(startprogram);
           pauseButton.Click += new EventHandler(pauseprogram);
           fast.Click += new EventHandler(fastChecked);
           slow.Click += new EventHandler(slowChecked);
           exitButton.Click += new EventHandler(exitprogram);

           trafficTimer.Enabled = false;
           trafficTimer.Elapsed += new ElapsedEventHandler(traffic);

           slow.Checked = true; //defaults it to slow


      }// end of trafficinterface


    //for event EventHandler
      private enum Light {Blank, Red, Green, Yellow};

      Light current = Light.Blank;

      protected void traffic(System.Object sender, ElapsedEventArgs evt){ //time-based traffic light that changes checking the radio buttons' bool values
        switch(current){ //current will start at blank so that it's empty on start
          case Light.Red: //this is when I press "Start" it changes the case to this one
              if (slow.Checked == true){
                trafficTimer.Interval = (int)6000;
              }
              else if(fast.Checked == true){
                trafficTimer.Interval = (int)3000;
              }
              current = Light.Green;
              break;
          case Light.Green: //after a certain amount of increments, it switches to this case
              if (slow.Checked == true){
                trafficTimer.Interval = (int)2000;
              }
              else if(fast.Checked == true){
                trafficTimer.Interval = (int)1000;
              }
              current = Light.Yellow;
              break;
          case Light.Yellow: //same reason as above case
              if (slow.Checked == true){
                trafficTimer.Interval = (int)8000;
              }
              else if(fast.Checked == true){
                trafficTimer.Interval = (int)4000;
              }
              current = Light.Red;
              break;
        } //End of switch
        Invalidate();
      } //End of traffic

        protected override void OnPaint(PaintEventArgs ee){ //fills the traffic lights based on case above
           Graphics graph = ee.Graphics;
           switch(current){
             case Light.Blank: //first case when program starts up
                 graph.FillEllipse(Brushes.Gainsboro,175,75,250,250);
                 graph.FillEllipse(Brushes.Gainsboro,175,350,250,250);
                 graph.FillEllipse(Brushes.Gainsboro,175,625,250,250);
               break;
             case Light.Red: //fills red light and others not lit up
                 graph.FillEllipse(Brushes.Red,175,75,250,250);
                 graph.FillEllipse(Brushes.Gainsboro,175,350,250,250);
                 graph.FillEllipse(Brushes.Gainsboro,175,625,250,250);
               break;
             case Light.Green: //fills green light and others not lit up
                 graph.FillEllipse(Brushes.Gainsboro,175,75,250,250);
                 graph.FillEllipse(Brushes.Gainsboro,175,350,250,250);
                 graph.FillEllipse(Brushes.Green,175,625,250,250);
               break;
             case Light.Yellow: //fills yellow light and others not lit up
                 graph.FillEllipse(Brushes.Gainsboro,175,75,250,250);
                 graph.FillEllipse(Brushes.Gold,175,350,250,250);
                 graph.FillEllipse(Brushes.Gainsboro,175,625,250,250);
               break;
           } //end of switch
          base.OnPaint(ee);
        } // end of OnPaint function

      protected void exitprogram(Object sender, EventArgs events){ //closes the program
        Close();
      }

      protected void startprogram(Object sender, EventArgs events){ //activates the "electricity" for the traffic signal
        current = Light.Red; //when we start program we start at red
        trafficTimer.Enabled = true;
        slow.Checked = true;
        trafficTimer.Interval = (int)8000; //no matter what you do, even if you try starting with fast; you will always be defaulted to slow until after you start
        System.Console.WriteLine("You clicked on the Start button.");
        Invalidate();
      }

      protected void pauseprogram(Object sender, EventArgs events){ //pauses/resumes the current state of the traffic signal
        if(pauseButton.Text == "Pause"){ //shows pause initially/or after resuming program
          pauseButton.Text = "Resume";
          trafficTimer.Enabled = false;
          System.Console.WriteLine("You clicked on the Pause button.");
        }
        else if(pauseButton.Text == "Resume"){ //shows resume after pausing program
          pauseButton.Text = "Pause";
          trafficTimer.Enabled = true;
          System.Console.WriteLine("You clicked on the Resume button.");
        }

        Invalidate();
      }

      protected void slowChecked(Object sender, EventArgs events){ //disables bool for fast
        slow.Checked = true;
        fast.Checked = false;
        System.Console.WriteLine("You clicked on the Slow button.");
      }

      protected void fastChecked(Object sender, EventArgs events){ //disables bool for slow
        fast.Checked = true;
        slow.Checked = false;
        System.Console.WriteLine("You clicked on the Fast button.");
      }


} //end of form
