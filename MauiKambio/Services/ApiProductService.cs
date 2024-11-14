using ClassLibraryModels.DTOs;

namespace MauiKambio.Services
{
    public class ApiProductService
    {
        private readonly List<ProductDTO> data = new List<ProductDTO>();

        public ApiProductService() {
            LoadDB();
        }

        public List<ProductDTO> GetAll()
        {
            List<ProductDTO> result = new();

            foreach (var item in data) { 
                ProductDTO dto = new()
                {
                    Id = item.Id,
                    Name = item.Name,
                    User_Id = item.User_Id,
                    User_Name = item.User_Name,
                    User_Img = item.User_Img,
                    Status = item.Status,
                    Location = item.Location,
                    Stars = item.Stars,
                    Like = item.Like,
                    Images = new List<ProductImageDTO> { item.Images[0] }
                };

                result.Add(dto);
            }

            return result;
        }

        public ProductDTO? GetById(int id)
        {
            ProductDTO result = data.Find(e => e.Id == id);
            return result;
        }

        private void LoadDB()
        {
            ProductImageDTO img1 = new() { Id = 1, Img = "image1.png", };
            ProductImageDTO img2 = new() { Id = 2, Img = "image2.png", };
            ProductImageDTO img3 = new() { Id = 3, Img = "image3.png", };

            CategoryDTO cat1 = new() { Id = 1, Name = "Vehículos" };
            CategoryDTO cat2 = new() { Id = 2, Name = "Artículos Electrónicos" };
            CategoryDTO cat3 = new() { Id = 3, Name = "Celulares" };
            CategoryDTO cat4 = new() { Id = 4, Name = "Instrumentos Musicales" };
            CategoryDTO cat5 = new() { Id = 5, Name = "Muebles" };
            CategoryDTO cat6 = new() { Id = 6, Name = "TVs" };

            ProductDTO prod1 = new()
            {
                Id = 1,
                Name = "Nombre Producto 1",
                User_Id = "A123456",
                User_Name = "Francisco Acuña",
                User_Img = "user.jpg",
                Status = "Usado",
                Location = "Santiago",
                Stars = 4,
                Like = true,
                Description = "Producto bla bla bla, Busco trueque por etc...",
                BarterFor = $"{cat1.Name}, {cat3.Name}, {cat5.Name}",
                Image = img1,
                Images = new List<ProductImageDTO> { img1, img2, img3, },
            };

            ProductDTO prod2 = new()
            {
                Id = 2,
                Name = "Nombre Producto 2",
                User_Id = "B123456",
                User_Name = "The Nefelin",
                User_Img = "user.jpg",
                Status = "Usado",
                Location = "Valparaiso",
                Stars = 3,
                Like = true,
                Description = "Otro producto bla bla bla, Busco trueque por etc...",
                BarterFor = $"{cat1.Name}, {cat2.Name}, {cat3.Name}, {cat4.Name}, {cat5.Name}, {cat6.Name}",
                Image = img2,
                Images = new List<ProductImageDTO> { img2, img1, },
            };

            ProductDTO prod3 = new()
            {
                Id = 3,
                Name = "Nombre Producto 3",
                User_Id = "C123456",
                User_Name = "Care Chancla",
                User_Img = "user.jpg",
                Status = "Nuevo",
                Location = "Viña del Mar",
                Stars = 1,
                Like = false,
                Description = "Yaaa po Cambiamelo, yaaa po bla bla bla, Busco trueque por etc...",
                BarterFor = $"{cat2.Name}, {cat3.Name}, {cat4.Name}, {cat5.Name}",
                Image = img3,
                Images = new List<ProductImageDTO> { img3, },
            };

            data.Add(prod1);
            data.Add(prod2);
            data.Add(prod3);
        }
    }
}
