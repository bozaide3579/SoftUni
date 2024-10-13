
        int campHeight = 5364;
        int everest = 8848;
        int maxDays = 5;
        int currentHeight = campHeight;
        int days = 0;

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END" || currentHeight >= everest || days > maxDays)
                break;

            string[] parts = input.Split();
            string yesNo = parts[0];
            int meters = int.Parse(parts[1]);

            if (yesNo == "Yes")
            {
                days++;
                if (days > maxDays)
                    break;
            }

            currentHeight += meters;
        }

        if (currentHeight >= everest)
        {
            Console.WriteLine($"Goal reached for {days} days!");
        }
        else
        {
            Console.WriteLine("Failed!");
            Console.WriteLine(currentHeight - campHeight);
        }

