    private async Task CheckConditions()
    {
        foreach (var obj in myObjects)
        {
            if (obj.ConditionMet)
            {
                await HandleConditionAsync(obj);
            }
        }
        DoOtherWork();
    }
