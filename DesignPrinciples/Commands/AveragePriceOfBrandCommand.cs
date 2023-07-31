namespace DesignPrinciples
{
	public class AveragePriceOfBrandCommand : ICommand
	{
        private Receiver receiver;

        public AveragePriceOfBrandCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public void Execute()
        {
            this.receiver.AveragePriceOfBrand();
        }
    }
}

