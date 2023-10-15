using InvManagement1.models;
using InvManagement1.models;
using System;
using System.Collections.Generic;

namespace InvManagement1.Services
{
    public interface IServiceCatogory
    {
        IEnumerable<Catogory> GetAllCategories();
        Catogory GetCategoryById(int catogoryId);
        void AddCategory(Catogory catogory);
        void UpdateCategory(Catogory catogory);
        void DeleteCategory(int catogoryId);
    }
}
