using AnimalsAPI.Entities;

namespace AnimalsAPI.Repos
{
    public class AnimalRepo : IAnimalsRepo
    {
        private List<Animal> _animals;

        public AnimalRepo()
        {
            _animals = PopulateAnimalData();
        }

        public Animal CreateAnimal(Animal animal)
        {
            animal.Id = _animals.Max(x => x.Id) + 1;
            _animals.Add(animal);
            return animal;
        }

        public void DeleteAnimal(int id)
        {
            _animals.Remove(GetByID(id));
        }

        public List<Animal> GetAll()
        {
            return _animals;
        }
        public Animal GetByID(int id)
        {
            Animal animal = _animals.Find(x => x.Id == id);
            return animal;
        }

        public Animal UpdateAnimal(Animal animal)
        {
            Animal existingAnimal = _animals.FirstOrDefault(x => x.Id == animal.Id);
            if (existingAnimal != null)
            {
                existingAnimal.Name = animal.Name;
                existingAnimal.Type = animal.Type;
            }
            return existingAnimal;
        }

        private List<Animal> PopulateAnimalData()
        {
            return new List<Animal>
            {
                new Animal
                {
                    Id = 1,
                    Name = "Zebra",
                    Type = "Pray"
                },
                new Animal
                {
                    Id = 2,
                    Name = "Tiger",
                    Type = "Predator"
                },
                new Animal
                {
                    Id = 3,
                    Name = "Lion",
                    Type = "Predator"
                },
            };
        }

    }
}

