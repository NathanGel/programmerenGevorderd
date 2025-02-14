using System.Xml;

namespace fitnessApplicatie
{
    class Program
    {
        static void Main()
        {
            const string path = @"C:\Users\natha\programmerenGevorderd\programmerenGevorderd\fitnessApplicatie\insertRunningTest.txt";
            ImportBestand.BestandImporter(path);
            //Sessiebeheer aanmaken
            SessieBeheer sB = new SessieBeheer();
            //Keuzemenu met 2 opties uitbeelden otpie 1 Klant optie 2 datum
            while (true) {
                Console.WriteLine("     MAAK EEN KEUZE     ");
                Console.WriteLine("|----------------------|");
                Console.WriteLine("|1: zoek op klantnummer|");
                Console.WriteLine("|2: zoek op datum      |");
                Console.WriteLine("|3: stoppen            |");
                Console.WriteLine("|----------------------|");
                Console.Write("Keuze: ");
                string keuze = Console.ReadLine();
                if (keuze == "1") {
                    Console.WriteLine("Geef het klantnummer");
                    string klantnr = Console.ReadLine();
                    sB.GeefSessiesKlant(klantnr);
                } else if (keuze == "2") {
                    bool isDatum = false;
                    DateTime datum;
                    while (!isDatum) {
                        try {
                            Console.Write("Geef de datum (Formaat: dd-mm-yyyy): ");
                            isDatum = DateTime.TryParse(Console.ReadLine(), out datum);
                            if (isDatum) {
                                sB.GeefSessiesDatum(datum);
                                break;
                            }
                        } catch (Exception e) {
                            Console.WriteLine($"{e}\nGeef een correcte datum in.");
                        }
                    }
                } else if (keuze == "3") {
                    return;
                } else {
                    Console.Clear();
                    Console.WriteLine("Ongeldige keuze, Probeer opnieuw.\n");
                }
            }
        }
    }
}
