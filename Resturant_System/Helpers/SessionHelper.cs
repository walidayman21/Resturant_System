namespace Resturant_System.Helpers
{
    public static class SessionHelper
    {
        public static void SetCurrentOrderId(ISession session, int orderId)
        {
            session.SetInt32("CurrentOrderId", orderId);
        }

        public static int? GetCurrentOrderId(ISession session)
        {
            return session.GetInt32("CurrentOrderId");
        }

        public static void ClearCurrentOrder(ISession session)
        {
            session.Remove("CurrentOrderId");
        }
    }
}
