//_______________________________________________________________
//  Title   : IWindow INTERFACE
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

using System;
using System.Windows;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Infrastructure.Behaviors
{
  /// <summary>
  /// Defines the interface for the Dialogs that are shown by <see cref="DialogActivationBehavior"/>.
  /// </summary>
  public interface IWindow
  {
    /// <summary>
    /// Ocurrs when the <see cref="IWindow"/> is closed.
    /// </summary>
    event EventHandler Closed;

    /// <summary>
    /// Gets or sets the content for the <see cref="IWindow"/>.
    /// </summary>
    object Content { get; set; }

    /// <summary>
    /// Gets or sets the owner control of the <see cref="IWindow"/>.
    /// </summary>
    object Owner { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="System.Windows.Style"/> to apply to the <see cref="IWindow"/>.
    /// </summary>
    Style Style { get; set; }

    /// <summary>
    /// Opens the <see cref="IWindow"/>.
    /// </summary>
    void Show();

    /// <summary>
    /// Closes the <see cref="IWindow"/>.
    /// </summary>
    void Close();
  }
}