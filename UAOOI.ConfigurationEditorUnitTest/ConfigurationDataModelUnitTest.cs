﻿
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition;
using CAS.CommServer.UAOOI.ConfigurationEditor.ConfigurationDataModel;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using Networking = global::UAOOI.Configuration.Networking;
using System.IO;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.UnitTest
{
  [TestClass]
  [DeploymentItem(@"TestData\", @"TestData\")]
  public class ConfigurationDataModelUnitTest
  {
    [TestMethod]

    public void CompositionTest()
    {
      FileInfo _configFile = new FileInfo(@"TestData\ConfigurationDataConsumer.xml");
      Assert.IsTrue(_configFile.Exists);
      Networking.UANetworkingConfiguration<Networking.Serialization.ConfigurationData> _newConfiguration = new Networking.UANetworkingConfiguration<Networking.Serialization.ConfigurationData>();
      _newConfiguration.ReadConfiguration(_configFile);
      ConfigurationDataRepository.SetConfigurationData = _newConfiguration.CurrentConfiguration;
      AggregateCatalog _catalog = new AggregateCatalog();
      _catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetAssembly(typeof(IDataSetModelServices))));
      //_catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
      using (CompositionContainer _testContainer = new CompositionContainer(_catalog))
      {
        _testContainer.SatisfyImportsOnce(this);
        Assert.IsNotNull(DataSetModelServices);
        Assert.IsNotNull(MessageHandlerServices);
        Assert.IsNotNull(Repository);
        Assert.IsNotNull(Repository.ConfigurationData);
        Assert.AreSame(Repository.ConfigurationData, _newConfiguration.CurrentConfiguration);
        Test(Repository);
        Test(DataSetModelServices);
        Test(MessageHandlerServices);
      }
    }

    private void Test(ConfigurationDataRepository repository)
    {
      Assert.IsNotNull(repository.ConfigurationData.DataSets);
      Assert.IsNotNull(repository.ConfigurationData.MessageHandlers);
    }
    private void Test(IMessageHandlerServices service)
    {
    }
    private void Test(IDataSetModelServices service)
    {
      string _name = "DataSymbolicName";
      Assert.IsTrue(service.DataSetExists(_name));
      service.GetDescription(_name);
    }

    [Import]
    private IDataSetModelServices DataSetModelServices { get; set; }
    [Import]
    private IMessageHandlerServices MessageHandlerServices { get; set; }
    [Import]
    private ConfigurationDataRepository Repository { get; set; }

  }
}
