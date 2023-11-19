

namespace mediklaud_api.Infrastructure
{
    public class ConnectionSettings
    {
        public DBSettings? AbsDbSettings { get; set; }

        public DBSettings? HRDbSettings { get; set; }

        public DBSettings? InvDbSettings { get; set; }

        public DBSettings? BillgenixDbSettings { get; set; }

        public DBSettings? DashboardDbSettings { get; set; }
    }
}
