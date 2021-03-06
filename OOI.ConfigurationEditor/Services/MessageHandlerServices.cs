﻿//_______________________________________________________________
//  Title   : MessageHandlerServices
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

using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Services
{
  [Export(typeof(IMessageHandlerServices))]
  [PartCreationPolicy(CreationPolicy.Shared)]
  internal class MessageHandlerServices : IMessageHandlerServices
  {

    [ImportingConstructor]
    public MessageHandlerServices(MessageHandlerConfigurationCollection repository)
    {
      m_Configuration = repository;
    }
    public bool MessageHandlerExists(string identifier)
    {
      return m_Configuration.Where<IMessageHandlerConfigurationWrapper>(x => x.Name == identifier).Any<IMessageHandlerConfigurationWrapper>();
    }

    #region IMessageHandlerServices
    public MessageHandlerConfigurationCollection GetMessageHandlers()
    {
      return m_Configuration;
    }
    public IEnumerable<IMessageHandlerConfigurationWrapper> GetMessageHandlers(AssociationRole associationRole)
    {
      return m_Configuration.Where<IMessageHandlerConfigurationWrapper>(x => x.TransportRole == associationRole);
    }
    public void AddMessageHandler(IMessageHandlerConfigurationWrapper item)
    {
      m_Configuration.Add(item);
    }
    public bool Exist(string title)
    {
      return m_Configuration.Exists(title);
    }
    public void Remove(string title)
    {
      m_Configuration.Remove(title);
    }
    public void Remove(IMessageHandlerConfigurationWrapper item)
    {
      m_Configuration.Remove(item);
    }
    #endregion

    private readonly MessageHandlerConfigurationCollection m_Configuration;

  }
}
