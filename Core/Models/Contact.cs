namespace Core.Models
{
    public class Contact : Entity
    {
        public string Name { get; set; }
        public string RelationToUser { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneMobile { get; set; }
    }
}
