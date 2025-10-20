using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem3_pract3._2
{
    public static class TransportManager
    {
        public static void CollectionChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems?[0] is Transport newTransport)
                        Console.WriteLine($"Добавлен новый транспорт: {newTransport.Firma}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems?[0] is Transport oldTransport)
                        Console.WriteLine($"Удален транспорт: {oldTransport.Firma}");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    if ((e.NewItems?[0] is Transport replacingTransport) && (e.OldItems?[0] is Transport replacedTransport))
                        Console.WriteLine($"Транспорт {replacedTransport.Firma} заменен объектом {replacingTransport.Firma}");
                    break;
            }
        }
    }
}