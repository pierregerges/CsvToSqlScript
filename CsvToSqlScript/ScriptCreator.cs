using System.Text;

namespace CsvToSqlScript
{
    internal class ScriptCreator
    {
        public static string GetScript(BusinessUnit record, int id)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"IF NOT EXISTS (SELECT * FROM  [dbo].[BusinessUnit] Where [BusinessUnitId] = {id})");
            builder.AppendLine($"BEGIN");
            builder.AppendLine($"INSERT INTO [dbo].[BusinessUnit]");
            builder.AppendLine($"(");
            builder.AppendLine($"[BusinessUnitId],");
            builder.AppendLine($"[CostCode],");
            builder.AppendLine($"[Name],");
            builder.AppendLine($"[Section],");
            builder.AppendLine($"[SubSection],");
            builder.AppendLine($"[Show]");
            builder.AppendLine($")");
            builder.AppendLine($"VALUES");
            builder.AppendLine($"(");
            builder.AppendLine($"{id},");
            builder.AppendLine($"{record.CostCenterCode},");
            builder.AppendLine($"'{record.Name}',");
            builder.AppendLine($"'{record.Section}',");
            builder.AppendLine($"'{record.SubSection}',");
            builder.AppendLine($"'True'");
            builder.AppendLine($")");
            builder.AppendLine($"END");
            return builder.ToString();
        }

        public static string GetScript(States record)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"IF NOT EXISTS (SELECT * FROM  [dbo].[States] Where [StateId] = {record.id})");
            builder.AppendLine($"BEGIN");
            builder.AppendLine($"INSERT INTO [dbo].[States]");
            builder.AppendLine($"(");
            builder.AppendLine($"[StateId],");
            builder.AppendLine($"[Name],");
            builder.AppendLine($"[Country_id],");
            builder.AppendLine($"[Country_code],");
            builder.AppendLine($"[Fips_code],");
            builder.AppendLine($"[Type],");
            builder.AppendLine($"[Latitude],");
            builder.AppendLine($"[Longitude],");
            builder.AppendLine($"[Flag]");
            builder.AppendLine($")");
            builder.AppendLine($"VALUES");

            builder.AppendLine($"(");
            builder.AppendLine($"{record.id},");
            builder.AppendLine($"'{record.name}',");
            builder.AppendLine($"{record.country_id},");
            builder.AppendLine($"'{record.country_code}',");
            builder.AppendLine($"'{record.state_code}',");
            builder.AppendLine($"'{record.type}',");
            builder.AppendLine($"'{record.latitude}',");
            builder.AppendLine($"'{record.longitude}',");
            builder.AppendLine($"1");
            builder.AppendLine($")");
            builder.AppendLine($"END");

            return builder.ToString();
        }
    }
}
