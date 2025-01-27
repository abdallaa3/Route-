using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationOOP
{
	internal class PracticalExam:Exam
	{
		public PracticalExam(int time, int numOfQuestions) : base(time, numOfQuestions)
		{
			
		}

		public override void CreateListOfQuestions()
		{
			Questions = new Question[NumberOfQuestions];
            
            for (int i = 0; i < Questions.Length; i++)
			{
				Questions[i] = new MCQ();
				Questions[i].AddQuestion();
			}
			
		}

		public override void ShowExam()
		{
			for (int i = 0;i < Questions.Length;i++)
			{
                Console.Write($"Q.{i+1}-");
                Console.WriteLine(Questions[i]);
				for(int j = 0; j < Questions[i].Answers.Length;j++)
				{
					Console.WriteLine(Questions[i].Answers[j]);
                }
                Console.WriteLine("------------------");

				int userAnswer;
				bool flag;

				do
				{
                    Console.Write("Enter your answer:(1 or 2 or 3):");
					flag=int.TryParse(Console.ReadLine(), out userAnswer);
                }while(!(flag&&userAnswer is 1 or 2 or 3));


				Questions[i].UserAnswer.AnswerId = userAnswer;
				Questions[i].UserAnswer.AnswerText = Questions[i].Answers[userAnswer - 1].AnswerText;

                Console.WriteLine("========================");

            }
			Console.Clear();
            Console.WriteLine("Ther Right Answers");
            for (int i = 0;i<Questions.Length;i++)
			{
				Console.WriteLine($"Q.{i + 1}:{Questions[i].Body}=>{Questions[i].RightAnswer.AnswerText}");
				Console.WriteLine("================================");
            }
        }
	}
}
