    [Route("api/Atributes/{value}")]
    public IHttpActionResult GetAtributeByValue(string value)
    {
        var atribute = ( from a in db.Atributes
                        join p in db.Cards on a.Atr_Nr equals p.Card_Nr
                        where a.Atr_Value == value
                        select new Employee
                        {
                            Name = p.Name,
                            Surname = p.Surname,
                            Number = a.Atr_Value
                        }).ToList();
    
    //use count, if that does not work, length here
        if (atribute.Count() == 0)
        {
            return NotFound();
        }
    
        return Ok(atribute);
    }
