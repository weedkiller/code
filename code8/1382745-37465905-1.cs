    public class CountSubject<T> : ISubject<T>, IDisposable
    {
        private readonly ISubject<T> _baseSubject;
        private int _counter;
        private IDisposable _disposer = Disposable.Empty;
        private bool _disposed;
        public int Count
        {
            get { return _counter; }
        }
        public CountSubject()
            : this(new Subject<T>())
        {
            // Need to clear up Subject we created
            _disposer = (IDisposable) _baseSubject;
        }
        public CountSubject(ISubject<T> baseSubject)
        {
            _baseSubject = baseSubject;
        }
        public void OnCompleted()
        {
            _baseSubject.OnCompleted();
        }
        public void OnError(Exception error)
        {
            _baseSubject.OnError(error);
        }
        public void OnNext(T value)
        {
            _baseSubject.OnNext(value);
        }
        public IDisposable Subscribe(IObserver<T> observer)
        {
            Interlocked.Increment(ref _counter);
            return new CompositeDisposable(Disposable.Create(() => Interlocked.Decrement(ref _counter)),
                                           _baseSubject.Subscribe(observer));
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _disposer.Dispose();
                }
                _disposed = true;
            }
        }
    }
