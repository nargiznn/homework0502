using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace homework0502
{
    public class Student
    {
        public int No;
        public string FullName;
        Dictionary<string, int> exams = new Dictionary<string, int>();
        public Student()
        {
            exams = new Dictionary<string, int>();
        }
        public void AddExam(string name, int points)
        {
            exams.Add(name, points);
            Console.WriteLine("Yeni imtahan əlavə edildi!");
        }
        public void RemoveExam(string examname,int points)
        {
            if (exams.ContainsKey(examname) && exams[examname] == points)
            {
                exams.Remove(examname);
                Console.WriteLine($"{examname} imtahanı {points} bal ilə silindi.");
            }
            else
            {
                Console.WriteLine($"Tələbənin {examname} imtahanı tapılmadı və ya {points} balı ilə əlaqəli deyil!");
            }
        }
        //-GetExamResult() - examName dəyəri qəbul edib həmin exam -in balını qaytarır
        public int GetExamResult(string examName)
        {
            if (exams.ContainsKey(examName))
            {
                return exams[examName];
            }
            else
            {
                Console.WriteLine($"Tələbənin {examName} imtahanı tapılmadı!");
                return -1;
            }
        }

        public double GetExamAvg()
        {
            if (exams.Count == 0)
            {
                Console.WriteLine("Tələbənin heç bir imtahanı yoxdur!");
                return 0;
            }

            double total = 0;
            foreach (var point in exams.Values)
            {
                total += point;
            }

            return total / exams.Count;
        }
        public Dictionary<string, int> GetExams()
        {
            return exams;
        }


    }
}

