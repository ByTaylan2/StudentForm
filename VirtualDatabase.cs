using System.Collections.Generic;

namespace StudentForm
{
    static internal class VirtualDatabase
    {
        public static List<Student> students;
        static VirtualDatabase()
        {
            students = new List<Student>();
        }
    }
}
