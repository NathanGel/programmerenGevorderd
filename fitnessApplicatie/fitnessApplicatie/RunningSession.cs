using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessApplicatie {
    class RunningSession {
        private int _sessieNr;
        public int SessieNr {
            get { return _sessieNr; } 
            set {
                if (value < 1) throw new Exception("Sessienummer is niet geldig");
                else _sessieNr = value; 
            } 
        }
        public DateTime Datum { get; set; }
        private int _klantNr;
        public int KlantNr {
            get { return _klantNr; }
            set {
                if (value < 1) throw new Exception("klantnummer is niet geldig");
                else _klantNr = value;
            }
        }
        private int _duur;
        public int Duur {
            get { return _duur; }
            set {
                if (value < 180 && value > 5) throw new Exception("Tijdsduur is niet geldig");
                else _sessieNr = value;
            }
        }
        private double _gemiddeldeSnelheid;
        public double GemiddeldeSnelheid {
            get { return _gemiddeldeSnelheid; }
            set {
                if (value < 5 || value > 22) throw new Exception("Gemiddelde snelheid is niet geldig");
                else _gemiddeldeSnelheid = value;
            }
        }
        public List<Interval> Interval {  get; set; } 
    }
}
