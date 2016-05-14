﻿namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel
{

  internal interface IAssociationCouple
  {

    bool Associated { get; set; }
    string Title { get;  }
    /// <summary>
    /// Reverts the association to the initial state.
    /// </summary>
    void Revert();

  }
}