using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ClassLibraryGenTrack
{
    public class CSVFile
    {
        private String _header;
        private static string _footer;
        private String _fileName;
        private String _Line200;
        private String[] data;
        private StreamWriter writer;

        public CSVFile(string header, string footer, string Line200)
        {
            _header = header;
            _footer = footer;
            _Line200 = Line200;
        }

        public String Header
        {
            get => _header;
            set
            {
                _header = value;
            }
        }

        public String Footer
        {
            get => _footer;
            set
            {
                _footer = value;
            }
        }

        public String[] Data
        {
            get => data;
            set
            {
                data = value;
            }
        }

        public String FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
            }
        }

        public void FileNameCreater(string line)
        {
            string result = "";
            int i = 4;
            char[] linearray = line.ToCharArray();
            while (linearray[i] != ',') 
            {
                result = result + linearray[i];
                i++;
            }
            _fileName=  result + ".csv";
        
         }

        public void closefile()
        {
            writer.Close();
        }

        public void openfileforwriting()
        {
            writer = new StreamWriter(_fileName);
            writer.WriteLine(_header);
            writer.WriteLine(_Line200);

        }

        public void writetofile(String line)
        {
            writer.WriteLine(line);
        }
    }
}