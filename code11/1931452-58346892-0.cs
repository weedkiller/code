public static List<Objects.Logs.GenericLog> GetLogs(int entityId = int.MinValue, 
    int logLevelId = int.MinValue, DateTime startDate = DateTime.MinValue, 
    DateTime endDate = DateTime.MinValue)
{
    using(var db = CORAContext.GetCORAContext())
    {
        return db.GenericLog
            .Where(i => startDate = DateTime.MinValue || i.LogDateTime >= startDate)
            .Where(i => endDate = DateTime.MinValue || i.LogDateTime <= endDate)
            .Where(i => entityId = int.MinValue || i.EntityId == entityId)
            .Where(i => logLevelId = int.MinValue || i.LogLevelId == logLevelId)
            .Select(i => new Objects.Logs.GenericLog
            {
                EntityId = i.FkEntityId,
                LogSourceCode = i.FkLogSourceCode,
                LogLevelId = i.FkLogLevelId,
                LogDateTime = i.LogDateTime,
                LogId = i.PkLogId,
                Message = i.Message
            }).ToList();
    }
}
