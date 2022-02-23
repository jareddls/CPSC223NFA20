// Jared De Los Santos
// 223N Final
// Dec 16, 2020
// run the program by doing sh run.sh

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

public class ClickUI : Form {
  Random generator = new Random();

  private Label author = new Label(); //me

  private Label x_label = new Label();
  private Label y_label = new Label();
  private Label successCount = new Label();
  private Label attemptCount = new Label();

  private TextBox x_text = new TextBox();
  private TextBox y_text = new TextBox();
  private TextBox success_text = new TextBox();
  private TextBox attempt_text = new TextBox();

  private Button startButton = new Button();
  private Button newButton = new Button();
  private Button exitButton = new Button();

  private Panel headerPanel = new Panel();
  private Rectangle display = new Rectangle(0,100,1024,500);
  private Panel controlPanel = new Panel();

  //Ball coordinates and time
  private const double ball_center_initial_coord_x = 512; //initial, starts
  private const double ball_center_initial_coord_y = 325; //at middle

  private double ball_center_current_coord_x; // CURRENT coords
  private double ball_center_current_coord_y;

  private double ball_upper_left_current_coord_x;
  private double ball_upper_left_current_coord_y;

  private double ball_delta_x;
  private double ball_delta_y;

  private double ball_direction;
  private double radians;

  private double physicalMouseX;
  private double physicalMouseY;

  private double clickies = 0;
  private double success = 0;
  private double distance = 0;
  //Time
  private double ball_linear_speed_pix_per_sec;
  private double ball_linear_speed_pix_per_tic;

  //Declare data about the motion clock:
  private static System.Timers.Timer ball_motion_control_clock = new System.Timers.Timer();
  private const double ball_motion_control_clock_rate = 45; //units are in Hz

  //Declare data about the refresh clock;
  private static System.Timers.Timer graphic_area_refresh_clock = new System.Timers.Timer();
  private const double graphic_refresh_rate = 45; //units are in Hz = #of refreshes per second

  //UI size
  private Size maximumInterfaceSize = new Size(1024, 800);
  private Size minimumInterfaceSize = new Size(1024, 800);

  private const double ball_radius = 20; //according to prof's suggestion

