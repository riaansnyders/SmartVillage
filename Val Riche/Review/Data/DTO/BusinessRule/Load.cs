namespace lfa.pmgmt.data.DTO.BusinessRule
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    #endregion

    public class Load
    {
        #region Public Properties
        public int Id
        {
            get;
            set;
        }

        public int CurrentLoad
        {
            get;
            set;
        }

        public int MaximumLoad
        {
            get;
            set;
        }
      #endregion
    }
}
