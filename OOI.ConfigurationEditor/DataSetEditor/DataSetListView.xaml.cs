// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using CAS.CommServer.UA.OOI.ConfigurationEditor.Infrastructure;
using CAS.CommServer.UA.OOI.ConfigurationEditor.Infrastructure.Behaviors;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Controls;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DataSetEditor
{
  /// <summary>
  /// Interaction logic for WatchListView.xaml
  /// </summary>
  [ViewExport(RegionName = RegionNames.MainRegion)]
  [PartCreationPolicy(CreationPolicy.NonShared)]
  public partial class DataSetListView : UserControl
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DataSetListView"/> class.
    /// </summary>
    public DataSetListView()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Sets the ViewModel.
    /// </summary>
    /// <remarks>
    /// This set-only property is annotated with the <see cref="ImportAttribute"/> so it is injected by MEF with
    /// the appropriate view model.
    /// </remarks>
    [Import]
    [SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly", Justification = "Needs to be a property to be composed by MEF")]
    internal DataSetListViewModel ViewModel
    {
      set
      {
        this.DataContext = value;
      }
    }
  }
}
