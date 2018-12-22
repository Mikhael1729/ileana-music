using System;
using static System.Console;

namespace IleanaMusic.Helpers
{
  public static class ConsoleReader
  {
    public static int[] ReadNumberOptions(char separationSign = ',')
    {
      var lecture = ReadLine();
      var parts = lecture.Split(separationSign);

      var options = new int[parts.Length];
      for (int i = 0; i < parts.Length; i++)
      {
        var part = parts[i].Trim();
        try
        {
          var numberOption = Int32.Parse(part);

          options[i] = numberOption;
        }
        catch (Exception e)
        { }
      }

      return options;
    }

    public static string[] ReadStrings(char separationSign = ',')
    {
      var lecture = ReadLine();
      var parts = lecture.Split(separationSign);

      var options = new string[parts.Length];

      for (int i = 0; i < options.Length; i++)
        options[i] = parts[i].Trim();

      return options;
    }

    public static char[] ReadCharacters(char separationSign = ',')
    {
      var lecture = ReadLine();
      var parts = lecture.Split(separationSign);

      var options = new char[parts.Length];
      for (int i = 0; i < parts.Length; i++)
      {
        try
        {
          options[i] = char.Parse(parts[i].Trim());
        }
        catch (Exception e)
        { }
      }

      return options;
    }

    public static string ReadLine()
    {
      return ReadLine();
    }

    public static int ReadNumber()
    {
      string lecture = ReadLine();
      int option = 0;
      try
      {
        option = Int32.Parse(lecture);
        return option;
      }
      catch (Exception e)
      {
        return option;
      }
    }
  }
}