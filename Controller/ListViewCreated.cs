using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace ListViewLibrary.Controller
{
    /// <summary>
    /// ListView 使用封装
    /// </summary>
    public class ListViewCreated : IDisposable
    {
        public delegate void ListViewItemCheckedChange();

        public event EventHandler<int> ListView_ItemChecked;
        public event EventHandler<int> ListView_SelectIndexClick;
        public event EventHandler<int> ListView_MouseDoubleClick;


        private readonly ListView _listView;
        private readonly List<ListViewItem> _listItems;
        private readonly ListViewAttributes _attributes;

        public ListViewCreated(ListView listView)
        {
            _listView = listView;
            _listItems = new List<ListViewItem>();
            _attributes = new ListViewAttributes();
        }

        /// <summary>
        /// ListView 初始化
        /// </summary>
        public void Created()
        {
            Bindings();
            _listView.Items.AddRange(_listItems.ToArray());
            //listview 单击check
            _listView.ItemChecked += delegate { ListView_ItemChecked.Invoke(this, _listView.CheckedItems.Count); };

            //listview 单击条目并选中
            _listView.SelectedIndexChanged += delegate(object sender, EventArgs args)
            {
                if (_listView.SelectedItems.Count > 0)
                {
                    if (ListView_SelectIndexClick != null)
                    {
                        ListView_SelectIndexClick.Invoke(this, _listView.SelectedItems[0].Index);
                    }
                }
            };

            //ListView 双击条目
            _listView.MouseDoubleClick += delegate(object sender, MouseEventArgs args)
            {
                if (_listView.SelectedItems.Count > 0)
                {
                    if (ListView_MouseDoubleClick != null)
                    {
                        ListView_MouseDoubleClick.Invoke(this, _listView.SelectedItems[0].Index);
                    }
                }
            };
        }

        /// <summary>
        /// 数据绑定MVVM
        /// </summary>
        private void Bindings()
        {
            _listView.DataBindings.Add(new Binding("View", _attributes, "View"));
            _listView.DataBindings.Add(new Binding("LabelEdit", _attributes, "LabelEdit"));
            _listView.DataBindings.Add(new Binding("FullRowSelect", _attributes, "FullRowSelect"));
            _listView.DataBindings.Add(new Binding("AllowColumnReorder", _attributes, "AllowColumnReorder"));
            _listView.DataBindings.Add(new Binding("CheckBoxes", _attributes, "CheckBoxes"));
            _listView.DataBindings.Add(new Binding("GridLines", _attributes, "GridLines"));
            _listView.DataBindings.Add(new Binding("Sorting", _attributes, "Sorting"));
        }


        /// <summary>
        /// 删除单个
        /// </summary>
        /// <remarks>删除ListView中单个Item</remarks>
        public void RemoveItem(int position)
        {
            _listItems.RemoveAt(position);
        }

        /// <summary>
        /// 删除所有
        /// </summary>
        /// <remarks>删除ListView中所有条目</remarks>
        public void RemoveItems()
        {
            _listItems.Clear();
        }

        /// <summary>
        /// 添加条目
        /// </summary>
        /// <param name="item">添加的单个条目</param>
        /// <remarks>单独给ListView添加一个Item,ListView 添加单独行</remarks>
        public void AddItem(ListViewItem item)
        {
            _listItems.Add(item);
        }

        /// <summary>
        /// 添加多个
        /// </summary>
        /// <param name="items">Item 集合</param>
        /// <remarks>给ListView 添加多个Item，使用List集合传入参数</remarks>
        public void AddItems(List<ListViewItem> items)
        {
            foreach (var value in items)
            {
                _listItems.Add(value);
            }
        }

        /// <summary>
        /// 刷新ListView
        /// </summary>
        public void RefreshView()
        {
            _listView.Refresh();
        }

        /// <summary>
        /// 更新ListView界面
        /// </summary>
        public void UpdateView()
        {
            _listView.Update();
        }

        /// <summary>
        /// ListView Column 标题
        /// </summary>
        /// <param name="columnsList">ListView Columns</param>
        /// <remarks>ListView 添加标题列</remarks>
        public void AddColumns(List<ListViewColumns> columnsList)
        {
            foreach (var item in columnsList)
            {
                _listView.Columns.Add(item.Text, item.Width, item.TextAlign);
            }
        }

        /// <summary>
        /// ListView 中的基本属性
        /// </summary>
        public ListViewAttributes Attributes => _attributes;


        

        public void Dispose()
        {
            _listView.Dispose();
            _listItems.Clear();
            ListView_MouseDoubleClick -= null;
            ListView_SelectIndexClick -= null;
            ListView_ItemChecked -= null;
        }
    }
}