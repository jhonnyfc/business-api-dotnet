namespace poroject_777.BusinessLogic.BusinessSearch.Models
{
    public class Business
    {
        public int Id { get; set; }
        public string BusinessNikname { get; set; }
        public string Telf { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime LeavingDate { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Description { get; set; }
        public string InstaLink { get; set; }
        public string FacebookLink { get; set; }
        public string LinkedInLink { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string BusinessSector { get; set; }
    }
}
