using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class Animalerie
    {
        public event Action<Animal> OnAddAnimal;

        public List<Animal> LIST_Animal = new ();
        public void AddAnimal(Animal animal)
        {
            LIST_Animal.Add(animal);
            OnAddAnimal?.Invoke(animal);

            foreach (var an in LIST_Animal)
            {
                if (an is Poisson)
                {
                    an.Die();
                }
            }
        }

        public bool Contains(Animal AnimalToCheck)
        {
            return LIST_Animal.Contains(AnimalToCheck);
        }

        public Animal GetAnimal(int AnimalIndex)
        {
            return LIST_Animal[AnimalIndex];
        }

        public void FeedAll()
        {
            foreach (var animal in LIST_Animal)
            {
                animal.GetFeed();
            }
        }
        

    }
}
