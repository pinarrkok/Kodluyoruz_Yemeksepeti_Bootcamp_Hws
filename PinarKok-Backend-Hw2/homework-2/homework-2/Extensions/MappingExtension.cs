using homework_2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_2.Extensions
{
    public static class MappingExtension
    {
        public static List<Exam> ExamListMapping(this List<ExamDto> data)
        {
            return data.Select(e => new Exam
            {
                Id = e.Id,
                Title = e.Title,
                Information = e.Information,
                NumberOfQuestions = e.NumberOfQuestions,
                AddedAt = DateTime.Now,
                StartTime = e.StartTime,
                EndTime = e.EndTime
            }).ToList();
        }

        public static List<ExamDto> ExamDtoListMapping(this List<Exam> data)
        {
            List<ExamDto> result = new List<ExamDto>();
            foreach (var item in data)
            {
                result.Add(new ExamDto
                {
                    Id = item.Id,
                    Title = item.Title,
                    Information = item.Information,
                    NumberOfQuestions = item.NumberOfQuestions,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime
                });
            }
            return result;
        }

        public static Exam ExamMapping(this ExamDto examDto)
        {
            Exam exam = new Exam
            {
                Id = examDto.Id,
                Title = examDto.Title,
                Information = examDto.Information,
                NumberOfQuestions = examDto.NumberOfQuestions,
                AddedAt = DateTime.Now,
                StartTime = examDto.StartTime,
                EndTime = examDto.EndTime
            };

            return exam;
        }

        public static ExamDto ExamDtoMapping(this Exam exam)
        {
            ExamDto examDto = new ExamDto
            {
                Id = exam.Id,
                Title = exam.Title,
                Information = exam.Information,
                NumberOfQuestions = exam.NumberOfQuestions,
                StartTime = exam.StartTime,
                EndTime = exam.EndTime
            };

            return examDto;
        }
    }
}
