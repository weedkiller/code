    private async void RecalculateItemsPerPage()
    {
        await Task.Run(new Action(async () =>
        {
            await Application.Current.Dispatcher.InvokeAsync(new Action(() =>
            {
                Clear();
    
                var startIndex = _currentPage * _itemsPerPage - _itemsPerPage;
    
                for (var i = startIndex; i < startIndex + _itemsPerPage; i++)
                {
                    if (_originalCollection.Count > i)
                    {
                        base.InsertItem(i - startIndex, _originalCollection[i]);
                    }
                }
            }));
        }));
    }
