using System;

namespace FinancialFoundations.StudentWork.CoreProcessing
{
	public class StudentGrade : IEquatable<StudentGrade>
	{
		public StudentGrade(int numberOfCorrectAnswers, int numberOfQuestions)
		{
			NumberOfCorrectAnswers = numberOfCorrectAnswers;
			NumberOfQuestions = numberOfQuestions;
		}

		public int NumberOfCorrectAnswers { get; }
		public int NumberOfQuestions { get; }

		public bool Equals(StudentGrade other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return NumberOfCorrectAnswers == other.NumberOfCorrectAnswers && NumberOfQuestions == other.NumberOfQuestions;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == this.GetType() && Equals((StudentGrade) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (NumberOfCorrectAnswers * 397) ^ NumberOfQuestions;
			}
		}
	}
}