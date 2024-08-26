using Practice_LINQ_GROUP_JOIN;

// Create a list of students
var studentList = new List<Student>();

studentList.Add(new Student { StudentID = 1, Name = "Ali", ClassID = 1 });
studentList.Add(new Student { StudentID = 2, Name = "Ayşe", ClassID = 2 });
studentList.Add(new Student { StudentID = 3, Name = "Mehmet", ClassID = 1 });
studentList.Add(new Student { StudentID = 4, Name = "Fatma", ClassID = 3 });
studentList.Add(new Student { StudentID = 5, Name = "Ahmet", ClassID = 2 });

// Create a list of classes
var classList = new List<Classroom>();

classList.Add(new Classroom { ClassID = 1, ClassName = "Mathematics" });
classList.Add(new Classroom { ClassID = 2, ClassName = "Turkish" });
classList.Add(new Classroom { ClassID = 3, ClassName = "Chemical" });

// Perform a GroupJoin between classes and students based on ClassID
var classWithStudents = classList.GroupJoin(studentList,
                                              classes => classes.ClassID,
                                              student => student.ClassID,
                                              (classes,classStudents) => new
                                              {
                                                  ClassName = classes.ClassName,
                                                  Students = classStudents             
                                              });

// Print the results, class name with the list of students in that class
foreach (var classes in classWithStudents)
{
    Console.WriteLine($"\n{classes.ClassName}:");

    // Check if there are students in the class and print their names
    foreach (var student in classes.Students)
    {
        Console.WriteLine($"{student.Name}");
    }
}