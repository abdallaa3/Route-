using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationOOP
{
	internal  class MCQ : Question
	{
		public override string Header =>"MCQ Question";


        public MCQ()
        {
            Answers = new Answer[3];
        }

		public override void AddQuestion()
		{
			bool flag,flag1;
			int mark;
            Console.WriteLine(Header);

			do
			{
                Console.WriteLine("Enter The Body Of Qeustion:");
                Body = Console.ReadLine();
			}while(string.IsNullOrWhiteSpace(Body));

			do
			{
				Console.Write("Enter Marks of Question: ");
				flag = int.TryParse(Console.ReadLine(), out mark);

			} while (!(flag && mark > 0));

			Mark = mark;
            Console.WriteLine();

            Console.WriteLine("Choices");

			for (int i = 0;i< Answers.Length; i++)
			{
				Answers[i]=new Answer() { AnswerId=i+1};

				do
				{
					Console.Write($"Enter Choice No.{i + 1}:");
					Answers[i].AnswerText = Console.ReadLine();

				} while (string.IsNullOrWhiteSpace(Answers[i].AnswerText));

            }
            Console.WriteLine();
            int rightAnswerId;

			do
			{
				Console.Write("Enter The Right Answer:(1 or 2 or 3): ");

				flag1 = int.TryParse(Console.ReadLine(), out rightAnswerId);

			} while (!(flag && rightAnswerId is 1 or 2 or 3));

			RightAnswer.AnswerId = rightAnswerId;
			RightAnswer.AnswerText = Answers[rightAnswerId - 1].AnswerText;

			Console.Clear();


		}    
	}
}
