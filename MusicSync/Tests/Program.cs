using System;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using System.Collections.Generic;
using HundredMilesSoftware.UltraID3Lib;

class Program
{

    static void Main()
    {

        string sourceFile = "D:\\en_windows_8_1_x64_dvd_2707217.iso";
        string destFile = "E:\\en_windows_8_1_x64_dvd_2707217.iso";
        FileSystem.CopyFile(sourceFile, destFile, UIOption.AllDialogs);

        Console.WriteLine(File.Exists("Computer\\GT-i9300\\Card"));

        UltraID3 mp3TagReader = new UltraID3();
        mp3TagReader.Read(@"This PC\Наско Маринов (GT-I930\Card\Music\01 - W.F.O..mp3");
        Console.WriteLine(mp3TagReader.Title);
        using (StreamWriter sw = File.AppendText("D:\\result.txt"))
        {
            sw.Write(mp3TagReader.Title);
        }
    }
}

