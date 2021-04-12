using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class TextFileReadWriter
{
    private string path;
    private string pathCat;
    private int version = 10001;

    public TextFileReadWriter()
    {
        path = Directory.GetCurrentDirectory();
        WriteDataToFile("Test Data", "Test");
        ReadDataFromFile("Test");
    }

    public void PrintDirectory()
    {
        Console.WriteLine("Path: " + Path.GetDirectoryName(path));
        Console.WriteLine("Path string: " + path);
    }

    public void CheckCat()
    {
        pathCat = Directory.GetCurrentDirectory();
        pathCat += "\\Cat.txt";
        if (File.Exists(path))
        {
            StreamReader read = new System.IO.StreamReader(pathCat);
            string line = read.ReadLine();
            if (Int32.Parse(line) < version)
            {
                // update?
            }
        }
        else
        {
            WriteDataToFile(version.ToString(), "Cat");
        }
    }

    public string ReadDataFromFile(string name)
    {
        string line = "To be modified";
        try
        {
            string pathing = path + "\\" + name + ".txt";
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(pathing);

            //Read the first line of text
            line = sr.ReadLine();

            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the lie to console window
                Console.WriteLine(line);
                //Read the next line
                line = sr.ReadLine();
            }

            //close the file
            sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }
        return line;
    }

    public void WriteDataToFile(string data, string name)
    {
        try
        {
            //Open the File
            string pathing = path + "\\" + name + ".txt";
            File.Delete(pathing);
            StreamWriter sw = new StreamWriter(pathing, true, Encoding.ASCII);

            sw.WriteLine(data);

            //close the file
            sw.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }
    }

    public void WriteDataToFile(List<string> dataList, string name)
    {
        try
        {
            //Open the File
            string pathing = path + "\\" + name + ".txt";
            File.Delete(pathing);
            StreamWriter sw = new StreamWriter(pathing, true, Encoding.ASCII);
            foreach (string data in dataList)
            {
                sw.WriteLine(data);
            }

            //close the file
            sw.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }
    }

    public void DeleteFile(string name)
    {
        string pathing = path + "\\" + name + ".txt";
        File.Delete(pathing);
    }

}
