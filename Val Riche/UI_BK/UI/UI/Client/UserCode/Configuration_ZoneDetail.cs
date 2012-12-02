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
    public partial class Configuration_ZoneDetail
    {
        partial void Configuration_Zone_Loaded(bool succeeded)
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Configuration_Zone);
        }

        partial void Configuration_Zone_Changed()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Configuration_Zone);
        }

        partial void Configuration_ZoneDetail_Saved()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Configuration_Zone);
        }
    }
}