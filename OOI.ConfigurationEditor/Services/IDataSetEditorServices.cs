
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Services
{
  //TODO - remove it if it is uused.
  internal interface IDataSetEditorServices
  {
    ObservableCollection<string> RetrieveList();
    ICommand AddCommand { get; set; }
  }
}