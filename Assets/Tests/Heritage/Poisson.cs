using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class Poisson : Animal
    {
        public override bool IsAlive { get; protected set; }

        public override List<String> LIST_AnimalText { get; protected set; } = new List<String>()
        {
            "",
            "",
        };
        public override int INT_DialogueIndex { get; protected set; }
        public override string Crier()
        {
            return "";

            // if (Eat)
            // {
            //     return FeedText;
            // }
            // return HungryText;
        }

        public Poisson(string AnimalName) : base(AnimalName)
        {
        }
    }
}
