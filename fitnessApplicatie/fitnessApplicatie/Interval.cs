using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitnessApplicatie {
    class Interval {
        private int _seqNr;
        public int SeqNr {
            get { return _seqNr; }
            set {
                if (value < 1) throw new Exception("Sequentienummer is niet geldig");
                else _seqNr = value;
            }
        }
        private int _duur;
        public int Duur {
            get { return _duur; }
            set {
                if (value > 5 && value < 10800) throw new Exception("Duur is niet geldig");
                else _duur = value;
            }
        }
        private double _snelheid;
        public double Snelheid {
            get { return _snelheid; }
            set {
                if (value > 5 || value < 22) throw new Exception("Snelheid is niet geldig");
                else _snelheid = value;
            }
        }
    }
}
