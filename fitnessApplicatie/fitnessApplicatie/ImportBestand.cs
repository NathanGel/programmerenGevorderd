using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace fitnessApplicatie {
    class ImportBestand {
        public static void BestandImporter (string path){
            List<RunningSession> sessions = new List<RunningSession>();

            using (StreamReader sr = new StreamReader(path)) {
                string line;
                while ((line = sr.ReadLine()) != null) {
                    ValideerTekst(line, sessions);
                }
            }
        }
        public static void ValideerTekst(string input, List<RunningSession> sessions) {
            const string patroon = @"\((.*?)\)";
            Match match = Regex.Match(input, patroon);
            if (match.Success) {
                string[] splitWaarden = match.Groups[1].Value.Split(',');
                foreach(var splitwaarde in splitWaarden) {
                    Console.WriteLine(splitwaarde);
                }
                if (splitWaarden.Length < 8) {
                    Console.WriteLine("fout: niet genoeg waarden");
                    return;
                }

                bool isGetal = int.TryParse(splitWaarden[0], out int sessieNr);
                if (!isGetal) {
                    Console.WriteLine($"fout: sessieNr ({splitWaarden[0]}) is ongeldig");
                    return;
                }

                string cleanedDate = splitWaarden[1].Replace("'", "");
                bool isDatum = DateTime.TryParseExact(cleanedDate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datum);
                if (!isDatum) {
                    Console.WriteLine($"fout: datum ({cleanedDate}) is ongeldig");
                    return;
                }

                bool isKlantNr = int.TryParse(splitWaarden[2], out int klantNr);
                if (!isKlantNr) {
                    Console.WriteLine($"fout: klantNr ({splitWaarden[2]}) is ongeldig");
                    return;
                }

                bool isTrainingsDuur = int.TryParse(splitWaarden[3], out int trainingsDuur);
                if (!isTrainingsDuur) {
                    Console.WriteLine($"fout: trainingsDuur ({splitWaarden[3]}) is ongeldig");
                    return;
                }

                bool isGemiddeldeSnelheid = double.TryParse(splitWaarden[4], out double gemiddeldeSnelheid);
                if (!isGemiddeldeSnelheid) {
                    Console.WriteLine($"fout: gemiddeldeSnelheid ({splitWaarden[4]}) is ongeldig");
                    return;
                }

                bool isSequentieNummer = int.TryParse(splitWaarden[5], out int sequentieNummer);
                if (!isSequentieNummer) {
                    Console.WriteLine($"fout: sequentieNummer ({splitWaarden[5]}) is ongeldig");
                    return;
                }

                bool isIntervalDuur = int.TryParse(splitWaarden[6], out int intervalDuur);
                if (!isIntervalDuur) {
                    Console.WriteLine($"fout: intervalDuur ({splitWaarden[6]}) is ongeldig");
                    return;
                }

                bool isSnelheidInterval = double.TryParse(splitWaarden[7], out double snelheidInterval);
                if (!isSnelheidInterval) {
                    Console.WriteLine($"fout: snelheidInterval ({splitWaarden[7]}) is ongeldig");
                    return;
                }

                Console.WriteLine($"✅ SessieNr: {sessieNr}, Datum: {datum}, KlantNr: {klantNr}, TrainingsDuur: {trainingsDuur}, Gemiddelde Snelheid: {gemiddeldeSnelheid}, SequentieNummer: {sequentieNummer}, IntervalDuur: {intervalDuur}, SnelheidInterval: {snelheidInterval}");
                // Parsing successful, continue processing...
                RunningSession r = new RunningSession();
                r.SessieNr = sessieNr;
                r.Datum = datum;
                r.KlantNr = klantNr;
                r.Duur = trainingsDuur;
                r.GemiddeldeSnelheid = gemiddeldeSnelheid;

                Interval i = new Interval();
                i.SeqNr = sequentieNummer;
                i.Duur = intervalDuur;
                i.Snelheid = snelheidInterval;
          
                //r.Interval = i;
                sessions.Add(r);
            }
        }
    }
}
