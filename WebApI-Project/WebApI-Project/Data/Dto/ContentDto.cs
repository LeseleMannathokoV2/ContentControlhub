using System;

namespace WebApI_Project.Data.Dto
{
    public class ContentDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
