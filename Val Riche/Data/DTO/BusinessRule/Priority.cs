namespace lfa.pmgmt.data.DTO.BusinessRule
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    #endregion

    public class Priority
    {
        #region Public Properties
        public int Id
        {
            get;
            set;
        }

        public int Id_RuleSet
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string PriorityType
        {
            get;
            set;
        }
        #endregion
    }
}
