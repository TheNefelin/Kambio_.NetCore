using ClassLibraryModels.DTOs;

namespace MauiKambio.Services
{
    class ApiCategoryService
    {
        private readonly List<CategoryDTO> data;

        public ApiCategoryService()
        {
            data = LoadDB();
        }
        public List<CategoryDTO> GetAll()
        {
            return data.OrderBy(e => e.Name).ToList();
        }

        public CategoryDTO? GetById(int id)
        {
            var result = data.FirstOrDefault(e => e.Id == id);
            return result;
        }

        private List<CategoryDTO> LoadDB() { 
            return new List<CategoryDTO>()
            {
                new CategoryDTO() { Id = 1, Name = "Computación"},
                new CategoryDTO() { Id = 2, Name = "Electrónica"},
                new CategoryDTO() { Id = 3, Name = "Deportes"},
                new CategoryDTO() { Id = 4, Name = "Vehículo"},
                new CategoryDTO() { Id = 5, Name = "Belleza"},
                new CategoryDTO() { Id = 6, Name = "Instrumentos"},
                new CategoryDTO() { Id = 7, Name = "Inmuebles"},
                new CategoryDTO() { Id = 8, Name = "Servicios"},
                new CategoryDTO() { Id = 9, Name = "Alimentos"},
                new CategoryDTO() { Id = 10, Name = "Juguetes"},
                new CategoryDTO() { Id = 11, Name = "Ropa"},
                new CategoryDTO() { Id = 12, Name = "Calzado "},
            };
        }
    }
}
