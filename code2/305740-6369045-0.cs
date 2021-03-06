    public static bool RemoveFromRoom(this Student student,School school)
	{
		if (student == null) throw new ArgumentNullException("student");
		if (school == null) throw new ArgumentNullException("school");
		bool ret = false;
		var room = school.Classrooms.SingleOrDefault(cr=>cr.Students.Contains(student));
		if (room !=null)
		{
			ret = true;
			room.Students.Remove(student);
		}
		
		return ret;
	}
