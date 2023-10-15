using System.ComponentModel.DataAnnotations;

namespace InvManagement1.models
{
    public class Catogory
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
