using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;

namespace LightSwitchApplication
{
    public partial class DeviceDetail
    {
        partial void Device_Loaded(bool succeeded)
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Device);
        }

        partial void Device_Changed()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Device);
        }

        partial void DeviceDetail_Saved()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Device);
        }
    }
}