using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TU_Challenge.Heritage
{

    public abstract class Animal
    {
        public abstract bool IsAlive { get; protected set; }
        public string Name { get; protected set; }
        protected Animal(string AnimalName)
        {
            Name = AnimalName;
        }

        public virtual void Die()
        {
            IsAlive = false;
        }

        public abstract int INT_DialogueIndex { get; protected set; }
        public abstract List<string> LIST_AnimalText { get; protected set; }
        public abstract string Crier();

        public void GetFeed()
        {
            INT_DialogueIndex++;
        }
    }
}
