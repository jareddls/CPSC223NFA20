// Jared De Los Santos
// 223N Final
// Dec 16, 2020
// run the program by doing sh run.sh

using System;
using System.Windows.Forms;

public class Clicky {
  public static void Main() {
    System.Console.WriteLine("The Clicky program has begun.");
    ClickUI game = new ClickUI();
    Application.Run(game);
    System.Console.WriteLine("The Clicky program has ended. Bye.");
  }
}
