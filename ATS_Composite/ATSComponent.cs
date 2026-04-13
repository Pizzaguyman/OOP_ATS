using System;
using System.Collections.Generic;
using System.Text;

namespace ATS_Composite
{
    /// <summary>
    /// Абстрактный класс компонента структуры номеров
    /// </summary>
    public abstract class ATSComponent
    {
        /// <summary>
        /// Узел TreeList, с которым связан компонент
        /// </summary>
        public abstract TreeNode Node { get; set; }
        /// <summary>
        /// Добавить подкомпонент
        /// </summary>
        /// <param name="c">Добавляемый компонент</param>
        public abstract void Add(ATSComponent c);
        /// <summary>
        /// Убрать непосредственный подкомпонент
        /// </summary>
        /// <param name="c">Удаляемый компонент</param>
        public abstract void Remove(ATSComponent c);
        /// <summary>
        /// Сделать компонент или все подкомпоненты занятыми
        /// </summary>
        public abstract void Connect();
        /// <summary>
        /// Сделать компонент или все подкомпоненты свободными
        /// </summary>
        public abstract void Disconnect();
    }
}
