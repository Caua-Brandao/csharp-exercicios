using System;

namespace LibraryExercice.Entites
{
    internal class Member
    {
        public string  Name { get; set; }
        public string  MemberId { get; set; }
        public DateTime JoinDate { get; set; }

        public Member(string name, string memberId)
        {
            this.Name = name;
            this.MemberId = memberId;
            JoinDate = DateTime.Now;
        }

        public int GetMembershipDays()
        {
            TimeSpan diff = DateTime.Now - JoinDate;
            return (int)diff.TotalDays;
        }

        public override string ToString()
        {
            return $"{Name} (ID: {MemberId}) - Membro há {GetMembershipDays()} dias";
        }
    }
}
