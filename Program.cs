using System;

namespace CSC_295_hwWeek3
{

class Student
{
    public string Name { get; }
    public double Gpa { get; }

     public Student(string name, double gpa)
     {
            if (gpa < 0 || gpa > 4)
            {
                throw new ArgumentException("GPA must be between 0 and 4");
            }
            Name = name;
            Gpa = gpa;
        }
    }
    class StudentSorter
    {
        static void Main(string[] args)
        {
            Student[] students = {
            new Student("Chai", 3.5),
            new Student("Robert", 3.8),
            new Student("Julian", 2.9),
            new Student("Lee", 3.2),
            new Student("Josh", 3.9)
        };

            while (true)
            {
                Console.WriteLine("Select sorting algorithm:");
                Console.WriteLine("1. Bubble Sort");
                Console.WriteLine("2. Selection Sort");
                Console.WriteLine("3. Insertion Sort");
                Console.WriteLine("4. Merge Sort");
                Console.WriteLine("5. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        BubbleSort(students);
                        break;
                    case 2:
                        SelectionSort(students);
                        break;
                    case 3:
                        InsertionSort(students);
                        break;
                    case 4:
                        students = MergeSort(students);
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Type a number 1 - 4 in correlation to the sort");
                        continue;
                }

                Console.WriteLine("Sorted list of students by GPA (descending):");
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.Name} - {student.Gpa}");
                }
                Console.ReadKey();
            }
        }

        static void BubbleSort(Student[] students)
        {
            int n = students.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (students[j].Gpa < students[j + 1].Gpa)
                    {
                        // swap students[j+1] and students[j]
                        var temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }
        }

        static void SelectionSort(Student[] students)
        {
            int n = students.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int maxIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (students[j].Gpa > students[maxIdx].Gpa)
                    {
                        maxIdx = j;
                    }
                }
                var temp = students[maxIdx];
                students[maxIdx] = students[i];
                students[i] = temp;
            }
        }

        static void InsertionSort(Student[] students)
        {
            int n = students.Length;
            for (int i = 1; i < n; ++i)
            {
                var key = students[i];
                int j = i - 1;

                while (j >= 0 && students[j].Gpa < key.Gpa)
                {
                    students[j + 1] = students[j];
                    j = j - 1;
                }
                students[j + 1] = key;
            }
        }

        static Student[] MergeSort(Student[] students)
        {
            if (students.Length <= 1)
            {
                return students;
            }

            int mid = students.Length / 2;
            var left = new Student[mid];
            var right = new Student[students.Length - mid];

            Array.Copy(students, 0, left, 0, mid);
            Array.Copy(students, mid, right, 0, students.Length - mid);

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        static Student[] Merge(Student[] left, Student[] right)
        {
            var result = new Student[left.Length + right.Length];
            int i = 0, j = 0, k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i].Gpa >= right[j].Gpa)
                {
                    result[k++] = left[i++];
                }
                else
                {
                    result[k++] = right[j++];
                }
            }
            while (i < left.Length)
            {
                result[k++] = left[i++];
            }
            while (j < right.Length)
            {
                result[k++] = right[j++];
            }
            return result;
        }
    }
}
