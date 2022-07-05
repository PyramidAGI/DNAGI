//this is the DNAGI program
using System;
using System.Collections.Generic;
using System.IO;

namespace DNAGI
{
    class DNAGIHelper
    {
        string path="";
        public DNAGIHelper()
        {
            path = Directory.GetCurrentDirectory();
        }
        public void Test()
        {
            Console.WriteLine(" in helper test");
            var sr = new StreamReader("psd001.txt");
            string line = sr.ReadLine();
            Console.WriteLine(line);
            sr.Close();
        }
        public void CalculateICL(string type)
        {
            //depending on type, calculate information content level
            //get list of all files in directory
            string [] fileEntries = Directory.GetFiles(path);
            foreach(string fileName in fileEntries)
                Console.WriteLine(fileName);
            Console.WriteLine(" ICL is : " + fileEntries.Length);
            //ICL value is transformed to keywords using lkp table
            //these keywords are then used for filtering
        }
        public void CalculateDelta(string type)
        {
            //depending on type:
            //calculate using vector between actual and normal?
            //delta value is transformed to keywords using lkp table
            //these keywords are then used for filtering
        }
        public void FilePopulator(string filename)
        {
            var sw = new StreamWriter(path + @"\" + filename);
            sw.WriteLine("empty");
            sw.Close();
        }
        public void CopyFile(string oldname, string newname)
        {
            File.Copy(oldname, newname);
        }
        public void Populator()
        {
            //uses CopyFile and Filepopulator
            //in combination with a lkpadd table
            //to position the PSDs in a 'landscape'
        }
        public void GetNextCandidate()
        {
            //apply telescope variables:
            //what is the normal, the ICL, the delta, the optimization, TEECL? 
            //-> with these determine next candidate
            //this candidate can be an element, a Sent, a PSD, even a program
            //the pyramid 'landscape' (filled with smaller pyramids) leads to a candidate
            //this candidate can be filtered out using lkp tables and head-tail mechanisms
        }
        public void GetQuarks(string element)
        {
            //get the quarks associated with the element
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string message = "Hello World for DNAGI";
            Console.WriteLine(message);
            var dnh = new DNAGIHelper();
            dnh.CalculateICL("");
            dnh.Test();
            dnh.FilePopulator("test001.txt");
            dnh.CopyFile("test001.txt", "test002.txt");
        }
    }
}

//C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe dnagi.cs