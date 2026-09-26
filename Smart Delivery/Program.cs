namespace Smart_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Theoretical Questions
            /*

Q1) Object Copying
----------------

a) What happens when you assign one object variable to another?
 We copy the reference, not the object itself.
 So both variables point to the same object in memory.

b) Does assigning one object create a new object?
 No. It only copies the reference.
 Both variables refer to the same object.

c) What is the difference between copying an object and copying its reference?
Copying the reference means two variables point to the same object.
Copying the object means creating a new and independent object.


Q2) Shallow Copy vs Deep Copy
--------------------------------

a) What is a Shallow Copy?
 A new object is created, but reference-type members still point
to the same objects as the original.

b) What is a Deep Copy?
A new object is created, and its reference-type members are also
copied into new independent objects.

c) What happens to reference-type members in Shallow Copy?
They still refer to the same object.

d) What happens to reference-type members in Deep Copy?
New objects are created for them, so they become independent.

e) When is Deep Copy safer?
When changing the copied object should not affect the original object.


Q3) Static Members
------------------
a) What is a static field?
A static field belongs to the class and there is only one shared copy.
An instance field has a separate copy for every object.

b) What is a static method?
A static method belongs to the class and can be called using

c) What is a static constructor?
It initializes static members and runs automatically only once
d) What is a static class?
A class that contains only static members and cannot be instantiated.


Q4) Extension Methods
-----------------
a) What is an Extension Method?
It allows us to add a new method to an existing type without
   modifying the original class.

b) What keyword is used in the first parameter?
this.

c) Where must an Extension Method be declared?
Inside a static class, and the method itself must be static.

d) Can it access private members?
No. It can only access members that are normally accessible from outside the class.


Q5) Partial Classes and Partial Methods
--------------------

a) What is a Partial Class?
A class whose code is divided into multiple files using
the "partial" keyword. The compiler combines them into one class.

b) Why split a class into multiple files?
To organize large code, make it easier to read, and allow multiple developers to work on different parts.

c) What is a Partial Method?
A method whose declaration is in one part of the class and
whose implementation can be written in another part.

d) What happens if a Partial Method has no implementation?
The compiler removes the declaration and its calls,

*/

            #endregion


            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Smart Delivery Management System");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Creating Shipments...");
            DeliveryUtilities.PrintSeparator();

            Shipment shipment1 = new Shipment("SH001", "Standard", 3,
                new DeliveryAddress("Cairo"), "In Transit");
            Console.WriteLine("Standard Shipment Created");

            Shipment shipment2 = new Shipment("SH002", "Express", 2,
                new DeliveryAddress("Alexandria"), "Out For Delivery");
            Console.WriteLine("Express Shipment Created");

            Shipment shipment3 = new Shipment("SH003", "International", 8,
                new DeliveryAddress("Giza"), "Delivered");
            Console.WriteLine("International Shipment Created");
            Console.WriteLine();

            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
            Console.WriteLine();

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Object Copying");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            Shipment assignedShipment = shipment1;
            Console.WriteLine($"Original Shipment : {shipment1.TrackingCode}");
            Console.WriteLine($"Assigned Shipment : {assignedShipment.TrackingCode}");
            Console.WriteLine($"Same Object : {ReferenceEquals(shipment1, assignedShipment)}");
            Console.WriteLine();

            Shipment realCopy = shipment1.CopyShipment(); 
            Console.WriteLine($"Is CopyShipment() a different object? : {!ReferenceEquals(shipment1, realCopy)}");
            Console.WriteLine();

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Shallow Copy");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            Shipment shallowCopy = shipment1.ShallowCopy();
            Console.WriteLine($"Original Shipment Address : {shipment1.DeliveryAddress.City}");
            Console.WriteLine($"Copied Shipment Address   : {shallowCopy.DeliveryAddress.City}");
            Console.WriteLine();

            Console.WriteLine("Changing copied shipment address...");
            shallowCopy.DeliveryAddress.City = "Giza";
            Console.WriteLine();

            Console.WriteLine($"Original Shipment Address : {shipment1.DeliveryAddress.City}");
            Console.WriteLine($"Copied Shipment Address   : {shallowCopy.DeliveryAddress.City}");
            Console.WriteLine();
            Console.WriteLine($"Same DeliveryAddress Object : " +
                $"{ReferenceEquals(shipment1.DeliveryAddress, shallowCopy.DeliveryAddress)}");
            Console.WriteLine();

            shipment1.DeliveryAddress.City = "Cairo";

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Deep Copy");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            Shipment deepCopy = shipment1.DeepCopy();
            Console.WriteLine($"Original Shipment Address : {shipment1.DeliveryAddress.City}");
            Console.WriteLine($"Copied Shipment Address   : {deepCopy.DeliveryAddress.City}");
            Console.WriteLine();

            Console.WriteLine("Changing copied shipment address...");
            deepCopy.DeliveryAddress.City = "Giza";
            Console.WriteLine();

            Console.WriteLine($"Original Shipment Address : {shipment1.DeliveryAddress.City}");
            Console.WriteLine($"Copied Shipment Address   : {deepCopy.DeliveryAddress.City}");
            Console.WriteLine();
            Console.WriteLine($"Same DeliveryAddress Object : " +
                $"{ReferenceEquals(shipment1.DeliveryAddress, deepCopy.DeliveryAddress)}");
            Console.WriteLine();

     
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Extension Methods");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            Console.WriteLine(shipment1.GetSummary());
            Console.WriteLine(shipment2.GetSummary());
            Console.WriteLine(shipment3.GetSummary());
            Console.WriteLine();

            Console.WriteLine($"SH001 Is Delivered : {shipment1.IsDelivered()}");
            Console.WriteLine($"SH003 Is Delivered : {shipment3.IsDelivered()}");
            Console.WriteLine();


            Console.WriteLine("Tracking Status");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            shipment1.UpdateTrackingStatus("Out For Delivery");
            Console.WriteLine();

    
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Static Utilities");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            DeliveryUtilities.PrintSystemTitle();
            Console.WriteLine();
            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
            Console.WriteLine();


            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Partial Method");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine();

            shipment1.UpdateTrackingStatus("Delivered");
            Console.WriteLine();

            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Assignment Completed");
            DeliveryUtilities.PrintSeparator();
        }
    }
}
