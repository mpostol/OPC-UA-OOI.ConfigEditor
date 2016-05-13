//_______________________________________________________________
//  Title   : DialogActivationBehavior
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate:  $
//  $Rev: $
//  $LastChangedBy: $
//  $URL: $
//  $Id:  $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using System.Collections.Specialized;
using System.Windows;
using Prism.Regions;
using Prism.Regions.Behaviors;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.Infrastructure.Behaviors
{

  /// <summary>
  /// Defines a behavior that creates a Dialog to display the active view of the target <see cref="IRegion"/>.
  /// </summary>
  public abstract class DialogActivationBehavior : RegionBehavior, IHostAwareRegionBehavior
  {

    #region public API
    /// <summary>
    /// The key of this behavior
    /// </summary>
    public const string BehaviorKey = "DialogActivation";
    #endregion

    #region IHostAwareRegionBehavior
    /// <summary>
    /// Gets or sets the <see cref="DependencyObject"/> that the <see cref="IRegion"/> is attached to.
    /// </summary>
    /// <value>A <see cref="DependencyObject"/> that the <see cref="IRegion"/> is attached to.
    /// This is usually a <see cref="FrameworkElement"/> that is part of the tree.</value>
    public DependencyObject HostControl { get; set; }
    #endregion

    #region RegionBehavior
    /// <summary>
    /// Performs the logic after the behavior has been attached.
    /// </summary>
    protected override void OnAttach()
    {
      this.Region.ActiveViews.CollectionChanged += this.ActiveViews_CollectionChanged;
    }
    /// <summary>
    /// Override this method to create an instance of the <see cref="IWindow"/> that 
    /// will be shown when a view is activated.
    /// </summary>
    /// <returns>
    /// An instance of <see cref="IWindow"/> that will be shown when a 
    /// view is activated on the target <see cref="IRegion"/>.
    /// </returns>
    protected abstract IWindow CreateWindow();
    #endregion

    #region private
    private IWindow contentDialog;
    private void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      if (e.Action == NotifyCollectionChangedAction.Add)
      {
        this.CloseContentDialog();
        this.PrepareContentDialog(e.NewItems[0]);
      }
      else if (e.Action == NotifyCollectionChangedAction.Remove)
      {
        this.CloseContentDialog();
      }
    }
    private Style GetStyleForView()
    {
      return this.HostControl.GetValue(RegionPopupBehaviors.ContainerWindowStyleProperty) as Style;
    }
    private void PrepareContentDialog(object view)
    {
      this.contentDialog = this.CreateWindow();
      this.contentDialog.Content = view;
      this.contentDialog.Owner = this.HostControl;
      this.contentDialog.Closed += this.ContentDialogClosed;
      this.contentDialog.Style = this.GetStyleForView();
      this.contentDialog.Show();
    }
    private void CloseContentDialog()
    {
      if (this.contentDialog != null)
      {
        this.contentDialog.Closed -= this.ContentDialogClosed;
        this.contentDialog.Close();
        this.contentDialog.Content = null;
        this.contentDialog.Owner = null;
      }
    }
    private void ContentDialogClosed(object sender, System.EventArgs e)
    {
      this.Region.Deactivate(this.contentDialog.Content);
      this.CloseContentDialog();
    }
    #endregion

  }

}
