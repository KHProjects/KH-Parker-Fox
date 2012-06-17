using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkerFoxQuote
{
  class Program
  {
    static void Main(string[] args)
    {
      //declairations
      Tools tool = new Tools();
      string value;
      int running = 1;

      while (running == 1)
      {
        //collect input
        Console.WriteLine("Please enter an integer to convert to words: ");
        value = Console.ReadLine();

        //validate input (check that the value is numeric, remove commas, pounds, fullstops and any values after the fullstop
        value = tool.ValidateInput(value);

        //check value for "error"
        if (value == "error")
        {
          Console.WriteLine("There was an error with the input.");
          Console.WriteLine("");
          Console.WriteLine("Please press enter and try another");
          Console.Clear();
        }
        else//convert int to words.
        {
          //get word from number
          string word = tool.IntToEnglish(value);

          Console.WriteLine(word);
          Console.WriteLine("");
          Console.WriteLine("Conversion Complete.. Please press enter and try another");
          Console.ReadLine();
          //for (int i = 0; i < 20; i++ )
          //  Console.WriteLine("");
          Console.Clear();
        }
      }

    }

  }
}
