using ClassLibraryModels.DTOs;

namespace MauiKambio.Services
{
    public class ApiProductService
    {
        public ApiProductService() { 
        
        }

        public List<ProductDTO> GetAll()
        {
            ProductImageDTO img1 = new() { Id = 1, Img = "image1.png", };
            ProductImageDTO img2 = new() { Id = 1, Img = "image2.png", };
            ProductImageDTO img3 = new() { Id = 1, Img = "image3.png", };

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
            };

            prod1.Images.Add(img1);
            prod1.Images.Add(img2);
            prod1.Images.Add(img3);

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
                Like = false,
            };

            prod2.Images.Add(img1);
            prod2.Images.Add(img2);
            prod2.Images.Add(img3);

            ProductDTO prod3 = new()
            {
                Id = 2,
                Name = "Nombre Producto 3",
                User_Id = "C123456",
                User_Name = "Care Chancla",
                User_Img = "user.jpg",
                Status = "Nuevo",
                Location = "Viña del Mar",
                Stars = 1,
                Like = false,
            };

            prod3.Images.Add(img1);
            prod3.Images.Add(img2);
            prod3.Images.Add(img3);

            return new List<ProductDTO> { prod1, prod2, prod3 };
        }
    }
}
