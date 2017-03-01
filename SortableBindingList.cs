using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Microsoft.LiveMeeting.RecordingExporter
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private ListSortDirection _sortDirection;
        private PropertyDescriptor _sortProperty;

        protected override bool SupportsSortingCore
        {
            get
            {
                return true;
            }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get
            {
                return _sortDirection;
            }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get
            {
                return _sortProperty;
            }
        }

        protected override bool IsSortedCore
        {
            get
            {
                for (int i = 0; i < Items.Count - 1; ++i)
                {
                    T lhs = Items[i];
                    T rhs = Items[i + 1];
                    PropertyDescriptor property = SortPropertyCore;
                    if (property != null)
                    {
                        object lhsValue = lhs == null ? null : property.GetValue(lhs);
                        object rhsValue = rhs == null ? null : property.GetValue(rhs);
                        int result;
                        if (lhsValue == null)
                        {
                            result = -1;
                        }
                        else if (rhsValue == null)
                        {
                            result = 1;
                        }
                        else
                        {
                            result = Comparer.Default.Compare(lhsValue, rhsValue);
                        }

                        if (SortDirectionCore == ListSortDirection.Descending)
                        {
                            result = -result;
                        }

                        if (result >= 0)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        protected override void ApplySortCore(
            PropertyDescriptor prop,
            ListSortDirection direction)
        {
            _sortProperty = prop;
            _sortDirection = direction;

            List<T> list = (List<T>)Items;
            list.Sort(delegate (T lhs, T rhs)
            {
                if (_sortProperty != null)
                {
                    object lhsValue = lhs == null ? null : _sortProperty.GetValue(lhs);
                    object rhsValue = rhs == null ? null : _sortProperty.GetValue(rhs);
                    int result;
                    if (lhsValue == null)
                    {
                        result = -1;
                    }
                    else if (rhsValue == null)
                    {
                        result = 1;
                    }
                    else
                    {
                        result = Comparer.Default.Compare(lhsValue, rhsValue);
                    }
                    if (_sortDirection == ListSortDirection.Descending)
                    {
                        result = -result;
                    }
                    return result;
                }
                else
                {
                    return 0;
                }
            });
        }

        protected override void RemoveSortCore()
        {
            _sortDirection = ListSortDirection.Ascending;
            _sortProperty = null;
        }
    }
}
