 static void Main(string[] args)
        {
            foreach (var item in GetNumbers())
            {
                Console.WriteLine(item);
            }

        }
        static IEnumerable<int> GetNumbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
