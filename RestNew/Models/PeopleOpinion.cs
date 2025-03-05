namespace RestNew.Models
{
    public class PeopleOpinion : BaseEntity
    {
        public int PeopleOpinionId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Text { get; set; }
    }
}
