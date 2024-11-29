using System;

namespace ClassLibraryModels.DTOs
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public int Chat_Id { get; set; }
        public int SendBy_Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public virtual Chat Chat { get; set; }
        public virtual ChatUser SendBy { get; set; }
    }
}
