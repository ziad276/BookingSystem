using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Infrastructure.Data.SeedData
{
    public class SeedDataModel
    {
        public List<SeedPerson> Providers { get; set; }
        public List<SeedPerson> Clients { get; set; }
        public List<SeedSlot> Slots { get; set; }
    }

    public class SeedPerson
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class SeedSlot
    {
        public int ProviderIndex { get; set; }
        public int DaysFromNow { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public bool IsBooked { get; set; }
    }
}
