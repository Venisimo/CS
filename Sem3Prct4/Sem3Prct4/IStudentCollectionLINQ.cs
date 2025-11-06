using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3Prct4
{
    // Интерфейс для демонстрации работы к заданию 3 - 4
    public interface IStudentCollectionLINQ
    {
        IReadOnlyList<Student> Students { get; }
        void AddStudent(Student student);
        bool RemoveStudent(Student student);
        IEnumerable<Student> GetStudentsByCourse(int course);
        Student GetYoungestStudent();
        int GetStudentCountByGroup(string group);
        Student GetFirstStudentByName(string name);
        IEnumerable<Student> SortStudentsBySurname(bool ascending = true);
    }
}
