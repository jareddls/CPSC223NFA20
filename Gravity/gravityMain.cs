// Jared De Los Santos
// 223 Midterm
// Oct 19, 2020


using System;
using System.Windows.Forms;
public class Gravity {
  public static void Main() {
      System.Console.WriteLine("The Gravity program has begun.");
      gravityUI slide = new gravityUI();
      Application.Run(slide);
      System.Console.WriteLine("The Gravity program has ended. Bye.");
   }
}
