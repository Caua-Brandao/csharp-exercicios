namespace ConferenceManager.Entities
{
    internal class Organizer : Participant
    {
        private string position;

        public Organizer(string name, string email, string position):base(name, email)
        {
            this.position = position;
        }

        public override double GetFee()
        {
            return 0;
        }
        public override string GetInfo()
        {
            return base.GetInfo() + $" - Position: {position}";
        }
    }
}
