using AnimalsAPI.Entities;

namespace AnimalsAPI.Repos
{
    public interface IAnimalsRepo
    {
        List<Animal> GetAll();
        Animal GetByID(int id);
        Animal CreateAnimal(Animal animal);
        Animal UpdateAnimal(Animal animal);
        void DeleteAnimal(int id);

    }
}
