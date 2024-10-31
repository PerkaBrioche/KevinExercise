using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace TU_Challenge.Heritage
{
    public class Chat : Animal
    {
        public override bool IsAlive { get; protected set; }

        public override List<string> LIST_AnimalText { get; protected set; } = new List<string> 
        {
            "Miaou (j'ai faim)",
            "Miaou (c'est bon laisse moi tranquille humain)", 
            "Miaou (Le poisson était bon)"
        };

        public override int INT_DialogueIndex { get; protected set; } = 0;
        public int Pattes { get; protected set; } = 4;
        public event Action OnDie;
        public override void Die()
        {
            OnDie?.Invoke();
        }
        
        public override string Crier()
        {
            return LIST_AnimalText[INT_DialogueIndex];
        }

        public Chat(string AnimalName) : base(AnimalName)
        { 
        }
    }
}
