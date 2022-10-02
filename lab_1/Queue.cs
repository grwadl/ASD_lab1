
using System;
using System.Xml.Linq;

namespace lab_1
{
    public class Element
    {
        public Element? _PreviousElement;
        public Element? _NextElement;
        public char _Value;

        public Element(char value)
        {
            _Value = value;
        }

        public string showElement()
        {
            return $"[previous: {_PreviousElement?._Value}; element: {_Value}; next: {_NextElement?._Value}]";
        }

    }


    public class Queue
    {
        private Element _Tail;
        private Element _Head;
        private int quantity = 0;
        private int index = 0;
        public string addToQueue(char value)
        {
            Element newElement = new Element(value);
            if (_Tail != null)
                _Tail._NextElement = newElement;
            newElement._PreviousElement = _Tail;
            _Tail = newElement;
            if (_Head == null)
                _Head = _Tail;
            /**else
            { 
                _Head._PreviousElement = _Tail; //раскомментировать для цикличного
                _Tail._NextElement = _Head;
            }**/
            quantity++;
            return $"element '{value}' added!";
        }
        //удаление элемента
        public string popQueue()
        {
            if (_Head == null)
                return "queue is empty";
            _Head = _Head._NextElement;
            _Head._PreviousElement = null; // закомментировать для цикличного
           // _Head._PreviousElement = _Tail; //раскомментировать для цикличного
           // _Tail._NextElement = _Head; //раскомментировать для цикличного 
            quantity--;
            return "head element deleted!";
        }

        //рекурсия для перебора элементов очереди
        void listQueue(Element el, Queue queue)
        {
            if (el == null)
                return;
            Console.WriteLine(el?.showElement());
            if (el._NextElement != null)
                listQueue(el._NextElement, queue);
            return;
        }
        //проверка на то является ли элемент началом списка
        /**bool elementIsHead(Element el, Queue queue)
        {
            return el._Value == queue._Head._Value && el._PreviousElement == queue._Head._PreviousElement && el._NextElement == queue._Head._NextElement;
        }**/

        //метод для вывода структуры на экран
        public void showQueue(Queue queue1)
        {
            if(queue1._Head == null && queue1._Tail == null)
            {
                Console.WriteLine("queue is empty!");
                return;
            }
            Console.WriteLine("\n <--- START OF THE QUEUE\n");
            Console.WriteLine(queue1._Head.showElement());
            listQueue(queue1._Head._NextElement, queue1);
            Console.WriteLine("\nEND OF THE QUEUE ---> \n\n");
            return;
        }
        //метод для вывода начального элемента очереди на экран
        public string showFirstElement()
        {
            if (_Head == null)
            {
                return "your queue is empty!";
            }
            return _Head.showElement();
        }
        //метод для вывода количества элементов на экран
        public string countElements()
        {
            return $"there is {quantity} elements in your queue";
        }
        //метод для проверки на пустоту очереди
        public string isEmpty()
        {
            return quantity == 0 ? "your queue is empty" : "your queue is not empty";
        }
        //рекурсия для перебора элементов основной очереди и разделения ее на две подочереди
        public void listDividedQueue(Element el, Queue firstSubQueue, Queue secondSubQueue)
        {
            if (el == null)
            {
                showQueue(secondSubQueue); // закомментировать для цикличного
                return;
            }
            /**if (index == quantity)
            {
                showQueue(secondSubQueue);
                return;
            }**/ //раскомментировать для цикличного
            if(index < quantity / 2)
            {
                firstSubQueue.addToQueue(el._Value);
                ++index;
                listDividedQueue(el._NextElement, firstSubQueue, secondSubQueue);
            }
            if (index == quantity / 2)
            {
                showQueue(firstSubQueue);
                secondSubQueue.addToQueue(el._Value);
                ++index;
                listDividedQueue(el._NextElement, firstSubQueue, secondSubQueue);
            }
            if(index > quantity / 2 && index < quantity)
            {
                secondSubQueue.addToQueue(el._Value);
                ++index;
                listDividedQueue(el._NextElement, firstSubQueue, secondSubQueue);
            }
            return;
            
        }
        //метод вывода двух подочередей на экран
        public void divideQueue()
        {
            if(quantity == 0 || quantity % 2 != 0)
            {
                Console.WriteLine("quantity of elements in queue is not even or queue is empty. queue can't be diveded into 2 equal queues!");
                return;
            }
            Queue firstSubQueue = new Queue();
            Queue secondSubQueue = new Queue();
            index = 0;
            listDividedQueue(_Head, firstSubQueue, secondSubQueue);

        }
    }   
}