using System.ComponentModel.DataAnnotations;

namespace Workshop.Core.Settings
{
    public class ConnectionStrings: DataAnnotationSetting
    {
        [Required(AllowEmptyStrings = false)]
        public string PostgresDatabase { get; set; }
    }
}