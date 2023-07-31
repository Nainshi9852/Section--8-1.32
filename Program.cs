using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section_8_1._32
{
    class Student
    {
        public string Name { get; set; }
        public string Class { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string filePath = "D:\\Training File\\File Nancy\\student_data_1.txt";

            // Read data from the text file and populate the list of students
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                if (data.Length == 2)
                {
                    students.Add(new Student { Name = data[0].Trim(), Class = data[1].Trim() });
                }
            }

            // Sort the student data using QuickSort
            QuickSort(students, 0, students.Count - 1);

            // Display the sorted data
            Console.WriteLine("Sorted Student Data by Quick Sort:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name}, {student.Class}");
            }

            // Search for a student by name using binary search
            Console.Write("\nEnter the name of the student to search by Binary Search: ");
            string searchName = Console.ReadLine().Trim();

            int index = BinarySearch(students, searchName);
            if (index != -1)
            {
                Student foundStudent = students[index];
                Console.WriteLine($"Student found: {foundStudent.Name}, {foundStudent.Class}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
            Console.ReadKey();
        }

        static void QuickSort(List<Student> students, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(students, low, high);
                QuickSort(students, low, partitionIndex - 1);
                QuickSort(students, partitionIndex + 1, high);
            }
        }

        static int Partition(List<Student> students, int low, int high)
        {
            string pivot = students[high].Name;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (students[j].Name.CompareTo(pivot) <= 0)
                {
                    i++;
                    Swap(students, i, j);
                }
            }

            Swap(students, i + 1, high);
            return i + 1;
        }

        static void Swap(List<Student> students, int i, int j)
        {
            Student temp = students[i];
            students[i] = students[j];
            students[j] = temp;
        }

        static int BinarySearch(List<Student> students, string searchName)
        {
            int left = 0;
            int right = students.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparisonResult = searchName.CompareTo(students[mid].Name);

                if (comparisonResult == 0)
                {
                    return mid; // Found the student at index 'mid'
                }
                else if (comparisonResult < 0)
                {
                    right = mid - 1; // Search in the left half
                }
                else
                {
                    left = mid + 1; // Search in the right half
                }
            }

            return -1; // Student not found

        }
    }
}
