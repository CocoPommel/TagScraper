using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TagScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile;
            string searchTerm;
            string[] input;
            string[] ignore;
            List<string> output = new List<string>();

            Console.WriteLine("Enter name of text file with derpicdn links:");
            inputFile = Console.ReadLine();
            if (inputFile.Length > 3 && !inputFile.Substring(inputFile.Length - 4).Equals(".txt"))
            {
                inputFile += ".txt";
            }
            input = File.ReadAllLines(inputFile);

            Console.WriteLine("Enter tag to search for:");
            searchTerm = Console.ReadLine();

            if(searchTerm.Length > 5 && searchTerm.Substring(0, 6) != "artist")
            {
                searchTerm = " " + searchTerm; //the tags have spaces before them except for the first, which is usually the artist tag
            }

            Console.WriteLine("Enter any key to start. Alternatively, if you want to strip certain strings from output, enter name of text file containing strings to ignore:");

            try
            {
                string temp = Console.ReadLine();
                if (temp.Length > 3 && !temp.Substring(temp.Length - 4).Equals(".txt"))
                {
                    temp += ".txt";
                }
                ignore = File.ReadAllLines(temp);
                Console.WriteLine("Stripping outputs from " + temp + ".");
            }
            catch (Exception e)
            {
                ignore = new string[] { };
            };

            Console.WriteLine("Searching. If the input is large, this may take a while.");

            using (WebClient client = new WebClient())
            {
                for (int i = 0; i < input.Length; i++)
                {
                    string temp = input[i]; // so we only pull the string once
                    string[] tempsplit = temp.Split('/'); //would have to do this twice otherwise
                    if(temp.Length < 31)
                    {
                        continue; //so non-websites don't crash shit
                    }
                    if (temp.Substring(0, 5).Equals("http:")) //make sure all of them are https
                    {
                        temp = "https:" + temp.Substring(5);
                    }
                    if (temp.Substring(8, 22).Equals("derpicdn.net/img/view/")) //after formatting, if they're a derpi link, add the json so we get info
                    {
                        string temp2 = new string(tempsplit[tempsplit.Length - 1].Split('.')[0].TakeWhile(c => !Char.IsLetter(c)).ToArray()); //gets the ID at the end and strips out any string because some phenomenal troglodyte at derpibooru decided to make derpicdn links work with arbitrary strings after the ID
                        temp2 = "https://derpibooru.org/" + temp2 + ".json"; //turn the link into derpibooru header plus the last part of the cdn url, with file extension removed
                        DerpiImage img = JsonConvert.DeserializeObject<DerpiImage>(client.DownloadString(temp2)); //need the json to get the tags
                        string tags = img.tags;

                        if(tags != null && tags.Split(',').Contains<string>(searchTerm) && !ignore.Contains<string>(temp))
                        {
                            output.Add(temp);
                        }
                    }
                }
            }

            if (File.Exists("output.text"))
            {
                File.Delete("output.text"); //get rid of previous output if it was still there
            }
            File.WriteAllLines("output.txt", output.ToArray<string>());

            Console.WriteLine("[](/rdsalute) All done. Press any key to exit");
            Console.ReadKey();
        }
    }
}