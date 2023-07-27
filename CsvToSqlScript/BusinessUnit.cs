namespace CsvToSqlScript
{
    public class BusinessUnit
    {
        public int CostCenterCode { get; set; }
        public required string Name { get; set; }
        public string? Section { get; set; }
        public string? SubSection { get; set; }
    }
}
