using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class Chien : Animal
    {
        public override bool IsAlive { get; protected set; }

        public override List<string> LIST_AnimalText { get; protected set; } = new List<String>()
        {
            "Ouaf (j'ai faim)",
            "Ouaf (viens on joue ?)",
        };
        public override int INT_DialogueIndex { get; protected set; }  = 0;
        
        public override string Crier()
        {
            return LIST_AnimalText[INT_DialogueIndex];
        }
        public Chien(string AnimalName) : base(AnimalName)
        { }
    }
}
