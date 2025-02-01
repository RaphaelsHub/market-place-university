using System;

namespace WebProject.Core.DTO.HelpFull
{
    public class ErrorAnalyticDto
    {
        public uint Id { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime TimeOfError { get; set; }
        public string ErrorType { get; set; }
        public string SourceController { get; set; }
        public string Severity { get; set; }
        public string UserId { get; set; }
        public string HttpMethod { get; set; }
        public string Url { get; set; }
    }
}