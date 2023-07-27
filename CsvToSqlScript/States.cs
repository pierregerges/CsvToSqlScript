namespace CsvToSqlScript
{
    internal class States
    {
        public int id { get; set; }
        public required string name { get; set; }
        public int country_id { get; set; }
        public required string country_code { get; set; }
        public required string country_name { get; set; }
        public string? state_code { get; set; }
        public string? type { get; set; }
        public decimal? latitude { get; set; }
        public decimal? longitude { get; set; }
    }

}
