using System;
using DemoApp.Model;

namespace DemoApp.DataAccess
{
    /// <summary>
    /// Event arguments used by CustomerRepository's CustomerAdded event.
    /// </summary>
    public class CustomerAddedEventArgs : EventArgs
    {
        public CustomerAddedEventArgs(Customer newCustomer)
        {
      System.Diagnostics.PresentationTraceSources.DataBindingSource.Switch.Level = System.Diagnostics.SourceLevels.Critical;
            this.NewCustomer = newCustomer;
        }

        public Customer NewCustomer { get; private set; }
    }
}