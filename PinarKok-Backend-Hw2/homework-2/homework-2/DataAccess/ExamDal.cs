using homework_2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace homework_2.DataAccess
{
    public class ExamDal
    {
        public List<Exam> exams = new List<Exam>();
        private static string FILE_NAME = "exams.json";

        public ExamDal()
        {
            if (File.Exists(FILE_NAME))
            {
                exams = JsonSerializer.Deserialize<List<Exam>>(File.ReadAllText(FILE_NAME));
            }
        }

        private void SynchronizeJsonFile()
        {
            File.WriteAllText(FILE_NAME, JsonSerializer.Serialize(exams));
        }

        public List<Exam> GetAll()
        {
            return exams;
        }

        public void Add(Exam exam)
        {
            exams.Add(exam);
            SynchronizeJsonFile();
        }

        public void Update(Exam exam)
        {
            int index = exams.FindIndex(e => e.Id == exam.Id);
            exams[index] = exam;
            SynchronizeJsonFile();
        }

        public void Remove(int id)
        {
            exams.Remove(exams.FirstOrDefault(e => e.Id == id));
            SynchronizeJsonFile();
        }
    }
}
