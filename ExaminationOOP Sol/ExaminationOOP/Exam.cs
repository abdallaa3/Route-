using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationOOP
{
	internal abstract class Exam
	{
		public int Time { get; set; }

		public int NumberOfQuestions { get; set; }

		public Question[] Questions { get; set; }


		public Exam(int time, int numOfQuestions)
		{
			Time = time;
			NumberOfQuestions = numOfQuestions;

		}

		public abstract void ShowExam();
		public abstract void CreateListOfQuestions();
	}
}
