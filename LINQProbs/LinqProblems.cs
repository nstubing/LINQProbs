using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace LINQProbs
{
    class LinqProblems
    {
        List<string> words = new List<string>() { "the", "bike", "this", "teeth", "mathematics" };
        List<string> names = new List<string>() { "Mike", "Dan", "Scott", "Nick", "Mike" };
        List<string> classGrades = new List<string>()
        {
        "80,100,92,89,65",
        "93,81,78,84,69",
        "73,88,83,99,64",
        "98,100,66,74,55"
        };


        public LinqProblems()
        {
           // ContainsTh(words);
            //DuplicateNames(names);
            ClassAverage(classGrades);
        }
        public bool ContainsTh(List<string> words)
        {
            bool wordsContainTh=false;
            List<string> wordsWithTh = words.FindAll(w=>w.Contains("%th%"));
            if (wordsWithTh.Count > 0)
            {
                wordsContainTh = true;
            }
            foreach(string word in wordsWithTh)
            {
                Console.WriteLine(""+word);
            }
            return wordsContainTh;
            
        }

        public List<string> DuplicateNames(List<string> names)
        {
            var noDupes = names.Distinct().ToList();
            foreach (string name in noDupes)
            {
                Console.WriteLine("" + name);
            }
            return noDupes;
        }

        public double ClassAverage(List<string> studentGrades)
        {
            var studentSplit = studentGrades.Select(s => s.Split(',')).Select(s => s.Select(g => Int32.Parse(g)).ToArray());
            var studentOrder = studentSplit.Select(s => s.OrderBy(g => g).ToArray());
            var studentGradesLess = studentOrder.Select(s=> s.Skip(1).ToArray());
            var studentGradeAverage = studentGradesLess.Select(s=> s.Average(g=>g)).ToArray();
            var classAverage = studentGradeAverage.Average(s => s);
            return classAverage;



           
        }

        public string LetterCount(string word)
        {
            string[] letters = word.Split().ToArray();
            var orderletters = letters.OrderBy(l => l);
            var noDupes = orderletters.Distinct().ToArray();
            string letterString = "";
            for (int i =0; i<noDupes.Count();i++)
            {
                int repeat = 1;
                for (int j =0; j<letters.Count();i++)
                {
                    
                    if (noDupes[i] ==letters[j])
                    {
                        repeat++;
                    }
                }
                letterString += noDupes[i] + repeat;
            }
            Console.WriteLine(letterString);
            return letterString;
        }
    }
}
