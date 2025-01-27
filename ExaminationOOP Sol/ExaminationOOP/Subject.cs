using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationOOP
{
	internal class Subject
	{
		public int SubjectId { get; set; }

		public string SubjectName { get; set; }

		public Exam Exam { get; set; }


		public Subject(int subId, string subName)
		{
			SubjectId = subId;
			SubjectName = subName;

		}


		public void CreateExam()
		{
			bool flag, flag2, flag3;
			int typeOfExam, time, numOfQuestions;

			do
			{
				Console.Write("Please choose the type of exam (1 for practical and 2 for final):");

				flag = int.TryParse(Console.ReadLine(), out typeOfExam);
			} while (!(flag && typeOfExam is 1 or 2));


			do
			{
				Console.Write("Please Enter The Time Of Exam from 30 to 180 In Minutes : ");
				flag2 = int.TryParse(Console.ReadLine(), out time);
			} while (!(flag2 && (time >= 30 && time <= 180)));

			do
			{
				Console.Write("Please Enter The Number Of Questions You Want : ");
				flag3 = int.TryParse(Console.ReadLine(), out numOfQuestions);
			} while (!(flag3 && (numOfQuestions > 0)));

			Console.Clear();

			if (typeOfExam == 1)
			{
				Exam = new PracticalExam(time, numOfQuestions);
				Exam.CreateListOfQuestions();
			}
			else
			{
				Exam = new FinalExam(time, numOfQuestions);
				Exam.CreateListOfQuestions();
			}

			Console.Clear();


		}
	}
}
