using System;
using System.Collections.Generic;
using System.Linq;
using WpfTask10.Services;
using WpfTask10.Util;

namespace WpfTask10.Models
{
    public class UserRepository : IRepository<UserModel>
    {
        private readonly List<UserModel> users = new List<UserModel>();

        public UserRepository()
        {
            Load();
        }

        public UserModel Add(UserModel item)
        {
            int id = users.Count + 1;

            for (int i = 0; i < users.Count; i++)
            {
                users[i].Id = i + 1;
            }

            item.Id = id;
            users.Add(item);

            Save();
            CollectionChanged?.Invoke();
            return item;
        }

        public void Update(UserModel item)
        {
            users[item.Id - 1] = item;
            Save();
            CollectionChanged?.Invoke();
        }

        public List<UserModel> Get()
        {
            return (from user in users select user)
                   .ToList();
        }

        public UserModel Get(int id)
        {
            return users[id - 1];
        }

        public void Remove(int id)
        {
            users.RemoveAt(id - 1);
            for (int i = 0; i < users.Count; i++)
            {
                users[i].Id = i + 1;
            }

            Save();
            CollectionChanged?.Invoke();
        }

        public void Pull()
        {
            Load();
        }

        protected void Load()
        {
            IDataAccessor<List<UserModel>> accessor = DependencyInjector.instance.GetDependency<IDataAccessor<List<UserModel>>>();
            users.Clear();
            users.AddRange(accessor.Load());
            CollectionChanged?.Invoke();
        }

        protected void Save()
        {
            IDataAccessor<List<UserModel>> accessor = DependencyInjector.instance.GetDependency<IDataAccessor<List<UserModel>>>();
            accessor.Save(users);
        }

        public event Action CollectionChanged;
    }
}
