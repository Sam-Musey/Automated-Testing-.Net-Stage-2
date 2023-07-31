namespace DesignPrinciples
{
	public class AveragePriceOfAllCarsCommand : ICommand
    {
        private Receiver receiver;

        public AveragePriceOfAllCarsCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public void Execute()
        {
            this.receiver.AveragePriceOfAllCars();
        }
    }
}

