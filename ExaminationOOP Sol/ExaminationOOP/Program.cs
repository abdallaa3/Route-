using System.Diagnostics;

namespace ExaminationOOP
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Subject sub = new Subject(1, "C#");

			sub.CreateExam();

			Console.Clear();


			char YesOrNo;
			bool flag;
			do
			{
				Console.Write("Do You Want To Start Exam : Press (Y for Yes and N for No):");
				flag = char.TryParse(Console.ReadLine(), out YesOrNo);

			} while (!(flag && char.ToLower(YesOrNo) == 'y' || char.ToLower(YesOrNo) == 'n'));

			if(YesOrNo=='y')
			{
				Console.Clear() ;
				Stopwatch stopwatch=new Stopwatch();
				stopwatch.Start();
				sub.Exam.ShowExam();
				
                Console.WriteLine($"The ELpased Time:{stopwatch.Elapsed}");

            }


		}
	}
}
