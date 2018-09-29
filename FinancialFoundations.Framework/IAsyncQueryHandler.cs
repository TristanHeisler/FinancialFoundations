using System.Threading.Tasks;

namespace FinancialFoundations.Framework
{
	public interface IAsyncQueryHandler<in TQuery, TResult>
		where TQuery : IQuery<TResult>
	{
		Task<TResult> Handle(TQuery parameters);
	}
}