using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationOOP
{
	internal class FinalExam:Exam
	{
		public FinalExam(int time, int numOfQuestions) : base(time, numOfQuestions)
		{
		}

		public override void CreateListOfQuestions()
		{
			Questions = new Question[NumberOfQuestions];

			for (int i = 0; i < Questions.Length; i++)
			{
				int questionType;
				bool flag;

				do
				{
					Console.Write("Enter Type Of Questions (1 for MCQ and 2 for T/f):");
					flag = int.TryParse(Console.ReadLine(), out questionType);
				} while (!(flag && questionType is 1 or 2));

				if (questionType == 1)
				{
					Questions[i]=new MCQ();
					Questions[i].AddQuestion();

				}

				else
				{
					Questions[i]=new TFQuestion();
					Questions[i].AddQuestion();
				}
			}

			Console.Clear();
		}

		public override void ShowExam()
		{
			int userAnswer;
			bool flag;
            for (int i = 0;i < Questions.Length;i++)
			{
                Console.Write($"Q.{i+1}:");
                Console.WriteLine(Questions[i]);

				for(int j = 0; j < Questions[i].Answers.Length;j++)
				{
					Console.WriteLine($"{Questions[i].Answers[j]}");
                }

                Console.WriteLine("-------------------------");


				if (Questions[i].GetType()==typeof(MCQ))
				{
					do
					{
                        Console.Write("Enter yor answer (1 or 2 or 3):");
						flag=int.TryParse(Console.ReadLine(), out userAnswer);
                    }while(!(flag && userAnswer is 1 or 2 or 3));

				}

                else
                {
                    do
					{
                        Console.Write("Enter Your answer 1 for true and 2 for false :");
						flag = int.TryParse(Console.ReadLine(), out userAnswer);
                    }while(!(flag &&userAnswer is 1 or 2 ));
                }

				Questions[i].UserAnswer.AnswerId= userAnswer;
				Questions[i].UserAnswer.AnswerText = Questions[i].Answers[userAnswer-1].AnswerText;
				Console.WriteLine("=================================");

            }

			Console.Clear();

			int grade = 0, totalMarks = 0;

			for (int i = 0; i < Questions.Length;i++)
			{
				totalMarks += Questions[i].Mark;

				if (Questions[i].UserAnswer.AnswerId == Questions[i].RightAnswer.AnswerId)
					grade += Questions[i].Mark;

				Console.WriteLine($"Q{i + 1}.{Questions[i].Body}\t\t({Questions[i].Mark} Marks)");
				Console.WriteLine($"Your Answer=>{Questions[i].UserAnswer.AnswerText}");
				Console.WriteLine($"Right Answer=>{Questions[i].RightAnswer.AnswerText}");
				Console.WriteLine("=================================");
            }

            Console.WriteLine($"Your grade is  {grade}/{totalMarks}Marks");



        }
	}
}
