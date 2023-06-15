using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class DoublyLinkedList
{
    private ListNode head; // Посилання на перший елемент списку
    private ListNode end; // Посилання на останній елемент списку
    private int length; // Кількість елементів у списку
    
    // Метод додавання елемента в кінець списку
    public void AddToEnd(Student value)
    {
        ListNode newNode = new ListNode(value);

        if (head == null) // Якщо список порожній
        {
            head = newNode;
            end = newNode;
        }
        else
        {
            end.next = newNode;
            newNode.prev = end;
            end = newNode;
        }
        
        length++;
    }

    // Метод видалення елемента з n-ої позиції списку
    public void RemoveAt(int position)
    {
        if (position < 0 || position >= length)
        {
            throw new ArgumentOutOfRangeException("position", "Invalid position");
        }

        ListNode nodeToRemove;

        // Визначення напрямку швидше досягнути вузла (початок чи кінець)
        if (position < length / 2)
        {
            ListNode current = head;

            // Дійти до потрібної позиції
            for (int i = 0; i < position; i++)
            {
                current = current.next;
            }

            nodeToRemove = current;
        }
        else
        {
            ListNode current = end;

            // Дійти до потрібної позиції
            for (int i = length - 1; i > position; i--)
            {
                current = current.prev;
            }

            nodeToRemove = current;
        }

        // Видалення поточного вузла
        if (nodeToRemove.prev != null)
        {
            nodeToRemove.prev.next = nodeToRemove.next;
        }
        else
        {
            head = nodeToRemove.next;
        }

        if (nodeToRemove.next != null)
        {
            nodeToRemove.next.prev = nodeToRemove.prev;
        }
        else
        {
            end = nodeToRemove.prev;
        }

        length--;
    }


    // Індексатор для читання та зміни значення вузла за порядковим номером
    public Student this[int index]
    {
        get
        {
            if (index < 0 || index >= length)
            {
                throw new ArgumentOutOfRangeException("index", "Invalid index");
            }

            // Перевірка, який напрямок (початок чи кінець) швидше досягнути елемента
            if (index < length / 2)
            {
                ListNode current = head;

                for (int i = 0; i < index; i++)
                {
                    current = current.next;
                }

                return current.data;
            }
            else
            {
                ListNode current = end;

                for (int i = length - 1; i > index; i--)
                {
                    current = current.prev;
                }

                return current.data;
            }
        }
        set
        {
            if (index < 0 || index >= length)
            {
                throw new ArgumentOutOfRangeException("index", "Invalid index");
            }

            // Перевірка, який напрямок (початок чи кінець) швидше досягнути елемента
            if (index < length / 2)
            {
                ListNode current = head;

                for (int i = 0; i < index; i++)
                {
                    current = current.next;
                }

                current.data = value;
            }
            else
            {
                ListNode current = end;

                for (int i = length - 1; i > index; i--)
                {
                    current = current.prev;
                }

                current.data = value;
            }
        }
    }


    // Властивість для отримання довжини списку
    public int Length
    {
        get { return length; }
    }
    public ListNode GetLastNode()
    {
        return end;
    }

    public ListNode GetNextNode(ListNode currentNode)
    {
        if (currentNode == null)
        {
            throw new ArgumentNullException("currentNode", "Current node cannot be null");
        }

        return currentNode.next;
    }
    public ListNode GetPreviousNode(ListNode currentNode)
    {
        if (currentNode == null)
        {
            throw new ArgumentNullException("currentNode", "Current node cannot be null");
        }

        return currentNode.prev;
    }
    public void Sort()
    {
        
        bool swapped;

        do
        {
            swapped = false;

            ListNode current = head;

            while (current != null && current.next != null)
            {
                if (current.data.CompareTo(current.next.data) > 0)
                {
                    
                    (current.data, current.next.data) = (current.next.data, current.data);

                    swapped = true;
                }

                current = current.next;
            }

            if (!swapped)
            {
               
                break;
            }

            swapped = false;

            current = current.prev;

            while (current != null && current.prev != null)
            {
                if (current.prev.data.CompareTo(current.data) > 0)
                {
                 
                    (current.data, current.prev.data) = (current.prev.data, current.data);

                    swapped = true;
                }

                current = current.prev;
            }

        } while (swapped);
    }
    public List<Student> FindStudentsWithIdealWeight()
    {
        List<Student> result = new List<Student>();

        ListNode current = head;

        while (current != null)
        {
            if (Math.Abs(current.data.Height - current.data.Weight - 110) < 0.5)
            {
                result.Add(current.data);
            }

            current = current.next;
        }

        return result;
    }


   
}

}