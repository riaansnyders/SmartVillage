namespace lfa.pmgmt.data.DTO.BusinessRule
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    #endregion

    public class Condition
    {
        #region Public Properties
        public int Id
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
        #endregion
    }
}
