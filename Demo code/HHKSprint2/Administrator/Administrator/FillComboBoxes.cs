using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adminidtrator.ServiceReference1;

namespace Adminidtrator
{
   public class FillComboBoxes
    {
       IJSService client = new JSServiceClient();
       public void FillUserType(AddUser userType)
       {
           
           List<string> uType = new List<string>();
           uType = client.GetUserType().ToList();
           for (int i = 0; i < uType.Count(); i++)
           {
               userType.userTypeCombox.Items.Add(uType[i]);
           }
       }

       public void FillStream(AddUser stream)
       {
           List<string> streamList = new List<string>();
           streamList = client.GetStreamList().ToList();
           for (int i = 0; i < streamList.Count(); i++)
           {
               if (streamList[i] != "All")
               {
                   stream.streamCombox.Items.Add(streamList[i]);
               }
           }
       }
    }
}
