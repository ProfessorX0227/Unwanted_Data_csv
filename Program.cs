using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace RemovingUnwanted
{
	class Program
	{
		//method gets rid of extra data not needed in the master.csv file
		static void Main(string[] args)
		{

			string searchone = @"LocalizedResourceName=@%SystemRoot%\system32\shell32.dll";
			string searchtwo = "[.ShellClassInfo]";
			string searchthree = @"IconResource=%SystemRoot%\system32\imageres.dll";
			string searchfour = "-21798";
			string searchfive = "-184";

			string destinationFile = @"C:\Users\xadams\Desktop\MasterData.csv";
			string outputFile = @"C:\Users\xadams\Desktop\Hello.csv";

			//gets file from downloads folder
			//string[] filePaths = Directory.GetFiles(sourceFolder, $"{TickerSymbol}.csv");


			List<String> lines = new List<string>();
			string line;
			StreamReader file = new StreamReader(destinationFile);

			while ((line = file.ReadLine()) != null)
			{
				lines.Add(line);
			}

			lines.RemoveAll(l => l.Contains(searchone));
			lines.RemoveAll(l => l.Contains(searchtwo));
			lines.RemoveAll(l => l.Contains(searchthree));
			lines.RemoveAll(l => l.Contains(searchfour));
			lines.RemoveAll(l => l.Contains(searchfive));

			using (System.IO.StreamWriter outfile = new System.IO.StreamWriter(outputFile))
			{
				outfile.Write(String.Join(System.Environment.NewLine, lines.ToArray()));
			}
		}

		}
}
