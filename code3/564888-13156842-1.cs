    public ActionResult EditEntity(EntityDto model)
    {
        using(var context = new MyContext())
        {
            var entity = Mapper.Map<Entity>(model);
            context.Set<Entity>().Attach(entity); // (or context.Entity.Attach(entity);)
            context.Entry<Entity>(entity).State = System.Data.EntityState.Modified;
            context.SaveChanges();
            return View(model);
        }
    }
