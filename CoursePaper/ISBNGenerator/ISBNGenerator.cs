using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class ISBNGenerator
{
    static Random randomGen = new Random();
    static string GenerateISBN()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("978-");
        for (int i = 0; i < 3; i++)
        {
            sb.Append(randomGen.Next(0, 10));
        }
        sb.Append('-');
        sb.Append(randomGen.Next(0, 10));
        sb.Append(randomGen.Next(0, 10));
        sb.Append('-');
        for (int i = 0; i < 4; i++)
        {
            sb.Append(randomGen.Next(0, 10));
        }
        sb.Append('-');
        sb.Append(randomGen.Next(0, 10));
        return sb.ToString();
    }
    [STAThread]
    static void Main()
    {
        string isbn = GenerateISBN();
        Console.WriteLine(isbn);
        System.Windows.Forms.Clipboard.SetText(isbn);
        string pattern = "(978|979)[ |-][0-9]{1,5}[ |-][0-9]{1,7}[ |-][0-9]{1,7}[0-9]{1}";
        Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
    }
}
