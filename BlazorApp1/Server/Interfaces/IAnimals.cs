using BlazorApp1.Shared.Model;
namespace BlazorApp1.Server.Interfaces
{
    public interface  IAnimal
    {
        public List<Animal> GetAnimalDetails();
        public void AddAnimal(Animal animal);
        public void UpdateAnimalDetails(Animal animal);
        public Animal GetAnimalData(Int16 id);
        public void DeleteAnimal(Int16 id);

    }
}
