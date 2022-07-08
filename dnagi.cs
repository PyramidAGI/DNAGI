//this is the DNAGI program
using System;
using System.Collections.Generic;
using System.IO;

namespace DNAGI
{
    class DNRecord
    {
        public string key;
        public string val;
    }
    class DNAGIHelper
    {
        string path="";
        List<DNRecord> qli = new List<DNRecord>(); //quarks are stored in this list
        public DNAGIHelper()
        {
            path = Directory.GetCurrentDirectory();
            ReadQuarks();
        }
        public void ReadQuarks()
        {
            Console.WriteLine(" in ReadQuarks");
            qli.Clear();
            var sr = new StreamReader("quarks.txt");
            string line = "";
            while ((line=sr.ReadLine())!=null)
            {
                string[] word = line.Split(',');
                if (word.Length>0)
                {
                    var q = new DNRecord();
                    q.key = word[0];
                    q.val = word[1];
                    qli.Add(q); //add record from quarks file to qli
                } 
            }
            //Console.WriteLine(line);
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
            File.Copy(oldname, newname,true); //overwrite existing file
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
            //with these determine next candidate
            //this candidate can be an element, a Sent, a PSD, even a program
            //the pyramid 'landscape' (filled with smaller pyramids) leads to a candidate
            //this candidate can be filtered out using lkp tables and head-tail mechanisms
        }
        public void GetQuarks(string element)
        {
            //get the quarks associated with the element
        }
        public string CharacterizePSD(string PSDname)
        {
            //read the PSD file
            //characterize it by reading the quarks
            //and also by maybe by counting the number of lines?
            string res = "";
            try
            {
                var sr = new StreamReader(path + @"\" + PSDname);
                string line = sr.ReadLine();
                string[] word = line.Split();
                if (word.Length > 0)
                {
                    //check if element holds a quark:
                    string element = word[0];
                    foreach (DNRecord item in qli)
                    {
                        if (item.key==element) //TTD: make 'similar' subroutine
                        {
                            res = "quark detected";
                        }
                    }
                    //TTD: can we freqcount the quarks and maybe mention the top five in a summary?
                }
                sr.Close();
            }
            catch
            {
                Console.WriteLine("error: this file does not exist");
            }
            return res;
        }
        public string GetQuarksInSentence(string inp)
        {
            string res = "";
            string[] w = inp.Split();
            foreach(string item in w)
            {
                res += GetLookupBasic(item) + " ";
            }
            return res;
        }
        private string GetLookupBasic(string inp)
        {
            //TTD: let this sub change apple to fruit, and then fruit is picked up by quarks.txt
            string res = "";
            var sr = new StreamReader("inversequarks.txt");
            string line = "";
            while ((line=sr.ReadLine())!=null)
            {
                string[] word = line.Split(',');
                if (word.Length>0)
                {
                    string key = word[0];
                    if (key==inp)
                    {
                        string rightval=word[1];
                        string[] q = rightval.Split();
                        foreach(string item in q)
                        {
                            res+=item + " ";
                        }
                    }
                } 
            }
            sr.Close();
            return res;
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
            dnh.FilePopulator("test001.txt");
            dnh.CopyFile("test001.txt", "test002.txt");
            string icl = dnh.CharacterizePSD("psd001.txt");
            string quarks = dnh.GetQuarksInSentence("toshow insurance");
            Console.WriteLine("quarks detected in lkpbasic = " + quarks);
            Console.WriteLine("ICL detected in PSD is: " + icl);
        }
    }
}

//C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe dnagi.cs