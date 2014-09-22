using System;
using System.IO;
using System.Text;

class ClearSolution
{
    static void Main()
    {
        Console.Write("Enter the solution path: ");
        string path = Console.ReadLine();
        if (Directory.Exists(path) == true)
        {
            string[] allProjects = Directory.GetDirectories(path);
            foreach (var folder in allProjects)
            {
                StringBuilder binPath = new StringBuilder(folder);
                StringBuilder objPath = new StringBuilder(folder);

                binPath.Append(@"\bin");
                objPath.Append(@"\obj");

                if (Directory.Exists(binPath.ToString()) == true && Directory.Exists(objPath.ToString()) == true)
                {
                    Directory.Delete(binPath.ToString(), true);
                    Directory.Delete(objPath.ToString(), true);
                }
                else
                {
                    Console.WriteLine("The directory doesn't exist!");
                }

            }
        }
    }
}
