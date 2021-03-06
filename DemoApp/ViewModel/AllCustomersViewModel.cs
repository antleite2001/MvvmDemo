﻿using DemoApp.DataAccess;
using DemoApp.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace DemoApp.ViewModel
{
  /// <summary>
  /// Represents a container of CustomerViewModel objects
  /// that has support for staying synchronized with the
  /// CustomerRepository.  This class also provides information
  /// related to multiple selected customers.
  /// </summary>
  public class AllCustomersViewModel : WorkspaceViewModel
  {
    #region Fields

    private readonly CustomerRepository _customerRepository;

    #endregion // Fields

    #region Constructor

    public AllCustomersViewModel(CustomerRepository customerRepository)
    {
      Diag.DataBindingPresentation();

      if (customerRepository == null)
      {
        throw new ArgumentNullException("customerRepository");
      }

      base.ViewModelBaseInstanceName = Strings.AllCustomersViewModel_DisplayName;
      Diag.UpdateLog("(547865\tAllCustomersViewModel(C )\tbase.ViewModelBaseInstanceName \t" + base.ViewModelBaseInstanceName);
      _customerRepository = customerRepository;

      // Subscribe for notifications of when a new customer is saved.
      _customerRepository.CustomerAdded += OnCustomerAddedToRepository;

      // Populate the AllCustomers collection with CustomerViewModels.
      CreateAllCustomers();
    }

    private void CreateAllCustomers()
    {
      List<CustomerViewModel> all =
          (from cust in _customerRepository.GetCustomers()
           select new CustomerViewModel(cust, _customerRepository)).ToList();

      foreach (CustomerViewModel cvm in all)
      {
        cvm.PropertyChanged += OnCustomerViewModelPropertyChanged;
          Diag.UpdateLog("(521654)\tCreateAllCustomers()\t " + cvm.ToString() );

        
      }

      AllCustomers = new ObservableCollection<CustomerViewModel>(all);
      AllCustomers.CollectionChanged += OnCollectionChanged;
    }

    #endregion // Constructor

    #region Public Interface

    /// <summary>
    /// Returns a collection of all the CustomerViewModel objects.
    /// </summary>
    public ObservableCollection<CustomerViewModel> AllCustomers { get; private set; }

    /// <summary>
    /// Returns the total sales sum of all selected customers.
    /// </summary>
    public double TotalSelectedSales
    {
      get
      {
        return AllCustomers.Sum(
                custVM => custVM.IsSelected ? custVM.TotalSales : 0.0);
      }
    }
    #endregion // Public Interface

    #region  Base Class Overrides

    protected override void OnDispose()
    {
      foreach (CustomerViewModel custVM in AllCustomers)
      {
        custVM.Dispose();
      }

      AllCustomers.Clear();
      AllCustomers.CollectionChanged -= OnCollectionChanged;

      _customerRepository.CustomerAdded -= OnCustomerAddedToRepository;
    }

    #endregion // Base Class Overrides

    #region Event Handling Methods

    private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      if (e.NewItems != null && e.NewItems.Count != 0)
      {
        foreach (CustomerViewModel cvm in e.NewItems)
        {
          cvm.PropertyChanged += OnCustomerViewModelPropertyChanged;
          Diag.UpdateLog("(742342)\tOnCollectionChanged\te.NewItems\t" + cvm.ToString()+"\t"+e.NewItems.ToString());
        }
      }

      if (e.OldItems != null && e.OldItems.Count != 0)
      {
        foreach (CustomerViewModel cvm in e.OldItems)
        {
          cvm.PropertyChanged -= OnCustomerViewModelPropertyChanged;
          Diag.UpdateLog("(742109)\tOnCollectionChanged\te.OldItems\t" + cvm.ToString()+"\t"+e.OldItems.ToString());
        }
      }
    }

    private void OnCustomerViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      string IsSelected = "IsSelected";

      // Make sure that the property name we're referencing is valid.
      // This is a debugging technique, and does not execute in a Release build.
      (sender as CustomerViewModel).VerifyPropertyName(IsSelected);

      // When a customer is selected or unselected, we must let the
      // world know that the TotalSelectedSales property has changed,
      // so that it will be queried again for a new value.
      if (e.PropertyName == IsSelected)
      {
        
        OnPropertyChanged("TotalSelectedSales");
      }
    }

    private void OnCustomerAddedToRepository(object sender, CustomerAddedEventArgs e)
    {
      CustomerViewModel viewModel = new CustomerViewModel(e.NewCustomer, _customerRepository);
      AllCustomers.Add(viewModel);
    }

    #endregion // Event Handling Methods
  }
}