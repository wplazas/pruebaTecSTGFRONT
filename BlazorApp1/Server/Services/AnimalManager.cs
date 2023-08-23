using BlazorApp1.Server.Interfaces;
using BlazorApp1.Server.Model;
using BlazorApp1.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Services
{
    public class AnimalManager : IAnimal
    {

        readonly DatabaseContext _dbContext = new();
        public AnimalManager(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        
         public List<Animal> GetAnimalDetails()
        {
            try
            {
                return _dbContext.Animals.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddAnimal(Animal animal)
        {
            try
            {
                _dbContext.Animals.Add(animal);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public void UpdateAnimalDetails(Animal animal)
        {
            try
            {
                _dbContext.Entry(animal).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Animal GetAnimalData(Int16 id)
        {
            try
            {
                Animal? animal = _dbContext.Animals.Find(id);
                if (animal != null)
                {
                    return animal;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void DeleteAnimal(Int16 id)
        {
            try
            {
                Animal? animal = _dbContext.Animals.Find(id);
                if (animal != null)
                {
                    _dbContext.Animals.Remove(animal);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

   
    }
}
