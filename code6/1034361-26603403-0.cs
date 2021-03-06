    public class AutofacCommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext context;
        public AutofacCommandDispatcher(IComponentContext context)
        {
            this.context = context;
        }
        public void Dispatch<TCommand>(TCommand command)
        {
            var handler = container.Resolve<ICommandHandler<TCommand>>();
            void handler.Handle(command);
        }
    }
