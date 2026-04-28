namespace ConferenceManager.Entities
{
    internal class Speaker : Participant
    {
        private string specialty;
        private double fee;

        public Speaker(string name, string email, string specialty, double fee) : base(name, email)
        {
            this.specialty = specialty;
            this.fee = fee;
        }

        public override double GetFee()
        {
            return fee;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $" - Specialty: {specialty} - Fee: {fee}";
        }
    }
}
