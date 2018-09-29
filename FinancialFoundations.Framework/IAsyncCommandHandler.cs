using System.Threading.Tasks;
using Functional;

namespace FinancialFoundations.Framework
{
	public interface IAsyncCommandHandler<in TCommand, TError>
		where TCommand : ICommand<TError>
	{
		Task<Result<Unit, TError>> Handle(TCommand parameters);
	}
}
