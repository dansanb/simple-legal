namespace API.DTO.AgGrid;

public class AgGridOperationDto
{
    public int StartRow { get; set; }
    public int EndRow { get; set; }
    public AgGridSortDto[]? SortModel { get; set; }
    public Dictionary<string, AgGridFilterDto>? FilterModel { get; set; }
}