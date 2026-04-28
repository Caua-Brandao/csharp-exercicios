using System;

namespace ConferenceManager.Entities
{
    abstract class Participant
    {
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public DateTime RegistrationDate { get; protected set; }

        public Participant(string name, string email)
        {
            this.Name = name;
            this.Email = email;
            RegistrationDate = DateTime.Now;
        }

        public int GetDaysSinceRegistration()
        {
            DateTime now = DateTime.Now;
            return (int)(now - RegistrationDate).TotalDays;
        }

        public abstract double GetFee();
        public virtual string GetInfo()
        {
            return $"Name: {Name} - Email: {Email}";
        }
    }
}
