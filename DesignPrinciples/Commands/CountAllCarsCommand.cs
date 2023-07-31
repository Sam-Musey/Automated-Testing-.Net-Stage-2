namespace DesignPrinciples
{
	public class CountAllCarsCommand : ICommand
	{
        private Receiver receiver;

		public CountAllCarsCommand(Receiver receiver)
		{
            this.receiver = receiver;
		}

        public void Execute()
        {
            this.receiver.CountAllCarsCommand();
        }
    }
}

