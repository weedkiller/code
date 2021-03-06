     foreach (DbEntityEntry entity in
                     ChangeTracker.Entries().Where(e => e.State == EntityState.Modified)
            {
                foreach (var propName in entity.CurrentValues.PropertyNames)
                {
                    var current = entity.CurrentValues[propName];
                    var original = entity.OriginalValues[propName];
                }
            }
