/*
* Description:
*  Configuration file with four fields which will be 
*  adjusted in the appsettings.json file.
**********************************
*/


namespace Cinema_API.Configuration
{
    public class ValidationConfiguration
    {
        public int NameMaxCharacters { get; set; }
        public int LocationMaxCharacters { get; set; }
        public int MovieMaxCharacters { get; set; }

        public int RowsMaxValue { get; set; }
        public int SeatsMaxValue { get; set; }

        public string CinemaRegex { get; set; }
    }
}