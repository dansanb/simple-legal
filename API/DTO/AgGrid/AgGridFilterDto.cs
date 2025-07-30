using System.Text.Json.Serialization;

namespace API.DTO.AgGrid;

public class AgGridFilterDto
{
    // public AgGridFilterDto? Condition1 { get; set; }
    // public AgGridFilterDto? Condition2 { get; set; }
    [JsonPropertyName("operator")]
    public string? LogicOperator { get; set; }
    public string? Type { get; set; }
    public string? Filter { get; set; }
    public string? FilterTo { get; set; }
    public string? DateFrom { get; set; }
    public string? DateTo { get; set; }
    public string? FilterType { get; set; }

    public AgGridFilterDto[]? Conditions { get; set; }
}