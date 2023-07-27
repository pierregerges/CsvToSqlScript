using CsvHelper;
using CsvToSqlScript;
using System.Globalization;

var path = Environment.CurrentDirectory;
using (var reader = new StreamReader(Path.Combine(path, "businessunits.csv")))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    var records = csv.GetRecords<BusinessUnit>();

    if (records != null)
    {
        int id = 1;
        using (var outputFile = new StreamWriter(Path.Combine(path, "businessunits.sql")))
        {
            outputFile.WriteLine($"BEGIN TRANSACTION");
            foreach (var record in records)
            {
                string script = ScriptCreator.GetScript(record, id);
                outputFile.Write(script);
                id++;
            }
            outputFile.WriteLine($"COMMIT TRANSACTION");
            outputFile.WriteLine($"GO");
        }
    }
}


using (var reader = new StreamReader(Path.Combine(path, "states.csv")))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    var records = csv.GetRecords<States>();

    if (records != null)
    {
        int id = 1;
        using (var outputFile = new StreamWriter(Path.Combine(path, "states.sql")))
        {
            outputFile.WriteLine($"BEGIN TRANSACTION");
            foreach (var record in records)
            {
                string script = ScriptCreator.GetScript(record);
                outputFile.Write(script);
                id++;
            }
            outputFile.WriteLine($"COMMIT TRANSACTION");
            outputFile.WriteLine($"GO");
        }
    }
}