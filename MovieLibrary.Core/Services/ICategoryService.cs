using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Models;
using System.Collections.Generic;

namespace MovieLibrary.Api.Services
{
    public interface ICategoryService
    {
        CategoryDTO GetCategoryById(int id);

        List<CategoryDTO> GetAll();

        int AddCategory(CreateCategoryDTO cCategoryDTO);

        bool ChangeCategoryById(int id, UpdateCategoryDTO uCategoryDTO);

        bool DeleteCategoryById(int id);
    }
}