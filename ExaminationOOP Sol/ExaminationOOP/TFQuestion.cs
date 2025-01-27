using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationOOP
{
	internal class TFQuestion : Question
	{
		public override string Header => "True or False Question";


        public TFQuestion()
        {
			Answers = new Answer[2];
			Answers[0] = new Answer(1, "true");
			Answers[1]=new Answer(2, "false");

        }

        public override void AddQuestion()
		{
            Console.WriteLine(Header);

			bool flag,flag1;
			int mark;

			do
			{
                Console.Write("Enter The Body Of Question:");
                Body = Console.ReadLine();
			}while(string.IsNullOrWhiteSpace(Body));


			do
			{
                Console.Write("Enter Mark of quesion : ");
				flag=int.TryParse(Console.ReadLine(), out mark);
            }while(!(flag&&mark>0));

			Mark= mark;
            Console.WriteLine();

            int rightAnswer;

			do
			{
				Console.Write("Please enter the right answer 1 for true and 2 for false : ");
				flag1 = int.TryParse(Console.ReadLine(), out rightAnswer);
			} while (!(flag && rightAnswer is 1 or 2));

			RightAnswer.AnswerId= rightAnswer;
			RightAnswer.AnswerText = Answers[rightAnswer-1].AnswerText;


			Console.Clear();




        }
	}
}
