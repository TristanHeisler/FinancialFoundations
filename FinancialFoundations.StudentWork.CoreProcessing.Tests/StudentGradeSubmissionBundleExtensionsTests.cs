using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoFakeItEasy;
using AutoFixture.Xunit2;
using FinancialFoundations.StudentWork.Domain;
using FluentAssertions;
using Xunit;

namespace FinancialFoundations.StudentWork.CoreProcessing.Tests
{
	public class StudentGradeSubmissionBundleExtensionsTests
	{
		[Theory]
		[NoCorrectAnswersArrangement]
		public void ShouldReturnZeroGradeWhenStudentAnswersAllQuestionsWrong(StudentGradeSubmissionBundle submissionBundle, StudentGrade expectedGrade)
		{
			VerifyComputedGradeMatchesExpectedGrade(submissionBundle, expectedGrade);
		}

		[Theory]
		[SomeCorrectAnswersArrangement]
		public void ShouldReturnTheExpectedGrade(StudentGradeSubmissionBundle submissionBundle, StudentGrade expectedGrade)
		{
			VerifyComputedGradeMatchesExpectedGrade(submissionBundle, expectedGrade);
		}

		[Theory]
		[AllCorrectAnswersArrangement]
		public void ShouldReturnPerfectGradeWhenStudentAnswersAllQuestionsCorrectly(StudentGradeSubmissionBundle submissionBundle, StudentGrade expectedGrade)
		{
			VerifyComputedGradeMatchesExpectedGrade(submissionBundle, expectedGrade);
		}

		private static void VerifyComputedGradeMatchesExpectedGrade(StudentGradeSubmissionBundle submissionBundle, StudentGrade expectedGrade)
		{
			var grade = submissionBundle.ComputeGrade();
			grade.Should().BeEquivalentTo(expectedGrade);
		}

		#region Arrangements

		private abstract class StudentGradeSubmissionBundleExtensionsTestsArrangementBase : AutoDataAttribute
		{
			protected StudentGradeSubmissionBundleExtensionsTestsArrangementBase(Func<StudentGradeSubmissionBundle> bundleFactory, Func<StudentGrade> studentGradeFactory)
			: base(() => new Fixture()
				.Customize(new AutoFakeItEasyCustomization())
				.Customize(new StudentGradeSubmissionBundleCustomization(bundleFactory))
				.Customize(new StudentGradeCustomization(studentGradeFactory)))
			{

			}
		}

		private class NoCorrectAnswersArrangement : StudentGradeSubmissionBundleExtensionsTestsArrangementBase
		{
			private static StudentGradeSubmissionBundle MakeStudentGradeSubmissionBundle()
			{
				var assignmentAnswerKey = CreateAssignmentAnswerKey();
				var studentAssignmentSubmission = new StudentAssignmentSubmission(Guid.Empty, Guid.Empty, Guid.Empty, assignmentAnswerKey.MultipleChoiceQuestionAnswerCollection.Select(x => new StudentAssignmentSubmissionMultipleChoiceQuestionAnswer(x.QuestionID, Guid.NewGuid())));
				return new StudentGradeSubmissionBundle(assignmentAnswerKey, studentAssignmentSubmission);
			}

			public NoCorrectAnswersArrangement()
				: base(MakeStudentGradeSubmissionBundle, () => new StudentGrade(0, CreateAssignmentAnswerKey().MultipleChoiceQuestionAnswerCollection.Count()))
			{
			}
		}

		private class SomeCorrectAnswersArrangement : StudentGradeSubmissionBundleExtensionsTestsArrangementBase
		{
			private static StudentGradeSubmissionBundle MakeStudentGradeSubmissionBundle()
			{
				var assignmentAnswerKey = CreateAssignmentAnswerKey();
				var studentAssignmentSubmission = new StudentAssignmentSubmission(Guid.Empty, Guid.Empty, Guid.Empty, assignmentAnswerKey.MultipleChoiceQuestionAnswerCollection.Select((x, i) => new StudentAssignmentSubmissionMultipleChoiceQuestionAnswer(x.QuestionID, i % 2 == 0 ? x.AnswerID : Guid.NewGuid())));
				return new StudentGradeSubmissionBundle(assignmentAnswerKey, studentAssignmentSubmission);
			}

			public SomeCorrectAnswersArrangement()
				: base(MakeStudentGradeSubmissionBundle, () => new StudentGrade((CreateAssignmentAnswerKey().MultipleChoiceQuestionAnswerCollection.Count()+1) / 2, CreateAssignmentAnswerKey().MultipleChoiceQuestionAnswerCollection.Count()))
			{
			}
		}

		private class AllCorrectAnswersArrangement : StudentGradeSubmissionBundleExtensionsTestsArrangementBase
		{
			private static StudentGradeSubmissionBundle MakeStudentGradeSubmissionBundle()
			{
				var assignmentAnswerKey = CreateAssignmentAnswerKey();
				var studentAssignmentSubmission = new StudentAssignmentSubmission(Guid.Empty, Guid.Empty, Guid.Empty, assignmentAnswerKey.MultipleChoiceQuestionAnswerCollection.Select(x => new StudentAssignmentSubmissionMultipleChoiceQuestionAnswer(x.QuestionID, x.AnswerID)));
				return new StudentGradeSubmissionBundle(assignmentAnswerKey, studentAssignmentSubmission);
			}

			public AllCorrectAnswersArrangement()
				: base(MakeStudentGradeSubmissionBundle, () => new StudentGrade(CreateAssignmentAnswerKey().MultipleChoiceQuestionAnswerCollection.Count(), CreateAssignmentAnswerKey().MultipleChoiceQuestionAnswerCollection.Count()))
			{
			}
		}

		#endregion

		#region Customizations

		private class StudentGradeSubmissionBundleCustomization : ICustomization
		{
			private readonly Func<StudentGradeSubmissionBundle> _bundleFactory;

			public StudentGradeSubmissionBundleCustomization(Func<StudentGradeSubmissionBundle> bundleFactory)
			{
				_bundleFactory = bundleFactory ?? throw new ArgumentNullException(nameof(bundleFactory));
			}

			public void Customize(IFixture fixture)
			{
				fixture.Inject(_bundleFactory.Invoke());
			}
		}

		private class StudentGradeCustomization : ICustomization
		{
			private readonly Func<StudentGrade> _gradeFactory;

			public StudentGradeCustomization(Func<StudentGrade> gradeFactory)
			{
				_gradeFactory = gradeFactory ?? throw new ArgumentNullException(nameof(gradeFactory));
			}

			public void Customize(IFixture fixture)
			{
				fixture.Inject(_gradeFactory.Invoke());
			}
		}

		#endregion

		#region Data

		private static AssignmentAnswerKey CreateAssignmentAnswerKey()
		{
			var multipleChoiceQuestionAnswerCollection = new List<AssignmentAnswerKeyMultipleChoiceQuestionAnswer>
			{
				new AssignmentAnswerKeyMultipleChoiceQuestionAnswer(Guid.NewGuid(), Guid.NewGuid()),
				new AssignmentAnswerKeyMultipleChoiceQuestionAnswer(Guid.NewGuid(), Guid.NewGuid()),
				new AssignmentAnswerKeyMultipleChoiceQuestionAnswer(Guid.NewGuid(), Guid.NewGuid())
			};

			return new AssignmentAnswerKey(Guid.Empty, Guid.Empty, multipleChoiceQuestionAnswerCollection);
		}

		#endregion
	}
}
