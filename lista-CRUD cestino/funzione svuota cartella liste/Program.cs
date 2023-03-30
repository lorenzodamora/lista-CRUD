using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace funzione_svuota_cartella_liste
{
	internal class Program
	{
		static void Main()
		{
			Console.WriteLine("Eliminare tutte le liste? \nChiudere per non farlo, doppio invio per cancellare");
			Console.ReadKey(true);
			Console.Write("1/2");
            Console.ReadKey(true);

			string path = Path.GetFullPath(".");
			for (int i = 3; i > 0; i--) 
				path = Path.GetDirectoryName(path);
			path += @"\liste";
			try
			{ //cancella anche \liste
				Directory.Delete(path, true);
			}
			catch (IOException e)
			{
				Console.WriteLine(LineNumber() + e.Message);
			}

			Directory.CreateDirectory(path); // la ricrea

			Console.Write("\r   \n!! liste cancellate !!\n\n\n\n");
		}

		static int LineNumber([System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0)
		{
			return lineNumber;
		}
	}
}
