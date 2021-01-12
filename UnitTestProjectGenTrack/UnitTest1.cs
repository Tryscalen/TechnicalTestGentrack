using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryGenTrack;
using System.IO;

namespace UnitTestProjectGenTrack
{
    [TestClass]
    public class UnitTest1
    {
        CSVFile _outputObj;
        MainFile _inputObj;
        String Line200, Header, Footer;

        [TestInitialize]
        public void init()
        {
            Line200 = "200,5212121212,5679,452,109";
            Header = "HeaderLine";
            Footer = "FooterLine";
            _outputObj = new CSVFile(Header, Footer, Line200);
            _inputObj = new MainFile();
        }


        [TestMethod]
        public void FileNameCreator()
        {
            _outputObj.FileNameCreater(Line200);
            Assert.AreEqual("5212121212.csv", _outputObj.FileName);

        }

        [TestMethod]
        public void FindFooter()
        {
            _inputObj.FindFooter();
            Assert.AreEqual("900", _inputObj.footerdata);

        }

        [TestMethod]
        public void openreaderfile()
        {
            String line = "";
            Boolean found = false;
            StreamReader readerMain = _inputObj.readerobj;
            while (readerMain.Peek() != -1)
            {
                line = readerMain.ReadLine();
                if (line.Contains("<CSVIntervalData>"))
                {
                    //cout<<"Found the line needed"<<endl;
                    found = true;
                    break;
                }
            }
            Assert.AreEqual(found, true);
            Assert.AreEqual(line.Contains("<CSVIntervalData>"), true);
            

        }

        [TestMethod]
        public void CSCVConstrutor1()
        {
            Assert.AreEqual(Header, _outputObj.Header);
        }

        [TestMethod]
        public void CSCVConstrutor2()
        {
            Assert.AreEqual(Footer, _outputObj.Footer);
        }
        

       

    }
}
