    public class Order
    {
    }
..
    public class FedExShipper : IShipper
    {
        private readonly Common.Logging.ILog logger;
        public static readonly string FriendlyName = typeof(FedExShipper).FullName;
        public FedExShipper(Common.Logging.ILog lgr)
        {
            if (null == lgr)
            {
                throw new ArgumentOutOfRangeException("Log is null");
            }
            this.logger = lgr;
        }
        public string FriendlyNameInstance => FriendlyName;
        public void ShipOrder(Order ord)
        {
            this.logger.Info("I'm shipping the Order with FedEx");
        }
