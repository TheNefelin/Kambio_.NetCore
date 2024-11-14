namespace ClassLibraryModels.DTOs
{
    public class ProductRequestDTO
    {
        public string Product_Name { get; set; } = string.Empty;
        public string Product_Description { get; set; } = string.Empty;
        public bool Product_IsNew { get; set; }
        public CategoryDTO Product_Category { get; set; } = new CategoryDTO();
        public List<CategoryDTO> Product_CategoryOfInterest { get; set; } = new List<CategoryDTO>();
        public string User_Id { get; set; }
    }
}
