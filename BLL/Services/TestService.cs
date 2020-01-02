using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using Ninject.Activation;

namespace BLL.Services
{
    /*class TestService : ITestService
    {
        IUnitOfWork Database { get; set; }

        public TestService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<TestDTO> GetProducts(Predicate<TestDTO> predic)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Test, TestDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Test>, List<TestDTO>>(Database.Tests.GetAll()).FindAll(predic);
        }

        public TestDTO GetProduct(int? id)
        {
            if (id == null)
                throw new ValidationException("Test id is not found", "");
            var test = Database.Tests.Get(id.Value);
            if (test == null)
                throw new ValidationException("Test is not found", "");

            TestDTO resTestDTO = new TestDTO
            {
                Id = test.Id, 
                Title = test.Title, 
                MaxMark = test.MaxMark, 
                IsOpen = test.IsOpen
            };

            foreach (Teacher teach in test.Teachers)
            {
                resTestDTO.TeacherIds.
            }

            return resTestDTO;
        }

        public void AddProduct(TestDTO testDTO)
        {
            ProductCategory existCategory = Database.ProductCategories.Get(productDTO.CategoryId);
            if (existCategory != null)
                throw new ValidationException("Category is not found.", productDTO.CategoryId.ToString());

            Provider existProvider = Database.Providers.Get(productDTO.CategoryId);
            if (existProvider != null)
                throw new ValidationException("Provider is not found.", productDTO.ProviderId.ToString());

            Test product = new Test
            {
                Id = testDTO.Id,
                Title = testDTO.Title,
                MaxMark = testDTO.Cost,
                Category = existCategory,
                Provider = existProvider
            };
            Database.Products.Create(product);
            Database.Save();
        }

        public void UpdateProduct(ProductDTO productDTO)
        {
            var existProduct = Database.Products.Get(productDTO.Id);
            if (existProduct == null)
                throw new ValidationException("Product is not found", "");

            ProductCategory existCategory = Database.ProductCategories.Get(productDTO.CategoryId);
            if (existCategory != null)
                throw new ValidationException("Category is not found.", productDTO.CategoryId.ToString());

            Provider existProvider = Database.Providers.Get(productDTO.CategoryId);
            if (existProvider != null)
                throw new ValidationException("Provider is not found.", productDTO.ProviderId.ToString());

            Product product = new Product
            {
                Id = productDTO.Id,
                Title = productDTO.Title,
                Cost = productDTO.Cost,
                Category = existCategory,
                Provider = existProvider
            };
            Database.Products.Update(product);
            Database.Save();
        }

        public void DeleteProduct(int? id)
        {
            if (id == null)
                throw new ValidationException("Product id is not found", "");
            var product = Database.Products.Get(id.Value);
            if (product == null)
                throw new ValidationException("Product is not found", "");

            Database.Products.Delete(product.Id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }*/
}
