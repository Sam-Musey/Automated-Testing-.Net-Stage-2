namespace DesignPrinciples
{
	public class Car
	{
		public static List<Car> carList = new List<Car>();
		public static List<string> carBrandsList = new List<string>();
		private string carBrand;
        private string carModel;
        private int carQuantity;
        private int carPrice;

        public Car(string carBrand, string carModel, int carQuantity, int carPrice)
		{
			this.carBrand = carBrand;
			this.carModel = carModel;
			this.carQuantity = carQuantity;
			this.carPrice = carPrice;
            carList.Add(this);
			carBrandsList.Add(this.carBrand);
		}

		public int CarQuantity
		{
			get { return carQuantity; }
		}

        public int CarPrice
        {
            get { return carPrice; }
        }

		public string CarBrand
		{
			get { return carBrand; }
		}

        public string CarModel
        {
            get { return carModel; }
        }
    }
}