  public ClickUI() { //constructor
    //set size of UI box
    System.Console.WriteLine("formwidth=1024. formheigh = 800.");
    Size = new Size (400,240);

    //set limits regarding to how much user can resize application
    MaximumSize = maximumInterfaceSize;
    MinimumSize = minimumInterfaceSize;

    //initialize text strings
    Text = "Finals";
    author.Text =  "Click by Jared De Los Santos";
    startButton.Text = "Start";
    newButton.Text = "New";
    exitButton.Text = "Exit";

    x_label.Text = "X -";
    y_label.Text = "Y -";
    attemptCount.Text = "Attempt #:";
    successCount.Text = "# of Successful Clicks: ";

    newButton.Enabled = false;

    //set sizes
    author.Size = new Size(800, 44);
    startButton.Size = new Size(100, 75);
    newButton.Size = new Size(100, 50);
    exitButton.Size = new Size (100, 50);

    x_label.Size = new Size(50,50);
    y_label.Size = new Size(50,50);
    x_text.Size = new Size(50,50);
    // x_text.Multiline = true;
    y_text.Size = new Size(50,50);

    attemptCount.Size = new Size(250,50);
    successCount.Size = new Size(250,50);
    success_text.Size = new Size(50,50);
    attempt_text.Size = new Size(50,50);

    headerPanel.Size = new Size(1024, 100);
    controlPanel.Size = new Size(1024, 200);

    //set colors
    headerPanel.BackColor = Color.Aquamarine;
    controlPanel.BackColor = Color.Aquamarine;

    startButton.BackColor = Color.Crimson;
    newButton.BackColor = Color.ForestGreen;
    exitButton.BackColor = Color.LightPink;

    //set fonts
    author.Font = new Font("Times New Roman", 25, FontStyle.Regular);

    startButton.Font = new Font("Times New Roman", 20, FontStyle.Bold);
    newButton.Font = new Font("Times New Roman", 20, FontStyle.Bold);
    exitButton.Font = new Font("Times New Roman", 20, FontStyle.Bold);

    attemptCount.Font = new Font("Times New Roman", 15, FontStyle.Regular);
    successCount.Font = new Font("Times New Roman", 15, FontStyle.Regular);
    attempt_text.Font = new Font("Times New Roman", 15, FontStyle.Regular);
    success_text.Font = new Font("Times New Roman", 15, FontStyle.Regular);

    x_label.Font = new Font("Times New Roman", 15, FontStyle.Regular);
    y_label.Font = new Font("Times New Roman", 15, FontStyle.Regular);
    x_text.Font = new Font("Times New Roman", 15, FontStyle.Regular);
    y_text.Font = new Font("Times New Roman", 15, FontStyle.Regular);


    //set locations
    headerPanel.Location = new Point(0, 0);
    controlPanel.Location = new Point(0,570);

    author.Location = new Point(300,40);

    startButton.Location = new Point(50, 25);
    newButton.Location = new Point(50, 125);
    exitButton.Location = new Point(800, 125);

    x_text.Location = new Point(250, 55);
    y_text.Location = new Point(250, 105);

    x_label.Location = new Point(200, 50);
    y_label.Location = new Point(200, 100);

    attemptCount.Location = new Point(325, 50);
    successCount.Location = new Point(500, 50);

    attempt_text.Location = new Point(350, 100);
    success_text.Location = new Point(575, 100);
    //associate new button with enter key
    AcceptButton = newButton;

    //set up clocks
    //set up motion clock. controls rate of update of coords
    ball_motion_control_clock.Enabled = false;
    ball_motion_control_clock.Elapsed += new ElapsedEventHandler(Update_ball_position);

    //set up the refresh clock
    graphic_area_refresh_clock.Enabled = false;
    graphic_area_refresh_clock.Elapsed += new ElapsedEventHandler(Update_display);

    //add controls to form
    Controls.Add(headerPanel);
      headerPanel.Controls.Add(author);
    Controls.Add(controlPanel);
      controlPanel.Controls.Add(startButton);
      controlPanel.Controls.Add(newButton);
      controlPanel.Controls.Add(exitButton);
      controlPanel.Controls.Add(successCount);
      controlPanel.Controls.Add(attemptCount);
      controlPanel.Controls.Add(success_text);
      controlPanel.Controls.Add(attempt_text);
      controlPanel.Controls.Add(x_label);
      controlPanel.Controls.Add(y_label);
      controlPanel.Controls.Add(x_text);
      controlPanel.Controls.Add(y_text);

    //balls initial coordinates
    ball_center_current_coord_x = ball_center_initial_coord_x;
    ball_center_current_coord_y = ball_center_initial_coord_y;
    System.Console.WriteLine("Initial coordinates: ball_center_current_coord_x = {0}. ball_center_current_coord_y = {1}.",
                              ball_center_current_coord_x,ball_center_current_coord_y);

    //register event handler
    startButton.Click += new EventHandler(letsGO);
    newButton.Click += new EventHandler(resetValue);
    exitButton.Click += new EventHandler(stopRun);

    //for centering program within screen
    CenterToScreen();
    ActiveControl = newButton;
  } //constructor end

  protected override void OnPaint(PaintEventArgs ee){
    Graphics graph = ee.Graphics;

    graph.FillRectangle(Brushes.Cornsilk, display); //rectangle bg color

    ball_upper_left_current_coord_x = ball_center_current_coord_x - ball_radius;
    ball_upper_left_current_coord_y = ball_center_current_coord_y - ball_radius;

    graph.FillEllipse(Brushes.MidnightBlue, (int)ball_upper_left_current_coord_x,
                                            (int)ball_upper_left_current_coord_y,
                                            (float)(2.0 * ball_radius),
                                            (float)(2.0 * ball_radius));

    base.OnPaint(ee);

  }//end of OnPaint

  protected void Update_ball_position(System.Object sender, ElapsedEventArgs evt){
    ball_center_current_coord_x += ball_delta_x;
    ball_center_current_coord_y += ball_delta_y;

    //determine if the ball has made a collision with the right wall.
    if((int)System.Math.Round(ball_center_current_coord_x + ball_radius) >= 1014){
           ball_delta_x = -ball_delta_x;
    }
    //determine if the ball has made a collision with the lower wall
    if((int)System.Math.Round(ball_center_current_coord_y + ball_radius) >= 569.5){
          ball_delta_y = -ball_delta_y;
    }
    //determine if the ball has made a collision with the left wall
    if((int)System.Math.Round(ball_center_current_coord_y - ball_radius) <= 100){
          ball_delta_y = -ball_delta_y;
    }
    //determine if the ball has made a collision with the upper wall
    if((int)System.Math.Round(ball_center_current_coord_x - ball_radius) <= 0){
          ball_delta_x = -ball_delta_x;
    }
  }//end of Update_ball_position

