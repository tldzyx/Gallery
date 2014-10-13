using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gallery.Event;

namespace GalleryUnitTest.Event
{
    public class TypeWithLotsOfEvents
    {
        // 定义一个虚实例字段，它引用一个集合。
        // 集合用于管理一组“事件/委托”对
        // 注意：EventSet类型不是FCL的一部分，它是用户自定义的类型
        private readonly EventSet _eventSet = new EventSet();

        // protected属性使派生类型能访问集合
        protected EventSet EventSet { get { return _eventSet; } }

        #region 用于支持Foo事件的代码(为附加的事件重复这个模式)
        // 定义Foo事件必要的成员。
        // 2a.构造一个静态只读对象来标识这个事件。
        // 每个对象都有它自己的哈希码，以便在对象的集合中查找这个事件的委托链表
        private static readonly EventKey __eventKey = new EventKey();
        
        // 2d.定义事件的访问器方法，用于在集合中增删委托
        public event EventHandler<FooEventArgs> Foo
        {
            add { _eventSet.Add(__eventKey, value); }
            remove { _eventSet.Remove(__eventKey, value); }
        }

        // 2e.为这个事件定义受保护的虚方法
        protected virtual void OnFoo(object sender, FooEventArgs e)
        {
            _eventSet.Raise(__eventKey, sender, e);
        }

        // 2f.定义将输入转换成这个事件的方法
        public void SimulateFoo(object sender, FooEventArgs e)
        {
            OnFoo(sender, e);
        }
        #endregion
    }
}
