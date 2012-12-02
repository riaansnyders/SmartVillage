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
    public partial class Schedule_Main
    {
        partial void Schedule_Device_Loaded(bool succeeded)
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Schedule_Device);
        }

        partial void Schedule_Device_Changed()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Schedule_Device);
        }

        partial void Schedule_Main_Saved()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Schedule_Device);
        }
    }
}