  protected override void OnMouseDown(MouseEventArgs oneclick){
    physicalMouseX = oneclick.X;
    physicalMouseY = oneclick.Y;
    base.OnMouseDown(oneclick);
    clickies += 1;

    distance = Math.Sqrt(Math.Pow(ball_center_current_coord_x - physicalMouseX,2)+
                         Math.Pow(ball_center_current_coord_y - physicalMouseY,2));

    if (clickies >= 10){
      graphic_area_refresh_clock.Enabled = false;
      ball_motion_control_clock.Enabled = false;
      attempt_text.Text = "10";
    }

    if(clickies > 0){
        ball_delta_x *= 1.25;
        ball_delta_y *= 1.25;
    }

    if(distance <= ball_radius){
      success += 1;
    }

    System.Console.WriteLine("X: {0}, Y: {1}",physicalMouseX,physicalMouseY);
    System.Console.WriteLine("Click: {0}",clickies);
  }//end of OnMouseDown

  protected void Update_display(System.Object sender, ElapsedEventArgs evt){
    Invalidate();
    x_text.Text = String.Format("{000}",ball_center_current_coord_x);
    y_text.Text = String.Format("{000}",ball_center_current_coord_y);
    attempt_text.Text = String.Format("{000}",clickies);
    success_text.Text = String.Format("{000}",success);

    if(!ball_motion_control_clock.Enabled){
      graphic_area_refresh_clock.Enabled = false;
      System.Console.WriteLine("Graphical area no longer updating.");
    }
  }//end of Update_display

  protected void Start_graphic_clock(double refresh_rate){
    double actual_refresh_rate = 1.0; //minimum is 1 to avoid problems
    double elapsed_time_between_tics;

    if(refresh_rate > actual_refresh_rate){
      actual_refresh_rate = refresh_rate;
    }

    elapsed_time_between_tics = 1000.0/actual_refresh_rate;
    graphic_area_refresh_clock.Interval = (int)System.Math.Round(elapsed_time_between_tics);
    graphic_area_refresh_clock.Enabled = true;
  }//end of Start_graphic_clock

  protected void Start_ball_clock(double update_rate){
    double elapsed_time_between_ball_moves;

    // if(update_rate < 1.0){
    //   update_rate = 1.0; //does not allow updates slower than 1 hz
    // }

    elapsed_time_between_ball_moves = 1000.0/update_rate; //1000 ms

    ball_motion_control_clock.Interval = (int)System.Math.Round(elapsed_time_between_ball_moves);
    ball_motion_control_clock.Enabled = true;
  }//end of start_ball_clock

  protected void letsGO(System.Object sender, EventArgs events){
    //refreshclock start
    Start_graphic_clock(graphic_refresh_rate);

    //motionclock start
    Start_ball_clock(ball_motion_control_clock_rate);

    ball_linear_speed_pix_per_sec = 150;
    ball_direction = generator.NextDouble() * 360;
    radians = (ball_direction * (Math.PI)) / 180;

    ball_linear_speed_pix_per_tic = ball_linear_speed_pix_per_sec/ball_motion_control_clock_rate;

    ball_delta_x = ball_linear_speed_pix_per_tic * Math.Cos(radians);
    ball_delta_y = ball_linear_speed_pix_per_tic * Math.Sin(radians);

    startButton.Enabled = false;
    newButton.Enabled = true;

    clickies = 0;
    success = 0;

  }//end of letsGO

  protected void resetValue(Object sender, EventArgs events) {
    System.Console.WriteLine("Game has been reset.");

    ball_center_current_coord_x = ball_center_initial_coord_x;
    ball_center_current_coord_y = ball_center_initial_coord_y;

    ball_motion_control_clock.Enabled = false;
    graphic_area_refresh_clock.Enabled = false;

    startButton.Enabled = true;
    newButton.Enabled = false;

    x_text.Text = String.Format("{000}",ball_center_current_coord_x);
    y_text.Text = String.Format("{000}",ball_center_current_coord_y);
    success_text.Text = "0";
    attempt_text.Text = "0";
    Invalidate();

  }// end of resetValue

  protected void stopRun(Object sender, EventArgs events){
    Close();
  } // end of stopRun

}//class end
