using System;

namespace Wpb.CarsRating.Core.ContextObjects
{
    public class BaseContextUnderTest<T> : IDisposable where T : class
    {
        private bool _disposed;
        public void Dispose(bool disposing)
        {
			if (_disposed)
			{
				return;
			}

			if (disposing)
			{
				// If there are any managed resources to be cleaned up
			}

			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
