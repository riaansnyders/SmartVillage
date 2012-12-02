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
    public partial class Schedule_UnitDetail
    {
        partial void Schedule_Unit_Loaded(bool succeeded)
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Schedule_Unit);
        }

        partial void Schedule_Unit_Changed()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Schedule_Unit);
        }

        partial void Schedule_UnitDetail_Saved()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Schedule_Unit);
        }
    }
}