using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static string lorem = "Lorem ipsum dolor sit amet consectetur adipiscing elit Quisque eu nisl vitae velit fermentum scelerisque ac id neque Nulla ornare aliquet fringilla Vivamus euismod nunc sed imperdiet ultricies ante tellus scelerisque sapien sit amet blandit risus mi non odio Morbi turpis magna dictum non pharetra eget pretium a nunc Nam gravida aliquet diam eget tristique Donec eu euismod tortor nec eleifend lacus Class aptent taciti sociosqu ad litora torquent per conubia nostra per inceptos himenaeos Proin et sagittis sapien Nulla facilisi ";

    static void Main(string[] args)
    {
        FileInfo file = new FileInfo("../../test.txt");
        while (file.Length <= 240000)
        {
            File.AppendAllText("../../test.txt", lorem);
            file = new FileInfo("../../test.txt");
        }
    }
}
