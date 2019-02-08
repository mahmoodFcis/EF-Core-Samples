using System.Collections.Generic;

namespace eCommerce.DAL
{
    public class Repository<T> : IRepository<T> where T : class

    {
        public void Add(T entity)
        {
            // fake add implementation 
        }

        public void Update(T entity)
        {
            // fake update implementation 
        }

        public void Delete(T entity)
        {
            // fake delete implementation 
        }

        public List<T> GetAll()
        {
            // fake GetAll implementation 

            return new List<T>();
        }

        public T GetById(int id)
        {

            // fake GetById implementation 
            return new List<T>().Find(t => t.Equals(id));
        }
    }
}
