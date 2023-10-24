using System.Collections.Generic;
using System.Text;
using CsvToSqlScript.Tables;

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
            DateTime defaultDate = new DateTime();
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
            builder.AppendLine($"[Created_at],");
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
            if (record.latitude == null) 
                builder.AppendLine($"null,");
            else
                builder.AppendLine($"'{record.latitude}',");

            if (record.longitude == null)
                builder.AppendLine($"null,");
            else
                builder.AppendLine($"'{record.longitude}',");
            builder.AppendLine($"'{defaultDate.ToString()}',");
            builder.AppendLine($"1");
            builder.AppendLine($")");
            builder.AppendLine($"END");
            return builder.ToString();
        }
        public static string GetScriptVehicleMake(VehicleMake record)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"IF NOT EXISTS (SELECT * FROM  [dbo].[VehicleMake] Where [VehicleMakeId] = {record.VehicleMakeId})");
            builder.AppendLine($"BEGIN");
            builder.AppendLine($"INSERT INTO [dbo].[VehicleMake]");
            builder.AppendLine($"(");
            builder.AppendLine($"[VehicleMakeId],");
            builder.AppendLine($"[Name],");
            //builder.AppendLine($"[Description],");
            builder.AppendLine($"[Show],");
            builder.AppendLine($"[SortOrder],");
            builder.AppendLine($"[VehicleYearId]");
            builder.AppendLine($")");
            builder.AppendLine($"VALUES");
            builder.AppendLine($"(");
            builder.AppendLine($"{record.VehicleMakeId},");
            builder.AppendLine($"'{record.Name}',");
            //builder.AppendLine($"'',");
            builder.AppendLine($"'True',");
            builder.AppendLine($"{record.VehicleMakeId},");
            builder.AppendLine($"{record.VehicleYearId}");
            builder.AppendLine($")");
            builder.AppendLine($"END");
            return builder.ToString();
        }
        public static string GetScriptVehicleModel(VehicleModel record)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"IF NOT EXISTS (SELECT * FROM  [dbo].[VehicleModel] Where [VehicleModelId] = {record.VehicleModelId})");
            builder.AppendLine($"BEGIN");
            builder.AppendLine($"INSERT INTO [dbo].[VehicleModel]");
            builder.AppendLine($"(");
            builder.AppendLine($"[VehicleModelId],");
            builder.AppendLine($"[Name],");
            //builder.AppendLine($"[Description],");
            builder.AppendLine($"[Category],");
            builder.AppendLine($"[Show],");
            builder.AppendLine($"[SortOrder],");
            builder.AppendLine($"[VehicleMakeId]");
            builder.AppendLine($")");
            builder.AppendLine($"VALUES");
            builder.AppendLine($"(");
            builder.AppendLine($"{record.VehicleModelId},");
            builder.AppendLine($"'{record.Name}',");
            //builder.AppendLine($"'',");
            builder.AppendLine($"'{record.Category}',");
            builder.AppendLine($"'True',");
            builder.AppendLine($"{record.VehicleModelId},");
            builder.AppendLine($"{record.VehicleMakeId}");
            builder.AppendLine($")");
            builder.AppendLine($"END");
            return builder.ToString();
        }
    }
}
