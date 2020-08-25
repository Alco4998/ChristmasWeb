using System;
using System.Collections.Generic;
using System.IO;

namespace ChristmasWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            string csv = @"../../../People.csv";
            List<Relative> Peoplefotheweb = new List<Relative>();

            using (StreamReader reader = new StreamReader(csv))
            {
                string line;
                int i = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    string[] Commit = line.Replace('\n', ' ').Split(',');
                    if(Commit[0] != "Name" || Commit[0] == string.Empty)
                    {
                        Peoplefotheweb.Add(new Relative(i, Commit[0]));
                        i++;
                    }
                }
            }

            string used = "";
            int[] array = new int[Peoplefotheweb.Count];
            Random random = new Random();

            foreach (var item in Peoplefotheweb)
            {
                bool ripX = false;

                while (!ripX)
                {
                    int rnd = random.Next(0, Peoplefotheweb.Count - 1);

                    if(!used.Contains(" " +rnd+ " ") && rnd != item.Id){
                        array[item.Id] = rnd;
                        ripX = true;

                        used += " " + rnd.ToString() + " ";

                        item.Link = rnd;
                    }

                   
                }
            }

            //Console.WriteLine();
            //Console.WriteLine();

            //for(int i = 0; i < dictionary.Count; i++)
            //{
            //    if(array[i] != 0)
            //    {
            //        dictionary[i] = array[i];
            //    }
            //}
            Console.WriteLine();

            //foreach (var item in Peoplefotheweb)
            //{
            //    Relative person = Peoplefotheweb.Find(x => x.Id == item.Link);

                //Console.WriteLine("{0} is Buying for: {1}", item.Name, person.Name);
            //    Console.WriteLine(item.ToString());
            //}

            using (StreamWriter writer = new StreamWriter(csv)) //"../../../notPeople.csv"
            {
                writer.WriteLine("Name,Sender");

                foreach (var item in Peoplefotheweb)
                {
                    Relative person = Peoplefotheweb.Find(x => x.Id == item.Link);
                    writer.WriteLine("{0},{1}", item.Name, person.Name);
                }

            }
        }
    }
}
