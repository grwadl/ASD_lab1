

using lab_1;
Queue queue = new Queue();
string input;
Console.WriteLine("ADS 1 Lab. 3 Variant. Vadym Hrashchenko 624p\n\n");
do
{

    Console.WriteLine("Type the type of operation u wanna do(add/delete/show/show first/divide/exit)");
    input = Console.ReadLine();
    if (input == "add")
    {
        try
        {
            Console.WriteLine("Type the element you want to add");
            string strElement = Console.ReadLine();
            string res = queue.addToQueue(strElement.ToCharArray()[0]);
            Console.WriteLine(res);
        }
        catch (FormatException)
        {
            Console.WriteLine("This is not int type!");
        }
    }
    if (input == "delete")
    {
        Console.WriteLine(queue.popQueue());
    }
    if (input == "show")
    {
        queue.showQueue(queue);
    }

    if(input == "show first")
    {
        Console.WriteLine(queue.showFirstElement());
    }
    if (input == "divide")
    {
        queue.divideQueue();
    }
}
while (input != "exit");