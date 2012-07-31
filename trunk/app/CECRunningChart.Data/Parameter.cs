using System.Data;

namespace CECRunningChart.Data
{
    public class Parameter
    {
        #region Private Readonly Members

        private readonly string key;
        private readonly object value;
        private readonly ParameterDirection direction;

        #endregion

        #region Constructors

        public Parameter(string key, object value)
            : this(key, value, ParameterDirection.Input)
        {
        }

        public Parameter(string key, object value, ParameterDirection parameterDirection)
        {
            this.key = key;
            this.value = value;
            this.direction = parameterDirection;
        }

        #endregion

        #region Public Properties

        public string Key
        {
            get { return key; }
        }

        public object Value
        {
            get { return value; }
        }

        /// <summary>
        /// Gets a value that indicates whether the parameter is input-only,
        /// output-only, bidirectional, or a stored procedure return value parameter.
        /// </summary>
        public ParameterDirection Direction
        {
            get { return direction; }
        }

        #endregion
    }
}
