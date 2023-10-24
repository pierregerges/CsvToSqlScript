using CsvHelper;
using CsvToSqlScript;
using CsvToSqlScript.Tables;
using System.Globalization;

var path = Path.Combine(Environment.CurrentDirectory, "CSVFiles");

//#region BusinessUnits
//using (var reader = new StreamReader(Path.Combine(path, "businessunits.csv")))
//using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
//{
//    var records = csv.GetRecords<BusinessUnit>();

//    if (records != null)
//    {
//        int id = 1;
//        using (var outputFile = new StreamWriter(Path.Combine(path, "businessunits.sql")))
//        {
//            outputFile.WriteLine($"BEGIN TRANSACTION");
//            foreach (var record in records)
//            {
//                string script = ScriptCreator.GetScript(record, id);
//                outputFile.Write(script);
//                id++;
//            }
//            outputFile.WriteLine($"COMMIT TRANSACTION");
//            outputFile.WriteLine($"GO");
//        }
//    }
//}
//#endregion
//#region States
//using (var reader = new StreamReader(Path.Combine(path, "states.csv")))
//using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
//{
//    var records = csv.GetRecords<States>();

//    if (records != null)
//    {
//        int id = 1;
//        using (var outputFile = new StreamWriter(Path.Combine(path, "states.sql")))
//        {
//            outputFile.WriteLine($"BEGIN TRANSACTION");
//            foreach (var record in records)
//            {
//                string script = ScriptCreator.GetScript(record);
//                outputFile.Write(script);
//                id++;
//            }
//            outputFile.WriteLine($"COMMIT TRANSACTION");
//            outputFile.WriteLine($"GO");
//        }
//    }
//}
//#endregion

//#region Get VehicleMakeId for VehicleModel list (grouped by VehicleMake and VehicleYear)
//var models = new List<VehicleModelToFix>();
//var makes = new List<VehicleMakeToFix>();
//var modelId = new List<int>();

//using (var reader = new StreamReader(Path.Combine(path, "VehicleModelToFix.csv")))
//using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
//{
//    models = csv.GetRecords<VehicleModelToFix>().ToList();
//}

//using (var reader = new StreamReader(Path.Combine(path, "VehicleMakeToFix.csv")))
//using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
//{
//    makes = csv.GetRecords<VehicleMakeToFix>().ToList();
//}

//foreach (var model in models)
//{
//    foreach (var make in makes)
//    {
//        if (model.make == make.Name && model.yearId == make.VehicleYearId)
//        {
//            modelId.Add(make.VehicleMakeId);
//            break;
//        }
//    }
//}

//using (var outputFile = new StreamWriter(Path.Combine(path, "VehicleModelNew.csv")))
//{
//    foreach (var id in modelId)
//    {
//        outputFile.WriteLine(id);
//    }
//}
//#endregion


#region VehicleMake
using (var reader = new StreamReader(Path.Combine(path, "VehicleMake.csv")))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    var records = csv.GetRecords<VehicleMake>();

    if (records != null)
    {
        using (var outputFile = new StreamWriter(Path.Combine(path, "VehicleMake.sql")))
        {
            outputFile.WriteLine($"SET IDENTITY_INSERT [dbo].[VehicleMake] ON");
            outputFile.WriteLine($"Print ' Adding Records for Parking VehicleMake- 1 '");
            outputFile.WriteLine($"BEGIN TRANSACTION");
            foreach (var record in records)
            {
                string script = ScriptCreator.GetScriptVehicleMake(record);
                outputFile.Write(script);
            }
            outputFile.WriteLine($"COMMIT TRANSACTION");
            outputFile.WriteLine($"GO");
            outputFile.WriteLine($"Print'End Adding Records for dbo VehicleMake>> 1337'");
            outputFile.WriteLine($"SET IDENTITY_INSERT [dbo].[VehicleMake] OFF");
        }
    }
}
#endregion
#region VehicleModel
using (var reader = new StreamReader(Path.Combine(path, "VehicleModel.csv")))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    var records = csv.GetRecords<VehicleModel>();

    if (records != null)
    {
        using (var outputFile = new StreamWriter(Path.Combine(path, "VehicleModel.sql")))
        {
            outputFile.WriteLine($"SET IDENTITY_INSERT [dbo].[VehicleModel] ON");
            outputFile.WriteLine($"Print ' Adding Records for Parking VehicleModel- 1 '");
            outputFile.WriteLine($"BEGIN TRANSACTION");
            foreach (var record in records)
            {
                string script = ScriptCreator.GetScriptVehicleModel(record);
                outputFile.Write(script);
            }
            outputFile.WriteLine($"COMMIT TRANSACTION");
            outputFile.WriteLine($"GO");
            outputFile.WriteLine($"Print'End Adding Records for dbo VehicleModel>> 11085'");
            outputFile.WriteLine($"SET IDENTITY_INSERT [dbo].[VehicleModel] OFF");
        }
    }
}
#endregion