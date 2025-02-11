namespace fitnessApplicatie
{
    class Program
    {
        static void Main()
        {
            string path = @"C:\Users\natha\Documents\insertRunning\insertRunningTest.txt";

            using (StreamReader sr = new StreamReader(path)) {
                string line;
                while ((line = sr.ReadLine()) != null) {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
