using homework0502;

List<Student> students = new List<Student>();
string opt;
do
{
    Console.WriteLine("\n-----------------------------Console App-------------------------");
    Console.WriteLine("1 -> Tələbə əlavə et+");
    Console.WriteLine("2 -> Tələbəyə imtahan əlavə et");
    Console.WriteLine("3 -> Tələbənin bir imtahan balına bax");
    Console.WriteLine("4 -> Tələbənin bütün imtahanlarını göstər ");
    Console.WriteLine("5 -> Tələbənin imtahan ortalamasını göstər ");
    Console.WriteLine("6 -> Tələbədən imtahan sil ");
    Console.WriteLine("7 -> Bütün tələbələr +");
    Console.WriteLine("0 -> Proqramı bitir +");
    Console.WriteLine("-----------------------------------------------------------------");
    Console.WriteLine(" Seçim edin !");
    opt = Console.ReadLine();

    switch (opt)
    {
        case "1":
            Console.Write("Tələbə adını daxil edin: ");
            string fullName = Console.ReadLine();
            Student newStudent = new Student();
            newStudent.FullName = fullName;
            newStudent.No = students.Count == 0 ? 1 : students.Last().No + 1;
            students.Add(newStudent);
            Console.WriteLine("Tələbə əlavə edildi!");
            break;
        case "2":
            //2. Tələbəyə imtahan əlavə et
            //2 seçilərsə tələbənin nömrəsi, imtahan adı və qiyməti daxil edilir
            Console.Write("Tələbə nömrəsini daxil edin: ");
            int studentNo = Convert.ToInt32(Console.ReadLine());

            Student selectedStudent = students.FirstOrDefault(s => s.No == studentNo);
            if (selectedStudent != null)
            {
                Console.Write("Imtahan adını daxil edin: ");
                string examName = Console.ReadLine();
                Console.Write("Pointi daxil edin : ");
                int examPoint = Convert.ToInt32(Console.ReadLine());
                selectedStudent.AddExam(examName, examPoint);
            }
            else
            {
                Console.WriteLine("Tələbə tapılmadı!");
            }
            break;
        case "3":
            //3. Tələbənin bir imtahan balına bax
            //3 seçilərsə tələbə no dəyəri və imtahan adı daxil edilməlidir və
            //nömrəsi daxil edlən tələbənin həmin imtahan balı göstərilməlidir
            Console.Write("Tələbə nömrəsini daxil edin: ");
            int studentNumberForResult = Convert.ToInt32(Console.ReadLine());
            Console.Write("Imtahan adını daxil edin: ");
            string examNameForResult = Console.ReadLine();

            Student selectedStudentForResult = students.FirstOrDefault(s => s.No == studentNumberForResult);
            if (selectedStudentForResult != null)
            {
                int result = selectedStudentForResult.GetExamResult(examNameForResult);
                if (result != -1)
                {
                    Console.WriteLine($"Tələbənin {examNameForResult} imtahan nəticəsi: {result}");
                }
            }
            else
            {
                Console.WriteLine("Tələbə tapılmadı!");
            }

            break;
        case "4":
            //4. Tələbənin bütün imtahanlarını göstər
            //4 seçilərsə tələbənin no dəyəri daxil edilir və o tələbənin bütün imthan
            //adları və balları göstərilir
            Console.Write("Tələbə nömrəsini daxil edin: ");
            int studentNumberForExams = Convert.ToInt32(Console.ReadLine());

            Student selectedStudentForExams = students.FirstOrDefault(s => s.No == studentNumberForExams);
            if (selectedStudentForExams != null)
            {
                Console.WriteLine($"\n{selectedStudentForExams.FullName} tələbəsinin imtahan nəticələri:");
                var exams = selectedStudentForExams.GetExams();
                foreach (var exam in exams)
                {
                    Console.WriteLine($"{exam.Key}: {exam.Value}");
                }
            }
            else
            {
                Console.WriteLine("Tələbə tapılmadı!");
            }
            break;
        case "5":
            Console.Write("Tələbə nömrəsini daxil edin: ");
            int studentNumberForAvg = Convert.ToInt32(Console.ReadLine());

            Student selectedStudentForAvg = students.FirstOrDefault(s => s.No == studentNumberForAvg);
            if (selectedStudentForAvg != null)
            {
                double avg = selectedStudentForAvg.GetExamAvg();
                Console.WriteLine($"{selectedStudentForAvg.FullName} tələbəsinin imtahan ortalaması: {avg}");
            }
            else
            {
                Console.WriteLine("Tələbə tapılmadı!");
            }
            break;
        case "6":
            //6.Tələbədən imtahan sil
            //6 seçilərsə tələbə no dəyəri və imtahan adı daxil edilir və
            //həmin tələbədən həmin imtahan dəyəri silinir
            Console.Write("Tələbə nömrəsini daxil edin: ");
            int studentNo1 = Convert.ToInt32(Console.ReadLine());

            Student selectedStudent1 = students.FirstOrDefault(s => s.No == studentNo1);
            if (selectedStudent1 != null)
            {
                Console.Write("Imtahan adını daxil edin: ");
                string examName = Console.ReadLine();
                Console.Write("Pointi daxil edin : ");
                int examPoint = Convert.ToInt32(Console.ReadLine());
                selectedStudent1.RemoveExam(examName, examPoint);
            }
            else
            {
                Console.WriteLine("Tələbə tapılmadı!");
            }
            break;
        case "7":
            Console.WriteLine("\n-----------Bütün tələbələr-------------");
            foreach (var student in students)
            {
                Console.WriteLine($"Nömrə: {student.No}, Ad: {student.FullName}");
            }
            break;
        case "0":
            Console.WriteLine("\nƏməliyyat bitdi!");
            break;
        default:
            Console.WriteLine("\nƏməliyyat yanlışdır!");
            break;

    }
}
while (opt != "0");

