namespace BackEnd_Thaibev.Models.Dto
{
    public class TbTQuestionDto
    {
        public int? id { get; set; }
        public string? question { get; set; }
        public string? choiceFirst { get; set; }
        public string? choiceSecond { get; set; }
        public string? choiceThird { get; set; }
        public string? choiceFour { get; set; }
        public string? createBy { get; set; }
        public DateTime? createDate { get; set; }
    }
}
