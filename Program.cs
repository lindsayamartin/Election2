using System;
using System.Collections.Generic;
using System.Linq;

namespace Election
{
    class Program
    {
        static void Main(string[] args)
        {
            int Number_Canidites = int.Parse(Console.ReadLine());
            string[] Candate_List = new string[Number_Canidites];
            string[] Party_List = new string[Number_Canidites];
            string maxKey;

            for (int i = 0; i < Number_Canidites; i++)
            {
                Candate_List[i] = Console.ReadLine().ToUpper();
                string party = Console.ReadLine();
                if (party.Length > 0)
                {
                    Party_List[i] = party;
                }
                else
                {
                    Party_List[i] = "independant";
                }
            }

            int Number_Votes = int.Parse(Console.ReadLine());
            string[] Votes = new string[Number_Votes];
            Dictionary<string, int> Vote_Count = new Dictionary<string, int>();

            for (int i = 0; i < Number_Votes; i++)
            {
                Votes[i] = Console.ReadLine().ToUpper();
            }

            foreach (string vote in Votes)
            {
                if (Vote_Count.ContainsKey(vote))
                {
                    Vote_Count[vote] += 1;
                }
                else
                {
                    Vote_Count.Add(vote, 1);
                }
            }

            int maxVote = Vote_Count.Values.Max();
            int x = 0;
            foreach (var vote in Vote_Count)
            {
                if (vote.Value == maxVote)
                {
                    x++;
                }
            }
            if (x < 2)
            {

                foreach (var vote in Vote_Count)
                {
                    if (vote.Value == maxVote)
                    {
                        maxKey = vote.Key;
                        x = Array.IndexOf(Candate_List, maxKey);
                        string Winner = (string)Party_List.GetValue(x);
                        Console.WriteLine(Winner);
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("tie");
            }
        }
    }
}