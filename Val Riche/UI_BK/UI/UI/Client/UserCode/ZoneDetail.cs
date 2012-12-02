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
    public partial class ZoneDetail
    {
        partial void Zone_Loaded(bool succeeded)
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Zone);
        }

        partial void Zone_Changed()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Zone);
        }

        partial void ZoneDetail_Saved()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Zone);
        }
    }
}