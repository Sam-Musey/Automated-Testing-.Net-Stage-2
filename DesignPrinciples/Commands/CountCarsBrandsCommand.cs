namespace DesignPrinciples
{
	public class CountCarsBrandsCommand : ICommand
    {
        private Receiver receiver;

        public CountCarsBrandsCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public void Execute()
        {
            this.receiver.CountNumberOfUniqueBrands();
        }
    }
}

