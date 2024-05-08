/*
**********************************
* Description:
* Config file with field containing the path of the database we want to reach.
* The path is stated in the appsettings.json file.
**********************************
*/


namespace Cinema_API.Configuration
{
    public class DBConfiguration
    {
        public string ConnectionString { get; set; }
    }
}