﻿using CAS.CommServer.UAOOI.ConfigurationEditor.Infrastructure;
using CAS.CommServer.UAOOI.ConfigurationEditor.Infrastructure.Behaviors;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.MessageHandlerEditor
{

  /// <summary>
  /// Interaction logic for MessageHandlersList.xaml
  /// </summary>
  [ViewExport(RegionName = RegionNames.MainRegion)]
  [PartCreationPolicy(CreationPolicy.NonShared)]
  public partial class MessageHandlersListView : UserControl
  {
    public MessageHandlersListView()
    {
      InitializeComponent();
    }
    [Import(typeof(MessageHandlersListViewModel))]
    internal MessageHandlersListViewModel MessageHandlersListViewModel
    {
      set { this.DataContext = value; }
      get { return (MessageHandlersListViewModel)this.DataContext; }
    }
  }
}
