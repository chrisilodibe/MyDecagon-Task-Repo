namespace Algorithm1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Words = "chisom is my name. he is from oba";

            Dictionary<string,int> collect = new Dictionary<string,int>();

            string[] words = Words.Split(" ");

            foreach (string word in words)
            {
                if (collect.ContainsKey(word))
                {
                    int value = collect[word] + 1;
                    collect[word] = value;
                }
                else
                {
                    collect.Add(word, 1);
                }
            }
            foreach (var Value in collect)
            {
                Console.WriteLine($" {Value.Key} {Value.Value}");
            }
        }
    }
}