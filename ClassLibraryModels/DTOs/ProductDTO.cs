namespace ClassLibraryModels.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;        
        public string User_Id { get; set; }
        public string User_Name { get; set; } = string.Empty;
        public string User_Img { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int Stars { get; set; }
        public bool Like { get; set; }
        public string Description { get; set; } = string.Empty;
        public string BarterFor { get; set; } = string.Empty;
        public ProductImageDTO Image { get; set; } = new();
        public List<ProductImageDTO> Images { get; set; } = new();
    }
}
