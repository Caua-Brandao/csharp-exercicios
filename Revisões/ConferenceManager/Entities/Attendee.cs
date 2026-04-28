namespace ConferenceManager.Entities
{
    internal class Attendee : Participant
    {
        private string category;

        public Attendee(string name, string email, string category):base(name, email)
        {
            this.category = category;
        }
        public override double GetFee()
        {
            switch (category)
            {
                case "Student":
                    return 100.0;
                    break;
                case "Professional":
                    return 500.0;
                    break;
                default:
                    return 300.0;
                    break;
            }
        }
        public override string GetInfo()
        {
            return base.GetInfo() + $" - Category: {category}";
        }
    }
}
