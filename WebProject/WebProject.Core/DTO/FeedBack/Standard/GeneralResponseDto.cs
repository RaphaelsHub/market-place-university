namespace WebProject.Core.DTO.ResponcesDto
{
    public class GeneralResponseDto<TModel,TModel1,TModel2>
    {
        // Response model
        public TModel Data { get; set; } = default;
        
        // Additional data
        public TModel1 Data1 { get; set; } = default;
        
        // Additional data
        public TModel2 Data2 { get; set; } = default;
        
        public string Message { get; set; } = string.Empty;
    }
}