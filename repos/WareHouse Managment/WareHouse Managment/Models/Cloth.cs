namespace WareHouse_Managment.Models
{
    public class Cloth
    {
            public int ClothId { get; set; } 
            public double EAN { get; set; }
            public double EpcNo { get; set; }
            public string Type { get; set; }
            public string Size { get; set; }
            public DateTime InWord { get; set; }

            public DateTime? OutWord { get; set; }
            public bool IsActive { get; set; }
            public Cloth()
            {
                IsActive = true; // Set the default value to 1 (true)
            }

    }
}
