using ClassLibraryModels.DTOs;

namespace ClassLibraryClient.Services
{
    public class ApiCategoryService
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

        private List<CategoryDTO> LoadDB()
        {
            return new List<CategoryDTO>()
            {
                new CategoryDTO() { Id = 1, Name = "Computación", IsSelected = false },
                new CategoryDTO() { Id = 2, Name = "Electrónica", IsSelected = false },
                new CategoryDTO() { Id = 3, Name = "Deportes", IsSelected = false },
                new CategoryDTO() { Id = 4, Name = "Vehículo", IsSelected = false },
                new CategoryDTO() { Id = 5, Name = "Belleza", IsSelected = false },
                new CategoryDTO() { Id = 6, Name = "Instrumentos", IsSelected = false },
                new CategoryDTO() { Id = 7, Name = "Inmuebles", IsSelected = false },
                new CategoryDTO() { Id = 8, Name = "Servicios", IsSelected = false },
                new CategoryDTO() { Id = 9, Name = "Alimentos", IsSelected = false },
                new CategoryDTO() { Id = 10, Name = "Juguetes", IsSelected = false },
                new CategoryDTO() { Id = 11, Name = "Ropa", IsSelected = false },
                new CategoryDTO() { Id = 12, Name = "Calzado ", IsSelected = false },
            };
        }
    }
}
