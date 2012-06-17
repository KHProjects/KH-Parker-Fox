using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ParkerFoxQuote
{
  public class Tools
  {

    public string ValidateInput(string inValue)
    {
      inValue = Regex.Replace(inValue, @"[^\w\s\.@-]", "");

      try 
      { 
        int integerTest = Convert.ToInt32(inValue);
        if (integerTest < 0)//convert a negative number into a positive
          inValue = Convert.ToString(integerTest - integerTest - integerTest);
      }
      catch { inValue = "error"; }

      return inValue;
    }

    public string IntToEnglish(string inValue)
    {
      string word = "";

      //add values into a list of 3 elements (units, tens, hundreds)
      List<UnitTenHundredModel> unitTenHundredList = new List<UnitTenHundredModel>();
      char[] ags = inValue.ToCharArray();

      //add data to the unitTenHundredList with the UnitTenHundredModel
      UnitTenHundredModel unitTenHundred = new UnitTenHundredModel();

      int counter = 0;
      for (int i = ags.Count()-1; i > -1 ; i--)
      {
        if (counter == 0)//Units
        {
          unitTenHundred.Unit = Convert.ToInt32(ags.ElementAtOrDefault(i).ToString());
          counter++;
          if (i == 0)// -1?.. If last element in the char[] array then add to list
          {
            //if this is the last value then push the current values into the correct U,T,H columns
            unitTenHundredList.Add(unitTenHundred);
          }
        }
        else if (counter == 1)//Ten
        {
          unitTenHundred.Ten = Convert.ToInt32(ags.ElementAtOrDefault(i).ToString());
          counter++;
          if (i == 0)// -1?.. If last element in the char[] array then add to list
          {
            //if this is the last value then push the current values into the correct U,T,H columns
            unitTenHundredList.Add(unitTenHundred);
          }
        }
        else if (counter == 2)//Hundred
        {
          unitTenHundred.Hundred = Convert.ToInt32(ags.ElementAtOrDefault(i).ToString());
          unitTenHundredList.Add(unitTenHundred);
          unitTenHundred = new UnitTenHundredModel();
          counter = 0;
        }
      }

      //reverse the unitTenHundredList
      unitTenHundredList.Reverse(0, unitTenHundredList.Count());

      // iterate through the unitTenHundredList to build the word
      for (int i = 0; i < unitTenHundredList.Count; i++)
      {
        string subWord = UnitTenHundredToWord(unitTenHundredList.ElementAt(i), i, unitTenHundredList.Count);

        if(subWord != "")
          word += subWord + " ";

        //only write the "billion", "million", "thousand" if there are valid values in either the Hundred, Ten or Unit Column
        if (unitTenHundredList.Count == 4 && i == 0 && unitTenHundredList.ElementAt(i).Hundred != 0
            || unitTenHundredList.Count == 4 && i == 0 && unitTenHundredList.ElementAt(i).Ten != 0
            || unitTenHundredList.Count == 4 && i == 0 && unitTenHundredList.ElementAt(i).Unit != 0)
          word += "billion, ";
        if (unitTenHundredList.Count == 4 && i == 1 && unitTenHundredList.ElementAt(i).Hundred != 0
            || unitTenHundredList.Count == 4 && i == 1 && unitTenHundredList.ElementAt(i).Ten != 0
            || unitTenHundredList.Count == 4 && i == 1 && unitTenHundredList.ElementAt(i).Unit != 0)
          word += "million, ";
        if (unitTenHundredList.Count == 4 && i == 2 && unitTenHundredList.ElementAt(i).Hundred != 0
            || unitTenHundredList.Count == 4 && i == 2 && unitTenHundredList.ElementAt(i).Ten != 0
            || unitTenHundredList.Count == 4 && i == 2 && unitTenHundredList.ElementAt(i).Unit != 0)
          word += "thousand, ";

        //million
        if (unitTenHundredList.Count == 3 && i == 0 && unitTenHundredList.ElementAt(i).Hundred != 0
            || unitTenHundredList.Count == 3 && i == 0 && unitTenHundredList.ElementAt(i).Ten != 0
            || unitTenHundredList.Count == 3 && i == 0 && unitTenHundredList.ElementAt(i).Unit != 0)
          word += "million, ";
        if (unitTenHundredList.Count == 3 && i == 1 && unitTenHundredList.ElementAt(i).Hundred != 0
            || unitTenHundredList.Count == 3 && i == 1 && unitTenHundredList.ElementAt(i).Ten != 0
            || unitTenHundredList.Count == 3 && i == 1 && unitTenHundredList.ElementAt(i).Unit != 0)
          word += "thousand, ";

        //"thousand"
        if (unitTenHundredList.Count == 2 && i == 0 && unitTenHundredList.ElementAt(i).Hundred != 0
            || unitTenHundredList.Count == 2 && i == 0 && unitTenHundredList.ElementAt(i).Ten != 0
            || unitTenHundredList.Count == 2 && i == 0 && unitTenHundredList.ElementAt(i).Unit != 0)
          word += "thousand, ";

      }

      //get rid of ", and" replace with " and"
      word = Regex.Replace(word, ",  and", " and");
      word = word.Trim();

      //remove first 4 letters when "and" (an update to the UnitTenHundredToWord() method could remove this section of code (currently tenWord and unitWord += "and", a different if statement could improve the method further)..
      char[] chars = word.ToCharArray();
      if (chars.ElementAtOrDefault(0).ToString() == "a")
        word = word.Remove(0, 4);

      if (chars.ElementAtOrDefault(chars.Count()-1).ToString() == ",")
        word = word.Remove(word.Length - 1, 1);
      return word;
    }

    public string UnitTenHundredToWord(UnitTenHundredModel uth, int numOfCurrentItem, int numOfAllItems)
    {
      string hundredWord = "";
      string tenWord = "";
      string unitWord = "";
      string uthWord = "";

      //get word for hundred value
      if (uth.Hundred != 0)
      { 
        hundredWord = GetWordFromNumber(uth.Hundred, "u");
        hundredWord += " hundred";
      }

      //get word for UnitTenValue (11 to 19)
      if (uth.Ten == 1 && uth.Unit > 0)
      {
        tenWord = GetWordFromNumber(Convert.ToInt32(uth.Ten + "" + uth.Unit), "ut");
      }
      else
      {
        //get word for ten value
        if (uth.Ten != 0)
          tenWord = GetWordFromNumber(uth.Ten, "t");

        //get word for unit value
        if (uth.Unit != 0)
          unitWord = GetWordFromNumber(uth.Unit, "u");
      }

      //write words for the Hundred, Ten and Unit to the uthWord
      if (hundredWord != "") //"one hundred"
        uthWord += "" + hundredWord;
      if (tenWord != "") // and twenty || and twelve || twenty || twelve
      {
        //if (numOfAllItems != 1 && numOfAllItems != numOfCurrentItem || hundredWord != "" && numOfAllItems == 1 && numOfAllItems != numOfCurrentItem)
        if (numOfAllItems != 1 || hundredWord != "" && numOfAllItems == 1)
          tenWord = "and " + tenWord;
        uthWord += " " + tenWord;
      }
      if (unitWord != "") // one
      {
        if (numOfAllItems != 1 && tenWord == "" || hundredWord != "" && tenWord == "" && numOfAllItems == 1)
          unitWord = "and " + unitWord;
        uthWord += " " + unitWord;
      }

      return uthWord;
    }

    public string GetWordFromNumber(int inValue, string inType)
    {
      string wordNumber = "";

      //if unit type
      if (inType == "u")
      {
        if (inValue == 1)
        { wordNumber = "one"; }
        else if (inValue == 2)
        { wordNumber = "two"; }
        else if (inValue == 3)
        { wordNumber = "three"; }
        else if (inValue == 4)
        { wordNumber = "four"; }
        else if (inValue == 5)
        { wordNumber = "five"; }
        else if (inValue == 6)
        { wordNumber = "six"; }
        else if (inValue == 7)
        { wordNumber = "seven"; }
        else if (inValue == 8)
        { wordNumber = "eight"; }
        else if (inValue == 9)
        { wordNumber = "nine"; }
      }

      //if ten type
      if (inType == "t")
      {
        if (inValue == 1)
        { wordNumber = "ten"; }
        if (inValue == 2)
        { wordNumber = "twenty"; }
        if (inValue == 3)
        { wordNumber = "thirty"; }
        if (inValue == 4)
        { wordNumber = "fourty"; }
        if (inValue == 5)
        { wordNumber = "fifty"; }
        if (inValue == 6)
        { wordNumber = "sixty"; }
        if (inValue == 7)
        { wordNumber = "seventy"; }
        if (inValue == 8)
        { wordNumber = "eighty"; }
        if (inValue == 9)
        { wordNumber = "ninety"; }
      }

      //if unit & ten type
      if (inType == "ut")
      {
        if (inValue == 11)
        { wordNumber = "eleven"; }
        if (inValue == 12)
        { wordNumber = "twelve"; }
        if (inValue == 13)
        { wordNumber = "thirteen"; }
        if (inValue == 14)
        { wordNumber = "fourteen"; }
        if (inValue == 15)
        { wordNumber = "fifteen"; }
        if (inValue == 16)
        { wordNumber = "sixteen"; }
        if (inValue == 17)
        { wordNumber = "seventeen"; }
        if (inValue == 18)
        { wordNumber = "eighteen"; }
        if (inValue == 19)
        { wordNumber = "nineteen"; }
      }

      return wordNumber;
    }

  }
}
