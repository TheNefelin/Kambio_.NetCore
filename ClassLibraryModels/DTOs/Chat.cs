namespace ClassLibraryModels.DTOs
{
    public class Chat
    {
        public int Id { get; set; }
        public int User1_Id { get; set; } 
        public int User2_Id { get; set; } 
        public virtual ChatUser User1 { get; set; }
        public virtual ChatUser User2 { get; set; }
        public virtual ICollection<ChatMessage> Messages { get; set; }
    }
}
