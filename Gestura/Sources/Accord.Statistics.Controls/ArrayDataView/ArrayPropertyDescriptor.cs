#region LIbrary Files
using System;
using System.Diagnostics;
using System.ComponentModel;
#endregion

namespace Accord.Controls
{

    /// <summary>
    ///   Provides an abstraction of array values.
    /// </summary>
    public class ArrayPropertyDescriptor : PropertyDescriptor
    {
        #region Variables
        private string name;
        private Type type;
        private int columnIndex;
        #endregion

        #region Constructors And Destructor
        /// <summary>
        ///   Constructs a new Array Property Descriptor.
        /// </summary>
        /// <param name="name">A title for the array.</param>
        /// <param name="type">The type of the property being displayed.</param>
        /// <param name="index">The index to display.</param>
        public ArrayPropertyDescriptor(string name, Type type, int index)
            : base(name, null)
        {
            this.name = name;
            this.type = type;
            this.columnIndex = index;
        }
        #endregion

        #region Properties
        /// <summary>
        ///   Returns the name of the array.
        /// </summary>
        public override string DisplayName
        {
            get { return name; }
        }

        /// <summary>
        ///   Returns the type of ArrayRowView.
        /// </summary>
        public override Type ComponentType
        {
            get { return typeof(ArrayRowView); }
        }

        /// <summary>
        ///   Returns false.
        /// </summary>
        public override bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        ///   Gets the type of the underlying multidimensional array.
        /// </summary>
        public override Type PropertyType
        {
            get { return type; }
        }

        /// <summary>
        ///   Gets a value from the array.
        /// </summary>
        public override object GetValue(object component)
        {
            try
            {
                return ((ArrayRowView)component).GetColumn(columnIndex);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return null;
        }
        #endregion

        #region Methods
        /// <summary>
        ///   Sets a value to the array.
        /// </summary>
        public override void SetValue(object component, object value)
        {
            try
            {
                ((ArrayRowView)component).SetColumnValue(columnIndex, value);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        /// <summary>
        ///   Returns false.
        /// </summary>
        public override bool CanResetValue(object component)
        {
            return false;
        }

        /// <summary>
        ///   Does nothing.
        /// </summary>
        public override void ResetValue(object component)
        {
        }

        /// <summary>
        ///   Returns false.
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
        #endregion
    }
}
