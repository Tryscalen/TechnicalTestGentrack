using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ClassLibraryGenTrack
{
	public class MainFile
	{
		private const String FileName = "testfile.txt";
		private StreamReader reader;
		private String footer, header;
		public MainFile()
        {
            try
            {
                reader = new StreamReader(FileName);

            } catch (IOException e)
            {
                Console.WriteLine("Error opening file");
                Console.WriteLine(e.Message);

            }
            
		}

        public StreamReader readerobj
        {
            get => reader;
        }

        public String footerdata
        {
            get => footer;
            set
            {
                footer = value;
            }
        }

        public String headerdata
        {
            get => header;
            set
            {
                header = value;
            }
        }

        public void FindFooter()
        {
			StreamReader readerfooter = new StreamReader(FileName);
			string toss;
			while (readerfooter.Peek()!=-1)
            {
				toss = readerfooter.ReadLine();
				if ((toss[0] == '9') && (toss[1] == '0') && (toss[2] == '0'))
				{
					footer = toss;
					break;
				}
			}
			readerfooter.Close();
		}

		public void closereadingfile()
        {
			reader.Close();
		}




    }
}