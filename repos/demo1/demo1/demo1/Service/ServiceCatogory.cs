
using InvManagement1.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvManagement1.Services
{
    public class ServiceCatogory : IServiceCatogory
    {
        private readonly List<Catogory> _categories;

        public ServiceCatogory()
        {
            // Initialize the list with some sample data
            _categories = new List<Catogory>
            {
                new Catogory { CategoryId = 1, CategoryName = "Category 1", Description = "Description 1" },
                new Catogory { CategoryId = 2, CategoryName = "Category 2", Description = "Description 2" },
                // Add more sample categories here
            };
        }

        public IEnumerable<Catogory> GetAllCategories()
        {
            return _categories;
        }

        public Catogory GetCategoryById(int categoryId)
        {
            return _categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }

        public void AddCategory(Catogory catogory)
        {
            if (catogory == null)
            {
                throw new ArgumentNullException(nameof(catogory));
            }

            // Generate a new CategoryId (in a real application, this might come from a database)
            catogory.CategoryId = _categories.Any() ? _categories.Max(c => c.CategoryId) + 1 : 1;

            _categories.Add(catogory);
        }

        public void UpdateCategory(Catogory catogory)
        {
            if (catogory == null)
            {
                throw new ArgumentNullException(nameof(catogory));
            }

            var existingCategory = _categories.FirstOrDefault(c => c.CategoryId == catogory.CategoryId);
            if (existingCategory != null)
            {
                // Update the existing category with the new values
                existingCategory.CategoryName = catogory.CategoryName;
                existingCategory.Description = catogory.Description;
            }
            else
            {
                throw new InvalidOperationException("Category not found.");
            }
        }

        public void DeleteCategory(int catogoryId)
        {
            var catogoryToRemove = _categories.FirstOrDefault(c => c.CategoryId == catogoryId);
            if (catogoryToRemove != null)
            {
                _categories.Remove(catogoryToRemove);
            }
            else
            {
                throw new InvalidOperationException("Category not found.");
            }
        }
    }
}
