using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ATS_Composite
{
    /// <summary>
    /// Класс компонент группы телефонных номеров
    /// </summary>
    public class PhoneGroup : ATSComponent
    {
        /// <summary>
        /// Узел TreeList, с которым связан компонент
        /// </summary>
        public override TreeNode Node { get; set; } = new TreeNode();
        public string Name { get; set; } = "";
        /// <summary>
        /// Подкомпоненты группы телефонов
        /// </summary>
        List<ATSComponent> Components { get; set; } = new List<ATSComponent>();
        /// <summary>
        /// Количество подкомпонентов
        /// </summary>
        public int ComponentCount { get; private set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public PhoneGroup() : base() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Название группы</param>
        public PhoneGroup(string name) : this() 
        { 
            Name = name;
            Node.Text = ToString();
        }
        /// <summary>
        /// Добавить подкомпонент
        /// </summary>
        /// <param name="c">Добавляемый компонент</param>
        public override void Add(ATSComponent c)
        {
            Components.Add(c);
            Node.Nodes.Add(c.Node);
            CountUpdate();
        }
        /// <summary>
        /// Убрать непосредственный подкомпонент
        /// </summary>
        /// <param name="c">Удаляемый компонент</param>
        public override void Remove(ATSComponent c)
        {
            Node.Nodes.RemoveAt(Components.IndexOf(c));
            Components.Remove(c);
            CountUpdate();
        }
        /// <summary>
        /// Обновить количество подкомпонентов
        /// </summary>
        private void CountUpdate()
        {
            ComponentCount = 0;
            foreach (ATSComponent c in Components)
            {
                if (c is PhoneGroup gr) ComponentCount += gr.ComponentCount;
                ComponentCount++;
            }
            Node.Text = ToString();
        }
        /// <summary>
        /// Сделать все подкомпоненты занятыми
        /// </summary>
        public override void Connect()
        {
            foreach (ATSComponent c in Components) c.Connect();
        }
        /// <summary>
        /// Сделать все подкомпоненты свободными
        /// </summary>
        public override void Disconnect()
        {
            foreach (ATSComponent c in Components) c.Disconnect();
        }
        /// <summary>
        /// Найти компонент, который является элементом поддерева с настоящим компонентом в корне по узлу TreeList
        /// </summary>
        /// <param name="node">Узел TreeList</param>
        /// <returns>Компонент, который связан с <paramref name="node"/></returns>
        public ATSComponent? FindChild(TreeNode node)
        {
            foreach(ATSComponent c in Components)
            {
                if(c.Node==node) return c;
            }
            foreach(ATSComponent c in Components)
            {
                if (c is PhoneGroup gr) return gr.FindChild(node);
            }
            return null;
        }
        /// <summary>
        /// Найти родителя компонента, который является элементом поддерева с настоящим компонентом в корне
        /// </summary>
        /// <param name="c">Компонент, у которого нужно найти родителя</param>
        /// <returns>Родитель компонента, null если такого нет или <paramref name="c"/> не найдено</returns>
        public ATSComponent? FindParentOf(ATSComponent c)
        {
            if(this == c) return null;
            if (Components.Contains(c)) return this;
            foreach (ATSComponent ic in Components)
            {
                if (ic is PhoneGroup gr) return gr.FindParentOf(c);
            }
            return null;
        }
        /// <summary>
        /// Получить занятость группы телефонов
        /// </summary>
        /// <returns>0 - если ни один номер не занят, 2 - если все заняты, иначе - 1</returns>
        public int GetBusiness()
        {
            int f = 0, t = 0;
            foreach (ATSComponent c in Components)
            {
                if (c is Phone ph)
                {
                    if (ph.Busy) t++;
                    else f++;
                }
                else if (c is PhoneGroup gr) gr.GetBusinessChild(ref f, ref t);
            }
            if (t == 0) return 0;
            else if (f == 0) return 2;
            else return 1;
        }
        /// <summary>
        /// Получить занятость подгруппы телефонов
        /// </summary>
        /// <param name="f">Количество свободных номеров</param>
        /// <param name="t">Количество занятых номеров</param>
        private void GetBusinessChild(ref int f, ref int t)
        {
            foreach (ATSComponent c in Components)
            {
                if (c is Phone ph)
                {
                    if (ph.Busy) t++;
                    else f++;
                }
                else if (c is PhoneGroup gr) gr.GetBusinessChild(ref f, ref t);
            }
        }
        /// <summary>
        /// Убрать компонент, который является элементом поддерева с настоящим компонентом в корне
        /// </summary>
        /// <param name="c">Компонент, который нужно удалить</param>
        public void RemoveDeep(ATSComponent c)
        {
            FindParentOf(c)?.Remove(c);
        }
        /// <summary>
        /// Получить информацию об объекте в строке
        /// </summary>
        /// <returns>Описание объекта телефонной группы</returns>
        public override string ToString()
        {
            return $"Группа {Name}, {ComponentCount} компонентов";
        }
    }
}
