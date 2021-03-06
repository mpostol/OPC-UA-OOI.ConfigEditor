﻿//_______________________________________________________________
//  Title   : DomainsWrapper
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate: 2016-06-11 21:25:44 +0200 (So, 11 cze 2016) $
//  $Rev: 12228 $
//  $LastChangedBy: mpostol $
//  $URL: svn://svnserver.hq.cas.com.pl/VS/trunk/CommServer.UA.OOI/OOI.ConfigurationEditor/ViewModel/DomainWrapper.cs $
//  $Id: DomainWrapper.cs 12228 2016-06-11 19:25:44Z mpostol $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using System;
using System.Collections.ObjectModel;
using System.Linq;
using UAOOI.DataDiscovery.DiscoveryServices.Models;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel
{
  /// <summary>
  /// Class DomainWrapper - provides ViewModel to edit <see cref="DomainModel"/> instances
  /// </summary>
  /// <seealso cref="Wrapper{DomainModel}"/>
  public class DomainModelWrapper : Wrapper<DomainModel>
  {

    #region creator
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainModelWrapper"/> class.
    /// </summary>
    /// <param name="item">The item.</param>
    internal DomainModelWrapper(DomainModel item) : base(item)
    {
      this.SemanticsDataCollection = new ObservableCollection<SemanticsDataIndexWrapper>(item.SemanticsDataCollection.Select<SemanticsDataIndex, SemanticsDataIndexWrapper>(x => new SemanticsDataIndexWrapper(x)).ToArray<SemanticsDataIndexWrapper>());
      this.SemanticsDataCollection.CollectionChanged += SemanticsDataCollection_CollectionChanged;
    }
    internal void ApplyChanges()
    {
      //TODO ApplyChanges must be implemented
    }
    #endregion

    #region API
    /// <summary>
    /// Gets or sets the name of the alias.
    /// </summary>
    /// <value>The name of the alias.</value>
    public string AliasName
    {
      get
      {
        return Item.AliasName;
      }
      set
      {
        SetProperty<string>(Item.AliasName, x => Item.AliasName = x, value);
      }
    }
    /// <summary>
    /// Gets or sets the URI of the domain.
    /// </summary>
    /// <value>The URI.</value>
    public Uri URI
    {
      get
      {
        return Item.DomainModelUri;
      }
      set
      {
        SetProperty<Uri>(Item.DomainModelUri, x => Item.DomainModelUri = x, value);
      }
    }
    /// <summary>
    /// Gets or sets the unique name of the domain.
    /// </summary>
    /// <value>The name of the unique.</value>
    public Guid UniqueName
    {
      get
      {
        return Item.DomainModelGuid;
      }
      set
      {
        SetProperty<Guid>(Item.DomainModelGuid, x => Item.DomainModelGuid = x, value);
      }
    }
    /// <summary>
    /// Gets or sets the description of the domain.
    /// </summary>
    /// <value>The description.</value>
    public string Description
    {
      get
      {
        return Item.Description;
      }
      set
      {
        SetProperty<string>(Item.Description, x => Item.Description = x, value);
      }
    }
    /// <summary>
    /// Gets the semantics data collection.
    /// </summary>
    /// <value>The semantics data collection.</value>
    public ObservableCollection<SemanticsDataIndexWrapper> SemanticsDataCollection { get; }
    /// <summary>
    /// Gets or sets the universal address space locator represented as the<see cref="string"/>.
    /// </summary>
    /// <value>The universal address space locator.</value>
    public string UniversalAddressSpaceLocator
    {
      get
      {
        return Item.UniversalAddressSpaceLocator;
      }
      set
      {
        SetProperty<string>(Item.UniversalAddressSpaceLocator, x => Item.UniversalAddressSpaceLocator = x, value);
      }
    }
    /// <summary>
    /// Gets or sets the universal discovery service locator.
    /// </summary>
    /// <value>The universal discovery service locator.</value>
    public string UniversalDiscoveryServiceLocator
    {
      get
      {
        return Item.UniversalDiscoveryServiceLocator;
      }
      set
      {
        SetProperty<string>(Item.UniversalDiscoveryServiceLocator, x => Item.UniversalDiscoveryServiceLocator = x, value);
      }
    }
    /// <summary>
    /// Gets or sets the universal authorization server locator.
    /// </summary>
    /// <value>The universal authorization server locator.</value>
    public string UniversalAuthorizationServerLocator
    {
      get
      {
        return Item.UniversalAuthorizationServerLocator;
      }
      set
      {
        SetProperty<string>(Item.UniversalAuthorizationServerLocator, x => Item.UniversalAuthorizationServerLocator = x, value);
      }
    }
    public ObservableCollection<TypeDictionaryWrapper> TypeDictionaries { get; }
    #endregion

    #region override
    /// <summary>
    /// Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
    public override string ToString()
    {
      return $"The domain {this.URI.ToString()} descriptor";
    }
    #endregion

    #region private
    private void SemanticsDataCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
      Item.SemanticsDataCollection = SemanticsDataCollection.Select<SemanticsDataIndexWrapper, SemanticsDataIndex>(x => x.Item).ToArray<SemanticsDataIndex>();
    }
    #endregion

  }
}
