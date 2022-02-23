// Jared De Los Santos
// 223 Midterm
// Oct 19, 2020

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class gravityUI: Form {

  private Label welcomeAuthor = new Label();
  private Label time = new Label();
  private Label timeElapsed = new Label();

  private Button startButton = new Button();
  private Button pauseButton = new Button();
  private Button exitButton = new Button();

  private Panel headerPanel = new Panel();
  private Panel controlPanel = new Panel();

  private Rectangle display = new Rectangle(0,70,1420,750);

  private Size maximumGravityUISize = new Size(1420,950);
  private Size minimumGravityUISize = new Size(1420,950);

 private const double speedOfGrav = 240;
 private const double animSpeedOfClock = 60.0;
 private const double delta = speedOfGrav/animSpeedOfClock;
 private const double animClockInterval = 1000.0/animSpeedOfClock; 

 int animSpeedOfClockInteger = (int)System.Math.Round(animClockInterval);

 private const double refreshClockSpeed = 30.0;
 private const double refreshClockInterval = 1000.0/refreshClockSpeed;

 int refreshClockSpeedInteger = (int)System.Math.Round(refreshClockInterval);

 private const double radius = 20;
 private double x;
 private double y;

 private double elapsedTime = 0.0;

 public gravityUI(){  //constructor

   //Set the size of the user interface box.
    MaximumSize = maximumGravityUISize;
    MinimumSize = minimumGravityUISize;

    //Initialize text strings
    Text = "Gravity";
    welcomeAuthor.Text = "Jared De Los Santos";
    time.Text = "Elapsed Time (seconds):";
    timeElapsed.Text = "000.00";
    startButton.Text = "Start";
    pauseButton.Text = "Pause";
    exitButton.Text = "Exit";

    //Set sizes
    Size = new Size(400,240);
    welcomeAuthor.Size = new Size(800,45);
    time.Size = new Size(275,45);
    timeElapsed.Size = new Size(250,45);
    startButton.Size = new Size(150,70);
    pauseButton.Size = new Size(150,70);
    exitButton.Size = new Size(150,70);
    headerPanel.Size = new Size(1420,70);
    controlPanel.Size = new Size(1420,150);

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
    welcomeAuthor.Location = new Point(625,18);
    time.Location = new Point(500,50);
    timeElapsed.Location = new Point(775,50);
    startButton.Location = new Point(100,30);
    pauseButton.Location = new Point(300,30);
    exitButton.Location = new Point(1100,30);
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

    //Prepare the gravity clock
    gravityClock.Enabled = false;
    gravityClock.Interval = animSpeedOfClockInteger;
    gravityClock.Elapsed += new ElapsedEventHandler(Update_gravity_coordinates);

    //Initialize the ball at the starting point: subtract ball's radius so that (x,y) is the upper corner of the ball.
    x = (double)100-radius;
    y = (double)120-radius;

    //Open this user interface window in the center of the display.
    CenterToScreen();

  }//End of constructor gravityUI

  Point A = new Point(100, 120);
  Point B = new Point(1320,750);

  private static System.Timers.Timer refreshClock = new System.Timers.Timer();
  private static System.Timers.Timer gravityClock = new System.Timers.Timer();

  bool started = false;
  bool reverse = true;

 protected override void OnPaint(PaintEventArgs ee) {
   Graphics graph = ee.Graphics;

   graph.FillRectangle(Brushes.Lavender,display); // displays background

   graph.DrawLine(Pens.Black,A,B);

   graph.FillEllipse (Brushes.Blue,
                     (int)System.Math.Round(x),
                     (int)System.Math.Round(y),
                     (int)System.Math.Round(2.0*radius),
                     (int)System.Math.Round(2.0*radius));

   base.OnPaint(ee);
 } // End of OnPaint

 protected void start(Object sender, EventArgs events) {
  System.Console.WriteLine("The animation has begun.");
  refreshClock.Enabled = true;
  gravityClock.Enabled = true;
  if (started == false) {
    started = true;
  }
  Invalidate();
} // End of start

 protected void pause(Object sender, EventArgs events) {
   System.Console.WriteLine("The animation has been paused.");
   refreshClock.Enabled = false;
   gravityClock.Enabled = false;
   Invalidate();
 }

 // updates time accumulated
 protected void Refresh_user_interface(System.Object sender, ElapsedEventArgs even) {
   timeElapsed.Text = String.Format("{0:000.00}",elapsedTime);
  Invalidate();
 }//End of Refresh_user_interface

 protected void Update_gravity_coordinates(System.Object sender, ElapsedEventArgs even) {
     if(reverse && System.Math.Abs(x+radius-(double)1320)>delta && System.Math.Abs(y+radius-(double)750)>delta) { //radius 20, x = 100-radius, y=200-radius, delta = 4
       x -= delta*(100-750)/(455-120)/1.5;
       y += delta/1.5;
     }
     else{
       reverse = false;
     }
     if(!reverse){
           x +=  (delta*(750-100)/(120-455)/1.5);
           y -=  (delta/1.5);
     }
     if(!reverse && x <= 80){
       refreshClock.Enabled = false;
       gravityClock.Enabled = false;
       startButton.Enabled = false;
       pauseButton.Enabled = false;
       System.Console.WriteLine("The program has completed. You may close now exit the program.");
     }

   elapsedTime += (double)animSpeedOfClockInteger/1000.0;
 }// end of Update_gravity_coordinates

 // closes the program
 protected void exitProgram(Object sender, EventArgs events) {
   Close();
 }//end of exitProgram

}//end of gravityUI
