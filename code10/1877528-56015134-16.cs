    var ids = new HashSet<int?>();
    foreach (var s1 in studentList1)
    {
        ids.Add(s1.StudentID);
    }
    for (var i = studentList2.Count - 1; i >= 0; --i)
    {
        if (ids.Contains(studentList2[i].StudentID))
        {
            studentList2.Remove(studentList2[i]);
        }
    }
    foreach (var student in studentList2)
    {
        Console.WriteLine(student);
    }
    // StudentID=4 StudentName=Ram
    // StudentID=5 StudentName=Ron
