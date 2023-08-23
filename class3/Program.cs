namespace class3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*create a simple phonebook program that stores name and phone number .
                you allow the user to look up phone number by entering a name*/

            Dictionary<string, string > Phonebook = new Dictionary<string, string>();

            string enteredName = Console.ReadLine();

            Phonebook.Add("chisom", "09031472109");
            Phonebook.Add("Chioma", "08122446657");

            bool numberFound = false;
            foreach (var phone in Phonebook)
            {
                if (phone.Key == enteredName)
                {
                    Console.WriteLine($"The phone number for {phone.Key} is {phone.Value}");
                    numberFound = true;
                }
                
                //else 
                //{
                //    Console.WriteLine($"The {enteredNumber} is not found.");
                //}
 
            }
            if (!numberFound)
            {
                Console.WriteLine($"Phone number not Found.");
            }

        }
    }
}