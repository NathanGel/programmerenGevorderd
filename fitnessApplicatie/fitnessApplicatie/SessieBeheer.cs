using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessApplicatie {
    class SessieBeheer {
        public SessieBeheer() {
            Dictionary<int, List<RunningSession>> klantNr = new Dictionary<int, List<RunningSession>> { };
            Dictionary<DateTime, List<RunningSession>> datum = new Dictionary<DateTime, List<RunningSession>> { };
        }
        public void GeefSessiesKlant(string klantNr) {
            Console.Clear();
        }
        public void GeefSessiesDatum(DateTime datum) {
            Console.Clear();
        }
    }
}
 