﻿//_______________________________________________________________
//  Title   : DomainConfirmation
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel;
using CAS.Windows.ViewModel;
using Prism.Commands;
using System.Windows.Input;
using System.Windows;
using System.Threading.Tasks;
using System;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainEditor
{
  internal class DomainConfirmation : ConfirmationBindable
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainConfirmation"/> class.
    /// </summary>
    /// <param name="domain">The domain.</param>
    internal DomainConfirmation(DomainWrapper domain)
    {
      DomainConfigurationWrapper = domain;
      LookupDNSCommand = DelegateCommand.FromAsyncHandler(DomainDiscovery);
      b_CurrentIsEnabled = true;
      b_CurrentCursor = Cursors.Arrow;
    }
    #region DataContext
    /// <summary>
    /// Gets the domain configuration wrapper.
    /// </summary>
    /// <remarks>
    /// It is to be used by the GUI.
    /// </remarks>
    /// <value>The domain configuration wrapper <see cref="DomainWrapper"/>.</value>
    public DomainWrapper DomainConfigurationWrapper { get; private set; }
    public ICommand LookupDNSCommand { get; }
    public bool? CurrentIsEnabled
    {
      get
      {
        return b_CurrentIsEnabled;
      }
      set
      {
        SetProperty<bool?>(ref b_CurrentIsEnabled, value);
      }
    }
    public Cursor CurrentCursor
    {
      get
      {
        return b_CurrentCursor;
      }
      set
      {
        SetProperty<Cursor>(ref b_CurrentCursor, value);
      }
    }
    #endregion

    internal void ApplyChanges()
    {
      DomainConfigurationWrapper.ApplyChanges();
    }

    //private
    private bool? b_CurrentIsEnabled;
    private Cursor b_CurrentCursor;

    private async Task DomainDiscovery()
    {
      try
      {
        CurrentCursor = Cursors.Wait;
        CurrentIsEnabled = false;
        DomainDescriptor _newDomain = await Services.DataDiscoveryServices.ResolveDomainDescriptionAsync<DomainDescriptor>(DomainConfigurationWrapper.URI.ToString());
      }
      catch (System.Exception _e)
      {
        MessageBox.Show($"Error while resolving the domain description {_e}", "Resolving of Semantics Data", MessageBoxButton.OK, MessageBoxImage.Warning);
      }
      finally
      {
        CurrentCursor = Cursors.Arrow;
        CurrentIsEnabled = true;
      }
    }

  }
  [Serializable]
  public class DomainDescriptor { }

}
