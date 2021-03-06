    AsyncProducerConsumerQueue<Packet[]> _queue;
    // producer
    async Task ReceiveAsync(CancellationToken token)
    {
        while (true)
        {
           var list = new List<Packet>();
           while (true)
           {
               token.ThrowIfCancellationRequested(token);
               var packet = await _device.ReadAsync(token);
               list.Add(packet);
               if (list.Count == 1000)
                   break;
           }
           // push next batch
           await _queue.EnqueueAsync(list.ToArray(), token);
        }
    }
    // consumer
    async Task LogAsync(CancellationToken token)
    {
        Task previousFlush = Task.FromResult(0); 
        var cts = new CancellationTokenSource();
        while (true)
        {
           token.ThrowIfCancellationRequested(token);
           // get next batch
           var nextBatch = await _queue.DequeueAsync(token);
           cts.Cancel(); // cancel the previous flush if not ready
           await previousFlush; // this throws cancellation exception if not completed
           // start flushing
           cts = CancellationTokenSource.CreateLinkedTokenSource(token);
           previousFlush = WriteAsync(nextBatch, cts.Token);
        }
    }
    async Task WriteAsync(Packet[] list, CancellationToken token)
    {
        // write the batch to a file asynchronously
        // ...
    }
