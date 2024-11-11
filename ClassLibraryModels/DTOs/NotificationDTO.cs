namespace ClassLibraryModels.DTOs
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string User_Name { get; set; } = string.Empty;
        public string User_Img { get; set; } = string.Empty;
        public string Offer_Description { get; set; } = string.Empty;
        public bool IsAccept { get; set; }
        public bool IsDecline { get; set; }
    }
}
