using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3Prct4
{
    // Класс Студент к заданию 2
    public class Student
    {
        private string surname;
        private string name;
        private string patronymic;
        private DateTime birthDate;
        private int course;
        private string group;

        // Конструктор по умолчанию
        public Student()
        {
            Surname = "Неизвестно";
            Name = "Неизвестно";
            Patronymic = "Неизвестно";
            BirthDate = new DateTime(2000, 1, 1);
            Course = 1;
            Group = "Неизвестно";
        }

        // Конструктор с параметрами
        public Student(string surname, string name, string patronymic, DateTime birthDate, int course, string group)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            BirthDate = birthDate;
            Course = course;
            Group = group;
        }

        // Свойства с валидацией
        public string Surname
        {
            get { return surname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Фамилия не может быть пустой");
                surname = value.Trim();
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Имя не может быть пустым");
                name = value.Trim();
            }
        }

        public string Patronymic
        {
            get { return patronymic; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Отчество не может быть пустым");
                patronymic = value.Trim();
            }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                if (value > DateTime.Now) throw new ArgumentException("Дата рождения не может быть в будущем");

                if (value < DateTime.Now.AddYears(-100)) throw new ArgumentException("Студент не может быть старше 100 лет");
                birthDate = value;
            }
        }

        public int Course
        {
            get { return course; }
            set
            {
                if (value < 1 || value > 6) throw new ArgumentException("Курс должен быть в диапазоне от 1 до 6");
                course = value;
            }
        }

        public string Group
        {
            get { return group; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Группа не может быть пустой");
                group = value.Trim().ToUpper();
            }
        }

        // Методы
        public string GetFullName()
        {
            return $"{Surname} {Name} {Patronymic}";
        }

        public override string ToString()
        {
            return $"{GetFullName()}, {birthDate:dd.MM.yyyy} дата рождения, {Course} курс, группа {Group}";
        }
    }
}