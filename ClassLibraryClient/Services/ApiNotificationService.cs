using ClassLibraryModels.DTOs;

namespace ClassLibraryClient.Services
{
    public class ApiNotificationService
    {
        private readonly List<NotificationDTO> data;

        public ApiNotificationService()
        {
            data = LoadDB();
        }

        public List<NotificationDTO> GetAll()
        {
            return data;
        }

        public NotificationDTO GetById(int id)
        {
            var result = data.FirstOrDefault(e => e.Id == id);
            return result;
        }

        private List<NotificationDTO> LoadDB()
        {
            return new List<NotificationDTO>()
            {
                new NotificationDTO() { Id = 1, User_Id = 1001, User_Name = "Nombre 1", User_Img = "user.jpg", Offer_Description = "Tengo una PS5 para cambiar" },
                new NotificationDTO() { Id = 2, User_Id = 1002, User_Name = "Nombre 2", User_Img = "user.jpg", Offer_Description = "Tengo una Litera para cambiar" },
                new NotificationDTO() { Id = 3, User_Id = 1003, User_Name = "Nombre 3", User_Img = "user.jpg", Offer_Description = "Tengo una Tetera para cambiar" },
                new NotificationDTO() { Id = 4, User_Id = 1004, User_Name = "Nombre 4", User_Img = "user.jpg", Offer_Description = "Tengo una Casa para cambiar" },
                new NotificationDTO() { Id = 5, User_Id = 1005, User_Name = "Nombre 5", User_Img = "user.jpg", Offer_Description = "Tengo una Guitarra para cambiar" },
                new NotificationDTO() { Id = 6, User_Id = 1006, User_Name = "Nombre 6", User_Img = "user.jpg", Offer_Description = "Tengo un León para cambiar" },
                new NotificationDTO() { Id = 7, User_Id = 1007, User_Name = "Nombre 7", User_Img = "user.jpg", Offer_Description = "Tengo una Esposa para cambiar" },
                new NotificationDTO() { Id = 8, User_Id = 1008, User_Name = "Nombre 8", User_Img = "user.jpg", Offer_Description = "Tengo 20 Japonesas para cambiar" },
            };
        }
    }
}
