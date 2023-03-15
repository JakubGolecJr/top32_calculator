namespace battlebots_top32_calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> top32list = new List<string>();
            List<pairDuel> top32heats = new List<pairDuel>();

            string select;


            PrintMenu();

            select = Console.ReadLine();

            while (select != "5")
            {
                IfSelectCorrect(select);

                if(select == "1" || select == "2" || select == "3" || select == "4")
                {
                    MainMenu(select, top32list, top32heats);
                }

                PrintMenu();
                select = Console.ReadLine();
                Console.Clear();
            }

            Console.WriteLine("Closing...");
        }

        static string IfSelectCorrect(string select)
        {
            if (select == "1" || select == "2" || select == "3" || select == "4")
            {
                return select;
            }
            else
            {
                Console.WriteLine("You chose invalid option. Please choose correct option and type the number.");
                return select;
            }
        }

        static void MainMenu(string select, List<string> top32list, List<pairDuel> top32heats)
        {
            switch (select)
            {
                case "1":
                    {
                        for(int i = 0;  i <= 32; i++)
                        {
                            Console.Clear();
                            PrintList(top32list);

                            Console.Write("Type " + (i+1) + " spot: ");
                            string currentSpot = Console.ReadLine();

                            if (currentSpot == "quit") break;

                            top32list.Add((i + 1) + " " + currentSpot);
                        }
                    }
                    break;

                case "2":
                    {
                        PrintList(top32list);
                    }
                    break;

                case"3":
                    {
                        ClearSpots(top32list);
                    }
                    break;
                case "4":
                    {
                        Generate32Tree(top32list, top32heats);
                    }
                    break;
            }
        }

        static List<pairDuel> Generate32Tree(List<string> top32list, List<pairDuel> top32heats)
        {
            int bottom = top32list.Count - 1;

            for (int top = 0; top < top32list.Count/2; top++)
            {
                pairDuel pair = new pairDuel();
                pair.contender1 = top32list[top];
                pair.contender2 = top32list[bottom];

                top32heats.Add(pair);

                bottom--;
            }

            PrintList(top32heats);

            return top32heats;
        }

        static List<string> ClearSpots(List<string> top32list)
        {
            top32list.Clear();

            return top32list;
        }

        static void PrintList(List<string> top32list)
        {
            if (top32list.Count == 0)
            {
                Console.WriteLine("empty list!");
            }
            else
            {
                foreach (string spot in top32list) 
                {
                    Console.WriteLine(spot);
                }
            }

            Console.WriteLine();
        }

        static void PrintList(List<pairDuel> top32list) //przeciazenie dla listDuel
        {
            if (top32list.Count == 0)
            {
                Console.WriteLine("empty list!");
            }
            else
            {
                foreach (var spot in top32list)
                {
                    Console.WriteLine(spot.contender1 + "\nvs" + "\n" + spot.contender2);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }

        static void PrintMenu()
        {
            Console.WriteLine("Championship - Top32 Calculator");
            Console.WriteLine("\n1. Type selection spots\n2. Show current selection spots\n3. Clear selection spots\n4. Proceed to Top 32 bracket\n5. Exit");
        }

        public void SaveFile(string filename)
        {

        }

        struct pairDuel
        {
            public string contender1;
            public string contender2;
        }
    }
}