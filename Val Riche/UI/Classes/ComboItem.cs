namespace lfa.pmgmt.ui
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    #endregion

    public class ComboItem
    {
        #region Public Properties
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
        #endregion

        #region ToString Override
        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
