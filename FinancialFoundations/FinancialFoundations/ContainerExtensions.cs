using FinancialFoundations.Framework;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialFoundations
{
    public static class ContainerExtensions
    {
        public static void RegisterDependencies(this Container container)
        {
            var assembliesToScan = new[]{
                typeof(StudentWork.Implementation.LocalFileStorage.AssemblyMarker).Assembly,
                typeof(SubjectMatter.Implementation.LocalFileStorage.AssemblyMarker).Assembly
            };

            container.Register(typeof(IAsyncQueryHandler<,>), assembliesToScan);
            container.Register(typeof(IAsyncCommandHandler<,>), assembliesToScan);
        }
    }
}
