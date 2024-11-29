namespace ClassLibraryModels.DTOs
{
    public class ChatUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Connection_Id { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
    }
}
