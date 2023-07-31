namespace DesignPrinciples
{
	public sealed class Invoker
	{
		private ICommand countAllCars;
        private ICommand countCarsBrands;
        private ICommand averagePriceOfAllCars;
        private ICommand averagePriceOfBrand;

        private static Invoker _invoker;

		private Invoker(ICommand CountAllCarsCommand, ICommand CountCarsBrandsCommand, ICommand AveragePriceOfAllCarsCommand, ICommand AveragePriceOfBrandCommand)
		{
			this.countAllCars = CountAllCarsCommand;
			this.countCarsBrands = CountCarsBrandsCommand;
			this.averagePriceOfAllCars = AveragePriceOfAllCarsCommand;
            this.averagePriceOfBrand = AveragePriceOfBrandCommand;
        }

        public static Invoker GetInstance()
        {
            Receiver receiver = new Receiver();
            if (_invoker == null)
            {
                _invoker = new Invoker(new CountAllCarsCommand(receiver),
                                       new CountCarsBrandsCommand(receiver),
                                       new AveragePriceOfAllCarsCommand(receiver),
                                       new AveragePriceOfBrandCommand(receiver));
            }
            return _invoker;
        }

        public void CountAllCars()
		{
			this.countAllCars.Execute();
		}

        public void CountCarsBrands()
        {
            this.countCarsBrands.Execute();
        }

        public void AveragePriceOfAllCars()
        {
            this.averagePriceOfAllCars.Execute();
        }

        public void AveragePriceOfBrand()
        {
            this.averagePriceOfBrand.Execute();
        }
    }
}

