namespace ClassLibraryModels.DTOs
{
    public class ResponseApiDTO<T>
    {
        public required bool IsSuccess { get; set; }
        public required int StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
