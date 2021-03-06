    public class CarOverride : IAutoMappingOverride<Car>
    {
        public void Override(AutoMapping<Car> mapping){
            mapping.Id( x => x.Id, "CarId")
              .UnsavedValue(0)
              .GeneratedBy.Identity();
        
            mapping.References(x => x.User, "UserId").Not.Nullable();
            mapping.Map(x => x.PlateNumber, "PlateNumber");
            // other properties
        }
    }
