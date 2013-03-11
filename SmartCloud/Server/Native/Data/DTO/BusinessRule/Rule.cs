namespace lfa.pmgmt.data.DTO.BusinessRule
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    #endregion

    public class Rule
    {
        #region Public Properties
        public int Id
        {
            get;
            set;
        }

        public string Condition
        {
            get;
            set;
        }

        public string Result
        {
            get;
            set;
        }


        public string Priority
        {
            get;
            set;
        }
        #endregion
    }
}
