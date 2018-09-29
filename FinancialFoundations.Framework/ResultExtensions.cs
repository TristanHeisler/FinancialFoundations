using System;
using System.Collections.Generic;
using System.Text;
using Functional;

namespace FinancialFoundations.Framework
{
	public static class ResultExtensions
	{
		public static TSuccess EnsureSuccess<TSuccess>(this Result<TSuccess, Exception> source)
		{
			return source.Match(x => x, exception => throw exception);
		}
	}
}
