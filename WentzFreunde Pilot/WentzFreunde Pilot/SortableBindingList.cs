using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public class SortableBindingList<T> : BindingList<T>
{
    private bool isSorted;
    private List<T> originalList;
    private PropertyDescriptor sortProperty;
    private ListSortDirection sortDirection;

    public SortableBindingList(IEnumerable<T> collection) : base(collection.ToList())
    {
        originalList = new List<T>(collection);
    }

    protected override bool SupportsSortingCore => true;
    protected override bool IsSortedCore => isSorted;
    protected override PropertyDescriptor SortPropertyCore => sortProperty;
    protected override ListSortDirection SortDirectionCore => sortDirection;

    protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
    {
        sortProperty = prop;
        sortDirection = direction;

        var sorted = direction == ListSortDirection.Ascending
            ? Items.OrderBy(x => prop.GetValue(x)).ToList()
            : Items.OrderByDescending(x => prop.GetValue(x)).ToList();

        ClearItems();

        foreach (var item in sorted)
            Add(item);

        isSorted = true;
    }

    protected override void RemoveSortCore()
    {
        ClearItems();

        foreach (var item in originalList)
            Add(item);

        isSorted = false;
    }
}