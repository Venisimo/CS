using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3Prct4
{
    // Класс к заданию 3 - 4 для демонстрации работы методов расширения запросовов LINQ
    public class ExpansionStudentCollection : IStudentCollectionLINQ
    {
        private readonly List<Student> students; // Поле со списком студентов

        // Конструктор по умолчанию
        public ExpansionStudentCollection()
        {
            students = new List<Student>();
            InitializeDefaultStudents();
        }



        // Метод для чтения содержимого поля класса
        public IReadOnlyList<Student> Students => students.AsReadOnly();

        // Добавить студента в список
        public void AddStudent(Student student)
        {
            if (student == null) throw new ArgumentNullException(nameof(student));
            students.Add(student);
        }

        // Удалить студента из списка
        public bool RemoveStudent(Student student)
        {
            return students.Remove(student);
        }



        // Вывести список студентов заданного курса
        public IEnumerable<Student> GetStudentsByCourse(int course)
        {
            return students.Where(s => s.Course == course);
        }

        // Найти самого молодого студента
        public Student GetYoungestStudent()
        {
            return students.OrderByDescending(s => s.BirthDate).FirstOrDefault();
        }

        // Вывести количество студентов заданной группы
        public int GetStudentCountByGroup(string group)
        {
            return students.Count(s => s.Group.Equals(group, StringComparison.OrdinalIgnoreCase));
        }

        // Найти первого студента с заданным именем
        public Student GetFirstStudentByName(string name)
        {
            return students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        // Вывести список студентов, упорядоченный по фамилии true - по возрастанию false - по убыванию
        public IEnumerable<Student> SortStudentsBySurname(bool ascending = true)
        {
            return ascending ? students.OrderBy(s => s.Surname) : students.OrderByDescending(s => s.Surname);
        }


        // Инициализация 20 студентов в список
        private void InitializeDefaultStudents()
        {
            students.AddRange(new[]
            {
        new Student("Иванов", "Иван", "Иванович", new DateTime(2000, 5, 15), 1, "ЛА-101"),
        new Student("Петров", "Петр", "Петрович", new DateTime(2001, 3, 20), 1, "ЛА-101"),
        new Student("Сидорова", "Анна", "Сергеевна", new DateTime(2000, 8, 10), 1, "ИБ-101"),
        new Student("Козлов", "Алексей", "Дмитриевич", new DateTime(1999, 12, 5), 2, "ИП-201"),
        new Student("Николаева", "Мария", "Владимировна", new DateTime(2000, 2, 28), 2, "ЛА-201"),
        new Student("Федоров", "Сергей", "Андреевич", new DateTime(2001, 7, 15), 2, "ИБ-201"),
        new Student("Морозова", "Елена", "Игоревна", new DateTime(1999, 11, 30), 3, "ИП-301"),
        new Student("Волков", "Дмитрий", "Олегович", new DateTime(1998, 4, 25), 3, "ЛА-301"),
        new Student("Алексеева", "Ольга", "Петровна", new DateTime(2000, 9, 12), 3, "ИБ-301"),
        new Student("Лебедев", "Андрей", "Викторович", new DateTime(1999, 6, 8), 4, "ИП-401"),
        new Student("Семенова", "Ирина", "Александровна", new DateTime(1998, 1, 18), 4, "ЛА-401"),
        new Student("Павлов", "Михаил", "Сергеевич", new DateTime(2001, 10, 5), 4, "ИБ-401"),
        new Student("Громов", "Артем", "Владимирович", new DateTime(1997, 3, 14), 5, "ЛА-501"),
        new Student("Орлова", "Наталья", "Дмитриевна", new DateTime(1998, 7, 22), 5, "ИП-501"),
        new Student("Белов", "Константин", "Игоревич", new DateTime(1999, 2, 11), 5, "ИБ-501"),
        new Student("Киселева", "Виктория", "Андреевна", new DateTime(2000, 12, 3), 1, "ЛА-102"),
        new Student("Григорьев", "Павел", "Николаевич", new DateTime(2001, 4, 17), 1, "ИБ-102"),
        new Student("Соколова", "Алиса", "Романовна", new DateTime(2000, 6, 9), 2, "ИП-202"),
        new Student("Новиков", "Роман", "Витальевич", new DateTime(1999, 8, 26), 3, "ЛА-302"),
        new Student("Кузнецова", "Екатерина", "Артемовна", new DateTime(1998, 5, 13), 4, "ИБ-402"),
        new Student("Михайлов", "Арсений", "Юрьевич", new DateTime(2002, 1, 8), 1, "ИП-103"),
        new Student("Зайцева", "Дарья", "Сергеевна", new DateTime(2001, 11, 19), 2, "ЛА-202"),
        new Student("Егоров", "Владислав", "Анатольевич", new DateTime(2000, 7, 7), 3, "ИБ-303"),
        new Student("Романова", "София", "Алексеевна", new DateTime(1999, 9, 25), 4, "ИП-402"),
        new Student("Сорокин", "Георгий", "Денисович", new DateTime(1997, 12, 14), 5, "ЛА-502")
    });
        }
    }
}