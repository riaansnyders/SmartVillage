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
    public partial class Schedule
    {
        partial void Schedule_Schedule_Loaded(bool succeeded)
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Schedule_Schedule);
        }

        partial void Schedule_Schedule_Changed()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Schedule_Schedule);
        }

        partial void Schedule_Saved()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Schedule_Schedule);
        }
    }
}