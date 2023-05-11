namespace TravelAppWebApp.Models
{
    public class Package
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public int? PackageCategoryId { get; set; }
        public string TypeOfPackage { get; set; }
    }
}
