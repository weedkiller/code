    public JsonResult GetAllRecipes()
    {
        var recipes = (from rec db.Recipes
                       join ing in db.Ingredients on rec.Id equals ing.RecipeId into subIngrs
                       from subIngr in subIngrs.DefaultIfEmpty()
                       join tag in db.RecipeTags on rec.Id equals tag.RecipeId into subTags
                       from subTag in subTags.DefaultIfEmpty()
                       order by rec.Name
                       select new 
                       {
                           rec.Id,
                           rec.Name,
                           Quantity = subIngr == null ? null : subIngr.Quantity, 
                           IngrName = subIngr == null ? null : subIngr.Name, 
                           UOM = subIngr == null ? null : subIngr.UOM, 
                           TagName = subTag == null ? null : subTag.Name 
                       }).ToList()
                       .GroupBy(x => new { x.Id, x.Name }).Select(x => new 
                       {
                           x.Key.Id,
                           x.Key.Name,
                           Ingredients = string.Join("," x.Where(x => x.IngrName != null).Select(x => $"{x.Quantity} {x.UOM} {x.Name}").Distinct()),
                           Tags = string.Join("," x.Where(x => x.TagName != null).Select(x => x.TagName).Distinct())
                       }).ToList();
        return new JsonResult { Data = recipes, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
    }
