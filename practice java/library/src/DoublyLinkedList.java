import java.util.ArrayList;
import java.util.List;

public class DoublyLinkedList {
    private ListNode head; // Посилання на перший елемент списку
    private ListNode end; // Посилання на останній елемент списку
    private int length; // Кількість елементів у списку
    // Метод додавання елемента в кінець списку
    public void addToEnd(Student value) {
        ListNode newNode = new ListNode(value);

        if (head == null) { // Якщо список порожній
            head = newNode;
            end = newNode;
        } else {
            end.next = newNode;
            newNode.prev = end;
            end = newNode;
        }

        length++;
    }
    // Метод видалення елемента з n-ої позиції списку
    public void removeAt(int position) {
        if (position < 0 || position >= length) {
            throw new IllegalArgumentException("Invalid position");
        }

        ListNode nodeToRemove;

        // Визначення напрямку швидше досягнути вузла (початок чи кінець)
        if (position < length / 2) {
            ListNode current = head;

            // Дійти до потрібної позиції
            for (int i = 0; i < position; i++) {
                current = current.next;
            }

            nodeToRemove = current;
        } else {
            ListNode current = end;

            // Дійти до потрібної позиції
            for (int i = length - 1; i > position; i--) {
                current = current.prev;
            }

            nodeToRemove = current;
        }

        // Видалення поточного вузла
        if (nodeToRemove.prev != null) {
            nodeToRemove.prev.next = nodeToRemove.next;
        } else {
            head = nodeToRemove.next;
        }

        if (nodeToRemove.next != null) {
            nodeToRemove.next.prev = nodeToRemove.prev;
        } else {
            end = nodeToRemove.prev;
        }

        length--;
    }
    // Індексатор для читання та зміни значення вузла за порядковим номером
    public Student get(int index) {
        if (index < 0 || index >= length) {
            throw new IllegalArgumentException("Invalid index");
        }

        // Перевірка, який напрямок (початок чи кінець) швидше досягнути елемента
        if (index < length / 2) {
            ListNode current = head;

            for (int i = 0; i < index; i++) {
                current = current.next;
            }

            return current.data;
        } else {
            ListNode current = end;

            for (int i = length - 1; i > index; i--) {
                current = current.prev;
            }

            return current.data;
        }
    }
    public void set(int index, Student value) {
        if (index < 0 || index >= length) {
            throw new IllegalArgumentException("Invalid index");
        }

        // Перевірка, який напрямок (початок чи кінець) швидше досягнути елемента
        if (index < length / 2) {
            ListNode current = head;

            for (int i = 0; i < index; i++) {
                current = current.next;
            }

            current.data = value;
        } else {
            ListNode current = end;

            for (int i = length - 1; i > index; i--) {
                current = current.prev;
            }

            current.data = value;
        }
    }
    // Властивість для отримання довжини списку
    public int getLength() {
        return length;
    }
    public ListNode getLastNode() {
        return end;
    }
    public ListNode getNextNode(ListNode currentNode) {
        if (currentNode == null) {
            throw new IllegalArgumentException("Current node cannot be null");
        }

        return currentNode.next;
    }
    public ListNode getPreviousNode(ListNode currentNode) {
        if (currentNode == null) {
            throw new IllegalArgumentException("Current node cannot be null");
        }

        return currentNode.prev;
    }
    public void sort() {
        boolean swapped;

        do {
            swapped = false;

            ListNode current = head;

            while (current != null && current.next != null) {
                if (current.data.compareTo(current.next.data) > 0) {
                    Student temp = current.data;
                    current.data = current.next.data;
                    current.next.data = temp;

                    swapped = true;
                }

                current = current.next;
            }

            if (!swapped) {
                break;
            }

            swapped = false;

            current = current.prev;

            while (current != null && current.prev != null) {
                if (current.prev.data.compareTo(current.data) > 0) {
                    Student temp = current.data;
                    current.data = current.prev.data;
                    current.prev.data = temp;

                    swapped = true;
                }

                current = current.prev;
            }

        } while (swapped);
    }
    public List<Student> findFemaleStudentsSecondCourse() {
        List<Student> result = new ArrayList<>();

        ListNode current = head;

        while (current != null) {
            if (Character.toLowerCase( current.data.getGender()) == 'f' && current.data.getCourse() == 2) {
                result.add(current.data);
            }

            current = current.next;
        }

        return result;
    }
}

