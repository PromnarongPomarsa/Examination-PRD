namespace BackEnd_Thaibev.Models
{
    public class TbTQuestion
    {
        public int? id { get; set; }
        public string? question { get; set; }
        public string? choice_first { get; set; }
        public string? choice_third { get; set; }
        public string? choice_four { get; set; }
        public string? create_by { get; set; }
        public DateTime? create_date { get; set; }
    }
}
