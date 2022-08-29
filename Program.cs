using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JsonToJtk2d
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
				string path;
				if (args.Length != 0)
				{
					Console.WriteLine("Launch args given, getting directory from launch args");
					path = args[0];
				}
				else
				{
					Console.WriteLine("Launch args not given, enter the target direcotry: ");
					path = Console.ReadLine();
				}
				if (Directory.Exists(path))
				{
					Console.WriteLine("Directory found, processing files...");
					string[] files = Directory.GetFiles(path, "*.json", SearchOption.AllDirectories);
					Console.WriteLine("Found " + files.Length.ToString() + " files.");
					Console.WriteLine("Starting the rename...");
					foreach (string file in files)
					{
						File.Move(file, file.Substring(0, file.LastIndexOf(".")) + ".jtk2d");
					}
				}
				else
				{
					Console.WriteLine("Directory not found, closing.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
			Console.WriteLine("Done!");
		}
    }
}
