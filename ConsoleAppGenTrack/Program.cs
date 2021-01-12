using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryGenTrack;
using System.IO;

namespace ConsoleAppGenTrack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting main program\n");
            MainFile main = new MainFile();
            StreamReader readerMain = main.readerobj;
            main.FindFooter();
            String line;
            Boolean found = false;
            Boolean goaround = true;
            Console.WriteLine("Set up top veriables and starting to read from file to find interval data\n");
            while(readerMain.Peek() != -1)
            {
                line = readerMain.ReadLine();
                if (line.Contains("<CSVIntervalData>"))
                {
                    //cout<<"Found the line needed"<<endl;
                    found = true;
                    break;
                }
            }
            Console.WriteLine("Interval data found\n");
            if(found)
            {
                line = readerMain.ReadLine();
                main.headerdata = line;
                line = readerMain.ReadLine();
                while (goaround)
                {
                    Console.WriteLine("Go round while loop entered\n");
                    String datasettop = "";
                    
                    if ((line[0] == '2') && (line[1] == '0') && (line[2] == '0'))
                    {
                        datasettop = line;
                    }
                    Console.WriteLine("data set top set");
                    CSVFile output = new CSVFile(main.headerdata, main.footerdata, datasettop); // if this doesnt work then create a list of these and then itterate through them depending on how many go arounds in the while loop
                    Console.WriteLine("csv output file class instance created");
                    output.FileNameCreater(datasettop);
                    output.openfileforwriting();
                    line = readerMain.ReadLine();
                    Console.WriteLine("Above the loop to add 300 rosw to file");
                    while ((line[0] != 2) || (line[0] != 9))
                    {//printing out all the 300 rows until reaching a 200 or 900 row
                        output.writetofile(line);
                        line = readerMain.ReadLine();
                        if (line[0] == '2') { break; }
                        if (line[0] == '9') { break; }

                    }
                    Console.WriteLine("300 line adding loop complete");
                    if (line[0] == '9')
                    {//not looping if next line is 900 signalling end of data set 
                        goaround = false;
                    }
                    else
                    {
                        goaround = true; // loop again as there is more data to be put into CSV's
                    }
                    output.writetofile(main.footerdata);
                    output.closefile();


                }


            } else
            {
                System.Environment.Exit(10); // never found file
            }
            main.closereadingfile();
            Console.WriteLine("Complete, awaiting final key push to close");
            Console.ReadKey();



        }
    }
}
