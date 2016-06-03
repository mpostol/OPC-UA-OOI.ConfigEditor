﻿
using CAS.Windows.mvvm;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{

  public abstract class MessageHandlerConfigurationWrapper<type> : Bindable, IMessageHandlerConfigurationIdentity, IWrapper<type>, IMessageHandlerConfigurationWrapper
    where type : MessageHandlerConfiguration
  {

    public MessageHandlerConfigurationWrapper(type configuration)
    {
      this.Item = configuration;
    }
    public MessageChannelConfigurationWrapper MessageChannelConfiguration
    {
      get { return new MessageChannelConfigurationWrapper(Item.Configuration); }
      set { SetProperty<MessageChannelConfigurationWrapper>(wrapper => Item.Configuration = wrapper.GetConfiguration(), value); }
    }
    public AssociationRole AssociationRole
    {
      get { return Item.TransportRole; }
      set { SetProperty<AssociationRole>(Item.TransportRole, x => Item.TransportRole = x, value); }
    }

    #region IMessageHandlerConfigurationIdentity
    public string Name
    {
      get { return Item.Name; }
      set { SetProperty<string>(Item.Name, x => Item.Name = x, value); }
    }
    #endregion

    #region IWrapper<type>
    /// <summary>
    /// The ultimate source of the item configuration
    /// </summary>
    public type Item
    {
      get; private set;
    }
    public abstract bool Check(DataSetConfigurationWrapper dataset);
    public abstract void Associate(bool associate, DataSetConfigurationWrapper dataset);
    #endregion

    #region override object 
    /// <summary>
    /// Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
    public override string ToString()
    {
      return $"Message Handler{Name} with {AssociationRole} role";
    }
    #endregion

  }

}